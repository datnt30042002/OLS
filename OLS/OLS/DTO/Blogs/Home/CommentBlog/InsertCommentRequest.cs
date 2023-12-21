namespace OLS.DTO.Blogs.Home.CommentBlog
{
    public class InsertCommentRequest
    {
        public int blogID { get; set; }
        public int userID { get; set; }
        public string? commentContent { get; set; }

    }
}
