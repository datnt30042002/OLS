using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Courses.Admin;
using OLS.DTO.Quizzes.Admin;
using OLS.Services.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizManagerController : ControllerBase
    {
        private readonly IQuizManagerRepository quizManagerRepo;
        public QuizManagerController(IQuizManagerRepository quizManagerRepo)
        {
            this.quizManagerRepo = quizManagerRepo;
        }

        // Get all quizzes by chapterId
        [HttpGet("/getAllQuizzesByChapterId")]
        public async Task<ActionResult<IEnumerable<QuizReadAdminDTO>>> GetAllQuizzesByChapterId(int chapterId)
        {
            try
            {
                var quizzes = await quizManagerRepo.GetAllQuizzesByChapterId(chapterId);
                return Ok(quizzes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new quiz 
        [HttpPost("/createQuiz")]
        public async Task<ActionResult<IEnumerable<QuizCreateAdminDTO>>> CreateQuiz(QuizCreateAdminDTO quiz)
        {
            try
            {
                var newQuiz = await quizManagerRepo.CreateQuiz(quiz);
                return Ok(newQuiz);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update quiz by quizId
        [HttpPut("/updateQuizByQuizId")]
        public async Task<ActionResult<IEnumerable<QuizUpdateAdminDTO>>> UpdateQuizByQuizId(int quizId, QuizUpdateAdminDTO updatedQuiz)
        {
            try
            {
                var quiz = await quizManagerRepo.UpdateQuizByQuizId(quizId, updatedQuiz);
                return Ok(quiz);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete quiz by quizId
        [HttpDelete("/deleteQuizByQuizId")]
        public async Task<ActionResult> DeleteQuizByQuizId(int quizId)
        {
            try
            {
                var deletedQuiz = await quizManagerRepo.DeleteQuizByQuizId(quizId);
                return NoContent(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
