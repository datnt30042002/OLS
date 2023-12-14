using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Quizzes.Admin;
using OLS.DTO.Quizzes.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class QuizRepository : IQuizRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public QuizRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all quizzes by chapterId
        public async Task<List<QuizReadHomeDTO>> GetAllQuizzesByChapterId(int chapterId)
        {
            try
            {
                var quizzes = await db.Quizzes
                    .Where(quiz => quiz.ChapterChapterId == chapterId)
                    .ToListAsync();
                var quizReadHomeDTO = mapper.Map<List<QuizReadHomeDTO>>(quizzes);

                return quizReadHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
