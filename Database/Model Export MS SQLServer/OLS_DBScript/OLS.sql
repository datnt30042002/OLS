USE [master]
GO
/****** Object:  Database [OLS]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[Answer]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[AnswerID] [int] IDENTITY(1,1) NOT NULL,
	[AnswerContent] [nvarchar](1500) NULL,
	[Question_QuestionID] [int] NOT NULL,
	[IsTrue] [int] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ask]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ask](
	[AskID] [int] IDENTITY(1,1) NOT NULL,
	[AskContent] [nvarchar](500) NULL,
	[User_UserID] [int] NULL,
	[Image] [nvarchar](2000) NULL,
	[Discuss_DiscussID] [int] NULL,
 CONSTRAINT [PK_Ask] PRIMARY KEY CLUSTERED 
(
	[AskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[BlogComment]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[BlogTag]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[BlogTopic]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[Chapter]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[Course]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[CourseEnrolled]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[Discuss]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discuss](
	[DiscussID] [int] IDENTITY(1,1) NOT NULL,
	[Lesson_LessonID] [int] NOT NULL,
 CONSTRAINT [PK_Discuss] PRIMARY KEY CLUSTERED 
(
	[DiscussID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[FeedbackContent] [nvarchar](1000) NULL,
	[User_UserID] [int] NOT NULL,
	[Course_CourseID] [int] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LearningPath]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[Lesson]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[LikeComment]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikeComment](
	[User_UserID] [int] NOT NULL,
	[BlogComment_BlogCommentID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[Notification]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[NotificationContent] [nvarchar](500) NULL,
	[Course_CourseID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[Quiz_QuizID] [int] NOT NULL,
	[QuestionContent] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[QuizID] [int] IDENTITY(1,1) NOT NULL,
	[Chapter_ChapterID] [int] NOT NULL,
	[QuizName] [nvarchar](500) NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[QuizID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RateStar]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateStar](
	[RateStarID] [int] IDENTITY(1,1) NOT NULL,
	[Star] [int] NULL,
	[User_UserID] [int] NOT NULL,
	[Course_CourseId] [int] NOT NULL,
 CONSTRAINT [PK_RateStar] PRIMARY KEY CLUSTERED 
(
	[RateStarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply](
	[ReplyID] [int] IDENTITY(1,1) NOT NULL,
	[ReplyContent] [nvarchar](2000) NULL,
	[Ask_AskID] [int] NULL,
	[User_UserID] [int] NULL,
	[Image] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Reply] PRIMARY KEY CLUSTERED 
(
	[ReplyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaveBlog]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[SaveLike]    Script Date: 14/12/2023 2:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaveLike](
	[Blog_BlogID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14/12/2023 2:14:07 PM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 14/12/2023 2:14:07 PM ******/
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
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([AnswerID], [AnswerContent], [Question_QuestionID], [IsTrue]) VALUES (1, N'Application Programming Interface', 4, 1)
INSERT [dbo].[Answer] ([AnswerID], [AnswerContent], [Question_QuestionID], [IsTrue]) VALUES (2, N'An Programming IOS', 4, 0)
INSERT [dbo].[Answer] ([AnswerID], [AnswerContent], [Question_QuestionID], [IsTrue]) VALUES (3, N'A Project IOS application', 4, 0)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Ask] ON 

INSERT [dbo].[Ask] ([AskID], [AskContent], [User_UserID], [Image], [Discuss_DiscussID]) VALUES (1, N'Khi nao anh ra video bai tiep theo', 2, N'https://dfstudio-d420.kxcdn.com/wordpress/wp-content/uploads/2019/06/digital_camera_photo-1080x675.jpg', NULL)
INSERT [dbo].[Ask] ([AskID], [AskContent], [User_UserID], [Image], [Discuss_DiscussID]) VALUES (2, N'Se ra mat som nhat', 2, N'16ask.png', NULL)
SET IDENTITY_INSERT [dbo].[Ask] OFF
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([BlogID], [BlogTitle], [BlogImage], [BlogContent], [PostDate], [Status], [ReadTime], [BlogTopic_BlogTopicID], [BlogTag_BlogTagID], [User_UserID]) VALUES (1, N'blog1', N'https://s.net.vn/8ixb', N'blog', CAST(N'2023-11-01T00:00:00.000' AS DateTime), 1, CAST(N'00:01:00' AS Time), 1, 1, 2)
INSERT [dbo].[Blog] ([BlogID], [BlogTitle], [BlogImage], [BlogContent], [PostDate], [Status], [ReadTime], [BlogTopic_BlogTopicID], [BlogTag_BlogTagID], [User_UserID]) VALUES (4, N'blog2', N'https://s.net.vn/8ixb', N'blog', CAST(N'2023-11-01T00:00:00.000' AS DateTime), 1, CAST(N'00:01:00' AS Time), 1, 1, 2)
INSERT [dbo].[Blog] ([BlogID], [BlogTitle], [BlogImage], [BlogContent], [PostDate], [Status], [ReadTime], [BlogTopic_BlogTopicID], [BlogTag_BlogTagID], [User_UserID]) VALUES (7, N'blog3', N'https://s.net.vn/8ixb', N'blog3', CAST(N'2023-11-02T00:00:00.000' AS DateTime), 1, CAST(N'00:00:00' AS Time), 1, 1, 2)
INSERT [dbo].[Blog] ([BlogID], [BlogTitle], [BlogImage], [BlogContent], [PostDate], [Status], [ReadTime], [BlogTopic_BlogTopicID], [BlogTag_BlogTagID], [User_UserID]) VALUES (8, N'string', N'https://s.net.vn/8ixb', N'string', CAST(N'2023-11-02T11:21:45.843' AS DateTime), 1, CAST(N'00:00:00' AS Time), 1, 1, 2)
INSERT [dbo].[Blog] ([BlogID], [BlogTitle], [BlogImage], [BlogContent], [PostDate], [Status], [ReadTime], [BlogTopic_BlogTopicID], [BlogTag_BlogTagID], [User_UserID]) VALUES (9, N'string', N'https://s.net.vn/8ixb', N'string', CAST(N'2023-11-02T11:21:45.843' AS DateTime), 1, CAST(N'00:00:00' AS Time), 1, 1, 2)
INSERT [dbo].[Blog] ([BlogID], [BlogTitle], [BlogImage], [BlogContent], [PostDate], [Status], [ReadTime], [BlogTopic_BlogTopicID], [BlogTag_BlogTagID], [User_UserID]) VALUES (10, N'testnew', N'https://s.net.vn/8ixb', N'string', CAST(N'2023-11-02T00:00:00.000' AS DateTime), 1, CAST(N'00:00:00' AS Time), 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogTag] ON 

INSERT [dbo].[BlogTag] ([BlogTagID], [BlogTagName]) VALUES (1, N'blog tag 1')
SET IDENTITY_INSERT [dbo].[BlogTag] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogTopic] ON 

INSERT [dbo].[BlogTopic] ([BlogTopicID], [BlogTopicName]) VALUES (1, N'blog topic 1')
SET IDENTITY_INSERT [dbo].[BlogTopic] OFF
GO
SET IDENTITY_INSERT [dbo].[Chapter] ON 

INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (3, N'updateed chapter ok', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (5, N'Chpater 3', 4)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (6, N'new Chapter', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (7, N'new chapter 2', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (8, N'new chapter 3', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (9, N'new chapter 4', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (12, N'new chapter', 2)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (13, N'new chapter 15/11', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (14, N'new chapter 15/11 - 2', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (16, N'new chapter 15/11 - 3', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (17, N'new chapter 15/11 - 3', 6)
INSERT [dbo].[Chapter] ([ChapterID], [ChapterName], [Course_CourseID]) VALUES (18, N'new chapter 15/11 - 4', 6)
SET IDENTITY_INSERT [dbo].[Chapter] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (2, N'c1', N'c1', N'c1', N'https://s.net.vn/MPOH', N'c1.mp4', 1, 1, 1, 2)
INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (4, N'c2', N'c2', N'c2', N'https://s.net.vn/MPOH', N'c2.mp4', 1, 1, 1, 2)
INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (6, N'course 6', N'course 6', N'course 6', N'https://s.net.vn/MPOH', N'course 6', 1200000, 1, 1, 2)
INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (7, N'string', N'string', N'string', N'https://s.net.vn/EbdL', N'string', 0, 1, 1, 2)
INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (8, N'string', N'string', N'string', N'https://s.net.vn/EbdL', N'string', 0, 1, 1, 2)
INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (9, N'string', N'string', N'string', N'https://s.net.vn/EbdL', N'string', 0, 1, 1, 2)
INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (12, N'updated course 15/11 - 1', N'string', N'string', N'https://s.net.vn/xrTK', N'string', 0, 1, 1, 2)
INSERT [dbo].[Course] ([CourseID], [CourseName], [Description], [CourseInfomation], [Image], [VideoIntro], [Fee], [Status], [LearningPath_LearningPathID], [User_UserID]) VALUES (30, N'MSC Data Scientce (Statistics) with Python Course', N'MSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Scientce (Statistics) with Python CourseMSC Data Sistics) with Python', N'string', N'https://s.net.vn/xrTK', N'string', 0, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseEnrolled] ON 

INSERT [dbo].[CourseEnrolled] ([CourseEnrolledID], [EnrolledDate], [Status], [Course_CourseID], [User_UserID]) VALUES (4, CAST(N'2023-11-12T00:00:00.000' AS DateTime), 1, 2, 2)
INSERT [dbo].[CourseEnrolled] ([CourseEnrolledID], [EnrolledDate], [Status], [Course_CourseID], [User_UserID]) VALUES (6, CAST(N'2023-12-11T13:18:17.543' AS DateTime), 1, 2, 16)
INSERT [dbo].[CourseEnrolled] ([CourseEnrolledID], [EnrolledDate], [Status], [Course_CourseID], [User_UserID]) VALUES (7, CAST(N'2023-12-11T13:20:57.850' AS DateTime), 1, 2, 28)
SET IDENTITY_INSERT [dbo].[CourseEnrolled] OFF
GO
SET IDENTITY_INSERT [dbo].[Discuss] ON 

INSERT [dbo].[Discuss] ([DiscussID], [Lesson_LessonID]) VALUES (1, 3)
INSERT [dbo].[Discuss] ([DiscussID], [Lesson_LessonID]) VALUES (2, 4)
INSERT [dbo].[Discuss] ([DiscussID], [Lesson_LessonID]) VALUES (3, 5)
INSERT [dbo].[Discuss] ([DiscussID], [Lesson_LessonID]) VALUES (4, 6)
INSERT [dbo].[Discuss] ([DiscussID], [Lesson_LessonID]) VALUES (5, 7)
SET IDENTITY_INSERT [dbo].[Discuss] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [FeedbackContent], [User_UserID], [Course_CourseID]) VALUES (1, N'Khoa hoc rat tot', 2, 2)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[LearningPath] ON 

INSERT [dbo].[LearningPath] ([LearningPathID], [LearningPathName], [Description], [Image], [Status]) VALUES (1, N'Full Stack', N'Full Stack Developer', N'https://s.net.vn/CDnn', 1)
INSERT [dbo].[LearningPath] ([LearningPathID], [LearningPathName], [Description], [Image], [Status]) VALUES (2, N'Full Stack 2', N'Full Stack Developer', N'https://s.net.vn/CDnn', 1)
INSERT [dbo].[LearningPath] ([LearningPathID], [LearningPathName], [Description], [Image], [Status]) VALUES (3, N'Full Stack 3', N'Full Stack Developer', N'https://s.net.vn/CDnn', 1)
INSERT [dbo].[LearningPath] ([LearningPathID], [LearningPathName], [Description], [Image], [Status]) VALUES (4, N'Full Stack 4', N'Full Stack Developer', N'https://s.net.vn/CDnn', 1)
SET IDENTITY_INSERT [dbo].[LearningPath] OFF
GO
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (3, N'Lesson 1', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (4, N'Lesson 2', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (5, N'Lesson 3', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (6, N'Lesson 4', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (7, N'Lesson 5', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (8, N'Lesson 6', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (9, N'Lesson 7', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (10, N'Lesson 8', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (11, N'Lesson 9', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (12, N'Lesson 10', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (13, N'Lesson 11', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 12)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (14, N'Lesson 12', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 9)
INSERT [dbo].[Lesson] ([LessonID], [Title], [Video], [Time], [Chapter_ChapterID]) VALUES (15, N'Lesson 13', N'LessonVideo.mp4', CAST(N'00:01:00' AS Time), 3)
SET IDENTITY_INSERT [dbo].[Lesson] OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([NotificationID], [NotificationContent], [Course_CourseID], [User_UserID]) VALUES (1, N'Admin da them moi khoa hoc moi', 2, 2)
INSERT [dbo].[Notification] ([NotificationID], [NotificationContent], [Course_CourseID], [User_UserID]) VALUES (3, N'Admin da them 2 khoa hoc moi', 2, 2)
SET IDENTITY_INSERT [dbo].[Notification] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([QuestionID], [Quiz_QuizID], [QuestionContent]) VALUES (4, 2, N'API la gi?')
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Quiz] ON 

INSERT [dbo].[Quiz] ([QuizID], [Chapter_ChapterID], [QuizName]) VALUES (2, 6, NULL)
SET IDENTITY_INSERT [dbo].[Quiz] OFF
GO
SET IDENTITY_INSERT [dbo].[RateStar] ON 

INSERT [dbo].[RateStar] ([RateStarID], [Star], [User_UserID], [Course_CourseId]) VALUES (1, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[RateStar] OFF
GO
SET IDENTITY_INSERT [dbo].[Reply] ON 

INSERT [dbo].[Reply] ([ReplyID], [ReplyContent], [Ask_AskID], [User_UserID], [Image]) VALUES (1, N'Mai nhe em', 1, 16, N'https://upload.wikimedia.org/wikipedia/vi/b/b0/Avatar-Teaser-Poster.jpg')
INSERT [dbo].[Reply] ([ReplyID], [ReplyContent], [Ask_AskID], [User_UserID], [Image]) VALUES (2, N'thanks a', 2, 2, N'reply 2.png')
SET IDENTITY_INSERT [dbo].[Reply] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [Email], [Facebook], [Github], [Phone], [Password], [FullName], [Dob], [Address], [Bio], [Image], [BackgroundImage], [GmailID], [FacebookID], [GithubID], [Status], [CodeVerify], [UserRole_RoleID]) VALUES (2, N'kien@gmail.com', N'1', N'1', N'0961498125', N'0212', N'Kien Van', CAST(N'2002-12-02T00:00:00.000' AS DateTime), N'Hai Duong', N'ok', N'k.png', N'k.png', N'0212', N'0212', N'0212', 1, N'0212', 1)
INSERT [dbo].[User] ([UserID], [Email], [Facebook], [Github], [Phone], [Password], [FullName], [Dob], [Address], [Bio], [Image], [BackgroundImage], [GmailID], [FacebookID], [GithubID], [Status], [CodeVerify], [UserRole_RoleID]) VALUES (16, N'string', N'string', N'string', N'string', N'string', N'name', CAST(N'2023-11-11T08:31:30.383' AS DateTime), N'string', N'string', N'avatar', N'string', N'string', N'string', N'string', 0, N'string', 1)
INSERT [dbo].[User] ([UserID], [Email], [Facebook], [Github], [Phone], [Password], [FullName], [Dob], [Address], [Bio], [Image], [BackgroundImage], [GmailID], [FacebookID], [GithubID], [Status], [CodeVerify], [UserRole_RoleID]) VALUES (28, N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2023-11-11T10:19:50.507' AS DateTime), N'string', N'string', N'string', N'string', N'string', N'string', N'string', 0, N'string', 1)
INSERT [dbo].[User] ([UserID], [Email], [Facebook], [Github], [Phone], [Password], [FullName], [Dob], [Address], [Bio], [Image], [BackgroundImage], [GmailID], [FacebookID], [GithubID], [Status], [CodeVerify], [UserRole_RoleID]) VALUES (29, N'string', N'string', N'string', N'string', N'string', N'string', CAST(N'2023-11-11T10:19:50.507' AS DateTime), N'string', N'string', N'string', N'string', N'string', N'string', N'string', 0, N'string', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([RoleID], [RoleName]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([Question_QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Ask]  WITH CHECK ADD  CONSTRAINT [FK_Ask_Discuss] FOREIGN KEY([Discuss_DiscussID])
REFERENCES [dbo].[Discuss] ([DiscussID])
GO
ALTER TABLE [dbo].[Ask] CHECK CONSTRAINT [FK_Ask_Discuss]
GO
ALTER TABLE [dbo].[Ask]  WITH CHECK ADD  CONSTRAINT [FK_Ask_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Ask] CHECK CONSTRAINT [FK_Ask_User]
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
ALTER TABLE [dbo].[Discuss]  WITH CHECK ADD  CONSTRAINT [FK_Discuss_Lesson] FOREIGN KEY([Lesson_LessonID])
REFERENCES [dbo].[Lesson] ([LessonID])
GO
ALTER TABLE [dbo].[Discuss] CHECK CONSTRAINT [FK_Discuss_Lesson]
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
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Course] FOREIGN KEY([Course_CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Course]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User]
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
ALTER TABLE [dbo].[RateStar]  WITH CHECK ADD  CONSTRAINT [FK_RateStar_Course] FOREIGN KEY([Course_CourseId])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[RateStar] CHECK CONSTRAINT [FK_RateStar_Course]
GO
ALTER TABLE [dbo].[RateStar]  WITH CHECK ADD  CONSTRAINT [FK_RateStar_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[RateStar] CHECK CONSTRAINT [FK_RateStar_User]
GO
ALTER TABLE [dbo].[Reply]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Ask] FOREIGN KEY([Ask_AskID])
REFERENCES [dbo].[Ask] ([AskID])
GO
ALTER TABLE [dbo].[Reply] CHECK CONSTRAINT [FK_Reply_Ask]
GO
ALTER TABLE [dbo].[Reply]  WITH CHECK ADD  CONSTRAINT [FK_Reply_User] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Reply] CHECK CONSTRAINT [FK_Reply_User]
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
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserRole_RoleID])
REFERENCES [dbo].[UserRole] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
USE [master]
GO
ALTER DATABASE [OLS] SET  READ_WRITE 
GO
