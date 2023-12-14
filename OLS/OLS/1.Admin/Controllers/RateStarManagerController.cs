using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.RateStar.Admin;
using OLS.Services.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateStarManagerController : ControllerBase
    {
        private readonly IRateStarManagerRepository rateStarRepo;
        public RateStarManagerController(IRateStarManagerRepository rateStarRepo)
        {
            this.rateStarRepo = rateStarRepo;
        }

        // Get all rate stars 
        [HttpGet("/getAllRateStars")]
        public async Task<ActionResult<IEnumerable<RateStarReadAdminDTO>>> GetAllRateStars()
        {
            try
            {
                var rateStars = await rateStarRepo.GetAllRateStars();
                return Ok(rateStars);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/filterAllRateStarsByCourseId")]
        public async Task<ActionResult<IEnumerable<RateStarReadAdminDTO>>> FilterAllRateStarsByCourseId(int courseId)
        {
            try
            {
                var rateStars = await rateStarRepo.FilterAllRateStarsByCourseId(courseId);
                return Ok(rateStars);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
