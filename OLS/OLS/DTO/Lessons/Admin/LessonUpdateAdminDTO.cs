namespace OLS.DTO.Lessons.Admin
{
    public class LessonUpdateAdminDTO
    {
        public string? Title { get; set; }
        public string? Video { get; set; }
        public TimeSpan? Time { get; set; }
        //public int ChapterChapterId { get; set; } // đang suy xét có nên update lesson của chapter này sang chapter khác được không
    }
}
