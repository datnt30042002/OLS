using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class User
    {
        public User()
        {
            Courses = new HashSet<Course>();
        }

        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Facebook { get; set; }
        public string? Github { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? BackgroundImage { get; set; }
        public string? GmailId { get; set; }
        public string? FacebookId { get; set; }
        public string? GithubId { get; set; }
        public int? Status { get; set; }
        public string? CodeVerify { get; set; }
        public int UserRoleRoleId { get; set; }

        public virtual UserRole UserRoleRole { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; }
    }
}
