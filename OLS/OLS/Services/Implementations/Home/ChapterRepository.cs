using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Chapters.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public ChapterRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all chapters by course id 
        public async Task<List<ChapterReadHomeDTO>> GetAllChaptersByCourseId(int courseId)
        {
            try
            {
                var chapters = await db.Chapters
                    .Where(chapter => chapter.CourseCourseId == courseId)
                    .ToListAsync();
                var chapterReadHomeDTO = mapper.Map<List<ChapterReadHomeDTO>>(chapters);

                return chapterReadHomeDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
