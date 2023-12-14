using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Feedbacks.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository feedbackRepo;
        public FeedbackController(IFeedbackRepository feedbackRepo)
        {
            this.feedbackRepo = feedbackRepo;
        }

        // Get all feedback by course id 
        [HttpGet("/getAllFeedbacksByCourseId")]
        public async Task<ActionResult<IEnumerable<FeedbackReadHomeDTO>>> GetAllFeedbacksByCourseId(int courseId)
        {
            try
            {
                var feedbacks = await feedbackRepo.GetAllFeedbacksByCourseId(courseId);
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get all feedbacks by user id in course id
        [HttpGet("/getAllFeedbacksByUserIdInCourseId")]
        public async Task<ActionResult<IEnumerable<FeedbackReadHomeDTO>>> GetAllFeedbacksByUserIdInCourseId(int userId, int courseId)
        {
            try
            {
                var feedbacks = await feedbackRepo.GetAllFeedbacksByUserIdInCourseId(userId, courseId);
                return Ok(feedbacks);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new feedback
        [HttpPost("/createFeedback")]
        public async Task<ActionResult<IEnumerable<FeedbackCreateHomeDTO>>> CreateFeedback(FeedbackCreateHomeDTO feedback)
        {
            try
            {
                var newFeedback = await feedbackRepo.CreateFeedback(feedback);
                return Ok(newFeedback);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update feedback by feedbackId
        [HttpPut("/updateFeedbackByFeedbackId")]
        public async Task<ActionResult<IEnumerable<FeedbackUpdateHomeDTO>>> UpdateFeedbackByFeedbackId(int feedbackId, FeedbackUpdateHomeDTO updatedFeedback)
        {
            try
            {
                var existingFeedback = await feedbackRepo.UpdateFeedbackByFeedbackId(feedbackId, updatedFeedback);
                return Ok(existingFeedback);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // Delete feedback by feedbackId
        [HttpDelete("/deleteFeedbackByFeedbackId")]
        public async Task<ActionResult> DeleteFeedbackByFeedbackId(int feedbackId)
        {
            try
            {
                var deletedFeedback = await feedbackRepo.DeleteFeedbackByFeedbackId(feedbackId);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
