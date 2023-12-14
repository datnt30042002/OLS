namespace OLS.DTO.Questions.Admin
{
    public class QuestionUpdateAdminDTO
    {
        public int QuestionId { get; set; }
        public int QuizQuizId { get; set; }
        public string? QuestionContent { get; set; }
    }
}
