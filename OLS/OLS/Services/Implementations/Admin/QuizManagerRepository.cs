using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Courses.Admin;
using OLS.DTO.Quizzes.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Admin
{
    public class QuizManagerRepository : IQuizManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public QuizManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all quizzes by chapter id 
        public async Task<List<QuizReadAdminDTO>> GetAllQuizzesByChapterId(int chapterId)
        {
            try
            {
                var quizzes = await db.Quizzes
                    .Where(quiz => quiz.ChapterChapterId == chapterId)
                    .ToListAsync();
                var quizReadAdminDTO = mapper.Map<List<QuizReadAdminDTO>>(quizzes);

                return quizReadAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new quiz
        public async Task<QuizCreateAdminDTO> CreateQuiz(QuizCreateAdminDTO quiz)
        {
            try
            {
                var newQuiz = mapper.Map<Quiz>(quiz);
                var createNewQuiz = await db.Quizzes.AddAsync(newQuiz);
                await db.SaveChangesAsync();
                var quizCreateAdminDTO = mapper.Map<QuizCreateAdminDTO>(newQuiz);

                return quizCreateAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update quiz by quizId
        public async Task<QuizUpdateAdminDTO> UpdateQuizByQuizId(int quizId, QuizUpdateAdminDTO updatedQuiz)
        {
            try
            {
                var existingQuiz = await db.Quizzes
                    .Where(quiz => quiz.QuizId == quizId)
                    .FirstOrDefaultAsync();

                if (existingQuiz == null)
                {
                    Console.WriteLine("Not found quiz");
                }

                mapper.Map(updatedQuiz, existingQuiz);
                db.SaveChangesAsync();
                var quizUpdateAdminDTO = mapper.Map<QuizUpdateAdminDTO>(existingQuiz);

                return quizUpdateAdminDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete quiz by quizId
        public async Task<bool> DeleteQuizByQuizId(int quizId)
        {
            try
            {
                var existingQuiz = await db.Quizzes
                    .Where(quiz => quiz.QuizId == quizId)
                    .FirstOrDefaultAsync();

                if (existingQuiz == null)
                {
                    Console.WriteLine("Not found quiz");
                }

                db.Quizzes.Remove(existingQuiz);
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
