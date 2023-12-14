using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Feedbacks.Home;
using OLS.DTO.Notes.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public FeedbackRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all feedbacks by course id 
        public async Task<List<FeedbackReadHomeDTO>> GetAllFeedbacksByCourseId(int courseId)
        {
            try
            {
                var feedbacks = await db.Feedbacks
                    .Where(feedback => feedback.CourseCourseId  == courseId)
                    .Include(feedback => feedback.UserUser) 
                    .ToListAsync();
                var feedbackReadHomeDTO = mapper.Map<List<FeedbackReadHomeDTO>>(feedbacks);

                return feedbackReadHomeDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get all feedbacks by user id in course id 
        public async Task<List<FeedbackReadHomeDTO>> GetAllFeedbacksByUserIdInCourseId(int userId, int courseId)
        {
            try
            {
                var feedbacks = await db.Feedbacks
                    .Where(feedback => feedback.UserUserId == userId)
                    .Where(feedback => feedback.CourseCourseId == courseId)
                    .Include(feedback => feedback.UserUser)
                    .ToListAsync();
                var feebackReadHomeDTO = mapper.Map<List<FeedbackReadHomeDTO>>(feedbacks);

                return feebackReadHomeDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new feedback 
        public async Task<FeedbackCreateHomeDTO> CreateFeedback(FeedbackCreateHomeDTO feedback)
        {
            try
            {
                var newFeedback = mapper.Map<Feedback>(feedback);
                var createFeedback = await db.Feedbacks.AddAsync(newFeedback);
                await db.SaveChangesAsync();
                var feebackCreateHomeDTO = mapper.Map<FeedbackCreateHomeDTO>(feedback);

                return feebackCreateHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update feedback by feedbackId
        public async Task<FeedbackUpdateHomeDTO> UpdateFeedbackByFeedbackId(int feedbackId, FeedbackUpdateHomeDTO updatedFeedback)
        {
            try
            {
                var existingFeedback = await db.Feedbacks
                    .Where(feedback => feedback.FeedbackId == feedbackId)
                    .FirstOrDefaultAsync();

                if (existingFeedback == null)
                {
                    Console.WriteLine("Not found feedback");
                }

                mapper.Map(updatedFeedback, existingFeedback);
                db.SaveChangesAsync();
                var feedbackUpdateHomeDTO = mapper.Map<FeedbackUpdateHomeDTO>(existingFeedback);

                return feedbackUpdateHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete feedback by feedbackId
        public async Task<bool> DeleteFeedbackByFeedbackId(int feedbackId)
        {
            try
            {
                var existingFeedback = await db.Feedbacks
                    .Where(feedback => feedback.FeedbackId == feedbackId)
                    .FirstOrDefaultAsync();

                if (existingFeedback == null)
                {
                    Console.WriteLine("Not found feedback");
                }

                db.Feedbacks.Remove(existingFeedback);
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
