using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Answers.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository answerRepo;
        public AnswerController(IAnswerRepository answerRepo)
        {
            this.answerRepo = answerRepo;
        }

        // Get all answers by questionId
        [HttpGet("/getAllAnswersByQuestionId_Home")]
        public async Task<ActionResult<IEnumerable<AnswerReadHomeDTO>>> GetAllAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = await answerRepo.GetAllAnswersByQuestionId(questionId);
                return Ok(answers);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Select true answer
        [HttpGet("/selectTrueAnswer")]
        public async Task<ActionResult<bool>> SelectTrueAnswer(int answerId, int questionId)
        {
            try
            {
                var trueAnswer = await answerRepo.SelectTrueAnswer(answerId, questionId);
                return Ok(trueAnswer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
