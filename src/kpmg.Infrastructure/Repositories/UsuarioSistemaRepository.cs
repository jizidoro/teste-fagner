#region

using System;
using System.Linq;
using kpmg.Core.UsuarioSistemaCore;
using kpmg.Domain.Bases;
using kpmg.Domain.Models;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class UsuarioSistemaRepository : Repository<UsuarioSistema>, IUsuarioSistemaRepository
    {
        private readonly KpmgContext _context;

        public UsuarioSistemaRepository(KpmgContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }


        public IQueryable<LookupEntity> BuscarPorNome(string nome)
        {
            var result = Db.UsuarioSistemas
                .Where(x => x.Situacao &&
                            x.Nome.Contains(nome)).Take(30)
                .OrderBy(x => x.Nome)
                .Select(s => new LookupEntity {Key = s.Id, Value = s.Nome});

            return result;
        }
    }
}