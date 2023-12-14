using AutoMapper;
using OLS.DTO.Chapters.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class ChapterMappingProfile : Profile
    {
        public ChapterMappingProfile()
        {
            CreateMap<Chapter, ChapterReadHomeDTO>()
                .ReverseMap();
        }
    }
}
