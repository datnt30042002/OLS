using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Courses.Admin;
using OLS.DTO.Users.Admin;
using OLS.Repositories.Implementations.Admin;
using OLS.Repositories.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseManagerController : ControllerBase
    {
        private readonly ICourseManagerRepository courseManagerRepo;
        public CourseManagerController(ICourseManagerRepository courseManagerRepo)
        {
            this.courseManagerRepo = courseManagerRepo;
        }

        // Get all courses
        [HttpGet("/getAllCourse")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> GetAllCourse()
        {
            try
            {
                var courses = await courseManagerRepo.GetAllCourse();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get course detail by CourseId
        [HttpGet("/getCourseByCourseId")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> GetCourseByCourseId(int courseId)
        {
            try
            {
                var course = await courseManagerRepo.GetCourseByCourseId(courseId);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new course
        [HttpPost("/createCourse")]
        public async Task<ActionResult<IEnumerable<CourseCreateAminDTO>>> CreateCourse(CourseCreateAminDTO course)
        {
            try
            {
                var newCourse = await courseManagerRepo.CreateCourse(course);
                return Ok(newCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update course by CourseId
        [HttpPut("/updateCourseByCourseId")]
        public async Task<ActionResult<IEnumerable<CourseUpdateAminDTO>>> UpdateCourseByCourseId(int courseId, CourseUpdateAminDTO course)
        {
            try
            {
                var updatedCourse = await courseManagerRepo.UpdateCourseByCourseId(courseId, course);
                return Ok(updatedCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete course by CourseId
        [HttpDelete("/deleteCourseByCourseId")]
        public async Task<ActionResult> DeleteCourseByCourseId(int courseId)
        {
            try
            {
                var deletedCourse = await courseManagerRepo.DeleteCourseByCourseId(courseId);
                return NoContent(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Search courses by CourseName
        // Task<List<CourseReadAminDTO>> SearchCoursesByCourseName(string keyword)
        [HttpGet("/searchCoursesByCourseName_Admin")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> SearchCoursesByCourseName(string keyword)
        {
            try
            {
                var searchedCourses = await courseManagerRepo.SearchCoursesByCourseName(keyword);
                return Ok(searchedCourses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Filter courses by LearningPath
        [HttpGet("/filterCoursesByLearningPath")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> FilterCoursesByLearningPath(string learningPath)
        {
            try
            {
                var filteredCourses = await courseManagerRepo.FilterCoursesByLearningPath(learningPath); 
                return Ok(filteredCourses);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
