using AutoMapper;
using OLS.DTO.Lessons.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile() 
        {
            CreateMap<Lesson, LessonReadHomeDTO>()
                .ReverseMap();
        }
    }
}
