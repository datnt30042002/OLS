using OLS.DTO.Replies.Home;

namespace OLS.Services.Interface.Home
{
    public interface IReplyRepository
    {
        Task<List<ReplyReadHomeDTO>> GetAllRepliesByAskId(int askId);
        Task<ReplyCreateHomeDTO> CreateReply(ReplyCreateHomeDTO reply);

    }
}
