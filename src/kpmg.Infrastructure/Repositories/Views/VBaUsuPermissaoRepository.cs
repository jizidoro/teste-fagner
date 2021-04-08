#region

using System.Linq;
using kpmg.Core.Views.VBaUsuPermissaoCore;
using kpmg.Domain.Models.Views;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories.Views
{
    public class VBaUsuPermissaoRepository : IVBaUsuPermissaoRepository
    {
        protected readonly KpmgContext Db;
        protected readonly DbSet<VBaUsuPermissao> DbSet;

        public VBaUsuPermissaoRepository(KpmgContext context)
        {
            Db = context;
            DbSet = Db.Set<VBaUsuPermissao>();
        }


        public IQueryable<VBaUsuPermissao> ListarPorIdUsu(int idUsu)
        {
            var permissoes = Db.VBaUsuPermissoes
                .Where(p => p.IdUsu == idUsu)
                .AsQueryable();

            return permissoes;
        }
    }
}