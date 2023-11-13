using OLS.DTO.Courses.Admin;

namespace OLS.Repositories.Interface.Admin
{
    public interface ICourseManagerRepository
    {
        // Course manager
        Task<List<CourseReadAminDTO>> GetAllCourse();
        Task<CourseReadAminDTO> GetCourseByCourseId(int courseId);
        Task<CourseCreateAminDTO> CreateCourse(CourseCreateAminDTO course);
        Task<CourseUpdateAminDTO> UpdateCourseByCourseId(int courseId, CourseUpdateAminDTO updatedCourse);
        Task<bool> DeleteCourseByCourseId(int courseId);
        Task<List<CourseReadAminDTO>> SearchCoursesByCourseName(string keyword);
        Task<List<CourseReadAminDTO>> FilterCoursesByLearningPath(string learningPath);
    }
}
