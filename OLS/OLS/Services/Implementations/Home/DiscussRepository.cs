using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Discusses.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class DiscussRepository : IDiscussRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public DiscussRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get discuss by lesson id
        public async Task<DiscussReadHomeDTO> GetDiscussByLessonId(int lessonId)
        {
            try
            {
                var discuss = await db.Discusses
                    .Where(discuss => discuss.LessonLessonId ==  lessonId)
                    .FirstOrDefaultAsync();
                var discussReadHomeDTO = mapper.Map<DiscussReadHomeDTO>(discuss);
                
                return discussReadHomeDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Discuss next, back when lesson next back 
        public async Task<DiscussReadHomeDTO> GetNextDiscuss(int currentDiscussId, int lessonId)
        {
            var discussesForLesson = await db.Discusses
                .Where(discuss => discuss.LessonLessonId == lessonId)
                .OrderBy(discuss => discuss.DiscussId)
                .ToListAsync();

            var currentDiscussIndex = discussesForLesson.FindIndex(discuss => discuss.DiscussId == currentDiscussId);

            if (currentDiscussIndex < 0 || currentDiscussIndex >= discussesForLesson.Count - 1)
            {
                // Invalid or last discuss, return null or handle accordingly
                return null;
            }

            var nextDiscuss = discussesForLesson[currentDiscussIndex + 1];
            return new DiscussReadHomeDTO { DiscussId = nextDiscuss.DiscussId, LessonLessonId = nextDiscuss.LessonLessonId };
        }

        public async Task<DiscussReadHomeDTO> GetPreviousDiscuss(int currentDiscussId, int lessonId)
        {
            var discussesForLesson = await db.Discusses
                .Where(discuss => discuss.LessonLessonId == lessonId)
                .OrderBy(discuss => discuss.DiscussId)
                .ToListAsync();

            var currentDiscussIndex = discussesForLesson.FindIndex(discuss => discuss.DiscussId == currentDiscussId);

            if (currentDiscussIndex <= 0)
            {
                // Invalid or first discuss, return null or handle accordingly
                return null;
            }

            var previousDiscuss = discussesForLesson[currentDiscussIndex - 1];
            return new DiscussReadHomeDTO { DiscussId = previousDiscuss.DiscussId, LessonLessonId = previousDiscuss.LessonLessonId };
        }
    }
}
