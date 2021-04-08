#region

using System;
using System.Linq;
using kpmg.Core.BaUsuCore;
using kpmg.Domain.Bases;
using kpmg.Domain.Models;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaUsuRepository : Repository<BaUsu>, IBaUsuRepository
    {
        private readonly KpmgContext _context;

        public BaUsuRepository(KpmgContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }


        public IQueryable<LookupEntity> BuscarPorNome(string nome)
        {
            var result = Db.BaUsus
                .Where(x => x.StsUsu == 0 &&
                            x.NomeUsu.Contains(nome)).Take(30)
                .OrderBy(x => x.NomeUsu)
                .Select(s => new LookupEntity {Key = s.Id, Value = s.NomeUsu});

            return result;
        }

        public void ExemploEager()
        {
            var teste1 = _context.BaUsus
                .Include(x => x.BaLogradouro)
                .Include(x => x.BaCargos)
                .Take(10).ToList();

            var teste2 = teste1.FirstOrDefault();
        }
    }
}