using OLS.Models;
using OLS.DTO;
using OLS.Helpers;
using OLS.Repositories;
using OLS.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OLS.Repositories.Implementations
{
    public class LearningPathRepository : ILearningPathRepository
    {
        private readonly OLSContext db;
        public LearningPathRepository(OLSContext db)
        {
            this.db = db;
        }

        // Homepage
        // get all learning paths - Homepage, LearningPaths
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
