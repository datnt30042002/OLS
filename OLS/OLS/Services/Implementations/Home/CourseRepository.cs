using OLS.Models;
using OLS.DTO;
using OLS.DTO.Courses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.Repositories.Interface.Home;

namespace OLS.Repositories.Implementations.Home
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OLSContext db;
        private readonly IMapper mapper;
        public CourseRepository(OLSContext db, IMapper mapper)
        {
            // <Summary> 
            // this được sử dụng để chỉ đến các thành viên của class trong trường hợp có sự trùng lặp tên giữa biến cục bộ và biến thành viên. 
            // Trong trường hợp này, việc sử dụng this không bắt buộc, nhưng nó có thể được sử dụng để làm cho mã nguồn rõ ràng hơn trong một số trường hợp, 
            // giúp phân biệt giữa biến cục bộ và biến thành viên.
            //<Summary>

            this.db = db;
            this.mapper = mapper;
        }

        // Homepage
        // Get 10 courses with Fee != 0
        public async Task<List<CourseReadHomeDTO>> Get10CoursesWithFee()
        {
            var courses = await db.Courses.Include(courses => courses.LearningPathLearningPath).Where(c => c.Fee != 0).Take(10).ToListAsync();
            var CourseReadHomePageDTO = mapper.Map<List<CourseReadHomeDTO>>(courses);

            return CourseReadHomePageDTO;
            //// Tạo một map để chỉ định cách ánh xạ, không lấy giá trị img
            //var mappingConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Course, CourseReadHomePageDTO>()
            //        .ForMember(dest => dest.Image, opt => opt.Ignore()); // Ignore field Image
            //});
            //var mapper = mappingConfig.CreateMapper();

            //// Loại bỏ trường Image sau khi ánh xạ - c2
            //CourseReadHomePageDTO.ForEach(dto => dto.Image = null);
            //return CourseReadHomePageDTO;

        }

        // Get 15 courses with Fee == 0
        public async Task<List<CourseReadHomeDTO>> Get15CoursesFree()
        {
            var courses = await db.Courses.Include(courses => courses.LearningPathLearningPath).Where(c => c.Fee == 0).Take(15).ToListAsync();
            var CourseReadHomePageDTO = mapper.Map<List<CourseReadHomeDTO>>(courses);

            return CourseReadHomePageDTO;
        }

        // Search course by course name
        public async Task<List<CourseReadHomeDTO>> SearchCoursesByCourseName(string keyword)
        {
            var courses = await db.Courses.Where(c => c.CourseName.Contains(keyword)).ToListAsync();
            var CourseReadHomePageDTO = mapper.Map<List<CourseReadHomeDTO>>(courses);

            return CourseReadHomePageDTO;
        }
    }
}
