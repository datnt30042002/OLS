using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Chapters.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;

namespace OLS.Services.Implementations.Admin
{
    public class ChapterManagerRepository : IChapterManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public ChapterManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all chapters by CourseId
        //public async Task<List<ChapterReadAdminDTO>> GetAllChaptersByCourseId(int courseId)
        //{
        //    try
        //    {
        //        var chaptersByCourseId = await db.Chapters
        //            .Where(chapters => chapters.CourseCourseId == courseId)
        //            .Include(chapters => chapters.CourseCourse)
        //            .ToListAsync();

        //        var chapterReadAdminDTO = mapper.Map<List<ChapterReadAdminDTO>>(chaptersByCourseId);

        //        var chapterReadAdminDTO;
        //    } catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        // Get all chapters 
        public async Task<List<ChapterReadAdminDTO>> GetAllChapters()
        {
            try
            {
                var chpaters = await db.Chapters
                    .Include(chapters => chapters.CourseCourse)
                    .ToListAsync();

                var chapterReadAdminDTO = mapper.Map<List<ChapterReadAdminDTO>>(chpaters);
                return chapterReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get chapter by ChapterId
        public async Task<ChapterReadAdminDTO> GetChapterByChapterId(int chapterId)
        {
            try
            {
                var chapter = await db.Chapters
                    .Where(chapter => chapter.ChapterId == chapterId)
                    .Include(chapter => chapter.CourseCourse)
                    .FirstOrDefaultAsync();
                var chapterReadAdminDTO = mapper.Map<ChapterReadAdminDTO>(chapter);

                return chapterReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new chapter
        // Course sẽ được add theo CourseId -> khi đó sẽ auto add CourseId theo các chapter của Course
        public async Task<ChapterCreateAdminDTO> CreateNewChapter(ChapterCreateAdminDTO chapter)
        {
            try
            {
                var newChapter = mapper.Map<Chapter>(chapter);
                var createChapter = await db.Chapters.AddAsync(newChapter);
                await db.SaveChangesAsync();
                var chapterCreateAdminDTO = mapper.Map<ChapterCreateAdminDTO>(newChapter);

                return chapterCreateAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update chapter by ChpaterId
        public async Task<ChapterUpdateAdminDTO> UpdateChapterByChapterId(int chapterId, ChapterUpdateAdminDTO updatedChapter)
        {
            try
            {
                // Check chapter exist 
                var existingChapter = await db.Chapters
                    .Where(chapter => chapter.ChapterId == chapterId)
                    .Include (chapter => chapter.CourseCourse)
                    .FirstOrDefaultAsync();

                // Notification not exist
                if(existingChapter == null) 
                {
                    Console.WriteLine("Not found chapter");                
                }

                // Mapper
                mapper.Map(updatedChapter, existingChapter);
                db.SaveChangesAsync();
                var chapterUpdateAdminDTO = mapper.Map<ChapterUpdateAdminDTO>(existingChapter);

                return chapterUpdateAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete chapter by ChpaterId
        public async Task<bool> DeleteChapterByChapterId(int chapterId)
        {
            try
            {
                // Check chapter exist
                var existingChapter = await db.Chapters
                    .Where(chapter => chapter.ChapterId == chapterId)
                    .FirstOrDefaultAsync ();

                // Notification if not exist 
                if(existingChapter == null)
                {
                    Console.WriteLine("Not found chapter");
                }

                // Mapper
                db.Chapters.Remove(existingChapter);
                db.SaveChangesAsync();

                return true;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //<Later function>
        // Search
        // Sort
        // Filter
        // Paging
        //<Later function>
    }
}
