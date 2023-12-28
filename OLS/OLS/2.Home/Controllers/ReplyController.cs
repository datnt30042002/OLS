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
        [HttpGet("/getAllRepliesByAskId/{askId}")]
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

        // Count amount of replies by askId
        [HttpGet("/countRepliesByAskId/{askId}")]
        public async Task<ActionResult> CountRepliesByAskId(int askId)
        {
            try
            {
                var replies = await replyRepo.CountRepliesByAskId(askId);
                return Ok(replies);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get reply by replyId
        [HttpGet("/getReplyByReplyId/{replyId}")] 
        public async Task<ActionResult<IEnumerable<ReplyReadHomeDTO>>> GetReplyByReplyId(int replyId)
        {
            try
            {
                var reply = await replyRepo.GetReplyByReplyId(replyId);
                return Ok(reply);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update reply by replyId
        [HttpPut("/updateReplyByReplyId/{replyId}")] 
        public async Task<ActionResult<IEnumerable<ReplyUpdateHomeDTO>>> UpdateReplyByReplyId(int replyId, ReplyUpdateHomeDTO updatedReply)
        {
            try
            {
                var existingReply = await replyRepo.UpdateReplyByReplyId(replyId, updatedReply);
                return Ok(existingReply);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete reply by replyId
        [HttpDelete("/deleteReplyByReplyId/{replyId}")]
        public async Task<ActionResult> DeleteReplyByReplyId(int replyId)
        {
            try
            {
                var existingReply = await replyRepo.DeleteReplyByReplyId(replyId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
