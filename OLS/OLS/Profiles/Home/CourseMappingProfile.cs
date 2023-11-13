using AutoMapper;
using OLS.DTO.Courses;
using OLS.Models;

namespace OLS.Helpers.Home
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            // Source -> Destination
            CreateMap<Course, CourseReadHomeDTO>().ReverseMap();
        }
    }
}
