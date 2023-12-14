using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Courses.Admin;
using OLS.DTO.Notes.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class NoteRepository : INoteRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public NoteRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all notes by user id in chapter id
        public async Task<List<NoteReadHomeDTO>> GetAllNotesByUserIdInChapterId(int userId, int chapterId)
        {
            try
            {
                var notes = await db.Notes
                    .Where(note => note.UserUserId == userId)
                    .Where(note => note.ChapterChapterId == chapterId)
                    .ToListAsync();
                var noteReadHomeDTO = mapper.Map<List<NoteReadHomeDTO>>(notes);

                return noteReadHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new note 
        public async Task<NoteCreateHomeDTO> CreateNote(NoteCreateHomeDTO note)
        {
            try
            {
                var newNote = mapper.Map<Note>(note);
                var createNote = await db.Notes.AddAsync(newNote);
                await db.SaveChangesAsync();
                var noteCreateHomeDTO = mapper.Map<NoteCreateHomeDTO>(newNote);

                return noteCreateHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update note by noteId
        public async Task<NoteUpdateHomeDTO> UpdateNoteByNoteId(int noteId, NoteUpdateHomeDTO updatedNote)
        {
            try
            {
                var existingNote = await db.Notes
                    .Where(note => note.NoteId == noteId)
                    .FirstOrDefaultAsync();
                
                if (existingNote == null)
                {
                    Console.WriteLine("Not found note");
                }

                mapper.Map(updatedNote, existingNote);
                db.SaveChangesAsync();
                var noteUpdateHomeDTO = mapper.Map<NoteUpdateHomeDTO>(existingNote);

                return noteUpdateHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete note by noteId
        public async Task<bool> DeleteNoteByNoteId(int noteId)
        {
            try
            {
                var existingNote = await db.Notes
                    .Where(note => note.NoteId == noteId)
                    .FirstOrDefaultAsync();

                if (existingNote == null)
                {
                    Console.WriteLine("Not found note");
                }

                db.Notes.Remove(existingNote);
                db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
