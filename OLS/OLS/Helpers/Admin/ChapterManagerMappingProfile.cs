using AutoMapper;
using OLS.DTO.Chapters.Admin;
using OLS.Models;

namespace OLS.Helpers.Admin
{
    public class ChapterManagerMappingProfile : Profile
    {
        public ChapterManagerMappingProfile()
        {
            // Read
            CreateMap<Chapter, ChapterReadAdminDTO>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseCourse.CourseName))
                .ReverseMap();

            // Create
            CreateMap<ChapterCreateAdminDTO, Chapter>()
                .ForMember(dest => dest.CourseCourseId, opt => opt.MapFrom(src => src.Course))
                .ReverseMap();

            // Update
            CreateMap<ChapterUpdateAdminDTO, Chapter>()
                .ReverseMap();
        }
    }
}
