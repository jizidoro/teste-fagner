#region

using System.Linq;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuPermissaoCore
{
    public interface IBaUsuPermissaoRepository
    {
        IQueryable<BaUsuPermissao> ListarPorIdUsu(int idUsu);
    }
}