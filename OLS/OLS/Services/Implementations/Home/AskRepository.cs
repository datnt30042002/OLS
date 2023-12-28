using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Asks.Home;
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
                    .OrderByDescending(ask => ask.AskId)
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

        // Get ask by askId
        public async Task<AskReadHomeDTO> GetAskByAskId(int askId)
        {
            try
            {
                var ask = await db.Asks
                    .Where(ask => ask.AskId == askId)
                    .Include(ask => ask.UserUser)
                    .FirstOrDefaultAsync();
                var askReadHomeDTO = mapper.Map<AskReadHomeDTO>(ask);

                return askReadHomeDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update ask by askId
        public async Task<AskUpdateHomeDTO> UpdateAskByAskID(int askId, AskUpdateHomeDTO updatedAsk)
        {
            try
            {
                var existingAsk = await db.Asks
                    .Where(ask => ask.AskId == askId)
                    .FirstOrDefaultAsync();

                if(existingAsk == null)
                {
                    Console.WriteLine("Not found ask");
                }

                mapper.Map(updatedAsk, existingAsk);
                await db.SaveChangesAsync();
                var askUpdateHomeDTO = mapper.Map<AskUpdateHomeDTO>(existingAsk);

                return askUpdateHomeDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete ask by askId
        public async Task<bool> DeleteAskByAskId(int askId)
        {
            try
            {
                var existingAsk = await db.Asks
                    .Where(ask => ask.AskId == askId)
                    .FirstOrDefaultAsync();

                if(existingAsk == null)
                {
                    Console.WriteLine("Not found ask");
                }

                 db.Asks.Remove(existingAsk);
                await db.SaveChangesAsync();

                return true;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
