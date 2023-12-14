using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Answers.Home;
using OLS.Models;
using OLS.Services.Interface.Admin;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public AnswerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all answers by questionId
        public async Task<List<AnswerReadHomeDTO>> GetAllAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = await db.Answers
                    .Where(answer => answer.QuestionQuestionId == questionId)
                    .ToListAsync();
                var answerReadHomeDTO = mapper.Map<List<AnswerReadHomeDTO>>(answers);

                return answerReadHomeDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Select true answer 
        public async Task<bool> SelectTrueAnswer(int answerId, int questionId)
        {
            try
            {
                var trueAnswer = await db.Answers
                    .Where(answer => answer.AnswerId == answerId)
                    .Where(answer => answer.QuestionQuestion.QuestionId == questionId)
                    .Where(answer => answer.IsTrue == 1)
                    .FirstOrDefaultAsync();

                if(trueAnswer == null)
                {
                    Console.WriteLine("Not found answer");
                    return false;
                }

                return true;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
