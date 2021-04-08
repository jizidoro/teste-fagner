#region

using System.Linq;
using kpmg.Core.BaUsuFilialCore;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaUsuFilialRepository : IBaUsuFilialRepository
    {
        protected readonly KpmgContext Db;
        protected readonly DbSet<BaUsuFilial> DbSet;

        public BaUsuFilialRepository(KpmgContext context)
        {
            Db = context;
            DbSet = Db.Set<BaUsuFilial>();
        }

        public IQueryable<BaUsuFilial> ListarFilialPorIdUsu(int idUsu)
        {
            var filiais = Db.BaUsuFiliais
                .Where(p => p.IdUsu == idUsu)
                .AsQueryable();

            return filiais;
        }
    }
}