using AutoMapper;
using BiddingManagementSystem.Application.Features.UserFeature.DTOs;
using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Application.Features.UserFeature.Mapping
{
    public class MappingProfileLoginUser : Profile
    {
        public MappingProfileLoginUser()
        {
            // Mapping from AppUser, to LoginUserDTO
            CreateMap<AppUser, LoginUserDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));


            // Mapping from LoginUserDTO to AppUser
            CreateMap<LoginUserDTO, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
