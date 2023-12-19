namespace OLS.DTO.CourseEnrolled.Home
{
    public class CourseEnrolledRegisterHomeDTO
    {
        public int CourseEnrolledId { get; set; }
        public DateTime? EnrolledDate { get; set; }
        public int? Status { get; set; }
        public int CourseCourseId { get; set; }
        public int UserUserId { get; set; }
    }
}
