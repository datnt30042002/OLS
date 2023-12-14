using OLS.DTO.Quizzes.Home;

namespace OLS.Services.Interface.Home
{
    public interface IQuizRepository
    {
        Task<List<QuizReadHomeDTO>> GetAllQuizzesByChapterId(int chapterId);
    }
}
