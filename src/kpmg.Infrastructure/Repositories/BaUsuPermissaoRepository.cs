#region

using System.Linq;
using kpmg.Core.BaUsuPermissaoCore;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaUsuPermissaoRepository : IBaUsuPermissaoRepository
    {
        protected readonly KpmgContext Db;
        protected readonly DbSet<BaUsuPermissao> DbSet;

        public BaUsuPermissaoRepository(KpmgContext context)
        {
            Db = context;
            DbSet = Db.Set<BaUsuPermissao>();
        }

        public IQueryable<BaUsuPermissao> ListarPorIdUsu(int idUsu)
        {
            var permissoes = Db.BaUsuPermissoes
                .Where(p => p.IdUsu == idUsu)
                .AsQueryable();

            return permissoes;
        }
    }
}