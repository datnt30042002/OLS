using AutoMapper;
using OLS.Models;
using OLS.DTO.Feedbacks.Home;

namespace OLS.Profiles.Home
{
    public class FeedbackMappingProfile : Profile
    {
        public FeedbackMappingProfile() 
        {
            CreateMap<Feedback, FeedbackReadHomeDTO>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.FullName : null))
                .ForMember(dest => dest.Avatar,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.Image : null))
                .ReverseMap();

            CreateMap<Feedback, FeedbackCreateHomeDTO>()
                .ReverseMap();

            CreateMap<Feedback, FeedbackUpdateHomeDTO>()
                .ReverseMap();
        }
    }
}
