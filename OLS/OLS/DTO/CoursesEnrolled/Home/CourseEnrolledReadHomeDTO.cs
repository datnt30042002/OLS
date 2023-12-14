namespace OLS.DTO.CoursesEnrolled.Home
{
    public class CourseEnrolledReadHomeDTO
    {
        public int CourseEnrolledId { get; set; }
        public DateTime? EnrolledDate { get; set; }
        public int? Status { get; set; }
        public int CourseCourseId { get; set; }
        public string? CourseName { get; set; }
        public int UserUserId { get; set; }
        public List<string?> NotificationContents { get; set; } = new List<string?>();
    }
}
