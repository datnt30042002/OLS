using OLS.DTO.Chapters.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface IChapterManagerRepository
    {
        // Chapter manager
        //Task<List<ChapterReadAdminDTO>> GetAllChaptersByCourseId(int courseId);
        Task<List<ChapterReadAdminDTO>> GetAllChapters();
        Task<ChapterReadAdminDTO> GetChapterByChapterId(int chapterId);
        Task<ChapterCreateAdminDTO> CreateNewChapter(ChapterCreateAdminDTO chapter);
        Task<ChapterUpdateAdminDTO> UpdateChapterByChapterId(int chapterId, ChapterUpdateAdminDTO updatedChapter);
        Task<bool> DeleteChapterByChapterId(int chapterId);
    }
}
