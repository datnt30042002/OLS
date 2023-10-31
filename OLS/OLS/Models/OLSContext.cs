using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OLS.Models
{
    public partial class OLSContext : DbContext
    {
        public OLSContext()
        {
        }

        public OLSContext(DbContextOptions<OLSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Ask> Asks { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogComment> BlogComments { get; set; } = null!;
        public virtual DbSet<BlogTag> BlogTags { get; set; } = null!;
        public virtual DbSet<BlogTopic> BlogTopics { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseEnrolled> CourseEnrolleds { get; set; } = null!;
        public virtual DbSet<Dicuss> Dicusses { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<LearningPath> LearningPaths { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<LikeComment> LikeComments { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<ReceiveNotification> ReceiveNotifications { get; set; } = null!;
        public virtual DbSet<Reply> Replies { get; set; } = null!;
        public virtual DbSet<SaveBlog> SaveBlogs { get; set; } = null!;
        public virtual DbSet<SaveLike> SaveLikes { get; set; } = null!;
        public virtual DbSet<SendNotification> SendNotifications { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server =ADMIN\\SQLEXPRESS; database = OLS;uid=sa;pwd=0212;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.AnswerContent).HasMaxLength(1500);

                entity.Property(e => e.QuestionQuestionId).HasColumnName("Question_QuestionID");

                entity.HasOne(d => d.QuestionQuestion)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<Ask>(entity =>
            {
                entity.ToTable("Ask");

                entity.Property(e => e.AskId).HasColumnName("AskID");

                entity.Property(e => e.AskContent).HasMaxLength(500);

                entity.Property(e => e.DicussDicussId).HasColumnName("Dicuss_DicussID");

                entity.HasOne(d => d.DicussDicuss)
                    .WithMany(p => p.Asks)
                    .HasForeignKey(d => d.DicussDicussId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ask_Dicuss");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.BlogContent).HasColumnType("text");

                entity.Property(e => e.BlogImage).HasMaxLength(150);

                entity.Property(e => e.BlogTagBlogTagId).HasColumnName("BlogTag_BlogTagID");

                entity.Property(e => e.BlogTitle).HasMaxLength(150);

                entity.Property(e => e.BlogTopicBlogTopicId).HasColumnName("BlogTopic_BlogTopicID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogTagBlogTag)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogTagBlogTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_BlogTag");

                entity.HasOne(d => d.BlogTopicBlogTopic)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogTopicBlogTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_BlogTopic");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_User");
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.ToTable("BlogComment");

                entity.Property(e => e.BlogCommentId).HasColumnName("BlogCommentID");

                entity.Property(e => e.BlogBlogId).HasColumnName("Blog_BlogID");

                entity.Property(e => e.CommentContent).HasColumnType("text");

                entity.Property(e => e.OriginCommentId).HasColumnName("OriginCommentID");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.ReplyToUser).HasColumnName("Reply_To_User");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogBlog)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.BlogBlogId)
                    .HasConstraintName("FK_BlogComment_Blog");

                entity.HasOne(d => d.ReplyToUserNavigation)
                    .WithMany(p => p.BlogCommentReplyToUserNavigations)
                    .HasForeignKey(d => d.ReplyToUser)
                    .HasConstraintName("FK_BlogComment_User1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.BlogCommentUserUsers)
                    .HasForeignKey(d => d.UserUserId)
                    .HasConstraintName("FK_BlogComment_User");
            });

            modelBuilder.Entity<BlogTag>(entity =>
            {
                entity.ToTable("BlogTag");

                entity.Property(e => e.BlogTagId).HasColumnName("BlogTagID");

                entity.Property(e => e.BlogTagName).HasMaxLength(150);
            });

            modelBuilder.Entity<BlogTopic>(entity =>
            {
                entity.ToTable("BlogTopic");

                entity.Property(e => e.BlogTopicId).HasColumnName("BlogTopicID");

                entity.Property(e => e.BlogTopicName).HasMaxLength(150);
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("Chapter");

                entity.Property(e => e.ChapterId).HasColumnName("ChapterID");

                entity.Property(e => e.ChapterName).HasMaxLength(150);

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chapter_Course");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseInfomation).HasMaxLength(500);

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.LearningPathLearningPathId).HasColumnName("LearningPath_LearningPathID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.Property(e => e.VideoIntro).HasMaxLength(150);

                entity.HasOne(d => d.LearningPathLearningPath)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LearningPathLearningPathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_LearningPath");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_User");
            });

            modelBuilder.Entity<CourseEnrolled>(entity =>
            {
                entity.ToTable("CourseEnrolled");

                entity.Property(e => e.CourseEnrolledId).HasColumnName("CourseEnrolledID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.EnrolledDate).HasColumnType("datetime");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.CourseEnrolleds)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseEnrolled_Course");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.CourseEnrolleds)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseEnrolled_User");
            });

            modelBuilder.Entity<Dicuss>(entity =>
            {
                entity.ToTable("Dicuss");

                entity.Property(e => e.DicussId).HasColumnName("DicussID");

                entity.Property(e => e.LessonLessonId).HasColumnName("Lesson_LessonID");

                entity.HasOne(d => d.LessonLesson)
                    .WithMany(p => p.Dicusses)
                    .HasForeignKey(d => d.LessonLessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dicuss_Lesson");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.FeedbackContent).HasMaxLength(1000);

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Course");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_User");
            });

            modelBuilder.Entity<LearningPath>(entity =>
            {
                entity.ToTable("LearningPath");

                entity.Property(e => e.LearningPathId).HasColumnName("LearningPathID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.LearningPathName).HasMaxLength(100);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.ChapterChapterId).HasColumnName("Chapter_ChapterID");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.Video).HasMaxLength(150);

                entity.HasOne(d => d.ChapterChapter)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ChapterChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Chapter");
            });

            modelBuilder.Entity<LikeComment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LikeComment");

                entity.Property(e => e.BlogCommentBlogCommentId).HasColumnName("BlogComment_BlogCommentID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogCommentBlogComment)
                    .WithMany()
                    .HasForeignKey(d => d.BlogCommentBlogCommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikeComment_BlogComment");

                entity.HasOne(d => d.UserUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikeComment_User");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Note");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.ChapterChapterId).HasColumnName("Chapter_ChapterID");

                entity.Property(e => e.NoteContent).HasMaxLength(500);

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.ChapterChapter)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ChapterChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_Chapter");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_User");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CorrectAnswer).HasMaxLength(2000);

                entity.Property(e => e.QuizQuizId).HasColumnName("Quiz_QuizID");

                entity.HasOne(d => d.QuizQuiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizQuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Quiz");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.Property(e => e.ChapterChapterId).HasColumnName("Chapter_ChapterID");

                entity.HasOne(d => d.ChapterChapter)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.ChapterChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_Chapter");
            });

            modelBuilder.Entity<ReceiveNotification>(entity =>
            {
                entity.ToTable("ReceiveNotification");

                entity.Property(e => e.ReceiveNotificationId).HasColumnName("ReceiveNotificationID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.SendNotificationSendNotificationId).HasColumnName("SendNotification_SendNotificationID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.ReceiveNotifications)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiveNotification_Course");

                entity.HasOne(d => d.SendNotificationSendNotification)
                    .WithMany(p => p.ReceiveNotifications)
                    .HasForeignKey(d => d.SendNotificationSendNotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiveNotification_SendNotification");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.ReceiveNotifications)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiveNotification_User");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.AskAskId).HasColumnName("Ask_AskID");

                entity.Property(e => e.ReplyContent).HasMaxLength(2000);

                entity.HasOne(d => d.AskAsk)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.AskAskId)
                    .HasConstraintName("FK_Reply_Ask");
            });

            modelBuilder.Entity<SaveBlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SaveBlog");

                entity.Property(e => e.BlogBlogId).HasColumnName("Blog_BlogID");

                entity.Property(e => e.SavedDay).HasColumnType("datetime");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogBlog)
                    .WithMany()
                    .HasForeignKey(d => d.BlogBlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaveBlog_Blog");

                entity.HasOne(d => d.UserUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaveBlog_User");
            });

            modelBuilder.Entity<SaveLike>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SaveLike");

                entity.Property(e => e.BlogBlogId).HasColumnName("Blog_BlogID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogBlog)
                    .WithMany()
                    .HasForeignKey(d => d.BlogBlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaveLike_Blog");

                entity.HasOne(d => d.UserUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaveLike_User");
            });

            modelBuilder.Entity<SendNotification>(entity =>
            {
                entity.ToTable("SendNotification");

                entity.Property(e => e.SendNotificationId).HasColumnName("SendNotificationID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.NotificationContent).HasMaxLength(1500);

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.SendNotifications)
                    .HasForeignKey(d => d.CourseCourseId)
                    .HasConstraintName("FK_SendNotification_Course");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.SendNotifications)
                    .HasForeignKey(d => d.UserUserId)
                    .HasConstraintName("FK_SendNotification_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.BackgroundImage).HasMaxLength(150);

                entity.Property(e => e.Bio).HasMaxLength(2500);

                entity.Property(e => e.CodeVerify).HasMaxLength(50);

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Facebook).HasMaxLength(50);

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(50)
                    .HasColumnName("FacebookID");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Github).HasMaxLength(50);

                entity.Property(e => e.GithubId)
                    .HasMaxLength(50)
                    .HasColumnName("GithubID");

                entity.Property(e => e.GmailId)
                    .HasMaxLength(50)
                    .HasColumnName("GmailID");

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(11);

                entity.Property(e => e.UserRoleRoleId).HasColumnName("UserRole_RoleID");

                entity.HasOne(d => d.UserRoleRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("UserRole");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
