#region

using System.Collections.Generic;
using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Utils
{
    public interface IListResultDto<TDto> : IResultDto
        where TDto : Dto
    {
        IList<TDto> Data { get; set; }
    }
}