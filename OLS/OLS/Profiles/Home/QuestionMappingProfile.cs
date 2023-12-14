using AutoMapper;
using OLS.DTO.Questions.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile() 
        {
            CreateMap<Question, QuestionReadHomeDTO>()
                .ReverseMap();
        }
    }
}
