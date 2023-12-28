using AutoMapper;
using OLS.DTO.Replies.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class ReplyMappingProfile : Profile
    {
        public ReplyMappingProfile() 
        {
            CreateMap<Reply, ReplyReadHomeDTO>()
                 .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.FullName : null))
                .ForMember(dest => dest.Avatar,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.Image : null))
                .ReverseMap();

            CreateMap<Reply, ReplyCreateHomeDTO>()
                .ReverseMap();

            CreateMap<Reply, ReplyUpdateHomeDTO>()
                .ReverseMap();
        }
    }
}
