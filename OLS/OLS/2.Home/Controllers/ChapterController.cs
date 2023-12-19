using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Chapters.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterRepository chapterRepo;
        public ChapterController(IChapterRepository chapterRepo)
        {
            this.chapterRepo = chapterRepo;
        }

        // Get all chapters by course id
        [HttpGet("/getAllChaptersByCourseId/{courseId}")]
        public async Task<ActionResult<IEnumerable<ChapterReadHomeDTO>>> GetAllChaptersByCourseId(int courseId)
        {
            try
            {
                var chapters = await chapterRepo.GetAllChaptersByCourseId(courseId);
                return Ok(chapters); 
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
