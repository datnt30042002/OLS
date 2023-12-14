using OLS.DTO.Feedbacks.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface IFeedbackManagerRepository
    {
        Task<List<FeedbackReadAdminDTO>> GetAllFeedbacks();
        Task<List<FeedbackReadAdminDTO>> FilterAllFeedbacksByCourseId(int courseId);
    }
}
