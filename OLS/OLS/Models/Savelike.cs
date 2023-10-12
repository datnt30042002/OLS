﻿using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Savelike
    {
        public int BlogBlogId { get; set; }
        public int UserUserId { get; set; }

        public virtual Blog BlogBlog { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
