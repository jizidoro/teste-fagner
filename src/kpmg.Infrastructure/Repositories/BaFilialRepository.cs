#region

using System;
using kpmg.Core.BaFilialCore;
using kpmg.Domain.Models;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaFilialRepository : Repository<BaFilial>, IBaFilialRepository
    {
        private readonly KpmgContext _context;

        public BaFilialRepository(KpmgContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }
    }
}