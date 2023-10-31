using OLS.Models;
using OLS.DTO;

namespace OLS.Repositories.Interface
{
    public interface ICourseRepository
    {
        // Homepage
        IEnumerable<CourseDTO> Get10CoursesWithFee();
        IEnumerable<CourseDTO> Get15CoursesFree();
    }
}
