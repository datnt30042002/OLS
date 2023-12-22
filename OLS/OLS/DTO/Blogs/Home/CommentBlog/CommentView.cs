namespace OLS.DTO.Blogs.Home.CommentBlog
{
    public class CommentView
    {
        public int BlogCommentID { get; set; }
        public int? BlogID { get; set; }
        public int? UserID { get; set; }
        public int? Level { get; set; }
        public int? OriginCommentID { get; set; }
        public int? ReplyToUserID { get; set; }
        public string? Content { get; set; }
        public DateTime? Publish { get; set; }
        public string? ReplyToUsername { get; set; }
        public string? CommentUser { get; set; }
        public string? ImageUserComment { get; set; }
    }
}
