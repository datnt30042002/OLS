using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Blogs.Admin.BlogManager;
using OLS.Services.Interface.Admin;
using OLS.Services.Interface.Home;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogManagerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogManagerRepository _repo;

        public BlogManagerController(IMapper mapper, IBlogManagerRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _repo.GetAllBlogs();
            return Ok(blogs);
        }

        [HttpGet("GetDetailBlog/{id}")]
        public async Task<IActionResult> GetDetailBlog(int id)
        {
            var blog = await _repo.GetDetailBlog(id);
            if (blog != null)
            {
                return Ok(blog);
            }
            return NotFound();
        }

        [HttpGet("SearchBlog")]
        public async Task<IActionResult> SearchBlogs([FromQuery] string keyword)
        {
            var blogs = await _repo.SearchBlogsByTitle(keyword);
            if (blogs != null)
            {
                return Ok(blogs);
            }
            return NotFound();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddBlog([FromForm] BlogManagerAddRequest blog)
        {
            var isAdded = await _repo.AddBlog(blog);
            if (isAdded)
            {
                return Ok("Blog added successfully.");
            }
            return BadRequest("Failed to add the blog.");
        }

        [HttpPut("UpdateBlog/{id}")]
        public async Task<IActionResult> UpdateBlog(int id, [FromForm] BlogManager blog)
        {
            var isUpdated = await _repo.UpdateBlog(id, blog);
            if (isUpdated)
            {
                return Ok("Blog updated successfully.");
            }
            return BadRequest("Failed to update the blog.");
        }

        [HttpDelete("DeleteBlog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var isDeleted = await _repo.DeleteBlog(id);
            if (isDeleted)
            {
                return Ok("Blog deleted successfully.");
            }
            return BadRequest("Failed to delete the blog.");
        }

        [HttpPut("LockBlog/{id}")]
        public async Task<IActionResult> LockBlog(int id, BlogManagerLockRequest blog)
        {
            var isLock = blog.IsLock;
            var result = await _repo.LockBlog(id, blog);

            if (result)
            {
                return Ok($"Blog with ID {id} has been {(isLock ? "locked" : "unlocked")}.");
            }

            return NotFound($"Blog with ID {id} not found.");
        }
    }
}
