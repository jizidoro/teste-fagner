#region

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Application.Interfaces
{
    public interface ILookupServiceApp<TEntity>
        where TEntity : Entity
    {
        Task<IList<LookupDto>> ObterLookup();
        Task<IList<LookupDto>> ObterLookup(Expression<Func<TEntity, bool>> predicate);
    }
}