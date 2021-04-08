#region

using System;
using kpmg.Core.BaLogradouroCore;
using kpmg.Domain.Models;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaLogradouroRepository : Repository<BaLogradouro>, IBaLogradouroRepository
    {
        private readonly KpmgContext _context;

        public BaLogradouroRepository(KpmgContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }
    }
}