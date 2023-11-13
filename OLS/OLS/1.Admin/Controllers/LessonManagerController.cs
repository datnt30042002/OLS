using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Chapters.Admin;
using OLS.DTO.Lessons.Admin;
using OLS.Repositories.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonManagerController : ControllerBase
    {
        private readonly ILessonManagerRepository lessonManagerRepo;
        public LessonManagerController(ILessonManagerRepository lessonManagerRepo)
        {
            this.lessonManagerRepo = lessonManagerRepo;
        }

        // Get all lessons
        [HttpGet("/getAllLessons")]
        public async Task<ActionResult<LessonReadAdminDTO>> GetAllLessons()
        {
            try
            {
                var lessons = await lessonManagerRepo.GetAllLessons();
                return Ok(lessons);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get all lessons by ChapterId

        // Get lesson by LessonId
        [HttpGet("/getLessonByLessonId")]
        public async Task<ActionResult<LessonReadAdminDTO>> GetLessonByLessonId(int lessonId)
        {
            try
            {
                var lesson = await lessonManagerRepo.GetLessonByLessonId(lessonId);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new lesson
        [HttpPost("/createNewLesson")]
        public async Task<ActionResult<LessonCreateAdminDTO>> CreateNewLesson(LessonCreateAdminDTO lesson)
        {
            try
            {
                var newLesson = await lessonManagerRepo.CreateNewLesson(lesson);
                return Ok(newLesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update lesson by LessonId
        [HttpPut("/updateLessonByLessonId")]
        public async Task<ActionResult<LessonUpdateAdminDTO>> UpdateLessonByLessonId(int lessonId, LessonUpdateAdminDTO lesson)
        {
            try
            {
                var updatedLesson = await lessonManagerRepo.UpdateLessonByLessonId(lessonId, lesson);
                return Ok(updatedLesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // // Delete lesson by LessonId
        [HttpDelete("/deleteLessonByLessonId")]
        public async Task<ActionResult> DeleteLessonByLessonId(int lessonId)
        {
            try
            {
                var deletedLesson = await lessonManagerRepo.DeleteLessonByLessonId(lessonId);
                return NoContent(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
