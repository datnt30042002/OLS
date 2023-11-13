using AutoMapper;
using OLS.DTO.LearningPaths.Home;
using OLS.Models;

namespace OLS.Helpers.Home
{
    public class LearningPathMappingProfile : Profile
    {
        public LearningPathMappingProfile()
        {
            CreateMap<LearningPath, LearningPathReadHomeDTO>().ReverseMap();
        }
    }
}
