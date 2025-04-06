using AutoMapper;
using BiddingManagementSystem.Application.Features.UserFeature.DTOs;
using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Application.Features.UserFeature.Mapping
{
    public class MappingProfileNewUser : Profile
    {
        public MappingProfileNewUser()
        {
            // Mapping from AppUser, to NewUserDTO
            CreateMap<AppUser, NewUserDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));


            // Mapping from NewUserDTO to AppUser
            CreateMap<NewUserDTO, AppUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
