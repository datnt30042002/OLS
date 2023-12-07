using OLS.DTO.Blogs.Admin.BlogManager;

namespace OLS.Repositories.Interface.Admin
{
    public interface IBlogManagerRepository
    {
        Task<IEnumerable<BlogManager>> GetAllBlogs();
        Task<BlogManager> GetDetailBlog(int id);
        Task<IEnumerable<BlogManager>> SearchBlogsByTitle(string keyword);
        Task<bool> AddBlog(BlogManagerAddRequest blog);
        Task<bool> UpdateBlog(int id, BlogManager blog);
        Task<bool> DeleteBlog(int id);
        Task<bool> LockBlog(int id, BlogManagerLockRequest blog);
    }
}
