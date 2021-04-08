#region

using kpmg.Domain.Interfaces;

#endregion

namespace kpmg.Core.Helpers.Interfaces
{
    public interface ISingleResult<TEntity> : IResult
        where TEntity : IEntity
    {
        TEntity Data { get; set; }
    }
}