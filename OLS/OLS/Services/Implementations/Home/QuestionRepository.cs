using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Questions.Admin;
using OLS.DTO.Questions.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public QuestionRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all questions by quizId 
        public async Task<List<QuestionReadHomeDTO>> GetAllQuestionsByQuizId(int quizId)
        {
            try
            {
                var questions = await db.Questions
                    .Where(question => question.QuizQuizId == quizId)
                    .ToListAsync();
                var questionReadHomeDTO = mapper.Map<List<QuestionReadHomeDTO>>(questions);

                return questionReadHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
