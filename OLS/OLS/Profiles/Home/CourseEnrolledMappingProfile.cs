using AutoMapper;
using OLS.DTO.CourseEnrolled.Home;
using OLS.DTO.CoursesEnrolled.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class CourseEnrolledMappingProfile : Profile
    {
        public CourseEnrolledMappingProfile() 
        {
            CreateMap<CourseEnrolled, CourseEnrolledRegisterHomeDTO>()
                .ReverseMap();

            CreateMap<CourseEnrolled, CourseEnrolledReadHomeDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.NotificationContents = src.CourseCourse.Notifications
                        .Where(n => n.UserUserId == src.UserUserId)
                        .Select(n => n.NotificationContent)
                        .ToList();
                })
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseCourse.CourseName))
                .ReverseMap();
        }
    }
}
