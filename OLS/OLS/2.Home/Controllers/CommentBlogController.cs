using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Blogs.Home.CommentBlog;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentBlogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repo;

        public CommentBlogController(IMapper mapper, IBlogRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("InsertCommentBlog")]
        public async Task<IActionResult> InsertCommentBlog([FromForm] InsertCommentRequest request)
        {
            var result = await _repo.InsertComment(request);
            if (!result)
            {
                return BadRequest("Comment Blog is unsuccessful !!");
            }
            return Ok(new { Message = "Comment Blog success !!" });
        }

        [HttpPost("InsertReplyBlog")]
        public async Task<IActionResult> InsertReplyBlog([FromForm] InsertReplyRequest request)
        {
            if (request.OriginCommentId == null)
            {
                var comment = new InsertCommentRequest
                {
                    blogID = request.blogID,
                    userID = request.userID,
                    commentContent = request.commentContent,

                };
                var resultComment = await _repo.InsertComment(comment);
                if (!resultComment)
                {
                    return BadRequest("Comment Blog is unsuccessful !!");
                }
                return Ok(new { Message = "Comment Blog success !!" });
            }
            else
            {
                var resultReply = await _repo.ReplyComment(request);
                if (!resultReply)
                {
                    return BadRequest("Reply Comment Blog is unsuccessful !!");
                }
                return Ok(new { Message = "Reply Comment Blog success !!" });
            }
        }

        [HttpGet("GetAllComments{blogId}")]
        public async Task<IActionResult> GetAllComments(int blogId)
        {
            var comments = await _repo.GetAllComments(blogId);
            return Ok(comments);
        }
    }
}
