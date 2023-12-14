namespace OLS.DTO.Answers.Home
{
    public class AnswerReadHomeDTO
    {
        public int AnswerId { get; set; }
        public string? AnswerContent { get; set; }
        public int QuestionQuestionId { get; set; }
        public int? IsTrue { get; set; }
    }
}
