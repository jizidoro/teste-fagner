#region

using System.Threading.Tasks;

#endregion

namespace kpmg.Core.Helpers.Interfaces
{
    public interface IService
    {
        Task<bool> Commit();
    }
}