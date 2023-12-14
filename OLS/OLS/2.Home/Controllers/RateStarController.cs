using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.RateStar.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateStarController : ControllerBase
    {
        private readonly IRateStarRepository ratestarRepo;
        public RateStarController(IRateStarRepository ratestarRepo)
        {
            this.ratestarRepo = ratestarRepo;
        }

        // Get all rate stars by course id 
        [HttpGet("/getAllRateStarsByCourseId")]
        public async Task<ActionResult<IEnumerable<RateStarReadHomeDTO>>> GetAllRateStarsByCourseId(int courseId)
        {
            try
            {
                var rateStars = await ratestarRepo.GetAllRateStarsByCourseId(courseId);
                return Ok(rateStars);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new rate star  
        [HttpPost("/createRateStar")]
        public async Task<ActionResult<IEnumerable<RateStarCreateHomeDTO>>> CreateRateStar(RateStarCreateHomeDTO rateStar)
        {
            try
            {
                var newRateStar = await ratestarRepo.CreateRateStar(rateStar);
                return Ok(newRateStar);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update rate star by rate star id 
        [HttpPut("/updateRateStarByRateStarId")]
        public async Task<ActionResult<IEnumerable<RateStarUpdateHomeDTO>>> UpdateRateStarByRateStarId(int rateStarId, RateStarUpdateHomeDTO updatedRateStar)
        {
            try
            {
                var existingRateStar = await ratestarRepo.UpdateRateStarByRateStarId(rateStarId, updatedRateStar);
                return Ok(existingRateStar);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete rate star by rate star id 
        [HttpDelete("/deleteRateStarByRateStarId")]
        public async Task<ActionResult> DeleteRateStarByRateStarId(int rateStarId)
        {
            try
            {
                var deletedRatestar = await ratestarRepo.DeleteRateStarByRateStarId(rateStarId);
                return NoContent();
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
