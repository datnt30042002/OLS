using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.Courses.Admin;
using OLS.DTO.Users.Admin;
using OLS.Models;
using OLS.Services.Interface.Admin;

namespace OLS.Services.Implementations.Admin
{
    public class CourseManagerRepository : ICourseManagerRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public CourseManagerRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Get all courses - Read
        public async Task<List<CourseReadAminDTO>> GetAllCourses()
        {
            try
            {
                var courses = await db.Courses.Include(courses => courses.LearningPathLearningPath).ToListAsync();
                var courseReadAminDTO = mapper.Map<List<CourseReadAminDTO>>(courses);

                return courseReadAminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get course details by CourseId
        public async Task<CourseReadAminDTO> GetCourseByCourseId(int courseId)
        {
            try
            {
                var course = await db.Courses.Where(course => course.CourseId == courseId).Include(course => course.LearningPathLearningPath).FirstOrDefaultAsync();
                var courseReadAminDTO = mapper.Map<CourseReadAminDTO>(course);

                return courseReadAminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create new course
        public async Task<CourseCreateAminDTO> CreateCourse(CourseCreateAminDTO course)
        {
            try
            {
                var newCourse = mapper.Map<Course>(course);
                var createCourse = await db.Courses.AddAsync(newCourse);
                await db.SaveChangesAsync();
                var courseCreateAminDTO = mapper.Map<CourseCreateAminDTO>(newCourse);

                return courseCreateAminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update course by CourseId
        public async Task<CourseUpdateAminDTO> UpdateCourseByCourseId(int courseId, CourseUpdateAminDTO updatedCourse)
        {
            try
            {
                // Check course exist
                var existingCourse = await db.Courses
                    .Where(course => course.CourseId == courseId)
                    .Include(course => course.LearningPathLearningPath)
                    .FirstOrDefaultAsync();

                // Notificate not exist
                if(existingCourse == null)
                {
                    Console.WriteLine("Not found course");
                }

                // Mapper
                mapper.Map(updatedCourse, existingCourse);
                db.SaveChangesAsync();
                var courseUpdateAminDTO = mapper.Map<CourseUpdateAminDTO>(existingCourse);

                return courseUpdateAminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete course by CourseId
        public async Task<bool> DeleteCourseByCourseId(int courseId) { 
            try
            {
                // Check course exist
                var existingCourse = await db.Courses
                    .Where(course => course.CourseId == courseId)
                    .FirstOrDefaultAsync();

                // Notificate not exist
                if(existingCourse == null)
                {
                    Console.WriteLine("Not found course");
                }

                db.Courses.Remove(existingCourse);
                db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Search all course by CourseName
        public async Task<List<CourseReadAminDTO>> SearchCoursesByCourseName(string keyword)
        {
            try
            {
                var searchedCourses = await db.Courses
                    .Where(courses => courses.CourseName.Contains(keyword))
                    .Include(courses => courses.LearningPathLearningPath)
                    .ToListAsync();

                var courseReadAminDTO = mapper.Map<List<CourseReadAminDTO>>(searchedCourses);

                return courseReadAminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Filter courses by LearningPath
        public async Task<List<CourseReadAminDTO>> FilterCoursesByLearningPath(string learningPath)
        {
            try
            {
                var filteredCourses = await db.Courses
                    .Where(courses => courses.LearningPathLearningPath.LearningPathName == learningPath)
                    .Include(courses => courses.LearningPathLearningPath)
                    .ToListAsync();

                var courseReadAminDTO = mapper.Map<List<CourseReadAminDTO>>(filteredCourses);

                return courseReadAminDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // <Later function>
        // Sort by title
        // Pagging
        // <Later function>

    }
}
