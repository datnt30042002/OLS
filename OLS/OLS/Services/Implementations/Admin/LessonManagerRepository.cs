using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Lessons.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;

namespace OLS.Services.Implementations.Admin
{
    public class LessonManagerRepository : ILessonManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public LessonManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all lessons
        public async Task<List<LessonReadAdminDTO>> GetAllLessons()
        {
            try
            {
                var lessons = await db.Lessons
                    .Include(lessons => lessons.ChapterChapter)
                    .ToListAsync();
                var lessonReadAdminDTO = mapper.Map<List<LessonReadAdminDTO>>(lessons);

                return lessonReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get all lessons by ChapterId

        // Get lesson by LessonId
        public async Task<LessonReadAdminDTO> GetLessonByLessonId(int lessonId)
        {
            try
            {
                var lesson = await db.Lessons
                    .Where(lesson => lesson.LessonId == lessonId)
                    .Include(lesson => lesson.ChapterChapter)
                    .FirstOrDefaultAsync();
                var lessonReadAdminDTO = mapper.Map<LessonReadAdminDTO>(lesson);

                return lessonReadAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new lesson
        public async Task<LessonCreateAdminDTO> CreateNewLesson(LessonCreateAdminDTO lesson)
        {
            try
            {
                var newLesson = mapper.Map<Lesson>(lesson);
                var createLesson = await db.Lessons.AddAsync(newLesson);
                await db.SaveChangesAsync();
                var lessonCreateAdminDTO = mapper.Map<LessonCreateAdminDTO>(newLesson);

                return lessonCreateAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update lesson by LessonId
        public async Task<LessonUpdateAdminDTO> UpdateLessonByLessonId(int lessonId, LessonUpdateAdminDTO updatedLesson)
        {
            try
            {
                // Check chapter exist 
                var existingLesson = await db.Lessons
                    .Where(lesson => lesson.LessonId == lessonId)
                    .FirstOrDefaultAsync();

                // Notification not exist
                if (existingLesson == null)
                {
                    Console.WriteLine("Not found lesson");
                }

                // Mapper
                mapper.Map(updatedLesson, existingLesson);
                db.SaveChangesAsync();
                var lessonUpdateAdminDTO = mapper.Map<LessonUpdateAdminDTO>(existingLesson);

                return lessonUpdateAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete lesson by LessonId
        public async Task<bool> DeleteLessonByLessonId(int lessonId)
        {
            try
            {
                // Check lesson exist
                var existingLesson = await db.Lessons
                    .Where(lesson => lesson.LessonId == lessonId)
                    .FirstOrDefaultAsync();

                // Notificate not exist
                if (existingLesson == null)
                {
                    Console.WriteLine("Not found lesson");
                }

                db.Lessons.Remove(existingLesson);
                db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // <Later function>
        // Search
        // Sort 
        // Filter 
        // Paging
        // <Later function>
    }
}
