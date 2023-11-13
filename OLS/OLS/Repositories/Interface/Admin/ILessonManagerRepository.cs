using OLS.DTO.Lessons.Admin;

namespace OLS.Repositories.Interface.Admin
{
    public interface ILessonManagerRepository
    {
        // Lesson manager 
        Task<List<LessonReadAdminDTO>> GetAllLessons();
        Task<LessonReadAdminDTO> GetLessonByLessonId(int lessonId);
        Task<LessonCreateAdminDTO> CreateNewLesson(LessonCreateAdminDTO lesson);
        Task<LessonUpdateAdminDTO> UpdateLessonByLessonId(int lessonId, LessonUpdateAdminDTO updatedLesson);
        Task<bool> DeleteLessonByLessonId(int lessonId);
    }
}
