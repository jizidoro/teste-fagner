#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.AirplaneCore
{
    public interface IAirplaneRepository : IRepository<Airplane>
    {
        Task<ISingleResult<Airplane>> RegistroCodigoRepetido(int id, string codigo);
    }
}