using OLS.DTO.RateStar.Home;

namespace OLS.Services.Interface.Home
{
    public interface IRateStarRepository
    {
        Task<List<RateStarReadHomeDTO>> GetAllRateStarsByCourseId(int courseId);
        Task<RateStarCreateHomeDTO> CreateRateStar(RateStarCreateHomeDTO rateStar);
        Task<RateStarUpdateHomeDTO> UpdateRateStarByRateStarId(int rateStarId, RateStarUpdateHomeDTO updatedRateStar);
        Task<bool> DeleteRateStarByRateStarId(int rateStarId);
    }
}
