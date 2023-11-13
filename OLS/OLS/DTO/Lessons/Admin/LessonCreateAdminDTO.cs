namespace OLS.DTO.Lessons.Admin
{
    public class LessonCreateAdminDTO
    {
        public string? Title { get; set; }
        public string? Video { get; set; }
        public TimeSpan? Time { get; set; }
        public int ChapterChapterId { get; set; } // ChapterId sẽ được tự động gán khi cretate new bên trong Chapter của Lessons
    }
}
