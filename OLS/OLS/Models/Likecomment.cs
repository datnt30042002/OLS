using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class LikeComment
    {
        public int UserUserId { get; set; }
        public int BlogCommentBlogCommentId { get; set; }

        public virtual BlogComment BlogCommentBlogComment { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
