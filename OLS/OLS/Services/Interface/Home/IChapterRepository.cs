using OLS.DTO.Chapters.Home;

namespace OLS.Services.Interface.Home
{
    public interface IChapterRepository 
    {
        Task<List<ChapterReadHomeDTO>> GetAllChaptersByCourseId(int courseId);
    }
}
