using OLS.Models;
using OLS.Helpers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.Repositories.Interface.Home;
using OLS.DTO.LearningPaths.Home;

namespace OLS.Repositories.Implementations.Home
{
    public class LearningPathRepository : ILearningPathRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public LearningPathRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Homepage
        // Get all learning paths - Homepage, LearningPaths
        public async Task<List<LearningPathReadHomeDTO>> GetAllLearningPaths()
        {
            var learningPaths = await db.LearningPaths.ToListAsync();
            var LearningPathReadHomePageDTO = mapper.Map<List<LearningPathReadHomeDTO>>(learningPaths);

            return LearningPathReadHomePageDTO;
        }

    }
}
