#region

using System.Linq;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Domain.Bases;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuCore
{
    public interface IBaUsuRepository : IRepository<BaUsu>
    {
        IQueryable<LookupEntity> BuscarPorNome(string nome);
    }
}