using OLS.DTO.Courses.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface ICourseManagerRepository
    {
        // Course manager
        Task<List<CourseReadAminDTO>> GetAllCourses();
        Task<CourseReadAminDTO> GetCourseByCourseId(int courseId);
        Task<CourseCreateAminDTO> CreateCourse(CourseCreateAminDTO course);
        Task<CourseUpdateAminDTO> UpdateCourseByCourseId(int courseId, CourseUpdateAminDTO updatedCourse);
        Task<bool> DeleteCourseByCourseId(int courseId);
        Task<List<CourseReadAminDTO>> SearchCoursesByCourseName(string keyword);
        Task<List<CourseReadAminDTO>> FilterCoursesByLearningPath(string learningPath);
        Task<List<CourseReadAminDTO>> GetAllCoursesWithPagination(int pageIndex, int pageSize);
        Task<List<CourseReadAminDTO>> GetNextPage(int pageIndex, int pageSize);
        Task<List<CourseReadAminDTO>> GetPreviousPage(int pageIndex, int pageSize);
    }
}
