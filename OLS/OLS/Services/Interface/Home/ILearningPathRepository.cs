using OLS.Models;
using OLS.DTO.LearningPaths.Home;

namespace OLS.Services.Interface.Home
{
    public interface ILearningPathRepository
    {
        // Homepage
        Task<List<LearningPathReadHomeDTO>> GetAllLearningPaths(); // Homepage, LearningPaths
    }
}
