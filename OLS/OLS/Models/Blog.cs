﻿using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Blog
    {
        public Blog()
        {
            BlogComments = new HashSet<BlogComment>();
        }

        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogImage { get; set; }
        public string? BlogContent { get; set; }
        public DateTime? PostDate { get; set; }
        public int? Status { get; set; }
        public TimeSpan? ReadTime { get; set; }
        public int BlogTopicBlogTopicId { get; set; }
        public int BlogTagBlogTagId { get; set; }
        public int UserUserId { get; set; }

        public virtual BlogTag BlogTagBlogTag { get; set; } = null!;
        public virtual BlogTopic BlogTopicBlogTopic { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
