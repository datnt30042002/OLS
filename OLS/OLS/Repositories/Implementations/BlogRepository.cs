using OLS.Models;
using OLS.DTO;
using OLS.Helpers;
using OLS.Repositories;
using OLS.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OLS.Repositories.Implementations
{
    public class BlogRepository : IBlogRepository
    {
        private readonly OLSContext db;
        public BlogRepository(OLSContext db)
        {
            this.db = db;
        }

        // Homepage
        // get 10 newest blogs
        public IEnumerable<BlogDTO> Get10NewestBlogs()
        {
            var blogs = db.Blogs
                .OrderByDescending(blog => blog.PostDate)
                .Take(10)
                .Select(blog => new BlogDTO
                {
                    BlogId = blog.BlogId,
                    BlogTitle = blog.BlogTitle,
                    BlogImage = blog.BlogImage,
                    BlogContent = blog.BlogContent,
                    PostDate = blog.PostDate,
                    Status = blog.Status,
                    ReadTime = blog.ReadTime,
                    BlogTopicBlogTopicId = blog.BlogTopicBlogTopicId,
                    BlogTagBlogTagId = blog.BlogTagBlogTagId,
                    UserUserId = blog.UserUserId,
                }).ToList();

            return blogs;
        }

    }
}
