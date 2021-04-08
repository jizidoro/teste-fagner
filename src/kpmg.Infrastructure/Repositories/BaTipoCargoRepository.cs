#region

using System;
using kpmg.Core.BaTipoCargoCore;
using kpmg.Domain.Models;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaTipoCargoRepository : Repository<BaTipoCargo>, IBaTipoCargoRepository
    {
        private readonly KpmgContext _context;

        public BaTipoCargoRepository(KpmgContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }
    }
}