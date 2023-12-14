using OLS.DTO.Questions.Home;

namespace OLS.Services.Interface.Home
{
    public interface IQuestionRepository
    {
        Task<List<QuestionReadHomeDTO>> GetAllQuestionsByQuizId(int quizId);
    }
}
