using OLS.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using OLS.DTO.Blogs.Home;
using OLS.Services.Interface.Home;
using OLS.DTO.Blogs.Home.BlogSite;
using OLS.DTO.Blogs.Home.CommentBlog;
using OLS.DTO.Blogs.Home.SaveBlog;

namespace OLS.Services.Implementations.Home
{
    public class BlogRepository : IBlogRepository
    {
        private readonly OLSContext _context;
        private readonly Mapper _mapper;

        public BlogRepository(OLSContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Homepage
        // Get 10 newest blogs
        public async Task<List<BlogReadHomeDTO>> Get10NewestBlogs()
        {
            var blogs = await _context.Blogs.OrderByDescending(blog => blog.PostDate).Take(10).Include(blog => blog.UserUser).ToListAsync();
            var blogReadHomePageDTO = _mapper.Map<List<BlogReadHomeDTO>>(blogs);

            return blogReadHomePageDTO;
        }

        // Search blogs by blog title
        public async Task<List<BlogReadHomeDTO>> SearchBlogsByBlogTitle(string keyword)
        {
            var blogs = await _context.Blogs.Where(blogs => blogs.BlogTitle.Contains(keyword)).Include(blogs => blogs.UserUser).ToListAsync();
            var blogReadHomePageDTO = _mapper.Map<List<BlogReadHomeDTO>>(blogs);

            return blogReadHomePageDTO;
        }

        // BlogOnSite
        public async Task<IEnumerable<BlogSite>> GetAllBlogOnSite()
        {
            var blogs = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                       .Include(b => b.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .Where(b => b.Status == 1)
                                       .OrderByDescending(b => b.PostDate)
                                       .ToListAsync();

            var blogSite = _mapper.Map<IEnumerable<BlogSite>>(blogs);

            return blogSite;
        }

        public async Task<IEnumerable<GetAllBlogTagRequest>> GetListBlogTag()
        {
            var tags = await _context.BlogTags.ToListAsync();
            var blogTag = _mapper.Map<IEnumerable<GetAllBlogTagRequest>>(tags);
            return blogTag;
        }

        public async Task<IEnumerable<GetAllBlogTopicRequest>> GetListBlogTopic()
        {
            var topics = await _context.BlogTopics.ToListAsync();
            var blogTopic = _mapper.Map<IEnumerable<GetAllBlogTopicRequest>>(topics);
            return blogTopic;
        }

        public async Task<IEnumerable<BlogSite>> Get5NewBlogs()
        {
            var blogs = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                       .Include(b => b.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .Where(b => b.Status == 1)
                                       .OrderByDescending(b => b.PostDate)
                                       .Take(5)
                                       .ToListAsync();

            var FiveNewBlogs = _mapper.Map<IEnumerable<BlogSite>>(blogs);

            return FiveNewBlogs;
        }

        public async Task<BlogSite> GetBlogsByID(GetBlogByIDRequest blogID)
        {
            var blog = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                       .Include(b => b.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .FirstOrDefaultAsync(b => b.BlogId == _mapper.Map<Blog>(blogID).BlogId);

            if (blog != null)
            {
                var blogViewOnsite = _mapper.Map<BlogSite>(blog);
                return blogViewOnsite;
            }
            return null;
        }
        public async Task<IEnumerable<BlogSite>> GetBlogsByTag(GetBlogByTagRequest blogTag)
        {
            var blogs = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                       .Include(b => b.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .Where(b => b.Status == 1 && b.BlogTagBlogTag.BlogTagId == _mapper.Map<BlogTag>(blogTag).BlogTagId)
                                       .ToListAsync();

            var blogSiteByTag = _mapper.Map<IEnumerable<BlogSite>>(blogs);

            return blogSiteByTag;
        }

        public async Task<IEnumerable<BlogSite>> GetBlogsByTopic(GetBlogByTopicRequest blogTopic)
        {
            var blogs = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                       .Include(b => b.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .Where(b => b.Status == 1 && b.BlogTopicBlogTopic.BlogTopicId == _mapper.Map<BlogTopic>(blogTopic).BlogTopicId)
                                       .ToListAsync();

            var blogSiteByTopic = _mapper.Map<IEnumerable<BlogSite>>(blogs);

            return blogSiteByTopic;
        }

        public async Task<IEnumerable<BlogSite>> GetBlogsByTopicAndTag(GetBlogByTopicRequest blogTopic, GetBlogByTagRequest blogTag)
        {
            var blogs = await _context.Blogs.Include(b => b.BlogTagBlogTag)
                                       .Include(b => b.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .Where(b => b.Status == 1 && b.BlogTopicBlogTopic.BlogTopicId == _mapper.Map<BlogTopic>(blogTopic).BlogTopicId && b.BlogTagBlogTag.BlogTagId == _mapper.Map<BlogTag>(blogTag).BlogTagId)
                                       .ToListAsync();

            var blogSiteByTagAndTopic = _mapper.Map<IEnumerable<BlogSite>>(blogs);

            return blogSiteByTagAndTopic;
        }


        // Save Blog
        public async Task<IEnumerable<BlogSaved>> GetListSaveBlog()
        {
            var blogs = await _context.SaveBlogs.Include(b => b.BlogBlog)
                                       .Include(b => b.BlogBlog.BlogTagBlogTag)
                                       .Include(b => b.BlogBlog.BlogTopicBlogTopic)
                                       .Include(b => b.UserUser)
                                       .Where(b => b.BlogBlog.Status == 1)
                                       .OrderByDescending(b => b.SavedDay)
                                       .ToListAsync();

            var SaveBlogs = _mapper.Map<IEnumerable<BlogSaved>>(blogs);

            return SaveBlogs;
        }

        public async Task<bool> AddSaveBlog(AddSaveBlogRequest blogRequest)
        {
            try
            {
                if (blogRequest.UserId == null) { return false; }
                else
                {
                    var blogMap = _mapper.Map<SaveBlog>(blogRequest);
                    var blog = await _context.Blogs
                        .Where(b => b.BlogId == blogMap.BlogBlogId)
                        .FirstOrDefaultAsync();

                    if (blog != null)
                    {
                        var existingSavedBlog = await _context.SaveBlogs
                            .Where(sb => sb.BlogBlogId == blogMap.BlogBlogId && sb.UserUserId == blogMap.UserUserId)
                            .FirstOrDefaultAsync();

                        if (existingSavedBlog == null)
                        {
                            var savedBlog = new SaveBlog
                            {
                                BlogBlogId = blogMap.BlogBlogId,
                                UserUserId = blogMap.UserUserId,
                                SavedDay = DateTime.UtcNow
                            };
                            _context.ChangeTracker.TrackGraph(savedBlog, e => e.Entry.State = EntityState.Detached);
                            _context.SaveBlogs.Add(savedBlog);
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteSaveBlog(DeleteSaveBlogRequest blogRequest)
        {
            try
            {
                if (blogRequest.UserId == null) { return false; }
                else
                {
                    var blogMap = _mapper.Map<SaveBlog>(blogRequest);
                    var blog = await _context.SaveBlogs
                        .Where(b => b.BlogBlogId == blogMap.BlogBlogId && b.UserUserId == blogMap.UserUserId)
                        .FirstOrDefaultAsync();

                    if (blog != null)
                    {
                        _context.SaveBlogs.Remove(blog);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<GetIDListSaveBlog>> GetIDListSaveBlog(GetIDListSaveBlogRequest userID)
        {
            var blogIds = await _context.Blogs
                                .Include(b => b.BlogTagBlogTag)
                                .Include(b => b.BlogTopicBlogTopic)
                                .Include(b => b.UserUser)
                                .Where(b => b.UserUser.UserId == _mapper.Map<User>(userID).UserId)
                                .Select(b => b.BlogId)
                                .ToListAsync();

            var idListSaveBlogs = blogIds.Select(id => new GetIDListSaveBlog { blogID = id });

            return idListSaveBlogs;
        }

        public async Task<bool> InsertComment(InsertCommentRequest comment)
        {
            try
            {
                if (comment.userID == null) { return false; }
                else
                {
                    var commentMap = _mapper.Map<BlogComment>(comment);
                    var blog = await _context.Blogs
                        .Where(b => b.BlogId == commentMap.BlogBlogId)
                        .FirstOrDefaultAsync();

                    if (blog != null)
                    {
                        var commentBlog = new BlogComment
                        {
                            BlogCommentLevel = 1,
                            CommentContent = commentMap.CommentContent,
                            ReplyToUser = commentMap.UserUserId,
                            BlogBlogId = commentMap.BlogBlogId,
                            UserUserId = commentMap.UserUserId,
                            PublishDate = DateTime.UtcNow
                        };
                        _context.BlogComments.Add(commentBlog);
                        await _context.SaveChangesAsync();
                        int originComment_id = commentBlog.BlogCommentId;
                        commentBlog.OriginCommentId = originComment_id;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<bool> ReplyComment(InsertReplyRequest reply)
        {
            try
            {
                if (reply.userID == null) { return false; }
                else
                {
                    var commentMap = _mapper.Map<BlogComment>(reply);
                    var blog = await _context.Blogs
                        .Where(b => b.BlogId == commentMap.BlogBlogId)
                        .FirstOrDefaultAsync();

                    if (blog != null)
                    {
                        var replyBlog = new BlogComment
                        {
                            BlogCommentLevel = 2,
                            OriginCommentId = commentMap.OriginCommentId,
                            CommentContent = commentMap.CommentContent,
                            ReplyToUser = commentMap.ReplyToUser,
                            BlogBlogId = commentMap.BlogBlogId,
                            UserUserId = commentMap.UserUserId,
                            PublishDate = DateTime.UtcNow
                        };
                        _context.BlogComments.Add(replyBlog);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<CommentView>> GetAllComments(int id)
        {
            var comments = await _context.BlogComments
                                .Include(c => c.UserUser)
                                .Include(c => c.ReplyToUserNavigation)
                                .Where(c => c.BlogBlogId == id)
                                .OrderByDescending(c => c.OriginCommentId)
                                .ThenBy(c => c.BlogCommentLevel)
                                .Select(c => new CommentView
                                {
                                    BlogCommentID = c.BlogCommentId,
                                    BlogID = c.BlogBlogId,
                                    UserID = c.UserUserId,
                                    Level = c.BlogCommentLevel,
                                    OriginCommentID = c.OriginCommentId,
                                    ReplyToUserID = c.ReplyToUser,
                                    Content = c.CommentContent,
                                    Publish = c.PublishDate,
                                    ReplyToUsername = c.ReplyToUserNavigation.FullName,
                                    ImageUserComment = c.UserUser.Image
                                })
                                .ToListAsync();

            return _mapper.Map<IEnumerable<CommentView>>(comments);

        }

    }
}
