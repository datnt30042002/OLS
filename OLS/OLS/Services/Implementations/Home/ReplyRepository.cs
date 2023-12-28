using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        // Count amount of replies by askId
        public async Task<int> CountRepliesByAskId(int askId)
        {
            try
            {
                var count = await db.Replies
                    .Where(reply => reply.AskAskId == askId)
                    .CountAsync();

                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get reply by replyId
        public async Task<ReplyReadHomeDTO> GetReplyByReplyId(int replyId)
        {
            try
            {
                var reply = await db.Replies
                    .Where(reply => reply.ReplyId == replyId)
                    .Include(reply => reply.UserUser)
                    .FirstOrDefaultAsync();
                var replyReadHomeDTO = mapper.Map<ReplyReadHomeDTO>(reply);

                return replyReadHomeDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update reply by replyId
        public async Task<ReplyUpdateHomeDTO> UpdateReplyByReplyId(int replyId, ReplyUpdateHomeDTO updatedReply)
        {
            try
            {
                var existingReply = await db.Replies
                    .Where(reply => reply.ReplyId == replyId)
                    .FirstOrDefaultAsync();

                if(existingReply == null)
                {
                    Console.WriteLine("Not found reply");
                }

                mapper.Map(updatedReply, existingReply);
                await db.SaveChangesAsync();
                var replyUpdateHomeDTO = mapper.Map<ReplyUpdateHomeDTO>(existingReply);

                return replyUpdateHomeDTO;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete reply by replyId
        public async Task<bool> DeleteReplyByReplyId(int replyId)
        {
            try
            {
                var existingReply = await db.Replies
                    .Where(reply => reply.ReplyId == replyId)
                    .FirstOrDefaultAsync();

                if (existingReply == null)
                {
                    Console.WriteLine("Not found reply");
                }

                db.Replies.Remove(existingReply);
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
