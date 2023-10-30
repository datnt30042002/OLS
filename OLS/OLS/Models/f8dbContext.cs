using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OLS.Models
{
    public partial class F8DBContext : DbContext
    {
        public F8DBContext()
        {
        }

        public F8DBContext(DbContextOptions<F8DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Ask> Asks { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogComment> BlogComments { get; set; } = null!;
        public virtual DbSet<BlogTag> BlogTags { get; set; } = null!;
        public virtual DbSet<BlogTopic> BlogTopics { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseEnroll> CourseEnrolls { get; set; } = null!;
        public virtual DbSet<Dicuss> Dicusses { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<LessonDetail> LessonDetails { get; set; } = null!;
        public virtual DbSet<LikeComment> LikeComments { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Reply> Replies { get; set; } = null!;
        public virtual DbSet<SaveBlog> SaveBlogs { get; set; } = null!;
        public virtual DbSet<SaveLike> SaveLikes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server =ADMIN\\SQLEXPRESS; database = F8DB;uid=sa;pwd=0212;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Answer");

                entity.Property(e => e.Answer1)
                    .HasMaxLength(50)
                    .HasColumnName("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.QuestionQuestionId).HasColumnName("Question_QuestionID");

                entity.HasOne(d => d.QuestionQuestion)
                    .WithMany()
                    .HasForeignKey(d => d.QuestionQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<Ask>(entity =>
            {
                entity.ToTable("Ask");

                entity.Property(e => e.AskId).HasColumnName("AskID");

                entity.Property(e => e.AskDetail).HasMaxLength(500);

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

                entity.Property(e => e.BlogDetail).HasMaxLength(2000);

                entity.Property(e => e.BlogImage).HasMaxLength(150);

                entity.Property(e => e.BlogTagBlogTagId).HasColumnName("BlogTag_BlogTagID");

                entity.Property(e => e.BlogTitle).HasMaxLength(100);

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
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.ToTable("BlogComment");

                entity.Property(e => e.BlogCommentId).HasColumnName("BlogCommentID");

                entity.Property(e => e.BlogContent)
                    .HasMaxLength(2000)
                    .HasColumnName("Blog_Content");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.BlogLevel).HasColumnName("Blog_Level");

                entity.Property(e => e.OriginCommentId).HasColumnName("Origin_Comment_ID");

                entity.Property(e => e.Publish).HasColumnType("datetime");

                entity.Property(e => e.ReplyToUser).HasColumnName("Reply_To_User");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<BlogTag>(entity =>
            {
                entity.ToTable("BlogTag");

                entity.Property(e => e.BlogTagId).HasColumnName("BlogTagID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<BlogTopic>(entity =>
            {
                entity.ToTable("BlogTopic");

                entity.Property(e => e.BlogTopicId).HasColumnName("BlogTopicID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryImage).HasMaxLength(150);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CategoryCategoryId).HasColumnName("Category_CategoryID");

                entity.Property(e => e.CourseInfo).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.Property(e => e.VideoIntro).HasMaxLength(200);

                entity.HasOne(d => d.CategoryCategory)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Category");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_User");
            });

            modelBuilder.Entity<CourseEnroll>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CourseEnroll");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.CourseEnrollId).HasColumnName("CourseEnrollID");

                entity.Property(e => e.EnrollDate).HasColumnType("date");

                entity.Property(e => e.LessonCurrent).HasMaxLength(150);

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany()
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseEnroll_Course");

                entity.HasOne(d => d.UserUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseEnroll_User");
            });

            modelBuilder.Entity<Dicuss>(entity =>
            {
                entity.ToTable("Dicuss");

                entity.Property(e => e.DicussId).HasColumnName("DicussID");

                entity.Property(e => e.LessonDetailLessonDetailId).HasColumnName("LessonDetail_LessonDetailID");

                entity.HasOne(d => d.LessonDetailLessonDetail)
                    .WithMany(p => p.Dicusses)
                    .HasForeignKey(d => d.LessonDetailLessonDetailId)
                    .HasConstraintName("FK_Dicuss_LessonDetail");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.Feedback1)
                    .HasMaxLength(500)
                    .HasColumnName("Feedback");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Course");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Course");
            });

            modelBuilder.Entity<LessonDetail>(entity =>
            {
                entity.ToTable("LessonDetail");

                entity.Property(e => e.LessonDetailId).HasColumnName("LessonDetailID");

                entity.Property(e => e.LessonLessonId).HasColumnName("Lesson_LessonID");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Video).HasMaxLength(100);

                entity.HasOne(d => d.LessonLesson)
                    .WithMany(p => p.LessonDetails)
                    .HasForeignKey(d => d.LessonLessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LessonDetail_Lesson");
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

                entity.Property(e => e.LessonLessonId).HasColumnName("Lesson_LessonID");

                entity.HasOne(d => d.LessonLesson)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.LessonLessonId)
                    .HasConstraintName("FK_Quiz_Lesson");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.AskAskId).HasColumnName("Ask_AskID");

                entity.Property(e => e.ReplyDetail).HasMaxLength(500);

                entity.HasOne(d => d.AskAsk)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.AskAskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Ask");
            });

            modelBuilder.Entity<SaveBlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SaveBlog");

                entity.Property(e => e.BlogBlogId).HasColumnName("Blog_BlogID");

                entity.Property(e => e.SaveDay)
                    .HasColumnType("datetime")
                    .HasColumnName("Save_Day");

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

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.BackgroundImage).HasMaxLength(200);

                entity.Property(e => e.Bio).HasMaxLength(200);

                entity.Property(e => e.CodeVerify).HasMaxLength(150);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Facebook).HasMaxLength(200);

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(200)
                    .HasColumnName("FacebookID");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Github).HasMaxLength(200);

                entity.Property(e => e.GithubId)
                    .HasMaxLength(200)
                    .HasColumnName("GithubID");

                entity.Property(e => e.GmailId)
                    .HasMaxLength(200)
                    .HasColumnName("GmailID");

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsFixedLength();

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

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
