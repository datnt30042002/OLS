using OLS.Models;
using OLS.DTO.Blogs.Home;
using OLS.DTO.Blogs.Home.BlogSite;
using OLS.DTO.Blogs.Home.CommentBlog;
using OLS.DTO.Blogs.Home.SaveBlog;

namespace OLS.Services.Interface.Home
{
    public interface IBlogRepository
    {
        // Homepage
        Task<List<BlogReadHomeDTO>> Get10NewestBlogs();
        Task<List<BlogReadHomeDTO>> SearchBlogsByBlogTitle(string keyword);

        // BlogSite
        Task<IEnumerable<BlogSite>> GetAllBlogOnSite();
        Task<IEnumerable<GetAllBlogTagRequest>> GetListBlogTag();
        Task<IEnumerable<GetAllBlogTopicRequest>> GetListBlogTopic();
        Task<IEnumerable<BlogSite>> Get5NewBlogs();
        Task<BlogSite> GetBlogsByID(GetBlogByIDRequest blogID);
        Task<IEnumerable<BlogSite>> GetBlogsByTag(GetBlogByTagRequest blogTag);
        Task<IEnumerable<BlogSite>> GetBlogsByTopic(GetBlogByTopicRequest blogTopic);
        Task<IEnumerable<BlogSite>> GetBlogsByTopicAndTag(GetBlogByTopicRequest blogTopic, GetBlogByTagRequest blogTag);

        // SaveBlog
        Task<IEnumerable<BlogSaved>> GetListSaveBlog();
        Task<IEnumerable<GetIDListSaveBlog>> GetIDListSaveBlog(GetIDListSaveBlogRequest userID);
        Task<bool> AddSaveBlog(AddSaveBlogRequest blog);
        Task<bool> DeleteSaveBlog(DeleteSaveBlogRequest blog);

        // BlogComment 
        Task<bool> InsertComment(InsertCommentRequest comment);
        Task<bool> ReplyComment(InsertReplyRequest reply);

        Task<IEnumerable<CommentView>> GetAllComments(int id);
    }
}
