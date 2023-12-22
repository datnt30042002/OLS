using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OLS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogTag",
                columns: table => new
                {
                    BlogTagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTagName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTag", x => x.BlogTagID);
                });

            migrationBuilder.CreateTable(
                name: "BlogTopic",
                columns: table => new
                {
                    BlogTopicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTopicName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTopic", x => x.BlogTopicID);
                });

            migrationBuilder.CreateTable(
                name: "LearningPath",
                columns: table => new
                {
                    LearningPathID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningPathName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningPath", x => x.LearningPathID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Github = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BackgroundImage = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GmailID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FacebookID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GithubID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CodeVerify = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserRole_RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserRole",
                        column: x => x.UserRole_RoleID,
                        principalTable: "UserRole",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BlogImage = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BlogContent = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ReadTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    BlogTopic_BlogTopicID = table.Column<int>(type: "int", nullable: false),
                    BlogTag_BlogTagID = table.Column<int>(type: "int", nullable: false),
                    User_UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blog_BlogTag",
                        column: x => x.BlogTag_BlogTagID,
                        principalTable: "BlogTag",
                        principalColumn: "BlogTagID");
                    table.ForeignKey(
                        name: "FK_Blog_BlogTopic",
                        column: x => x.BlogTopic_BlogTopicID,
                        principalTable: "BlogTopic",
                        principalColumn: "BlogTopicID");
                    table.ForeignKey(
                        name: "FK_Blog_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CourseInfomation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    VideoIntro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Fee = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    LearningPath_LearningPathID = table.Column<int>(type: "int", nullable: false),
                    User_UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_LearningPath",
                        column: x => x.LearningPath_LearningPathID,
                        principalTable: "LearningPath",
                        principalColumn: "LearningPathID");
                    table.ForeignKey(
                        name: "FK_Course_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "BlogComment",
                columns: table => new
                {
                    BlogCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogCommentLevel = table.Column<int>(type: "int", nullable: true),
                    OriginCommentID = table.Column<int>(type: "int", nullable: true),
                    CommentContent = table.Column<string>(type: "text", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reply_To_User = table.Column<int>(type: "int", nullable: true),
                    Blog_BlogID = table.Column<int>(type: "int", nullable: true),
                    User_UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComment", x => x.BlogCommentID);
                    table.ForeignKey(
                        name: "FK_BlogComment_Blog",
                        column: x => x.Blog_BlogID,
                        principalTable: "Blog",
                        principalColumn: "BlogID");
                    table.ForeignKey(
                        name: "FK_BlogComment_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_BlogComment_User1",
                        column: x => x.Reply_To_User,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "SaveBlog",
                columns: table => new
                {
                    SaveBlogId = table.Column<int>(type: "int", nullable: false),
                    Blog_BlogID = table.Column<int>(type: "int", nullable: false),
                    User_UserID = table.Column<int>(type: "int", nullable: false),
                    SavedDay = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SaveBlog_Blog",
                        column: x => x.Blog_BlogID,
                        principalTable: "Blog",
                        principalColumn: "BlogID");
                    table.ForeignKey(
                        name: "FK_SaveBlog_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "SaveLike",
                columns: table => new
                {
                    Blog_BlogID = table.Column<int>(type: "int", nullable: false),
                    User_UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SaveLike_Blog",
                        column: x => x.Blog_BlogID,
                        principalTable: "Blog",
                        principalColumn: "BlogID");
                    table.ForeignKey(
                        name: "FK_SaveLike_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    ChapterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Course_CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.ChapterID);
                    table.ForeignKey(
                        name: "FK_Chapter_Course",
                        column: x => x.Course_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrolled",
                columns: table => new
                {
                    CourseEnrolledID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrolledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Course_CourseID = table.Column<int>(type: "int", nullable: false),
                    User_UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrolled", x => x.CourseEnrolledID);
                    table.ForeignKey(
                        name: "FK_CourseEnrolled_Course",
                        column: x => x.Course_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_CourseEnrolled_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RateStar = table.Column<int>(type: "int", nullable: true),
                    User_UserID = table.Column<int>(type: "int", nullable: false),
                    Course_CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK_Feedback_Course",
                        column: x => x.Course_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_Feedback_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "SendNotification",
                columns: table => new
                {
                    SendNotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationContent = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Course_CourseID = table.Column<int>(type: "int", nullable: true),
                    User_UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendNotification", x => x.SendNotificationID);
                    table.ForeignKey(
                        name: "FK_SendNotification_Course",
                        column: x => x.Course_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_SendNotification_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "LikeComment",
                columns: table => new
                {
                    User_UserID = table.Column<int>(type: "int", nullable: false),
                    BlogComment_BlogCommentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LikeComment_BlogComment",
                        column: x => x.BlogComment_BlogCommentID,
                        principalTable: "BlogComment",
                        principalColumn: "BlogCommentID");
                    table.ForeignKey(
                        name: "FK_LikeComment_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Video = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Chapter_ChapterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK_Lesson_Chapter",
                        column: x => x.Chapter_ChapterID,
                        principalTable: "Chapter",
                        principalColumn: "ChapterID");
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Chapter_ChapterID = table.Column<int>(type: "int", nullable: false),
                    User_UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_Note_Chapter",
                        column: x => x.Chapter_ChapterID,
                        principalTable: "Chapter",
                        principalColumn: "ChapterID");
                    table.ForeignKey(
                        name: "FK_Note_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chapter_ChapterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizID);
                    table.ForeignKey(
                        name: "FK_Quiz_Chapter",
                        column: x => x.Chapter_ChapterID,
                        principalTable: "Chapter",
                        principalColumn: "ChapterID");
                });

            migrationBuilder.CreateTable(
                name: "ReceiveNotification",
                columns: table => new
                {
                    ReceiveNotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendNotification_SendNotificationID = table.Column<int>(type: "int", nullable: false),
                    Course_CourseID = table.Column<int>(type: "int", nullable: false),
                    User_UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiveNotification", x => x.ReceiveNotificationID);
                    table.ForeignKey(
                        name: "FK_ReceiveNotification_Course",
                        column: x => x.Course_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_ReceiveNotification_SendNotification",
                        column: x => x.SendNotification_SendNotificationID,
                        principalTable: "SendNotification",
                        principalColumn: "SendNotificationID");
                    table.ForeignKey(
                        name: "FK_ReceiveNotification_User",
                        column: x => x.User_UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Dicuss",
                columns: table => new
                {
                    DicussID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lesson_LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dicuss", x => x.DicussID);
                    table.ForeignKey(
                        name: "FK_Dicuss_Lesson",
                        column: x => x.Lesson_LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Quiz_QuizID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Question_Quiz",
                        column: x => x.Quiz_QuizID,
                        principalTable: "Quiz",
                        principalColumn: "QuizID");
                });

            migrationBuilder.CreateTable(
                name: "Ask",
                columns: table => new
                {
                    AskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AskContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Dicuss_DicussID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ask", x => x.AskID);
                    table.ForeignKey(
                        name: "FK_Ask_Dicuss",
                        column: x => x.Dicuss_DicussID,
                        principalTable: "Dicuss",
                        principalColumn: "DicussID");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerContent = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Question_QuestionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answer_Question",
                        column: x => x.Question_QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID");
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    ReplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyContent = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Ask_AskID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ReplyID);
                    table.ForeignKey(
                        name: "FK_Reply_Ask",
                        column: x => x.Ask_AskID,
                        principalTable: "Ask",
                        principalColumn: "AskID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_Question_QuestionID",
                table: "Answer",
                column: "Question_QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ask_Dicuss_DicussID",
                table: "Ask",
                column: "Dicuss_DicussID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogTag_BlogTagID",
                table: "Blog",
                column: "BlogTag_BlogTagID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogTopic_BlogTopicID",
                table: "Blog",
                column: "BlogTopic_BlogTopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_User_UserID",
                table: "Blog",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_Blog_BlogID",
                table: "BlogComment",
                column: "Blog_BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_Reply_To_User",
                table: "BlogComment",
                column: "Reply_To_User");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_User_UserID",
                table: "BlogComment",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_Course_CourseID",
                table: "Chapter",
                column: "Course_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LearningPath_LearningPathID",
                table: "Course",
                column: "LearningPath_LearningPathID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_User_UserID",
                table: "Course",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolled_Course_CourseID",
                table: "CourseEnrolled",
                column: "Course_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolled_User_UserID",
                table: "CourseEnrolled",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Dicuss_Lesson_LessonID",
                table: "Dicuss",
                column: "Lesson_LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Course_CourseID",
                table: "Feedback",
                column: "Course_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_User_UserID",
                table: "Feedback",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Chapter_ChapterID",
                table: "Lesson",
                column: "Chapter_ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComment_BlogComment_BlogCommentID",
                table: "LikeComment",
                column: "BlogComment_BlogCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComment_User_UserID",
                table: "LikeComment",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_Chapter_ChapterID",
                table: "Note",
                column: "Chapter_ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_User_UserID",
                table: "Note",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Quiz_QuizID",
                table: "Question",
                column: "Quiz_QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_Chapter_ChapterID",
                table: "Quiz",
                column: "Chapter_ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveNotification_Course_CourseID",
                table: "ReceiveNotification",
                column: "Course_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveNotification_SendNotification_SendNotificationID",
                table: "ReceiveNotification",
                column: "SendNotification_SendNotificationID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveNotification_User_UserID",
                table: "ReceiveNotification",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_Ask_AskID",
                table: "Reply",
                column: "Ask_AskID");

            migrationBuilder.CreateIndex(
                name: "IX_SaveBlog_Blog_BlogID",
                table: "SaveBlog",
                column: "Blog_BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_SaveBlog_User_UserID",
                table: "SaveBlog",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SaveLike_Blog_BlogID",
                table: "SaveLike",
                column: "Blog_BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_SaveLike_User_UserID",
                table: "SaveLike",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SendNotification_Course_CourseID",
                table: "SendNotification",
                column: "Course_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_SendNotification_User_UserID",
                table: "SendNotification",
                column: "User_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRole_RoleID",
                table: "User",
                column: "UserRole_RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "CourseEnrolled");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "LikeComment");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "ReceiveNotification");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "SaveBlog");

            migrationBuilder.DropTable(
                name: "SaveLike");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "BlogComment");

            migrationBuilder.DropTable(
                name: "SendNotification");

            migrationBuilder.DropTable(
                name: "Ask");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Dicuss");

            migrationBuilder.DropTable(
                name: "BlogTag");

            migrationBuilder.DropTable(
                name: "BlogTopic");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "LearningPath");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
