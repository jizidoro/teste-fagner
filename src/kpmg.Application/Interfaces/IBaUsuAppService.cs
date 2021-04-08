#region

using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Application.Filters;
using kpmg.Application.Utils;

#endregion

namespace kpmg.Application.Interfaces
{
    public interface IBaUsuAppService : IAppService
    {
        Task<IPageResultDto<BaUsuDto>> Listar(PaginationFilter paginationFilter = null);
        Task<ListResultDto<LookupDto>> BuscarPorNome(string nome);
        Task<ISingleResultDto<BaUsuDto>> Obter(int id);
        Task<ISingleResultDto<EntityDto>> Incluir(BaUsuIncluirDto dto);
        Task<ISingleResultDto<EntityDto>> Editar(BaUsuEditarDto dto);
        Task<ISingleResultDto<EntityDto>> Excluir(int id);
    }
}