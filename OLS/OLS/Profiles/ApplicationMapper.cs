using AutoMapper;
using OLS.DTO.Blogs.Admin.BlogManager;
using OLS.DTO.Blogs.Home.BlogSite;
using OLS.DTO.Blogs.Home.CommentBlog;
using OLS.DTO.Blogs.Home.SaveBlog;
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

            CreateMap<BlogSite, Blog>()
                .ForPath(dest => dest.BlogTagBlogTag.BlogTagName, opt => opt.MapFrom(src => src.BlogTag))
                .ForPath(dest => dest.BlogTopicBlogTopic.BlogTopicName, opt => opt.MapFrom(src => src.BlogTopic))
                .ForPath(dest => dest.UserUser.FullName, opt => opt.MapFrom(src => src.PosterName))
                .ForPath(dest => dest.UserUser.Image, opt => opt.MapFrom(src => src.PosterImage))
                .ReverseMap();

            CreateMap<GetAllBlogTagRequest, BlogTag>()
                 .ForMember(dest => dest.BlogTagId, opt => opt.MapFrom(src => src.BlogTagId))
                 .ForMember(dest => dest.BlogTagName, opt => opt.MapFrom(src => src.BlogTagName))
                 .ReverseMap();

            CreateMap<GetAllBlogTopicRequest, BlogTopic>()
                 .ForMember(dest => dest.BlogTopicId, opt => opt.MapFrom(src => src.BlogTopicId))
                 .ForMember(dest => dest.BlogTopicName, opt => opt.MapFrom(src => src.BlogTopicName))
                 .ReverseMap();

            CreateMap<GetBlogByIDRequest, Blog>()
                .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.blogID))
                .ReverseMap();

            CreateMap<GetBlogByTagRequest, BlogTag>()
                .ForMember(dest => dest.BlogTagId, opt => opt.MapFrom(src => src.tagID))
                .ReverseMap();

            CreateMap<GetBlogByTopicRequest, BlogTopic>()
                .ForMember(dest => dest.BlogTopicId, opt => opt.MapFrom(src => src.topicID))
                .ReverseMap();


            CreateMap<BlogSaved, SaveBlog>()
                .ForPath(dest => dest.BlogBlog.BlogId, opt => opt.MapFrom(src => src.BlogId))
                .ForPath(dest => dest.BlogBlog.BlogTitle, opt => opt.MapFrom(src => src.BlogTitle))
                .ForPath(dest => dest.BlogBlog.BlogImage, opt => opt.MapFrom(src => src.BlogImage))
                .ForPath(dest => dest.BlogBlog.BlogContent, opt => opt.MapFrom(src => src.BlogContent))
                .ForPath(dest => dest.BlogBlog.Status, opt => opt.MapFrom(src => src.Status))
                .ForPath(dest => dest.BlogBlog.ReadTime, opt => opt.MapFrom(src => src.ReadTime))
                .ForPath(dest => dest.BlogBlog.BlogTagBlogTag.BlogTagName, opt => opt.MapFrom(src => src.BlogTag))
                .ForPath(dest => dest.BlogBlog.BlogTopicBlogTopic.BlogTopicName, opt => opt.MapFrom(src => src.BlogTopic))
                .ForPath(dest => dest.UserUser.FullName, opt => opt.MapFrom(src => src.PosterName))
                .ForPath(dest => dest.UserUser.Image, opt => opt.MapFrom(src => src.PosterImage))
                .ForPath(dest => dest.SavedDay, opt => opt.MapFrom(src => src.SavedDay))
                .ReverseMap();

            CreateMap<AddSaveBlogRequest, SaveBlog>()
                 .ForMember(dest => dest.BlogBlogId, opt => opt.MapFrom(src => src.BlogId))
                 .ForMember(dest => dest.UserUserId, opt => opt.MapFrom(src => src.UserId))
                 .ReverseMap();

            CreateMap<DeleteSaveBlogRequest, SaveBlog>()
                .ForMember(dest => dest.BlogBlogId, opt => opt.MapFrom(src => src.BlogId))
                .ForMember(dest => dest.UserUserId, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();

            CreateMap<GetIDListSaveBlogRequest, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.userID))
                .ReverseMap();

            CreateMap<GetIDListSaveBlog, Blog>()
                .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.blogID))
                .ReverseMap();

            CreateMap<InsertCommentRequest, BlogComment>()
                 .ForMember(dest => dest.BlogBlogId, opt => opt.MapFrom(src => src.blogID))
                 .ForMember(dest => dest.UserUserId, opt => opt.MapFrom(src => src.userID))
                 .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.commentContent))
                 .ReverseMap();

            CreateMap<InsertReplyRequest, BlogComment>()
                 .ForMember(dest => dest.BlogBlogId, opt => opt.MapFrom(src => src.blogID))
                 .ForMember(dest => dest.UserUserId, opt => opt.MapFrom(src => src.userID))
                 .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.commentContent))
                 .ForMember(dest => dest.ReplyToUser, opt => opt.MapFrom(src => src.userReplyID))
                 .ForMember(dest => dest.OriginCommentId, opt => opt.MapFrom(src => src.OriginCommentId))
                 .ReverseMap();

            CreateMap<BlogComment, CommentView>()
            .ForMember(dest => dest.BlogCommentID, opt => opt.MapFrom(src => src.BlogCommentId))
            .ForMember(dest => dest.BlogID, opt => opt.MapFrom(src => src.BlogBlogId))
            .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserUserId))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.BlogCommentLevel))
            .ForMember(dest => dest.OriginCommentID, opt => opt.MapFrom(src => src.OriginCommentId))
            .ForMember(dest => dest.ReplyToUserID, opt => opt.MapFrom(src => src.ReplyToUser))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.CommentContent))
            .ForMember(dest => dest.Publish, opt => opt.MapFrom(src => src.PublishDate))
            .ForMember(dest => dest.ReplyToUsername, opt => opt.MapFrom(src => src.ReplyToUserNavigation.FullName))
            .ForMember(dest => dest.CommentUser, opt => opt.MapFrom(src => src.UserUser.FullName))
            .ForMember(dest => dest.ImageUserComment, opt => opt.MapFrom(src => src.UserUser.Image))
            .ReverseMap();
        }

    }
}
