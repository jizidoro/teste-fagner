#region

using System;
using System.Linq;
using System.Threading.Tasks;
using kpmg.Core.AirplaneCore;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Messages;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Domain.Models;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        private readonly KpmgContext _context;

        public AirplaneRepository(KpmgContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }

        public async Task<ISingleResult<Airplane>> RegistroCodigoRepetido(int id, string codigo)
        {
            var existe = await Db.Airplanes
                .Where(p => p.Id != id && p.Codigo.Equals(codigo))
                .AnyAsync();

            return existe ? new SingleResult<Airplane>(MensagensNegocio.MSG08) : new SingleResult<Airplane>();
        }
    }
}