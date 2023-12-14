namespace OLS.DTO.RateStar.Admin
{
    public class RateStarReadAdminDTO
    {
        public int RateStarId { get; set; }
        public int? Star { get; set; }
        public int UserUserId { get; set; }
        public string? FullName { get; set; } 
        public int CourseCourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseImage { get; set; }
    }
}
