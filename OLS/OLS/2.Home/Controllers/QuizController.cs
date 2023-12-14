using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Quizzes.Admin;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository quizRepo;
        public QuizController(IQuizRepository quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        //Get all quizzes by chapterId
        [HttpGet("/getAllQuizzesByChapterId_Home")]
        public async Task<ActionResult<IEnumerable<QuizReadAdminDTO>>> GetAllQuizzesByChapterId(int chapterId)
        {
            try
            {
                var quizzes = await quizRepo.GetAllQuizzesByChapterId(chapterId);
                return Ok(quizzes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
