using OLS.DTO.CourseEnrolled.Home;
using OLS.DTO.CoursesEnrolled.Home;

namespace OLS.Services.Interface.Home
{
    public interface ICourseEnrolledRepository
    {
        Task<bool?> IsCourseEnrolled(int courseId);
        Task<CourseEnrolledRegisterHomeDTO> RegisterFreeCourse(CourseEnrolledRegisterHomeDTO course);
        Task<List<CourseEnrolledReadHomeDTO>> GetAllCoursesEnrolledByUserId(int userId);
    }
}
