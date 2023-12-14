using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Discusses.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussController : ControllerBase
    {
        private readonly IDiscussRepository discussRepo;
        public DiscussController(IDiscussRepository discussRepo)
        {
            this.discussRepo = discussRepo;
        }

        // Get discuss by lesson id 
        [HttpGet("/getDiscussByLessonId")]
        public async Task<ActionResult<IEnumerable<DiscussReadHomeDTO>>> GetDiscussByLessonId(int lessonId)
        {
            try
            {
                var discuss = await discussRepo.GetDiscussByLessonId(lessonId);
                return Ok(discuss);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// Get next discuss
        //[HttpGet("/getNextDiscuss")]
        //public async Task<ActionResult<DiscussReadHomeDTO>> GetNextDiscuss(int currentDiscussId, int lessonId)
        //{
        //    try
        //    {
        //        var nextDiscuss = await discussRepo.GetNextDiscuss(currentDiscussId, lessonId);

        //        if (nextDiscuss == null)
        //        {
        //            return NotFound($"Next discuss not found for Discuss ID {currentDiscussId} in Lesson ID {lessonId}.");
        //        }

        //        return Ok(nextDiscuss);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //// Get previous discuss
        //[HttpGet("/getPreviousDiscuss")]
        //public async Task<ActionResult<DiscussReadHomeDTO>> GetPreviousDiscuss(int currentDiscussId, int lessonId)
        //{
        //    try
        //    {
        //        var previousDiscuss = await discussRepo.GetPreviousDiscuss(currentDiscussId, lessonId);

        //        if (previousDiscuss == null)
        //        {
        //            return NotFound($"Previous discuss not found for Discuss ID {currentDiscussId} in Lesson ID {lessonId}.");
        //        }

        //        return Ok(previousDiscuss);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
