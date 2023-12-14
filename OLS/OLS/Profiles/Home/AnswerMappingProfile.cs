using AutoMapper;
using OLS.DTO.Answers.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile() 
        {
            CreateMap<Answer, AnswerReadHomeDTO>()
                .ReverseMap();
        }
    }
}
