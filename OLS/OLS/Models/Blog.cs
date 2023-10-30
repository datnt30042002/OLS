using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogImage { get; set; }
        public string? BlogDetail { get; set; }
        public DateTime? PostDate { get; set; }
        public int? BlogStatus { get; set; }
        public int? TimeToRead { get; set; }
        public int UserUserId { get; set; }
        public int BlogTopicBlogTopicId { get; set; }
        public int BlogTagBlogTagId { get; set; }

        public virtual BlogTag BlogTagBlogTag { get; set; } = null!;
        public virtual BlogTopic BlogTopicBlogTopic { get; set; } = null!;
    }
}
