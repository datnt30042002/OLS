using OLS.Models;
using OLS.DTO;

namespace OLS.Repositories.Interface
{
    public interface IBlogRepository
    {
        // Homepage
        IEnumerable<BlogDTO> Get10NewestBlogs();
    }
}
