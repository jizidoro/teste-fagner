#region

using System.Collections.Generic;
using kpmg.Core.Helpers.Interfaces;

#endregion

namespace kpmg.Application.Utils
{
    public interface IResultDto : IResult
    {
        IList<string> Mensagens { get; set; }
    }
}