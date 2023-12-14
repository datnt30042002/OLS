using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Questions.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository questionRepo;
        public QuestionController(IQuestionRepository questionRepo)
        {
            this.questionRepo = questionRepo;
        }

        // Get all questions by quizId
        [HttpGet("/getAllQuestionsByQuizId_Home")]
        public async Task<ActionResult<IEnumerable<QuestionReadHomeDTO>>> GetAllQuestionsByQuizId(int quizId)
        {
            try
            {
                var questions = await questionRepo.GetAllQuestionsByQuizId(quizId);
                return Ok(questions);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
