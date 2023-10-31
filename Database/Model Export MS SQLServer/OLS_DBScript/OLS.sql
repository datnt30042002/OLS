USE [master]
GO
/****** Object:  Database [OLS]    Script Date: 31/10/2023 7:30:48 PM ******/
CREATE DATABASE [OLS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OLS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OLS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OLS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OLS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OLS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OLS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OLS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OLS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OLS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OLS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OLS] SET ARITHABORT OFF 
GO
ALTER DATABASE [OLS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OLS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OLS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OLS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OLS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OLS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OLS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OLS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OLS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OLS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OLS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OLS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OLS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OLS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OLS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OLS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OLS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OLS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OLS] SET  MULTI_USER 
GO
ALTER DATABASE [OLS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OLS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OLS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OLS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OLS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OLS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OLS] SET QUERY_STORE = ON
GO
ALTER DATABASE [OLS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OLS]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[AnswerID] [int] IDENTITY(1,1) NOT NULL,
	[AnswerContent] [nvarchar](1500) NULL,
	[Question_QuestionID] [int] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ask]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ask](
	[AskID] [int] IDENTITY(1,1) NOT NULL,
	[AskContent] [nvarchar](500) NULL,
	[Dicuss_DicussID] [int] NOT NULL,
 CONSTRAINT [PK_Ask] PRIMARY KEY CLUSTERED 
(
	[AskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](150) NULL,
	[BlogImage] [nvarchar](150) NULL,
	[BlogContent] [text] NULL,
	[PostDate] [datetime] NULL,
	[Status] [int] NULL,
	[ReadTime] [time](7) NULL,
	[BlogTopic_BlogTopicID] [int] NOT NULL,
	[BlogTag_BlogTagID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogComment]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComment](
	[BlogCommentID] [int] IDENTITY(1,1) NOT NULL,
	[BlogCommentLevel] [int] NULL,
	[OriginCommentID] [int] NULL,
	[CommentContent] [text] NULL,
	[PublishDate] [datetime] NULL,
	[Reply_To_User] [int] NULL,
	[Blog_BlogID] [int] NULL,
	[User_UserID] [int] NULL,
 CONSTRAINT [PK_BlogComment] PRIMARY KEY CLUSTERED 
(
	[BlogCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogTag]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTag](
	[BlogTagID] [int] IDENTITY(1,1) NOT NULL,
	[BlogTagName] [nvarchar](150) NULL,
 CONSTRAINT [PK_BlogTag] PRIMARY KEY CLUSTERED 
(
	[BlogTagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogTopic]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTopic](
	[BlogTopicID] [int] IDENTITY(1,1) NOT NULL,
	[BlogTopicName] [nvarchar](150) NULL,
 CONSTRAINT [PK_BlogTopic] PRIMARY KEY CLUSTERED 
(
	[BlogTopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chapter]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapter](
	[ChapterID] [int] IDENTITY(1,1) NOT NULL,
	[ChapterName] [nvarchar](150) NULL,
	[Course_CourseID] [int] NOT NULL,
 CONSTRAINT [PK_Chapter] PRIMARY KEY CLUSTERED 
(
	[ChapterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[CourseInfomation] [nvarchar](500) NULL,
	[Image] [nvarchar](150) NULL,
	[VideoIntro] [nvarchar](150) NULL,
	[Fee] [int] NULL,
	[Status] [int] NULL,
	[LearningPath_LearningPathID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseEnrolled]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseEnrolled](
	[CourseEnrolledID] [int] IDENTITY(1,1) NOT NULL,
	[EnrolledDate] [datetime] NULL,
	[Status] [int] NULL,
	[Course_CourseID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
 CONSTRAINT [PK_CourseEnrolled] PRIMARY KEY CLUSTERED 
(
	[CourseEnrolledID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dicuss]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dicuss](
	[DicussID] [int] IDENTITY(1,1) NOT NULL,
	[Lesson_LessonID] [int] NOT NULL,
 CONSTRAINT [PK_Dicuss] PRIMARY KEY CLUSTERED 
(
	[DicussID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[FeedbackContent] [nvarchar](1000) NULL,
	[RateStar] [int] NULL,
	[User_UserID] [int] NOT NULL,
	[Course_CourseID] [int] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LearningPath]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LearningPath](
	[LearningPathID] [int] IDENTITY(1,1) NOT NULL,
	[LearningPathName] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](150) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_LearningPath] PRIMARY KEY CLUSTERED 
(
	[LearningPathID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[LessonID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Video] [nvarchar](150) NULL,
	[Time] [time](7) NULL,
	[Chapter_ChapterID] [int] NOT NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikeComment]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikeComment](
	[User_UserID] [int] NOT NULL,
	[BlogComment_BlogCommentID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[NoteID] [int] IDENTITY(1,1) NOT NULL,
	[NoteContent] [nvarchar](500) NULL,
	[Chapter_ChapterID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[CorrectAnswer] [nvarchar](2000) NULL,
	[Quiz_QuizID] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[QuizID] [int] IDENTITY(1,1) NOT NULL,
	[Chapter_ChapterID] [int] NOT NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[QuizID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiveNotification]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveNotification](
	[ReceiveNotificationID] [int] IDENTITY(1,1) NOT NULL,
	[SendNotification_SendNotificationID] [int] NOT NULL,
	[Course_CourseID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
 CONSTRAINT [PK_ReceiveNotification] PRIMARY KEY CLUSTERED 
(
	[ReceiveNotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply](
	[ReplyID] [int] IDENTITY(1,1) NOT NULL,
	[ReplyContent] [nvarchar](2000) NULL,
	[Ask_AskID] [int] NULL,
 CONSTRAINT [PK_Reply] PRIMARY KEY CLUSTERED 
(
	[ReplyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaveBlog]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaveBlog](
	[Blog_BlogID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
	[SavedDay] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaveLike]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaveLike](
	[Blog_BlogID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SendNotification]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SendNotification](
	[SendNotificationID] [int] IDENTITY(1,1) NOT NULL,
	[NotificationContent] [nvarchar](1500) NULL,
	[Course_CourseID] [int] NULL,
	[User_UserID] [int] NULL,
 CONSTRAINT [PK_SendNotification] PRIMARY KEY CLUSTERED 
(
	[SendNotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Facebook] [nvarchar](50) NULL,
	[Github] [nvarchar](50) NULL,
	[Phone] [nvarchar](11) NULL,
	[Password] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Dob] [datetime] NULL,
	[Address] [nvarchar](100) NULL,
	[Bio] [nvarchar](2500) NULL,
	[Image] [nvarchar](150) NULL,
	[BackgroundImage] [nvarchar](150) NULL,
	[GmailID] [nvarchar](50) NULL,
	[FacebookID] [nvarchar](50) NULL,
	[GithubID] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[CodeVerify] [nvarchar](50) NULL,
	[UserRole_RoleID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 31/10/2023 7:30:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([Question_QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Ask]  WITH CHECK ADD  CONSTRAINT [FK_Ask_Dicuss] FOREIGN KEY([Dicuss_DicussID])
REFERENCES [dbo].[Dicuss] ([DicussID])
GO
ALTER TABLE [dbo].[Ask] CHECK CONSTRAINT [FK_Ask_Dicuss]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_BlogTag] FOREIGN KEY([BlogTag_BlogTagID])
REFERENCES [dbo].[BlogTag] ([BlogTagID])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_BlogTag]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_BlogTopic] FOREIGN KEY([BlogTopic_BlogTopicID])
REFERENCES [dbo].[BlogTopic] ([BlogTopicID])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_BlogTopic]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_User]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_Blog] FOREIGN KEY([Blog_BlogID])
REFERENCES [dbo].[Blog] ([BlogID])
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_Blog]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_User]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_User1] FOREIGN KEY([Reply_To_User])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_User1]
GO
ALTER TABLE [dbo].[Chapter]  WITH CHECK ADD  CONSTRAINT [FK_Chapter_Course] FOREIGN KEY([Course_CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Chapter] CHECK CONSTRAINT [FK_Chapter_Course]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_LearningPath] FOREIGN KEY([LearningPath_LearningPathID])
REFERENCES [dbo].[LearningPath] ([LearningPathID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_LearningPath]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_User]
GO
ALTER TABLE [dbo].[CourseEnrolled]  WITH CHECK ADD  CONSTRAINT [FK_CourseEnrolled_Course] FOREIGN KEY([Course_CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[CourseEnrolled] CHECK CONSTRAINT [FK_CourseEnrolled_Course]
GO
ALTER TABLE [dbo].[CourseEnrolled]  WITH CHECK ADD  CONSTRAINT [FK_CourseEnrolled_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[CourseEnrolled] CHECK CONSTRAINT [FK_CourseEnrolled_User]
GO
ALTER TABLE [dbo].[Dicuss]  WITH CHECK ADD  CONSTRAINT [FK_Dicuss_Lesson] FOREIGN KEY([Lesson_LessonID])
REFERENCES [dbo].[Lesson] ([LessonID])
GO
ALTER TABLE [dbo].[Dicuss] CHECK CONSTRAINT [FK_Dicuss_Lesson]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Course] FOREIGN KEY([Course_CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Course]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Chapter] FOREIGN KEY([Chapter_ChapterID])
REFERENCES [dbo].[Chapter] ([ChapterID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Chapter]
GO
ALTER TABLE [dbo].[LikeComment]  WITH CHECK ADD  CONSTRAINT [FK_LikeComment_BlogComment] FOREIGN KEY([BlogComment_BlogCommentID])
REFERENCES [dbo].[BlogComment] ([BlogCommentID])
GO
ALTER TABLE [dbo].[LikeComment] CHECK CONSTRAINT [FK_LikeComment_BlogComment]
GO
ALTER TABLE [dbo].[LikeComment]  WITH CHECK ADD  CONSTRAINT [FK_LikeComment_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[LikeComment] CHECK CONSTRAINT [FK_LikeComment_User]
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Chapter] FOREIGN KEY([Chapter_ChapterID])
REFERENCES [dbo].[Chapter] ([ChapterID])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Chapter]
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_User]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Quiz] FOREIGN KEY([Quiz_QuizID])
REFERENCES [dbo].[Quiz] ([QuizID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Quiz]
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Chapter] FOREIGN KEY([Chapter_ChapterID])
REFERENCES [dbo].[Chapter] ([ChapterID])
GO
ALTER TABLE [dbo].[Quiz] CHECK CONSTRAINT [FK_Quiz_Chapter]
GO
ALTER TABLE [dbo].[ReceiveNotification]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveNotification_Course] FOREIGN KEY([Course_CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[ReceiveNotification] CHECK CONSTRAINT [FK_ReceiveNotification_Course]
GO
ALTER TABLE [dbo].[ReceiveNotification]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveNotification_SendNotification] FOREIGN KEY([SendNotification_SendNotificationID])
REFERENCES [dbo].[SendNotification] ([SendNotificationID])
GO
ALTER TABLE [dbo].[ReceiveNotification] CHECK CONSTRAINT [FK_ReceiveNotification_SendNotification]
GO
ALTER TABLE [dbo].[ReceiveNotification]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveNotification_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[ReceiveNotification] CHECK CONSTRAINT [FK_ReceiveNotification_User]
GO
ALTER TABLE [dbo].[Reply]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Ask] FOREIGN KEY([Ask_AskID])
REFERENCES [dbo].[Ask] ([AskID])
GO
ALTER TABLE [dbo].[Reply] CHECK CONSTRAINT [FK_Reply_Ask]
GO
ALTER TABLE [dbo].[SaveBlog]  WITH CHECK ADD  CONSTRAINT [FK_SaveBlog_Blog] FOREIGN KEY([Blog_BlogID])
REFERENCES [dbo].[Blog] ([BlogID])
GO
ALTER TABLE [dbo].[SaveBlog] CHECK CONSTRAINT [FK_SaveBlog_Blog]
GO
ALTER TABLE [dbo].[SaveBlog]  WITH CHECK ADD  CONSTRAINT [FK_SaveBlog_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[SaveBlog] CHECK CONSTRAINT [FK_SaveBlog_User]
GO
ALTER TABLE [dbo].[SaveLike]  WITH CHECK ADD  CONSTRAINT [FK_SaveLike_Blog] FOREIGN KEY([Blog_BlogID])
REFERENCES [dbo].[Blog] ([BlogID])
GO
ALTER TABLE [dbo].[SaveLike] CHECK CONSTRAINT [FK_SaveLike_Blog]
GO
ALTER TABLE [dbo].[SaveLike]  WITH CHECK ADD  CONSTRAINT [FK_SaveLike_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[SaveLike] CHECK CONSTRAINT [FK_SaveLike_User]
GO
ALTER TABLE [dbo].[SendNotification]  WITH CHECK ADD  CONSTRAINT [FK_SendNotification_Course] FOREIGN KEY([Course_CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[SendNotification] CHECK CONSTRAINT [FK_SendNotification_Course]
GO
ALTER TABLE [dbo].[SendNotification]  WITH CHECK ADD  CONSTRAINT [FK_SendNotification_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[SendNotification] CHECK CONSTRAINT [FK_SendNotification_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserRole_RoleID])
REFERENCES [dbo].[UserRole] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
USE [master]
GO
ALTER DATABASE [OLS] SET  READ_WRITE 
GO
