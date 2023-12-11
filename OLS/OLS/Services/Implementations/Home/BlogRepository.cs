using OLS.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using OLS.DTO.Blogs.Home;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class BlogRepository : IBlogRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public BlogRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Homepage
        // Get 10 newest blogs
        public async Task<List<BlogReadHomeDTO>> Get10NewestBlogs()
        {
            var blogs = await db.Blogs.OrderByDescending(blog => blog.PostDate).Take(10).Include(blog => blog.UserUser).ToListAsync();
            var blogReadHomePageDTO = mapper.Map<List<BlogReadHomeDTO>>(blogs);

            return blogReadHomePageDTO;
        }

        // Search blogs by blog title
        public async Task<List<BlogReadHomeDTO>> SearchBlogsByBlogTitle(string keyword)
        {
            var blogs = await db.Blogs.Where(blogs => blogs.BlogTitle.Contains(keyword)).Include(blogs => blogs.UserUser).ToListAsync();
            var blogReadHomePageDTO = mapper.Map<List<BlogReadHomeDTO>>(blogs);

            return blogReadHomePageDTO;
        }

    }
}
