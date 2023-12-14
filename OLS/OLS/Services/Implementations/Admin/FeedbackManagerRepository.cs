using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Feedbacks.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Admin
{
    public class FeedbackManagerRepository : IFeedbackManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public FeedbackManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all feedbacks
        public async Task<List<FeedbackReadAdminDTO>> GetAllFeedbacks()
        {
            try
            {
                var feedbacks = await db.Feedbacks
                    .Include(feedback => feedback.UserUser)
                    .ToListAsync();
                var feedbackReadAdminDTO = mapper.Map<List<FeedbackReadAdminDTO>>(feedbacks);

                return feedbackReadAdminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Filter all feedbacks by course id
        public async Task<List<FeedbackReadAdminDTO>> FilterAllFeedbacksByCourseId(int courseId)
        {
            try
            {
                var feedbacks = await db.Feedbacks
                    .Where(feedback => feedback.CourseCourseId == courseId)
                    .Include(feedback => feedback.UserUser)
                    .ToListAsync();
                var feedbackReadAdminDTO = mapper.Map<List<FeedbackReadAdminDTO>>(feedbacks);

                return feedbackReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
