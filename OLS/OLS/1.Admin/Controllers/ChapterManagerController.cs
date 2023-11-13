using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Chapters.Admin;
using OLS.Repositories.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterManagerController : ControllerBase
    {
        private readonly IChapterManagerRepository chapterManagerRepo;
        public ChapterManagerController(IChapterManagerRepository chapterManagerRepo)
        {
            this.chapterManagerRepo = chapterManagerRepo;
        }

        // Get all chapters
        [HttpGet("/getAllChapters")]
        public async Task<ActionResult<ChapterReadAdminDTO>> GetAllChapters()
        {
            try
            {
                var chaptes = await chapterManagerRepo.GetAllChapters();
                return Ok(chaptes);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get chapter by ChpaterId
        [HttpGet("/getChapterByChapterId")]
        public async Task<ActionResult<ChapterReadAdminDTO>> GetChapterByChapterId(int chapterId)
        {
            try
            {
                var chapter = await chapterManagerRepo.GetChapterByChapterId(chapterId);
                return Ok(chapter);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new chapter
        [HttpPost("/createNewChapter")]
        public async Task<ActionResult<ChapterCreateAdminDTO>> CreateNewChapter(ChapterCreateAdminDTO chapter)
        {
            try
            {
                var newChapter = await chapterManagerRepo.CreateNewChapter(chapter);
                return Ok(newChapter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update chapter by ChpaterId
        //public async Task<ChapterUpdateAdminDTO> UpdateChapterByChapterId(int chapterId, ChapterUpdateAdminDTO updatedChapter)
        [HttpPut("/updateChapterByChapterId")]
        public async Task<ActionResult<ChapterUpdateAdminDTO>> UpdateChapterByChapterId(int chapterId, ChapterUpdateAdminDTO chapter)
        {
            try
            {
                var updatedChpater = await chapterManagerRepo.UpdateChapterByChapterId(chapterId, chapter);
                return Ok(updatedChpater);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete chapter by ChapterId
        //Task<bool> DeleteChapterByChapterId(int chapterId)
        [HttpDelete("/deleteChapterByChapterId")]
        public async Task<ActionResult> DeleteChapterByChapterId(int chapterId)
        {
            try
            {
                var deletedChapter = await chapterManagerRepo.DeleteChapterByChapterId(chapterId);
                return NoContent();
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
