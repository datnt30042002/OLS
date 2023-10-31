using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class User
    {
        public User()
        {
            BlogCommentReplyToUserNavigations = new HashSet<BlogComment>();
            BlogCommentUserUsers = new HashSet<BlogComment>();
            Blogs = new HashSet<Blog>();
            CourseEnrolleds = new HashSet<CourseEnrolled>();
            Courses = new HashSet<Course>();
            Feedbacks = new HashSet<Feedback>();
            Notes = new HashSet<Note>();
            ReceiveNotifications = new HashSet<ReceiveNotification>();
            SendNotifications = new HashSet<SendNotification>();
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
        public virtual ICollection<BlogComment> BlogCommentReplyToUserNavigations { get; set; }
        public virtual ICollection<BlogComment> BlogCommentUserUsers { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<CourseEnrolled> CourseEnrolleds { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<ReceiveNotification> ReceiveNotifications { get; set; }
        public virtual ICollection<SendNotification> SendNotifications { get; set; }
    }
}
