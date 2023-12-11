using Microsoft.AspNetCore.Mvc;
using OLS.DTO.LearningPaths.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningPathsController : ControllerBase
    {
        private readonly ILearningPathRepository learningPathRepo;
        public LearningPathsController(ILearningPathRepository learningPathRepo)
        {
            this.learningPathRepo = learningPathRepo;
        }

        // Get all learningPaths
        [HttpGet("/getAllLearningPaths_LearningPaths")]
        public async Task<ActionResult<LearningPathReadHomeDTO>> GetAllLearningPaths()
        {
            var learningPaths = await learningPathRepo.GetAllLearningPaths();
            return Ok(learningPaths);
        }

    }
}
