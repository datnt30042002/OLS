using AutoMapper;
using OLS.DTO.Quizzes.Admin;
using OLS.Models;

namespace OLS.Profiles.Admin
{
    public class QuizManagerMappingProfile : Profile
    {
        public QuizManagerMappingProfile() 
        {
            CreateMap<Quiz, QuizReadAdminDTO>()
                .ReverseMap();

            CreateMap<Quiz, QuizCreateAdminDTO>()
                .ReverseMap();

            CreateMap<Quiz, QuizUpdateAdminDTO>()
                .ReverseMap();
        }
    }
}
