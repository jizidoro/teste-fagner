#region

using AutoMapper;
using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Domain.Bases;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Entity, EntityDto>();
            CreateMap<LookupEntity, LookupDto>();

            CreateMap<Airplane, AirplaneEditarDto>();
            CreateMap<Airplane, AirplaneDto>();

            CreateMap<UsuarioSistema, UsuarioSistemaEditarDto>();
            CreateMap<UsuarioSistema, UsuarioSistemaDto>();

            CreateMap<UsuarioSistema, AutenticacaoDto>()
                .ForMember(dest => dest.Chave, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));
        }
    }
}