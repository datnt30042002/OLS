using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class User
    {
        public User()
        {
            Asks = new HashSet<Ask>();
            BlogCommentReplyToUserNavigations = new HashSet<BlogComment>();
            BlogCommentUserUsers = new HashSet<BlogComment>();
            Blogs = new HashSet<Blog>();
            CourseEnrolleds = new HashSet<CourseEnrolled>();
            Courses = new HashSet<Course>();
            Feedbacks = new HashSet<Feedback>();
            Notes = new HashSet<Note>();
            Notifications = new HashSet<Notification>();
            RateStars = new HashSet<RateStar>();
            Replies = new HashSet<Reply>();
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
        public int Status { get; set; }
        public string? CodeVerify { get; set; }
        public int UserRoleRoleId { get; set; }

        public virtual UserRole UserRoleRole { get; set; } = null!;
        public virtual ICollection<Ask> Asks { get; set; }
        public virtual ICollection<BlogComment> BlogCommentReplyToUserNavigations { get; set; }
        public virtual ICollection<BlogComment> BlogCommentUserUsers { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<CourseEnrolled> CourseEnrolleds { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<RateStar> RateStars { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
