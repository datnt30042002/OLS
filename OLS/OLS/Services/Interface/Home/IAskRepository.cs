using OLS.DTO.Asks.Home;

namespace OLS.Services.Interface.Home
{
    public interface IAskRepository
    {
        Task<List<AskReadHomeDTO>> GetAllAsksByDiscussId(int discussId);
        Task<AskCreateHomeDTO> CreateAsk(AskCreateHomeDTO ask);
        Task<AskReadHomeDTO> GetAskByAskId(int askId);
        Task<AskUpdateHomeDTO> UpdateAskByAskID(int askId, AskUpdateHomeDTO updatedAsk);
        Task<bool> DeleteAskByAskId(int askId);
    }
}
