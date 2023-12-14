using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Lessons.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository lessonRepo;
        public LessonController(ILessonRepository lessonRepo)
        {
            this.lessonRepo = lessonRepo;
        }

        // Get all lessons by chapter id 
        [HttpGet("/getAllLessonsByChapterId")]
        public async Task<ActionResult<IEnumerable<LessonReadHomeDTO>>> GetAllLessonsByChapterIdInCourseId(int chapterId, int courseId)
        {
            try
            {
                var lessons = await lessonRepo.GetAllLessonsByChapterIdInCourseId(chapterId, courseId);
                return Ok(lessons);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get lesson by Id
        [HttpGet("/getLessonById")]
        public async Task<ActionResult<LessonReadHomeDTO>> GetLessonById(int lessonId)
        {
            try
            {
                var lesson = await lessonRepo.GetLessonById(lessonId);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get next lesson
        [HttpGet("/getNextLesson")]
        public async Task<ActionResult<LessonReadHomeDTO>> GetNextLesson(int currentLessonId, int chapterId)
        {
            try
            {
                var nextLesson = await lessonRepo.GetNextLesson(currentLessonId, chapterId);
                return Ok(nextLesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get previous lesson
        [HttpGet("/getPreviousLesson")]
        public async Task<ActionResult<LessonReadHomeDTO>> GetPreviousLesson(int currentLessonId, int chapterId)
        {
            try
            {
                var previousLesson = await lessonRepo.GetPreviousLesson(currentLessonId, chapterId);
                return Ok(previousLesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
