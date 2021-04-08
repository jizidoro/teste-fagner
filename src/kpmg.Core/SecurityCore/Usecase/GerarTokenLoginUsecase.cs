#region

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using kpmg.Core.BaCargoCore;
using kpmg.Core.BaUsuFilialCore;
using kpmg.Core.SecurityCore.Validation;
using kpmg.Core.Utils;
using kpmg.Core.Views.VBaUsuPermissaoCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

#endregion

namespace kpmg.Core.SecurityCore.Usecase
{
    public class GerarTokenLoginUsecase : IGerarTokenLoginUsecase
    {
        private readonly IBaCargoRepository _baCargoRepository;
        private readonly IBaUsuFilialRepository _baUsuFilialRepository;
        private readonly BaUsuValidarSenha _baUsuValidarSenha;
        private readonly IConfiguration _configuration;
        private readonly IVBaUsuPermissaoRepository _vBaUsuPermissaoRepository;


        public GerarTokenLoginUsecase(
            IConfiguration configuration,
            BaUsuValidarSenha baUsuValidarSenha,
            IBaCargoRepository baCargoRepository,
            IBaUsuFilialRepository baUsuFilialRepository,
            IVBaUsuPermissaoRepository vBaUsuPermissaoRepository
        )
        {
            _configuration = configuration;
            _baUsuValidarSenha = baUsuValidarSenha;
            _baCargoRepository = baCargoRepository;
            _baUsuFilialRepository = baUsuFilialRepository;
            _vBaUsuPermissaoRepository = vBaUsuPermissaoRepository;
        }

        public async Task<SecurityResult> Execute(string chave, string senha)
        {
            var result = await Task.Run(() =>
            {
                var resultSenha = _baUsuValidarSenha.Execute(chave, senha).Result;

                if (resultSenha.Sucesso)
                {
                    var usuSelecionado = resultSenha.Data;
                    var cargoUsuario = _baCargoRepository.ObterPorUsuCodCargo(usuSelecionado.CodCargo);
                    var perfil = "";
                    if (cargoUsuario.Result != null)
                    {
                        perfil = cargoUsuario.Result.BaTipoCargo?.DsTipoCargo;
                    }

                    var permissoes = _vBaUsuPermissaoRepository.ListarPorIdUsu(usuSelecionado.Id)
                        .Select(x => x.Permissao.ToString()).ToList();
                    var filiais = _baUsuFilialRepository.ListarFilialPorIdUsu(usuSelecionado.Id)
                        .Select(x => x.IdFilial.ToString()).ToList();

                    var user = new User
                    {
                        Chave = chave,
                        NomeUsuario = usuSelecionado.NomeUsu,
                        Papeis = new List<string> {string.IsNullOrEmpty(perfil) ? "" : perfil},
                        Permissoes = permissoes,
                        Filiais = filiais
                    };

                    user.Token = GenerateToken(user);

                    return new SecurityResult(user);
                }

                return new SecurityResult(resultSenha.Codigo, resultSenha.Mensagem);
            });

            return result;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var clains = new List<Claim>
            {
                new(ClaimTypes.Name, user.Chave),
                new("Nome", user.NomeUsuario)
            };

            foreach (var role in user.Papeis)
            {
                clains.Add(new Claim(ClaimTypes.Role, role));
            }

            foreach (var resource in user.Permissoes)
            {
                clains.Add(new Claim("Permissao", resource));
            }

            foreach (var filial in user.Filiais)
            {
                clains.Add(new Claim("Filial", filial));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clains),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}