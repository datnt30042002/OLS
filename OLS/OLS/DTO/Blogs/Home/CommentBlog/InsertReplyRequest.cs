namespace OLS.DTO.Blogs.Home.CommentBlog
{
    public class InsertReplyRequest
    {
        public int? OriginCommentId { get; set; }
        
        public int blogID { get; set; }
        public int userID { get; set; }
        public int? userReplyID { get; set; }
        public string? commentContent { get; set; }
    }
}
