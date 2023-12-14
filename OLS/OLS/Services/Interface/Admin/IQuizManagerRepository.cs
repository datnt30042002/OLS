using OLS.DTO.Quizzes.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface IQuizManagerRepository
    {
        Task<List<QuizReadAdminDTO>> GetAllQuizzesByChapterId(int chapterId);
        Task<QuizCreateAdminDTO> CreateQuiz(QuizCreateAdminDTO quiz);
        Task<QuizUpdateAdminDTO> UpdateQuizByQuizId(int quizId, QuizUpdateAdminDTO updatedQuiz);
        Task<bool> DeleteQuizByQuizId(int quizId);
    }
}
