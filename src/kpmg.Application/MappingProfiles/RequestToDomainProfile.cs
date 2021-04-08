#region

using AutoMapper;
using kpmg.Application.Filters;
using kpmg.Application.Queries;

#endregion

namespace kpmg.Application.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}