using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class BlogTopic
    {
        public BlogTopic()
        {
            Blogs = new HashSet<Blog>();
        }

        public int BlogTopicId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
