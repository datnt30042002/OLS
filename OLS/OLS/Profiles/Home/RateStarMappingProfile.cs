using AutoMapper;
using OLS.DTO.RateStar.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class RateStarMappingProfile : Profile
    {
        public RateStarMappingProfile() 
        {
            CreateMap<RateStar, RateStarReadHomeDTO>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.FullName : null))
                .ReverseMap();

            CreateMap<RateStar, RateStarCreateHomeDTO>()
                .ReverseMap();

            CreateMap<RateStar, RateStarUpdateHomeDTO>()
                .ReverseMap();
        }
    }
}
