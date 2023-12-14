using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Discusses.Home;
using OLS.DTO.Lessons.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class LessonRepository : ILessonRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;

        public LessonRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all lessons by chapter id 
        public async Task<List<LessonReadHomeDTO>> GetAllLessonsByChapterIdInCourseId(int chapterId, int courseId) 
        {
            try
            {
                var lessons = await db.Lessons
                    .Where(lesson => lesson.ChapterChapterId == chapterId)
                    .Where(lesson => lesson.ChapterChapter.CourseCourseId == courseId)
                    .ToListAsync();
                var lessonReadHomeDTO = mapper.Map<List<LessonReadHomeDTO>>(lessons);

                return lessonReadHomeDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Next lesson in chapter id 
        // Sau khi nhấn next, lesoson và discuss sẽ thay đổi 
        // Back 
        // Tương tự 
        public async Task<LessonReadHomeDTO> GetLessonById(int lessonId)
        {
            var lesson = await db.Lessons
                .FirstOrDefaultAsync(lesson => lesson.LessonId == lessonId);

            return mapper.Map<LessonReadHomeDTO>(lesson);
        }

        public async Task<LessonReadHomeDTO> GetNextLesson(int currentLessonId, int chapterId)
        {
            var lessonsInChapter = await db.Lessons
                .Where(lesson => lesson.ChapterChapterId == chapterId)
                .OrderBy(lesson => lesson.LessonId) // Ensure lessons are ordered by LessonId
                .ToListAsync();

            var currentLessonIndex = lessonsInChapter.FindIndex(lesson => lesson.LessonId == currentLessonId);

            if (currentLessonIndex < 0 || currentLessonIndex >= lessonsInChapter.Count - 1)
            {
                return null;
            }

            var nextLesson = lessonsInChapter[currentLessonIndex + 1];
            return mapper.Map<LessonReadHomeDTO>(nextLesson);
        }

        public async Task<LessonReadHomeDTO> GetPreviousLesson(int currentLessonId, int chapterId)
        {
            var lessonsInChapter = await db.Lessons
                .Where(lesson => lesson.ChapterChapterId == chapterId)
                .OrderBy(lesson => lesson.LessonId) // Ensure lessons are ordered by LessonId
                .ToListAsync();

            var currentLessonIndex = lessonsInChapter.FindIndex(lesson => lesson.LessonId == currentLessonId);

            if (currentLessonIndex <= 0)
            {
                return null;
            }

            var previousLesson = lessonsInChapter[currentLessonIndex - 1];
            return mapper.Map<LessonReadHomeDTO>(previousLesson);
        }
    }
}
