using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class BlogComment
    {
        public int BlogCommentId { get; set; }
        public int? BlogCommentLevel { get; set; }
        public int? OriginCommentId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? ReplyToUser { get; set; }
        public int? BlogBlogId { get; set; }
        public int? UserUserId { get; set; }

        public virtual Blog? BlogBlog { get; set; }
        public virtual User? ReplyToUserNavigation { get; set; }
        public virtual User? UserUser { get; set; }
    }
}
