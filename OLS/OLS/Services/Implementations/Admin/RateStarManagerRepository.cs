using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.RateStar.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;

namespace OLS.Services.Implementations.Admin
{
    public class RateStarManagerRepository : IRateStarManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public RateStarManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all rate stars 
        public async Task<List<RateStarReadAdminDTO>> GetAllRateStars()
        {
            try
            {
                var rateStars = await db.RateStars
                    .Include(rateStar => rateStar.UserUser)
                    .Include(rateStar => rateStar.CourseCourse)
                    .ToListAsync();
                var rateStarReadAdminDTO = mapper.Map<List<RateStarReadAdminDTO>>(rateStars);

                return rateStarReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Filter all rate stars by course id 
        public async Task<List<RateStarReadAdminDTO>> FilterAllRateStarsByCourseId(int courseId)
        {
            try
            {
                var rateStars = await db.RateStars
                    .Where(rateStar => rateStar.CourseCourseId == courseId)
                    .Include(rateStar => rateStar.UserUser)
                    .Include(rateStar => rateStar.CourseCourse)
                    .ToListAsync();
                var rateStarReadAdminDTO = mapper.Map<List<RateStarReadAdminDTO>>(rateStars);

                return rateStarReadAdminDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
