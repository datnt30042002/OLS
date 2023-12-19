namespace OLS.DTO.Courses.Admin
{
    public class CourseUpdateAminDTO
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? CourseInfomation { get; set; }
        public string? Image { get; set; }
        public string? VideoIntro { get; set; }
        public int? Fee { get; set; }
        public int Status { get; set; }
        public int LearningPath{ get; set; }
    }
}
