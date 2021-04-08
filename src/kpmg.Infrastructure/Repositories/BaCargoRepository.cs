#region

using System;
using System.Linq;
using System.Threading.Tasks;
using kpmg.Core.BaCargoCore;
using kpmg.Domain.Models;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaCargoRepository : Repository<BaCargo>, IBaCargoRepository
    {
        private readonly KpmgContext _context;

        public BaCargoRepository(KpmgContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }


        public async Task<BaCargo> ObterPorUsuCodCargo(int usuCodCargo)
        {
            var cargo = await Db.BaCargos
                .Include(x => x.BaTipoCargo)
                .Where(p => p.Id == usuCodCargo)
                .FirstOrDefaultAsync();

            return cargo;
        }
    }
}