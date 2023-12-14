using AutoMapper;
using OLS.DTO.Feedbacks.Admin;
using OLS.Models;

namespace OLS.Profiles.Admin
{
    public class FeedbackManagerMappingProfile : Profile
    {
        public FeedbackManagerMappingProfile() 
        {
            CreateMap<Feedback, FeedbackReadAdminDTO>()
                 .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.FullName : null))
                .ForMember(dest => dest.Avatar,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.Image : null))
                .ReverseMap();
        }
    }
}
