#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaCargoCore
{
    public interface IBaCargoRepository : IRepository<BaCargo>
    {
        Task<BaCargo> ObterPorUsuCodCargo(int usuCodCargo);
    }
}