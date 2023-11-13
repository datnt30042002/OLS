using AutoMapper;
using OLS.DTO.Courses.Admin;
using OLS.Models;

namespace OLS.Helpers.Admin
{
    public class CourseManagerMappingProfile : Profile
    {
        public CourseManagerMappingProfile()
        {
            // Read
            CreateMap<Course, CourseReadAminDTO>()
                .ForMember(dest => dest.LearningPath, opt => opt.MapFrom(src => src.LearningPathLearningPath.LearningPathName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => HelperFunctions.HelperFunctions.GetStatusString(src.Status)))
                .ReverseMap();

            // Create
            CreateMap<CourseCreateAminDTO, Course>().ReverseMap();

            // Update
            CreateMap<CourseUpdateAminDTO, Course>().ReverseMap();
        }
    }
}
