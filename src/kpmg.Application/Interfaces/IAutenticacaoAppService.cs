#region

using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Application.Utils;

#endregion

namespace kpmg.Application.Interfaces
{
    public interface IAutenticacaoAppService : IAppService
    {
        Task<ISingleResultDto<UsuarioDto>> GerarTokenLoginUsecase(AutenticacaoDto dto);
        Task<ISingleResultDto<EntityDto>> EsquecerSenha(AutenticacaoDto dto);
        Task<ISingleResultDto<EntityDto>> ExpirarSenha(AutenticacaoDto dto);
    }
}