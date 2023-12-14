using AutoMapper;
using OLS.DTO.Answers.Admin;
using OLS.Models;

namespace OLS.Profiles.Admin
{
    public class AnswerManagerMappingProfile : Profile
    {
        public AnswerManagerMappingProfile() 
        {
            CreateMap<Answer, AnswerReadAdminDTO>()
                .ReverseMap();

            CreateMap<Answer, AnswerCreateAdminDTO>()
                .ReverseMap();

            CreateMap<Answer, AnswerUpdateAdminDTO>()
                .ReverseMap();
        }
    }
}
