using OLS.DTO.Discusses.Home;

namespace OLS.Services.Interface.Home
{
    public interface IDiscussRepository
    {
        Task<DiscussReadHomeDTO> GetDiscussByLessonId(int lessonId);
        Task<DiscussReadHomeDTO> GetNextDiscuss(int currentDiscussId, int lessonId);
        Task<DiscussReadHomeDTO> GetPreviousDiscuss(int currentDiscussId, int lessonId);
    }
}
