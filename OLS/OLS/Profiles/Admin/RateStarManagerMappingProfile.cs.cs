using AutoMapper;
using OLS.DTO.RateStar.Admin;
using OLS.Models;

namespace OLS.Profiles.Admin
{
    public class RateStarManagerMappingProfile : Profile
    {
        public RateStarManagerMappingProfile() 
        {
            CreateMap<RateStar, RateStarReadAdminDTO>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.UserUserId == src.UserUser.UserId ? src.UserUser.FullName : null))
                .ForMember(dest => dest.CourseName,
                    opt => opt.MapFrom(src => src.CourseCourseId == src.CourseCourse.CourseId ? src.CourseCourse.CourseName : null))
                .ForMember(dest => dest.CourseImage,
                    opt => opt.MapFrom(src => src.CourseCourseId == src.CourseCourse.CourseId ? src.CourseCourse.Image : null))
                .ReverseMap();
        }
    }
}
