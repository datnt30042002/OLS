using OLS.DTO.Questions.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface IQuestionManagerRepository
    {
        Task<List<QuestionReadAdminDTO>> GetAllQuestionsByQuizId(int quizId);
        Task<QuestionCreateAdminDTO> CreateQuestion(QuestionCreateAdminDTO question);
        Task<QuestionUpdateAdminDTO> UpdateQueStionByQuestionId(int questionId, QuestionUpdateAdminDTO updatedQuestion);
        Task<bool> DeleteQuestionByQuestionId(int questionId);
    }
}
