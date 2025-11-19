using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using eCommerce.Application.Dtos;
using eCommerce.Application.Utils;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Mappers;

public class AppUserMappingProfile : Profile
{
    public AppUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dect => dect.UserId,
                opt => opt.MapFrom(src => src.UserId))
            .ForMember(dect => dect.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dect => dect.UserName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dect => dect.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ForMember(dect => dect.IsSuccess,
                opt => opt.Ignore())
            .ForMember(dect => dect.Token,
                opt => opt.Ignore()).ReverseMap();

        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password,
                opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender));
        
    }
}