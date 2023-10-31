using OLS.Models;
using OLS.DTO;

namespace OLS.Repositories.Interface
{
    public interface ILearningPathRepository
    {
        // Homepage
        IEnumerable<LearningPathDTO> GetAllLearningPaths(); // Homepage, LearningPaths
    }
}
