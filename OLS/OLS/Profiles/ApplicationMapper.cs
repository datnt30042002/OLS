using AutoMapper;
using OLS.DTO.Blogs.Admin.BlogManager;
using OLS.DTO.Users.Home;
using OLS.Models;

namespace OLS.Profiles
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<LoginByEmailRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();

            CreateMap<RegisterByEmailRequest, User>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();

            CreateMap<ForgotByEmailRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<ResetPassByEmailRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.RePassword))
                .ReverseMap();

            CreateMap<VerifyCodeRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CodeVerify, opt => opt.MapFrom(src => src.CodeVerify))
                .ReverseMap();

            CreateMap<BlogManager, Blog>()
                .ForPath(dest => dest.BlogTagBlogTag.BlogTagName, opt => opt.MapFrom(src => src.BlogTag))
                .ForPath(dest => dest.BlogTopicBlogTopic.BlogTopicName, opt => opt.MapFrom(src => src.BlogTopic))
                .ForPath(dest => dest.UserUser.FullName, opt => opt.MapFrom(src => src.PosterName))
                .ReverseMap();

            CreateMap<BlogManagerAddRequest, Blog>()
                .ForPath(dest => dest.BlogTagBlogTag.BlogTagName, opt => opt.MapFrom(src => src.BlogTag))
                .ForPath(dest => dest.BlogTopicBlogTopic.BlogTopicName, opt => opt.MapFrom(src => src.BlogTopic))
                .ForPath(dest => dest.UserUser.UserId, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();

            CreateMap<BlogManagerLockRequest, Blog>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsLock ? 0 : 1))
                .ReverseMap();
        }

    }
}
