namespace OLS.DTO.Quizzes.Admin
{
    public class QuizCreateAdminDTO
    {
        public int QuizId { get; set; }
        public int ChapterChapterId { get; set; }
        public string? QuizName { get; set; }
    }
}
