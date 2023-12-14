namespace OLS.DTO.Replies.Home
{
    public class ReplyReadHomeDTO
    {
        public int ReplyId { get; set; }
        public string? ReplyContent { get; set; }
        public int? AskAskId { get; set; }
        public int? UserUserId { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Image { get; set; }
    }
}
