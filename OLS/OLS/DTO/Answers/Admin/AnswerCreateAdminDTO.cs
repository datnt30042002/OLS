namespace OLS.DTO.Answers.Admin
{
    public class AnswerCreateAdminDTO
    {
        public int AnswerId { get; set; }
        public string? AnswerContent { get; set; }
        public int QuestionQuestionId { get; set; }
        public int? IsTrue { get; set; }
    }
}
