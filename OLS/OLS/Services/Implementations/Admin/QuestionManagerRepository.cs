using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Questions.Admin;
using OLS.DTO.Quizzes.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;

namespace OLS.Services.Implementations.Admin
{
    public class QuestionManagerRepository : IQuestionManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public QuestionManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all questions by quizId
        public async Task<List<QuestionReadAdminDTO>> GetAllQuestionsByQuizId(int quizId)
        {
            try
            {
                var questions = await db.Questions
                    .Where(question => question.QuizQuizId == quizId)
                    .ToListAsync();
                var questionReadAdminDTO = mapper.Map<List<QuestionReadAdminDTO>>(questions);

                return questionReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new question 
        public async Task<QuestionCreateAdminDTO> CreateQuestion(QuestionCreateAdminDTO question)
        {
            try
            {
                var newQuestion = mapper.Map<Question>(question);
                var createNewQuestion = await db.Questions.AddAsync(newQuestion);
                await db.SaveChangesAsync();
                var questionCreateAdminDTO = mapper.Map<QuestionCreateAdminDTO>(newQuestion);

                return questionCreateAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update question by questionId
        public async Task<QuestionUpdateAdminDTO> UpdateQueStionByQuestionId(int questionId, QuestionUpdateAdminDTO updatedQuestion)
        {
            try
            {
                var existingQuestion = await db.Questions
                    .Where(question => question.QuestionId == questionId)
                    .FirstOrDefaultAsync();

                if (existingQuestion == null)
                {
                    Console.WriteLine("Not found question");
                }

                mapper.Map(updatedQuestion, existingQuestion);
                db.SaveChangesAsync();
                var questionUpdateAdminDTO = mapper.Map<QuestionUpdateAdminDTO>(existingQuestion);

                return questionUpdateAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete question by questionId
        public async Task<bool> DeleteQuestionByQuestionId(int questionId)
        {
            try
            {
                var existingQuestion = await db.Questions
                    .Where(question => question.QuestionId == questionId)
                    .FirstOrDefaultAsync();

                if (existingQuestion == null)
                {
                    Console.WriteLine("Not found question");
                }

                db.Questions.Remove(existingQuestion);
                db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
