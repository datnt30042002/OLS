using AutoMapper;
using OLS.DTO.Lessons.Admin;
using OLS.Models;

namespace OLS.Helpers.Admin
{
    public class LessonManagerMappingProfile : Profile
    {
        public LessonManagerMappingProfile()
        {
            // Read
            CreateMap<Lesson, LessonReadAdminDTO>()
                .ForMember(dest => dest.Chapter, opt => opt.MapFrom(src => src.ChapterChapter.ChapterName))
                .ReverseMap();

            // Create
            CreateMap<LessonCreateAdminDTO, Lesson>()
                .ReverseMap();

            // Update
            CreateMap<LessonUpdateAdminDTO, Lesson>()
                .ReverseMap();
        }
    }
}
