using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.DTO.CourseEnrolled.Home;
using OLS.DTO.CoursesEnrolled.Home;
using OLS.Models;
using OLS.Services.Interface.Home;

namespace OLS.Services.Implementations.Home
{
    public class CourseEnrolledRepository : ICourseEnrolledRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        
        public CourseEnrolledRepository(OLSContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // Check course is enrolled or not 
        // <bool?> will return null instead of false 
        public async Task<bool?> IsCourseEnrolled(int courseId)
        {
            try
            {
                var isEnrolled = await db.CourseEnrolleds
                    .AnyAsync(courseEnrolled => courseEnrolled.CourseCourseId == courseId);

                return isEnrolled;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Register free course
        public async Task<CourseEnrolledRegisterHomeDTO> RegisterFreeCourse(CourseEnrolledRegisterHomeDTO course)
        {
            try
            {
                var newCourse = mapper.Map<CourseEnrolled>(course);
                var registerNewCourse = await db.CourseEnrolleds.AddAsync(newCourse);
                await db.SaveChangesAsync();
                var courseEnrolledRegisterHomeDTO = mapper.Map<CourseEnrolledRegisterHomeDTO>(newCourse);

                return courseEnrolledRegisterHomeDTO;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get all courses enrolled by user id 
        public async Task<List<CourseEnrolledReadHomeDTO>> GetAllCoursesEnrolledByUserId(int userId)
        {
            try
            {
                var coursesEnrolled = await db.CourseEnrolleds
                    .Include(ce => ce.CourseCourse.Notifications)
                    .Where(ce => ce.UserUserId == userId)
                    .ToListAsync();

                var courseEnrolledReadHomeDTO = mapper.Map<List<CourseEnrolledReadHomeDTO>>(coursesEnrolled);

                return courseEnrolledReadHomeDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
