using OLS.Models;
using OLS.DTO.Blogs.Home;

namespace OLS.Services.Interface.Home
{
    public interface IBlogRepository
    {
        // Homepage
        Task<List<BlogReadHomeDTO>> Get10NewestBlogs();
        Task<List<BlogReadHomeDTO>> SearchBlogsByBlogTitle(string keyword);
    }
}
