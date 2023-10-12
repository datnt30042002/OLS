using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Blogtopic
    {
        public Blogtopic()
        {
            Blogs = new HashSet<Blog>();
        }

        public int BlogTopicId { get; set; }
        public string? BlogTopicName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
