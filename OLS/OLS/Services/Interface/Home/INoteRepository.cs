using OLS.DTO.Notes.Home;

namespace OLS.Services.Interface.Home
{
    public interface INoteRepository
    {
        Task<List<NoteReadHomeDTO>> GetAllNotesByUserIdInChapterId(int userId, int chapterId);
        Task<NoteCreateHomeDTO> CreateNote(NoteCreateHomeDTO note);
        Task<NoteUpdateHomeDTO> UpdateNoteByNoteId(int noteId, NoteUpdateHomeDTO updatedNote);
        Task<bool> DeleteNoteByNoteId(int noteId);
    }
}
