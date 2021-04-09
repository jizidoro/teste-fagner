#region

using System.Linq;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Domain.Bases;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.UsuarioSistemaCore
{
    public interface IUsuarioSistemaRepository : IRepository<UsuarioSistema>
    {
        IQueryable<LookupEntity> BuscarPorNome(string nome);
    }
}