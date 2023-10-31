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
    public class HomePageController : ControllerBase
    {
        private readonly ICourseRepository courseEepo;
        private readonly ICategoryRepository learningPathRepo;
        private readonly IBlogRepository blogRepo;
        public HomePageController(ICourseRepository courseEepo, ICategoryRepository learningPathRepo, IBlogRepository blogRepo)
        {
            this.courseEepo = courseEepo;
            this.learningPathRepo = learningPathRepo;
            this.blogRepo = blogRepo;
        }

        // get 10 courses with fee != 0
        [HttpGet("/Get10CoursesWithFee")]
        public ActionResult<IEnumerable<CourseDTO>> Get10CoursesWithFee()
        {
            var courses = courseEepo.Get10CoursesWithFee();
            return Ok(courses);
        }

        // get 10 courses with fee == 0
        [HttpGet("/Get15CoursesFree")]
        public ActionResult<IEnumerable<CourseDTO>> Get15CoursesFree()
        {
            var courses = courseEepo.Get15CoursesFree();
            return Ok(courses);
        }

        // get all learning paths
        [HttpGet("/GetAllLearningPaths")]
        public ActionResult<IEnumerable<LearningPathDTO>> GetAllLearningPaths()
        {
            var learningPaths = learningPathRepo.GetAllLearningPaths();
            return Ok(learningPaths);
        }

        // get 10 newest blogs
        [HttpGet("/Get10NewestBlogs")]
        public ActionResult<IEnumerable<BlogDTO>> Get10NewestBlogs()
        {
            var blogs = blogRepo.Get10NewestBlogs();
            return Ok(blogs);
        }

    }
}
