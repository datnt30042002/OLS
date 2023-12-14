using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Asks.Home;
using OLS.DTO.Replies.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyRepository replyRepo;
        public ReplyController(IReplyRepository replyRepo)
        {
            this.replyRepo = replyRepo;
        }

        // Get all replies by ask id 
        [HttpGet("/getAllRepliesByAskId")]
        public async Task<ActionResult<IEnumerable<ReplyReadHomeDTO>>> GetAllRepliesByAskId(int askId)
        {
            try
            {
                var replies = await replyRepo.GetAllRepliesByAskId(askId);
                return Ok(replies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Cerate new ask 
        [HttpPost("/createReply")]
        public async Task<ActionResult<IEnumerable<ReplyCreateHomeDTO>>> CreateAsk(ReplyCreateHomeDTO reply)
        {
            try
            {
                var newReply = await replyRepo.CreateReply(reply);
                return Ok(newReply);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
