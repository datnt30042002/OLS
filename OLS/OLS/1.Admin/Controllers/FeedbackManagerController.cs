using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Feedbacks.Admin;
using OLS.Services.Interface.Admin;
using OLS.Services.Interface.Home;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackManagerController : ControllerBase
    {
        private readonly IFeedbackManagerRepository feedbackManagerRepo;
        public FeedbackManagerController(IFeedbackManagerRepository feedbackManagerRepo)
        {
            this.feedbackManagerRepo = feedbackManagerRepo;
        }

        // Get all feedbacks 
        [HttpGet("/getAllFeedbacks")]
        public async Task<ActionResult<IEnumerable<FeedbackReadAdminDTO>>> GetAllFeedbacks()
        {
            try
            {
                var feedbacks = await feedbackManagerRepo.GetAllFeedbacks();
                return Ok(feedbacks);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Filter all feedbacks by course id
        [HttpGet("/filterAllFeedbacksByCourseId")]
        public async Task<ActionResult<IEnumerable<FeedbackReadAdminDTO>>> FilterAllFeedbacksByCourseId(int courseId)
        {
            try
            {
                var feedbacks = await feedbackManagerRepo.FilterAllFeedbacksByCourseId(courseId);
                return Ok(feedbacks);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
