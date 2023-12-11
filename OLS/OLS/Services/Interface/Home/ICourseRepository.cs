using OLS.DTO.Courses;

namespace OLS.Services.Interface.Home
{
    public interface ICourseRepository
    {
        // Homepage
        Task<List<CourseReadHomeDTO>> Get10CoursesWithFee();
        Task<List<CourseReadHomeDTO>> Get15CoursesFree();
        Task<List<CourseReadHomeDTO>> SearchCoursesByCourseName(string keyword);
    }
}
