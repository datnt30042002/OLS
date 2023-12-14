namespace OLS.DTO.Lessons.Home
{
    public class LessonReadHomeDTO
    {
        public int LessonId { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public TimeSpan? Time { get; set; }
        public int ChapterChapterId { get; set; }
    }
}
