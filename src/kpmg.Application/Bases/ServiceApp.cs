#region

using AutoMapper;
using kpmg.Application.Utils;

#endregion

namespace kpmg.Application.Bases
{
    public class AppService : IAppService
    {
        public AppService(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get; }
    }
}