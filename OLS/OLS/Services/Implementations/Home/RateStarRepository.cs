using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Notes.Home;
using OLS.DTO.RateStar.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class RateStarRepository : IRateStarRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public RateStarRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all rate stars by course id 
        public async Task<List<RateStarReadHomeDTO>> GetAllRateStarsByCourseId(int courseId)
        {
            try
            {
                var rateStars = await db.RateStars
                    .Where(rateStar => rateStar.CourseCourseId == courseId)
                    .Include(rateStar => rateStar.UserUser)
                    .ToListAsync();
                var rateStarReadHomeDTO = mapper.Map<List<RateStarReadHomeDTO>>(rateStars);

                return rateStarReadHomeDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new rate star
        public async Task<RateStarCreateHomeDTO> CreateRateStar(RateStarCreateHomeDTO rateStar)
        {
            try
            {
                var newRateStar = mapper.Map<RateStar>(rateStar);
                var createRatestar = await db.RateStars.AddAsync(newRateStar);
                await db.SaveChangesAsync();
                var rateStarCreateHomeDTO = mapper.Map<RateStarCreateHomeDTO>(newRateStar);

                return rateStarCreateHomeDTO;
            } catch(Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        // Update rate star by rate star id 
        public async Task<RateStarUpdateHomeDTO> UpdateRateStarByRateStarId(int rateStarId, RateStarUpdateHomeDTO updatedRateStar)
        {
            try
            {
                var existingRateStar = await db.RateStars
                    .Where(rateStar => rateStar.RateStarId == rateStarId)
                    .FirstOrDefaultAsync();

                if (existingRateStar == null)
                {
                    Console.WriteLine("Not found rate star");
                }

                mapper.Map(updatedRateStar, existingRateStar);
                db.SaveChangesAsync();
                var rateStarUpdateHomeDTO = mapper.Map<RateStarUpdateHomeDTO>(existingRateStar);

                return rateStarUpdateHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete rate star by rate star id 
        public async Task<bool> DeleteRateStarByRateStarId(int rateStarId)
        {
            try
            {
                var existingRateStar = await db.RateStars
                    .Where(rateStar => rateStar.RateStarId == rateStarId)
                    .FirstOrDefaultAsync();

                if (existingRateStar == null)
                {
                    Console.WriteLine("Not found rate star");
                }

                db.RateStars.Remove(existingRateStar);
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
