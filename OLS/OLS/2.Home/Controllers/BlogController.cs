using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Blogs.Home.BlogSite;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repo;

        public BlogController(IMapper mapper, IBlogRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("GetAllBlog")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _repo.GetAllBlogOnSite();
            if (blogs != null)
            {
                return Ok(blogs);
            }
            return NotFound();
        }

        [HttpGet("GetListBlogTag")]
        public async Task<IActionResult> GetListBlogTag()
        {
            var tags = await _repo.GetListBlogTag();
            if (tags != null)
            {
                return Ok(tags);
            }
            return NotFound();
        }

        [HttpGet("GetListBlogTopic")]
        public async Task<IActionResult> GetListBlogTopic()
        {
            var topics = await _repo.GetListBlogTopic();
            if (topics != null)
            {
                return Ok(topics);
            }
            return NotFound();
        }

        [HttpGet("Get5NewBlog")]
        public async Task<IActionResult> Get5NewBlog()
        {
            var blogs = await _repo.Get5NewBlogs();
            if (blogs != null)
            {
                return Ok(blogs);
            }
            return NotFound();
        }

        [HttpGet("GetBlogByID/{blogID}")]
        public async Task<IActionResult> GetBlogByID(GetBlogByIDRequest blogID)
        {
            var blog = await _repo.GetBlogsByID(blogID);
            if (blog != null)
            {
                if (blog.Status == 1)
                {
                    return Ok(blog);
                }
                else
                {
                    return NotFound("Bài viết này đang tạm thời bị khóa.");
                }
            }
            return NotFound("Không tìm thấy bài viết.");
        }

        [HttpGet("GetBlogByTag/{blogTag}")]
        public async Task<IActionResult> GetBlogByTag(GetBlogByTagRequest blogTag)
        {
            var blogs = await _repo.GetBlogsByTag(blogTag);
            if (blogs != null)
            {
                return Ok(blogs);
            }

            return NotFound("Không tìm thấy các bài viết liên quan.");
        }

        [HttpGet("GetBlogByTopic/{blogTopic}")]
        public async Task<IActionResult> GetBlogByTopic(GetBlogByTopicRequest blogTopic)
        {
            var blogs = await _repo.GetBlogsByTopic(blogTopic);
            if (blogs != null)
            {
                return Ok(blogs);
            }

            return NotFound("Không tìm thấy các bài viết liên quan.");
        }

        [HttpPost("GetBlogByTopicAndTag")]
        public async Task<IActionResult> GetBlogByTopicAndTag([FromForm] GetBlogByTopicRequest blogTopic, [FromForm] GetBlogByTagRequest blogTag)
        {
            var blogs = await _repo.GetBlogsByTopicAndTag(blogTopic, blogTag);
            if (blogs != null)
            {
                return Ok(blogs);
            }

            return NotFound("Không tìm thấy các bài viết liên quan.");
        }
    }
}
