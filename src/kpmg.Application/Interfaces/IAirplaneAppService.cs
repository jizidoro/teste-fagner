#region

using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.AirplaneDtos;
using kpmg.Application.Filters;
using kpmg.Application.Utils;

#endregion

namespace kpmg.Application.Interfaces
{
    public interface IAirplaneAppService : IAppService
    {
        Task<IPageResultDto<AirplaneDto>> Listar(PaginationFilter paginationFilter = null);
        Task<ISingleResultDto<AirplaneDto>> Obter(int id);
        Task<ISingleResultDto<EntityDto>> Incluir(AirplaneIncluirDto dto);
        Task<ISingleResultDto<EntityDto>> Editar(AirplaneEditarDto dto);
        Task<ISingleResultDto<EntityDto>> Excluir(int id);
    }
}