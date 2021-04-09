#region

using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using kpmg.Core.UsuarioSistemaCore;
using kpmg.Core.UsuarioSistemaCore.Validation;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.SecurityCore.Validation
{
    public class UsuarioSistemaValidarSenha : EntityValidation<UsuarioSistema>
    {
        private readonly IUsuarioSistemaRepository _usuarioSistemaRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UsuarioSistemaValidarSenha(IUsuarioSistemaRepository usuarioSistemaRepository,
            IPasswordHasher passwordHasher)
            : base(usuarioSistemaRepository)
        {
            _usuarioSistemaRepository = usuarioSistemaRepository;
            _passwordHasher = passwordHasher;
        }

        public ISingleResult<UsuarioSistema> Execute(int chave, string senha)
        {
            var usuSelecionado = _usuarioSistemaRepository.GetById(chave).Result;
            var chaveValida = usuSelecionado != null;

            if (chaveValida)
            {
                var senhaValida = _passwordHasher.Check(usuSelecionado.Senha, senha);

                if (!senhaValida.Verified)
                {
                    return new SingleResult<UsuarioSistema>(1001, "Usuário ou senha informados não são válidos");
                }


                return new SingleResult<UsuarioSistema>(usuSelecionado);
            }


            return new SingleResult<UsuarioSistema>(1001, "Usuário ou senha informados não são válidos");
        }
    }
}