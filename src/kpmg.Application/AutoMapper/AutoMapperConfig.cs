#region

using AutoMapper;
using kpmg.Application.MappingProfiles;

#endregion

namespace kpmg.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new DtoToDomainMappingProfile());
                cfg.AddProfile(new RequestToDomainProfile());
            });
        }
    }
}