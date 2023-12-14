using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Answers.Admin;
using OLS.Services.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerManagerController : ControllerBase
    {
        private readonly IAnswerManagerRepository answerManagerRepo;
        public AnswerManagerController(IAnswerManagerRepository answerManagerRepo)
        {
            this.answerManagerRepo = answerManagerRepo;
        }

        // Get all answers by questionId
        [HttpGet("/getAllAnswersByQuestionId")]
        public async Task<ActionResult<IEnumerable<AnswerReadAdminDTO>>> GetAllAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = await answerManagerRepo.GetAllAnswersByQuestionId(questionId);
                return Ok(answers);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/createAnswer")]
        public async Task<ActionResult<IEnumerable<AnswerCreateAdminDTO>>> CreateAnswer(AnswerCreateAdminDTO answer)
        {
            try
            {
                var newAnswer = await answerManagerRepo.CreateAnswer(answer);
                return Ok(newAnswer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update answer by answerId
        [HttpPut("/updateAnswerByAnswerId")]
        public async Task<ActionResult<IEnumerable<AnswerUpdateAdminDTO>>> UpdateAnswerByAnswerId(int answerId, AnswerUpdateAdminDTO updatedAnswer)
        {
            try
            {
                var existingAnswer = await answerManagerRepo.UpdateAnswerByAnswerId(answerId, updatedAnswer);
                return Ok(existingAnswer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete answer by answerId
        [HttpDelete("/deleteAnswerByAnswerId")]
        public async Task<ActionResult> DeleteAnswerByAnswerId(int answerId)
        {
            try
            {
                var deletedAnwser = await answerManagerRepo.DeleteAnswerByAnswerId(answerId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
