using AutoMapper;
using OLS.DTO.Questions.Admin;
using OLS.Models;

namespace OLS.Profiles.Admin
{
    public class QuestionManagerMappingProfile : Profile
    {
        public QuestionManagerMappingProfile() 
        {
            CreateMap<Question, QuestionReadAdminDTO>()
                .ReverseMap();

            CreateMap<Question, QuestionCreateAdminDTO>()
                .ReverseMap();

            CreateMap<Question, QuestionUpdateAdminDTO>()
                .ReverseMap();
        }
    }
}
