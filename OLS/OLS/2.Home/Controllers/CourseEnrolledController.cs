using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.CourseEnrolled.Home;
using OLS.DTO.Courses;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrolledController : ControllerBase
    {
        private readonly ICourseEnrolledRepository registerRepo;
        public CourseEnrolledController(ICourseEnrolledRepository registerRepo)
        {
            this.registerRepo = registerRepo;
        }

        // Check course is enrolled or not 
        [HttpGet("/IsCourseEnrolled/{courseId}")]
        public async Task<ActionResult<bool?>> IsCourseEnrolled(int courseId)
        {
            try
            {
                var isEnrolled = await registerRepo.IsCourseEnrolled(courseId);

                if (isEnrolled == null)
                {
                    return NotFound($"Course with ID {courseId} not found");
                }

                return Ok(isEnrolled);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        // Register free course
        [HttpPost("/registerFreeCourse")] 
        public async Task<ActionResult<IEnumerable<CourseEnrolledRegisterHomeDTO>>>  RegisterFreeCourse(CourseEnrolledRegisterHomeDTO course)
        {
            try
            {
                var registerNewCourse = await registerRepo.RegisterFreeCourse(course);
                return Ok(registerNewCourse);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get all courses enrolled by user id 
        [HttpGet("/getAllCoursesEnrolledByUserId")]
        public async Task<ActionResult<IEnumerable<CourseReadHomeDTO>>> GetAllCoursesEnrolledByUserId(int userId)
        {
            try
            {
                var coursesEnrolled = await registerRepo.GetAllCoursesEnrolledByUserId(userId); 
                return Ok(coursesEnrolled);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
