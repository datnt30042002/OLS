using OLS.DTO.RateStar.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface IRateStarManagerRepository
    {
        Task<List<RateStarReadAdminDTO>> GetAllRateStars();
        Task<List<RateStarReadAdminDTO>> FilterAllRateStarsByCourseId(int courseId);
    }
}
