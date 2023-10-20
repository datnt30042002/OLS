using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Ask
    {
        public Ask()
        {
            Replies = new HashSet<Reply>();
        }

        public int AskId { get; set; }
        public string? Content { get; set; }
        public int? DicussDicussId { get; set; }

        public virtual Dicuss? DicussDicuss { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
