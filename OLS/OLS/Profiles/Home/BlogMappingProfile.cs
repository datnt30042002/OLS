using AutoMapper;
using OLS.DTO.Blogs.Home;
using OLS.Models;

namespace OLS.Helpers.Home
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            // Source -> Destination
            CreateMap<Blog, BlogReadHomeDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.UserUser.FullName))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.UserUser.Image))
                .ReverseMap();
        }
    }
}
