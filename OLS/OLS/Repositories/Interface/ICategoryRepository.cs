using OLS.Models;
using OLS.DTO;

namespace OLS.Repositories.Interface
{
    public interface ICategoryRepository
    {
        // Homepage
        IEnumerable<LearningPathDTO> GetAllLearningPaths();
    }
}
