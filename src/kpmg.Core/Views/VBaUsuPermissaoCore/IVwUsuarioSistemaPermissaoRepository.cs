#region

using System.Linq;
using kpmg.Domain.Models.Views;

#endregion

namespace kpmg.Core.Views.VBaUsuPermissaoCore
{
    public interface IVwUsuarioSistemaPermissaoRepository
    {
        IQueryable<VwUsuarioSistemaPermissao> ListarPorSqUsuarioSistema(int sqUsuarioSistema);
    }
}