#region

using System.Linq;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuFilialCore
{
    public interface IBaUsuFilialRepository
    {
        IQueryable<BaUsuFilial> ListarFilialPorIdUsu(int idUsu);
    }
}