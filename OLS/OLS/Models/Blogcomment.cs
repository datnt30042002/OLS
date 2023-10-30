using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class BlogComment
    {
        public int BlogCommentId { get; set; }
        public int? BlogId { get; set; }
        public int? UserId { get; set; }
        public int? BlogLevel { get; set; }
        public int? OriginCommentId { get; set; }
        public int? ReplyToUser { get; set; }
        public string? BlogContent { get; set; }
        public DateTime? Publish { get; set; }
    }
}
