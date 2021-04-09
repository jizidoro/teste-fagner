#region

using System.Linq;
using kpmg.Core.Views.VBaUsuPermissaoCore;
using kpmg.Domain.Models.Views;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories.Views
{
    public class VwUsuarioSistemaPermissaoRepository : IVwUsuarioSistemaPermissaoRepository
    {
        protected readonly KpmgContext Db;
        protected readonly DbSet<VwUsuarioSistemaPermissao> DbSet;

        public VwUsuarioSistemaPermissaoRepository(KpmgContext context)
        {
            Db = context;
            DbSet = Db.Set<VwUsuarioSistemaPermissao>();
        }


        public IQueryable<VwUsuarioSistemaPermissao> ListarPorSqUsuarioSistema(int sqUsuarioSistema)
        {
            var permissoes = Db.VUsuarioSistemaPermissoes
                .AsQueryable();

            return permissoes;
        }
    }
}