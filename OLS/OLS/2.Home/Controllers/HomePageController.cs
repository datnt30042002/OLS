using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Blogs.Home;
using OLS.DTO.Courses;
using OLS.DTO.LearningPaths.Home;
using OLS.Repositories.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly ICourseRepository courseEepo;
        private readonly ILearningPathRepository learningPathRepo;
        private readonly IBlogRepository blogRepo;
        public HomePageController(ICourseRepository courseEepo, ILearningPathRepository learningPathRepo, IBlogRepository blogRepo)
        {
            this.courseEepo = courseEepo;
            this.learningPathRepo = learningPathRepo;
            this.blogRepo = blogRepo;
        }

        // Get 10 courses with fee != 0
        [HttpGet("/get10CoursesWithFee")]
        public async Task<ActionResult<IEnumerable<CourseReadHomeDTO>>> Get10CoursesWithFee()
        {
            var courses = await courseEepo.Get10CoursesWithFee();
            return Ok(courses);
        }

        // Get 15 courses with fee == 0
        [HttpGet("/get15CoursesFree")]
        public async Task<ActionResult<IEnumerable<CourseReadHomeDTO>>> Get15CoursesFree()
        {
            var courses = await courseEepo.Get15CoursesFree();
            return Ok(courses);
        }

        // Get all learning paths
        [HttpGet("/getAllLearningPaths_HomePage")]
        public async Task<ActionResult<IEnumerable<LearningPathReadHomeDTO>>> GetAllLearningPaths()
        {
            var learningPaths = await learningPathRepo.GetAllLearningPaths();
            return Ok(learningPaths);
        }

        // Get 10 newest blogs
        [HttpGet("/get10NewestBlogs")]
        public async Task<ActionResult<IEnumerable<BlogReadHomeDTO>>> Get10NewestBlogs()
        {
            var blogs = await blogRepo.Get10NewestBlogs();
            return Ok(blogs);
        }

        // Search courses by course name
        [HttpGet("/searchCoursesByCourseName")]
        public async Task<ActionResult<IEnumerable<CourseReadHomeDTO>>> SearchCoursesByCourseName([FromQuery] string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest();
            }

            var courses = await courseEepo.SearchCoursesByCourseName(keyword);
            return Ok(courses);
        }

        // Seach blogs by blog title
        [HttpGet("/searchBlogsByBlogTitle")]
        public async Task<ActionResult<IEnumerable<BlogReadHomeDTO>>> SearchBlogsByBlogTitle([FromQuery] string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
            {
                return BadRequest();
            }

            var blogs = await blogRepo.SearchBlogsByBlogTitle(keyword);
            return Ok(blogs);
        }

    }
}
