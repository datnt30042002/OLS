using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Answers.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;

namespace OLS.Services.Implementations.Admin
{
    public class AnswerManagerRepository : IAnswerManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public AnswerManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all answers by questionId
        public async Task<List<AnswerReadAdminDTO>> GetAllAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = await db.Answers
                    .Where(answer => answer.QuestionQuestionId ==  questionId)
                    .ToListAsync();
                var answerReadAdminDTO = mapper.Map<List<AnswerReadAdminDTO>>(answers);

                return answerReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new answer 
        public async Task<AnswerCreateAdminDTO> CreateAnswer(AnswerCreateAdminDTO answer)
        {
            try
            {
                var newAnswer = mapper.Map<Answer>(answer);
                var createAnswer = await db.Answers.AddAsync(newAnswer);
                await db.SaveChangesAsync();
                var answerCreateAdminDTO = mapper.Map<AnswerCreateAdminDTO>(newAnswer);

                return answerCreateAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update answer by answerId
        public async Task<AnswerUpdateAdminDTO> UpdateAnswerByAnswerId(int answerId, AnswerUpdateAdminDTO updatedAnswer)
        {
            try
            {
                var existingAnswer = await db.Answers
                    .Where(answer => answer.AnswerId == answerId)
                    .FirstOrDefaultAsync();

                if (existingAnswer == null)
                {
                    Console.WriteLine("Not found answer");
                }

                mapper.Map(updatedAnswer, existingAnswer);
                db.SaveChangesAsync();
                var answerUpdateAdminDTO = mapper.Map<AnswerUpdateAdminDTO>(existingAnswer);

                return answerUpdateAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete answer by answerId
        public async Task<bool> DeleteAnswerByAnswerId(int answerId)
        {
            try
            {
                var existingAnswer = await db.Answers
                    .Where(answer => answer.AnswerId == answerId)
                    .FirstOrDefaultAsync();

                if (existingAnswer == null)
                {
                    Console.WriteLine("Not found answer");
                }

                db.Answers.Remove(existingAnswer);
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
