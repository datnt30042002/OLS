namespace OLS.DTO.Questions.Admin
{
    public class QuestionCreateAdminDTO
    {
        public int QuestionId { get; set; }
        public int QuizQuizId { get; set; }
        public string? QuestionContent { get; set; }
    }
}
