using AutoMapper;
using OLS.DTO.Quizzes.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class QuizMappingProfile : Profile
    {
        public QuizMappingProfile() 
        {
            CreateMap<Quiz, QuizReadHomeDTO>()
                .ReverseMap();
        }
    }
}
