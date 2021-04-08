#region

using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Utils
{
    public interface ISingleResultDto<TDto> : IResultDto
        where TDto : Dto
    {
        TDto Data { get; }
    }
}