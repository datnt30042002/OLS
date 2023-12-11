using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Blogs.Admin.BlogManager;
using OLS.Models;
using OLS.Services.Interface.Admin;


namespace OLS.Services.Implementations.Admin
{
    public class BlogManagerRepository : IBlogManagerRepository
    {
        private readonly OLSContext _context;
        private readonly Mapper _mapper;

        public BlogManagerRepository(OLSContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogManager>> GetAllBlogs()
        {
            var blogs = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                       .Include(b => b.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .ToListAsync();

            var blogManagers = _mapper.Map<List<BlogManager>>(blogs);

            return blogManagers;
        }

        public async Task<BlogManager> GetDetailBlog(int id)
        {
            var blog = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                           .Include(b => b.BlogTopicBlogTopic)
                                           .Include(b => b.UserUser)
                                           .FirstOrDefaultAsync(b => b.BlogId == id);

            if (blog != null)
            {
                var blogManager = _mapper.Map<BlogManager>(blog);
                return blogManager;
            }
            return null;
        }

        public async Task<IEnumerable<BlogManager>> SearchBlogsByTitle(string keyword)
        {
            var blogs = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                            .Include(b => b.BlogTopicBlogTopic)
                                            .Include(b => b.UserUser)
                                            .Where(b => b.BlogTitle.Contains(keyword))
                                            .ToListAsync();

            var blogManagers = _mapper.Map<List<BlogManager>>(blogs);
            return blogManagers;
        }

        public async Task<bool> AddBlog(BlogManagerAddRequest blog)
        {
            try
            {
                var blogMap = _mapper.Map<Blog>(blog);

                var blogTag = await _context.BlogTags.FirstOrDefaultAsync(tag => tag.BlogTagName == blogMap.BlogTagBlogTag.BlogTagName);
                if (blogTag != null)
                {
                    blogMap.BlogTagBlogTag = blogTag;
                }
                else
                {
                    //var newBlogTag = new BlogTag
                    //{
                    //    BlogTagName = blogMap.BlogTagBlogTag.BlogTagName
                    //};

                    //_context.BlogTags.Add(newBlogTag);
                    //await _context.SaveChangesAsync();

                    //blogMap.BlogTagBlogTag.BlogTagId = newBlogTag.BlogTagId;

                    _context.BlogTags.Add(blogMap.BlogTagBlogTag);
                }

                var blogTopic = await _context.BlogTopics.FirstOrDefaultAsync(topic => topic.BlogTopicName == blogMap.BlogTopicBlogTopic.BlogTopicName);
                if (blogTopic != null)
                {
                    blogMap.BlogTopicBlogTopic = blogTopic;
                }
                else
                {
                    //var newBlogTopic = new BlogTopic
                    //{
                    //    BlogTopicName = blogMap.BlogTopicBlogTopic.BlogTopicName
                    //};

                    //_context.BlogTopics.Add(newBlogTopic);
                    //await _context.SaveChangesAsync();

                    //blogMap.BlogTopicBlogTopic.BlogTopicId = newBlogTopic.BlogTopicId;
                    _context.BlogTopics.Add(blogMap.BlogTopicBlogTopic);
                }

                // Sử dụng sau khi Test API xong (getUser theo phiên đăng nhập)
                //var user = await _userManager.GetUserAsync(User);
                //if (user != null)
                //{
                //    blogMap.UserUserId = user.Id;
                //}

                _context.Blogs.Add(blogMap);
                int savedChanges = await _context.SaveChangesAsync();

                if (savedChanges > 0)
                {
                    return true;
                }
                else
                {
                    // Đã có lỗi xảy ra trong quá trình lưu dữ liệu
                    return false;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateBlog(int id, BlogManager blog)
        {
            var existingBlog = await _context.Blogs.FindAsync(id);

            if (existingBlog != null)
            {
                _mapper.Map(blog, existingBlog);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBlog(int id)
        {
            var existingBlog = await _context.Blogs.FindAsync(id);

            if (existingBlog != null)
            {
                _context.Blogs.Remove(existingBlog);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> LockBlog(int id, BlogManagerLockRequest blog)
        {
            var existingBlog = await _context.Blogs.FindAsync(id);

            if (existingBlog != null)
            {
                _mapper.Map(blog, existingBlog);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
