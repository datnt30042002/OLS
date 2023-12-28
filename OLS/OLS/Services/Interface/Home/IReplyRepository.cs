using OLS.DTO.Replies.Home;

namespace OLS.Services.Interface.Home
{
    public interface IReplyRepository
    {
        Task<List<ReplyReadHomeDTO>> GetAllRepliesByAskId(int askId);
        Task<ReplyCreateHomeDTO> CreateReply(ReplyCreateHomeDTO reply);
        Task<int> CountRepliesByAskId(int askId);
        Task<ReplyReadHomeDTO> GetReplyByReplyId(int replyId);
        Task<ReplyUpdateHomeDTO> UpdateReplyByReplyId(int replyId, ReplyUpdateHomeDTO updatedReply);
        Task<bool> DeleteReplyByReplyId(int replyId);

    }
}
