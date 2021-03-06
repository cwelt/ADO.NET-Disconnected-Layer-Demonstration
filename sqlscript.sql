USE [master]
GO
/****** Object:  Database [OpenUniversityDB]    Script Date: 24/06/2020 13:44:35 ******/
CREATE DATABASE [OpenUniversityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OpenUniversityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OpenUniversityDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OpenUniversityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OpenUniversityDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OpenUniversityDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OpenUniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OpenUniversityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OpenUniversityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OpenUniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OpenUniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OpenUniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OpenUniversityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OpenUniversityDB] SET  MULTI_USER 
GO
ALTER DATABASE [OpenUniversityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OpenUniversityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OpenUniversityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OpenUniversityDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OpenUniversityDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OpenUniversityDB] SET QUERY_STORE = OFF
GO
USE [OpenUniversityDB]
GO
/****** Object:  Table [dbo].[CourseLevels]    Script Date: 24/06/2020 13:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseLevels](
	[LevelId] [tinyint] NOT NULL,
	[LevelDescription] [nvarchar](18) NOT NULL,
 CONSTRAINT [PK_CourseLevels] PRIMARY KEY CLUSTERED 
(
	[LevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseOfferings]    Script Date: 24/06/2020 13:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseOfferings](
	[CourseId] [nchar](5) NOT NULL,
	[SemesterId] [nchar](5) NOT NULL,
 CONSTRAINT [PK_CourseOfferings] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 24/06/2020 13:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [nchar](5) NOT NULL,
	[CourseName] [nvarchar](70) NOT NULL,
	[Credits] [int] NOT NULL,
	[Level] [tinyint] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 24/06/2020 13:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[StudentId] [nchar](9) NOT NULL,
	[CourseId] [nchar](5) NOT NULL,
	[SemesterId] [nchar](5) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Grade] [tinyint] NULL,
 CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC,
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnrollmentStatuses]    Script Date: 24/06/2020 13:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollmentStatuses](
	[StatusId] [tinyint] NOT NULL,
	[StatusDescription] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_EnrollmentStatuses] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 24/06/2020 13:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[SemesterId] [nchar](5) NOT NULL,
	[Description] [nvarchar](15) NOT NULL,
	[Year] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 24/06/2020 13:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [nchar](9) NOT NULL,
	[StudentName] [nvarchar](30) NOT NULL,
	[Phone] [nvarchar](11) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CourseLevels] ([LevelId], [LevelDescription]) VALUES (0, N'Introductory ')
INSERT [dbo].[CourseLevels] ([LevelId], [LevelDescription]) VALUES (1, N'Intermediate ')
INSERT [dbo].[CourseLevels] ([LevelId], [LevelDescription]) VALUES (2, N'Advanced ')
INSERT [dbo].[CourseLevels] ([LevelId], [LevelDescription]) VALUES (3, N'Seminar\Workshop')
GO
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'04101', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20272', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20277', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20407', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20417', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20440', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20466', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20471', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20474', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20475', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20554', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20582', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20585', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20586', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20594', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20595', N'2018a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'04101', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20272', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20277', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20407', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20417', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20440', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20466', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20471', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20474', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20475', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20554', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20582', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20585', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20586', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20594', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20595', N'2018b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'04101', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20272', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20277', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20407', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20417', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20440', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20466', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20471', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20474', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20475', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20554', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20582', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20585', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20586', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20594', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20595', N'2019a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'04101', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20272', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20277', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20407', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20417', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20440', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20466', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20471', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20474', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20475', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20554', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20582', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20585', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20586', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20594', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20595', N'2019b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'04101', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20272', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20277', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20407', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20417', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20440', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20466', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20471', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20474', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20475', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20554', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20582', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20585', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20586', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20594', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20595', N'2020a')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'04101', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20272', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20277', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20407', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20417', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20440', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20466', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20471', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20474', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20475', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20554', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20582', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20585', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20586', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20594', N'2020b')
INSERT [dbo].[CourseOfferings] ([CourseId], [SemesterId]) VALUES (N'20595', N'2020b')
GO
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'04101', N'Introduction to Mathematics', 6, 0)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20272', N'Digital Design', 3, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20277', N'Database Systems', 4, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20407', N'Data Structures and Introduction to Algorithms', 6, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20417', N'Algorithms', 4, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20440', N'Automata Theory and Formal Languages', 4, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20466', N'Logic for Computer Science', 4, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20471', N'Computer Organization', 3, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20474', N'Infinitesimal Calculus I', 6, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20475', N'Infinitesimal Calculus II', 6, 1)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20554', N'Advanced Programming with Java', 4, 2)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20582', N'Introduction to Computer Networks', 6, 2)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20585', N'Introduction to the Theory of Computation & Complexity', 4, 2)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20586', N'OOP Workshop with C# and .NET Framework', 3, 3)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20594', N'Operating Systems', 4, 2)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Credits], [Level]) VALUES (N'20595', N'Data Mining', 4, 2)
GO
INSERT [dbo].[Enrollments] ([StudentId], [CourseId], [SemesterId], [Status], [Grade]) VALUES (N'201203007', N'20474', N'2020a', 1, 93)
INSERT [dbo].[Enrollments] ([StudentId], [CourseId], [SemesterId], [Status], [Grade]) VALUES (N'201203007', N'20475', N'2020b', 1, 72)
INSERT [dbo].[Enrollments] ([StudentId], [CourseId], [SemesterId], [Status], [Grade]) VALUES (N'201203007', N'20586', N'2020b', 0, NULL)
INSERT [dbo].[Enrollments] ([StudentId], [CourseId], [SemesterId], [Status], [Grade]) VALUES (N'201203012', N'20585', N'2019a', 1, 100)
INSERT [dbo].[Enrollments] ([StudentId], [CourseId], [SemesterId], [Status], [Grade]) VALUES (N'201203012', N'20586', N'2020b', 0, NULL)
GO
INSERT [dbo].[EnrollmentStatuses] ([StatusId], [StatusDescription]) VALUES (0, N'Registered')
INSERT [dbo].[EnrollmentStatuses] ([StatusId], [StatusDescription]) VALUES (1, N'Success')
INSERT [dbo].[EnrollmentStatuses] ([StatusId], [StatusDescription]) VALUES (2, N'Failed')
INSERT [dbo].[EnrollmentStatuses] ([StatusId], [StatusDescription]) VALUES (3, N'Canceled')
GO
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2018a', N'Autumn 2018', 2018, CAST(N'2017-10-17' AS Date), CAST(N'2018-01-29' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2018b', N'Spring 2018', 2018, CAST(N'2018-03-06' AS Date), CAST(N'2018-06-19' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2018c', N'Summer 2018', 2018, CAST(N'2018-07-08' AS Date), CAST(N'2018-09-07' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2019a', N'Autumn 2019', 2019, CAST(N'2018-10-14' AS Date), CAST(N'2019-01-18' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2019b', N'Spring 2019', 2019, CAST(N'2019-02-24' AS Date), CAST(N'2019-06-14' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2019c', N'Summer 2019', 2019, CAST(N'2019-07-07' AS Date), CAST(N'2019-09-06' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2020a', N'Autumn 2020', 2020, CAST(N'2019-11-03' AS Date), CAST(N'2020-02-07' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2020b', N'Spring 2020', 2020, CAST(N'2020-03-15' AS Date), CAST(N'2020-06-26' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2020c', N'Summer 2020', 2020, CAST(N'2020-07-14' AS Date), CAST(N'2020-09-14' AS Date))
INSERT [dbo].[Semesters] ([SemesterId], [Description], [Year], [StartDate], [EndDate]) VALUES (N'2021a', N'Autumn 2021', 2021, CAST(N'2020-10-18' AS Date), CAST(N'2021-01-22' AS Date))
GO
INSERT [dbo].[Students] ([StudentId], [StudentName], [Phone], [Email]) VALUES (N'201203007', N'James Bond', NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [StudentName], [Phone], [Email]) VALUES (N'201203012', N'Alan Turing', NULL, NULL)
GO
ALTER TABLE [dbo].[CourseOfferings]  WITH CHECK ADD  CONSTRAINT [FK_CourseOfferings_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[CourseOfferings] CHECK CONSTRAINT [FK_CourseOfferings_Courses]
GO
ALTER TABLE [dbo].[CourseOfferings]  WITH CHECK ADD  CONSTRAINT [FK_CourseOfferings_Semesters] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([SemesterId])
GO
ALTER TABLE [dbo].[CourseOfferings] CHECK CONSTRAINT [FK_CourseOfferings_Semesters]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_CourseLevels] FOREIGN KEY([Level])
REFERENCES [dbo].[CourseLevels] ([LevelId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_CourseLevels]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_CourseOfferings] FOREIGN KEY([SemesterId], [CourseId])
REFERENCES [dbo].[CourseOfferings] ([SemesterId], [CourseId])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_CourseOfferings]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_EnrollmentStatuses] FOREIGN KEY([Status])
REFERENCES [dbo].[EnrollmentStatuses] ([StatusId])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_EnrollmentStatuses]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Students]
GO
USE [master]
GO
ALTER DATABASE [OpenUniversityDB] SET  READ_WRITE 
GO
