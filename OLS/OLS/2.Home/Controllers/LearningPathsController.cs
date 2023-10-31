using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.Models;
using OLS.DTO;
using OLS.Helpers;
using OLS.Repositories;
using OLS.Repositories.Interface;

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

        // get all learningPaths
        [HttpGet("/getAllLearningPaths_LearningPaths")]
        public ActionResult<IEnumerable<LearningPathDTO>> GetAllLearningPaths()
        {
            var learningPaths = learningPathRepo.GetAllLearningPaths();
            return Ok(learningPaths);
        }

    }
}
