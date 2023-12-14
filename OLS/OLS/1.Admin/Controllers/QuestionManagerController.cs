using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Questions.Admin;
using OLS.DTO.Quizzes.Admin;
using OLS.Services.Interface.Admin;
namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionManagerController : ControllerBase
    {
        private readonly IQuestionManagerRepository questionManagerRepo;
        public QuestionManagerController(IQuestionManagerRepository questionManagerRepo)
        {
            this.questionManagerRepo = questionManagerRepo;
        }

        // Get all questions by quizId
        [HttpGet("/getAllQuestionsByQuizId")]
        public async Task<ActionResult<IEnumerable<QuestionReadAdminDTO>>> GetAllQuestionsByQuizId(int quizId)
        {
            try
            {
                var questions = await questionManagerRepo.GetAllQuestionsByQuizId(quizId);
                return Ok(questions);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new question 
        [HttpPost("/createQuestion")]
        public async Task<ActionResult<IEnumerable<QuestionCreateAdminDTO>>> CreateQuestion(QuestionCreateAdminDTO question)
        {
            try
            {
                var newQuestion = await questionManagerRepo.CreateQuestion(question);
                return Ok(newQuestion);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update question by questionId 
        [HttpPut("/updateQueStionByQuestionId")]
        public async Task<ActionResult<IEnumerable<QuestionUpdateAdminDTO>>> UpdateQueStionByQuestionId(int questionId, QuestionUpdateAdminDTO updatedQuestion)
        {
            try
            {
                var question = await questionManagerRepo.UpdateQueStionByQuestionId(questionId, updatedQuestion);
                return Ok(question);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete queStion by questionId 
        [HttpDelete("/deleteQuestionByQuestionId")]
        public async Task<ActionResult> DeleteQuestionByQuestionId(int questionId)
        {
            try
            {
                var deletedQuestion = await questionManagerRepo.DeleteQuestionByQuestionId(questionId);
                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
