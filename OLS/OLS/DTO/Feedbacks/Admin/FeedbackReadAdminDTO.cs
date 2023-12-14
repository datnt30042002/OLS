namespace OLS.DTO.Feedbacks.Admin
{
    public class FeedbackReadAdminDTO
    {
        public int FeedbackId { get; set; }
        public string? FeedbackContent { get; set; }
        public int UserUserId { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public int CourseCourseId { get; set; }
    }
}
