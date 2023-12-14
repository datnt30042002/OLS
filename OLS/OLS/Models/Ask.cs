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
        public string? AskContent { get; set; }
        public int? UserUserId { get; set; }
        public string? Image { get; set; }
        public int? DiscussDiscussId { get; set; }

        public virtual Discuss? DiscussDiscuss { get; set; }
        public virtual User? UserUser { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
