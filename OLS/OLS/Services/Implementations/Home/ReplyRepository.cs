using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Asks.Home;
using OLS.DTO.Replies.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public ReplyRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all replies by discuss id
        public async Task<List<ReplyReadHomeDTO>> GetAllRepliesByAskId(int askId)
        {
            try
            {
                var replies = await db.Replies
                    .Where(reply => reply.AskAskId == askId)
                    .Include(reply => reply.UserUser)
                    .ToListAsync();
                var replyReadHomeDTO = mapper.Map<List<ReplyReadHomeDTO>>(replies);

                return replyReadHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new reply
        public async Task<ReplyCreateHomeDTO> CreateReply(ReplyCreateHomeDTO reply)
        {
            try
            {
                var newReply = mapper.Map<Reply>(reply);
                var createReply = await db.Replies.AddAsync(newReply);
                await db.SaveChangesAsync();
                var replyCreateHomeDTO = mapper.Map<ReplyCreateHomeDTO>(reply);

                return replyCreateHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
