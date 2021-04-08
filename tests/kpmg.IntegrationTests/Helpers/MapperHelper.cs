#region

using AutoMapper;
using kpmg.Application.AutoMapper;

#endregion

namespace kpmg.IntegrationTests.Helpers
{
    internal class MapperHelper
    {
        public static IMapper ConfigMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToDomainMappingProfile());
                cfg.AddProfile(new DomainToDtoMappingProfile());
            }).CreateMapper();
        }
    }
}