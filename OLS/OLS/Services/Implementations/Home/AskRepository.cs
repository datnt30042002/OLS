using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Asks.Home;
using OLS.DTO.Chapters.Home;
using OLS.DTO.Courses.Admin;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class AskRepository : IAskRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public AskRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all asks by discuss id 
        public async Task<List<AskReadHomeDTO>> GetAllAsksByDiscussId(int discussId)
        {
            try
            {
                var asks = await db.Asks
                    .Where(ask => ask.DiscussDiscussId == discussId)
                    .Include(ask => ask.UserUser)
                    .ToListAsync();
                var askReadHomeDTO = mapper.Map<List<AskReadHomeDTO>>(asks);

                return askReadHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new ask 
        public async Task<AskCreateHomeDTO> CreateAsk(AskCreateHomeDTO ask)
        {
            try
            {
                var newAsk = mapper.Map<Ask>(ask);
                var createAsk = await db.Asks.AddAsync(newAsk);
                await db.SaveChangesAsync();
                var askCreateHomeDTO = mapper.Map<AskCreateHomeDTO>(newAsk);

                return askCreateHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
