#region

using AutoMapper;

#endregion

namespace kpmg.Application.Utils
{
    public interface IAppService
    {
        IMapper Mapper { get; }
    }
}