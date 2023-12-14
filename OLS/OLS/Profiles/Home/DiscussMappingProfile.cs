using AutoMapper;
using OLS.DTO.Discusses.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class DiscussMappingProfile : Profile
    {
        public DiscussMappingProfile() 
        {
            CreateMap<Discuss, DiscussReadHomeDTO>()
                .ReverseMap();
        }
    }
}
