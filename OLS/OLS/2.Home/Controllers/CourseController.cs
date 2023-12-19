using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Courses;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepo;
        public CourseController(ICourseRepository courseRepo)
        {
            this.courseRepo = courseRepo;
        }

        // Get course by course id 
        [HttpGet("/getCourseByCourseId_Home/{courseId}")]
        public async Task<ActionResult<IEnumerable<CourseReadHomeDTO>>> GetCourseByCourseId(int courseId)
        {
            try
            {
                var course = await courseRepo.GetCourseByCourseId(courseId);
                return Ok(course);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
