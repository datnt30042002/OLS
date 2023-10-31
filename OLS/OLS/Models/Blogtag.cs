using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class BlogTag
    {
        public BlogTag()
        {
            Blogs = new HashSet<Blog>();
        }

        public int BlogTagId { get; set; }
        public string? BlogTagName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
