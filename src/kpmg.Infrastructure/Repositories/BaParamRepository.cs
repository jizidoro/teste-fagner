#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Core.BaParamCore;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.Repositories
{
    public class BaParamRepository : IBaParamRepository
    {
        protected readonly KpmgContext Db;
        protected readonly DbSet<BaParam> DbSet;

        public BaParamRepository(KpmgContext context)
        {
            Db = context;
            DbSet = Db.Set<BaParam>();
        }

        public Task<string> ObterValorPorChave(string chave)
        {
            var filiais = Db.BaParams
                .Where(p => p.Chave == chave)
                .Select(x => x.Valor)
                .FirstOrDefaultAsync();

            return filiais;
        }

        public Task<string> ObterValorQtdeDiasTrocarSenhaSistema()
        {
            var filiais = Db.BaParams
                .Where(p => p.Chave == "QTDE_DIAS_TROCAR_SENHA_SISTEMA")
                .Select(x => x.Valor)
                .FirstOrDefaultAsync();

            return filiais;
        }
    }
}