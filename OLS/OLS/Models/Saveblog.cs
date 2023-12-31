﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OLS.Models
{
    public partial class SaveBlog
    {
        [Key]
        public int SaveBlogId { get; set; }
        public int BlogBlogId { get; set; }
        public int UserUserId { get; set; }
        public DateTime? SavedDay { get; set; }

        public virtual Blog BlogBlog { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
