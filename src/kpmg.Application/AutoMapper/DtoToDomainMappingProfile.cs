#region

using AutoMapper;
using kpmg.Application.Dtos;
using kpmg.Application.Dtos.AirplaneDtos;
using kpmg.Application.Dtos.UsuarioSistemaDtos;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<AirplaneIncluirDto, Airplane>();
            CreateMap<UsuarioSistemaIncluirDto, UsuarioSistema>();
            CreateMap<AutenticacaoDto, UsuarioSistema>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Chave))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));
        }
    }
}