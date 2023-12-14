using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Lessons.Home;
using OLS.DTO.Notes.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository noteRepo;
        public NoteController(INoteRepository noteRepo)
        {
            this.noteRepo = noteRepo;
        }

        // Get all notes by user id in chapter id
        [HttpGet("/getAllNotesByUserIdInChapterId")]
        public async Task<ActionResult<IEnumerable<NoteReadHomeDTO>>> GetAllNotesByUserIdInChapterId(int userId, int chapterId)
        {
            try
            {
                var notes = await noteRepo.GetAllNotesByUserIdInChapterId(userId, chapterId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new note 
        [HttpPost("/createNote")]
        public async Task<ActionResult<IEnumerable<NoteCreateHomeDTO>>> CreateNote(NoteCreateHomeDTO note)
        {
            try
            {
                var newNote = await noteRepo.CreateNote(note);
                return Ok(newNote);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update note by noteId 
        [HttpPut("/updateNoteByNoteId")]
        public async Task<ActionResult<IEnumerable<NoteUpdateHomeDTO>>> UpdateNoteByNoteId(int noteId, NoteUpdateHomeDTO updatedNote)
        {
            try
            {
                var newUpdatedNote = await noteRepo.UpdateNoteByNoteId(noteId, updatedNote);
                return Ok(newUpdatedNote);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete note by noteId
        [HttpDelete("/deleteNoteByNoteId")]
        public async Task<ActionResult> DeleteNoteByNoteId(int noteId)
        {
            try
            {
                var deletedNote = await noteRepo.DeleteNoteByNoteId(noteId);
                return NoContent(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
