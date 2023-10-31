using OLS.Models;
using OLS.DTO;
using OLS.Helpers;
using OLS.Repositories;
using OLS.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OLS.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OLSContext db;
        public CategoryRepository(OLSContext db)
        {
            this.db = db;
        }

        // Homepage
        // Get all learning paths(here is category table)
        public IEnumerable<LearningPathDTO> GetAllLearningPaths()
        {
            var learningPaths = db.LearningPaths
                .Select(lp => new LearningPathDTO
                {
                    LearningPathId = lp.LearningPathId,
                    LearningPathName = lp.LearningPathName,
                    Description = lp.Description,
                    Image = lp.Image,
                    Status = lp.Status,
                }).ToList();

            return learningPaths;
        }
    }
}
