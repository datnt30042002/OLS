namespace OLS.DTO.Courses
{
    public class CourseReadHomeDTO
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? CourseInfomation { get; set; }
        public string? Image { get; set; }
        public string? VideoIntro { get; set; }
        public int? Fee { get; set; }
        public string? Status { get; set; }
        public string? LearningPath { get; set; }
    }
}
