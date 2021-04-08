#region

using AutoMapper;
using kpmg.Application.Dtos;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<AirplaneIncluirDto, Airplane>();
            CreateMap<BaUsuIncluirDto, BaUsu>();
            CreateMap<AutenticacaoDto, BaUsu>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Chave))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));
        }
    }
}