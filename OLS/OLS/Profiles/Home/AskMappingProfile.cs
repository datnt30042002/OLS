using AutoMapper;
using OLS.DTO.Asks.Home;
using OLS.DTO.Courses;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class AskMappingProfile : Profile
    {
        public AskMappingProfile() 
        {
            CreateMap<Ask, AskReadHomeDTO>()
                .ForMember(dest => dest.FullName, 
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.FullName : null))
                .ForMember(dest => dest.Avatar, 
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.Image : null))
                .ReverseMap();

            CreateMap<Ask, AskCreateHomeDTO>()
                .ReverseMap();

            CreateMap<Ask, AskUpdateHomeDTO>()
                .ReverseMap();
        }
    }
}
