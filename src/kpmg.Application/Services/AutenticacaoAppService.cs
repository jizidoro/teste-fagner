#region

using System.Threading.Tasks;
using AutoMapper;
using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Application.Interfaces;
using kpmg.Application.Utils;
using kpmg.Core.SecurityCore.Usecase;
using kpmg.Core.Views.VBaUsuPermissaoCore;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Application.Services
{
    public class AutenticacaoAppService : AppService, IAutenticacaoAppService
    {
        private readonly AtualizarSenhaExpiradaUsecase _atualizarSenhaExpiradaUsecase;
        private readonly EsquecerSenhaUsecase _esquecerSenhaUsecase;
        private readonly GerarTokenLoginUsecase _gerarTokenLoginUsecase;
        private readonly IVBaUsuPermissaoRepository _vBaUsuPermissaoRepository;

        public AutenticacaoAppService(IVBaUsuPermissaoRepository vBaUsuPermissaoRepository,
            AtualizarSenhaExpiradaUsecase atualizarSenhaExpiradaUsecase,
            GerarTokenLoginUsecase gerarTokenLoginUsecase, EsquecerSenhaUsecase esquecerSenhaUsecase, IMapper mapper) :
            base(mapper)
        {
            _vBaUsuPermissaoRepository = vBaUsuPermissaoRepository;
            _atualizarSenhaExpiradaUsecase = atualizarSenhaExpiradaUsecase;
            _esquecerSenhaUsecase = esquecerSenhaUsecase;
            _gerarTokenLoginUsecase = gerarTokenLoginUsecase;
        }

        public async Task<ISingleResultDto<UsuarioDto>> GerarTokenLoginUsecase(AutenticacaoDto dto)
        {
            var result = await _gerarTokenLoginUsecase.Execute(dto.Chave, dto.Senha);

            if (result.Success)
            {
                var token = new UsuarioDto
                {
                    Token = result.User.Token
                };

                return new SingleResultDto<UsuarioDto>(token);
            }

            return new SingleResultDto<UsuarioDto>(result);
        }

        public async Task<ISingleResultDto<EntityDto>> EsquecerSenha(AutenticacaoDto dto)
        {
            var evento = Mapper.Map<BaUsu>(dto);

            var result = await _esquecerSenhaUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }

        public async Task<ISingleResultDto<EntityDto>> ExpirarSenha(AutenticacaoDto dto)
        {
            var evento = Mapper.Map<BaUsu>(dto);

            var result = await _atualizarSenhaExpiradaUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }
    }
}