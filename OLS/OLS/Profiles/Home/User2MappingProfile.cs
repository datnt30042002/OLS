using AutoMapper;
using OLS.Models;
using OLS.DTO.Users.Home;

namespace OLS.Profiles.Home
{
    public class User2MappingProfile : Profile
    {
        public User2MappingProfile() 
        {
            CreateMap<User, UserLoginHomeDTO>()
                    .ReverseMap();
        }
    }
}
