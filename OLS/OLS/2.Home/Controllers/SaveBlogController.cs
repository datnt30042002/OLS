using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Blogs.Home.SaveBlog;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveBlogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repo;

        public SaveBlogController(IMapper mapper, IBlogRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("GetListSaveBlog")]
        public async Task<IActionResult> GetListSaveBlog()
        {
            var blogs = await _repo.GetListSaveBlog();
            if (blogs != null)
            {
                return Ok(blogs);
            }
            return NotFound();
        }

        [HttpPost("AddSaveBlog")]
        public async Task<IActionResult> AddSaveBlog([FromForm] AddSaveBlogRequest request)
        {
            var result = await _repo.AddSaveBlog(request);
            if (!result)
            {
                return BadRequest("Save Blog is unsuccessful !!");
            }
            return Ok(new { Message = "Save Blog success !!" });
        }

        [HttpDelete("DeleteSaveBlog")]
        public async Task<IActionResult> DeleteSaveBlog([FromForm] DeleteSaveBlogRequest request)
        {
            var result = await _repo.DeleteSaveBlog(request);
            if (!result)
            {
                return BadRequest("Unsave Blog is unsuccessful !!");
            }
            return Ok(new { Message = "Unsave Blog success !!" });
        }

        [HttpGet("GetIDListSaveBlog/{userID}")]
        public async Task<IActionResult> GetIDListSaveBlog(GetIDListSaveBlogRequest request)
        {
            var blogIDs = await _repo.GetIDListSaveBlog(request);
            if (blogIDs != null)
            {
                return Ok(blogIDs);
            }

            return NotFound("Không tìm thấy ID của các bài viết liên quan.");
        }
    }
}
