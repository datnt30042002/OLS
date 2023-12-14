using OLS.DTO.Answers.Home;

namespace OLS.Services.Interface.Home
{
    public interface IAnswerRepository
    {
        Task<List<AnswerReadHomeDTO>> GetAllAnswersByQuestionId(int questionId);
        Task<bool> SelectTrueAnswer(int answerId, int questionId);
    }
}
