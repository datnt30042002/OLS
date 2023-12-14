using OLS.DTO.Feedbacks.Home;

namespace OLS.Services.Interface.Home
{
    public interface IFeedbackRepository
    {
        Task<List<FeedbackReadHomeDTO>> GetAllFeedbacksByCourseId(int courseId);
        Task<List<FeedbackReadHomeDTO>> GetAllFeedbacksByUserIdInCourseId(int userId, int courseId);
        Task<FeedbackCreateHomeDTO> CreateFeedback(FeedbackCreateHomeDTO feedback);
        Task<FeedbackUpdateHomeDTO> UpdateFeedbackByFeedbackId(int feedbackId, FeedbackUpdateHomeDTO updatedFeedback);
        Task<bool> DeleteFeedbackByFeedbackId(int feedbackId);
    }
}
