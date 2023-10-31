using OLS.Models;
using OLS.DTO;
using OLS.Helpers;
using OLS.Repositories;
using OLS.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OLS.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OLSContext db;
        public CourseRepository(OLSContext db)
        {
            this.db = db;
        }

        // Homepage
        // Get 10 courses with Fee != 0
        public IEnumerable<CourseDTO> Get10CoursesWithFee()
        {
            var courses = db.Courses
                .Where(c => c.Fee != 0)
                .Select(c => new CourseDTO
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    CourseInfomation = c.CourseInfomation,
                    Image = c.Image,
                    VideoIntro = c.VideoIntro,
                    Fee = c.Fee,
                    Status = c.Status,
                    LearningPathLearningPathId = c.LearningPathLearningPathId,
                    UserUserId = c.UserUserId
                }).Take(10)
            .ToList();

            return courses;
        }

        // Get 15 courses with Fee == 0
        public IEnumerable<CourseDTO> Get15CoursesFree()
        {
            var courses = db.Courses
                .Where(c => c.Fee == 0)
                .Select(c => new CourseDTO
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    CourseInfomation = c.CourseInfomation,
                    Image = c.Image,
                    VideoIntro = c.VideoIntro,
                    Fee = c.Fee,
                    Status = c.Status,
                    LearningPathLearningPathId = c.LearningPathLearningPathId,
                    UserUserId = c.UserUserId
                }
                ).Take(15)
                .ToList();

            return courses;
        }

    }
}
