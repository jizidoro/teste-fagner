#region

using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.UsuarioSistemaDtos;
using kpmg.Application.Filters;
using kpmg.Application.Utils;

#endregion

namespace kpmg.Application.Interfaces
{
    public interface IUsuarioSistemaAppService : IAppService
    {
        Task<IPageResultDto<UsuarioSistemaDto>> Listar(PaginationFilter paginationFilter = null);
        Task<ListResultDto<LookupDto>> BuscarPorNome(string nome);
        Task<ISingleResultDto<UsuarioSistemaDto>> Obter(int id);
        Task<ISingleResultDto<EntityDto>> Incluir(UsuarioSistemaIncluirDto dto);
        Task<ISingleResultDto<EntityDto>> Editar(UsuarioSistemaEditarDto dto);
        Task<ISingleResultDto<EntityDto>> Excluir(int id);
    }
}