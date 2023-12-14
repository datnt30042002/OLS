using OLS.DTO.Lessons.Home;
using System.Threading.Tasks;

namespace OLS.Services.Interface.Home
{
    public interface ILessonRepository
    {
        Task<List<LessonReadHomeDTO>> GetAllLessonsByChapterIdInCourseId(int chapterId, int courseId);
        Task<LessonReadHomeDTO> GetLessonById(int lessonId);
        Task<LessonReadHomeDTO> GetNextLesson(int currentLessonId, int chapterId);
        Task<LessonReadHomeDTO> GetPreviousLesson(int currentLessonId, int chapterId);

    }
}
