namespace OLS.DTO.Feedbacks.Home
{
    public class FeedbackUpdateHomeDTO
    {
        public int FeedbackId { get; set; }
        public string? FeedbackContent { get; set; }
        public int UserUserId { get; set; }
        public int CourseCourseId { get; set; }
    }
}
