USE [master]
GO
/****** Object:  Database [Questionnaire]    Script Date: 2021/11/17 上午 08:36:25 ******/
CREATE DATABASE [Questionnaire]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Questionnaire', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Questionnaire.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Questionnaire_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Questionnaire_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Questionnaire] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Questionnaire].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Questionnaire] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Questionnaire] SET ARITHABORT OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Questionnaire] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Questionnaire] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Questionnaire] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Questionnaire] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Questionnaire] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Questionnaire] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Questionnaire] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Questionnaire] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Questionnaire] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Questionnaire] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Questionnaire] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Questionnaire] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Questionnaire] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Questionnaire] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Questionnaire] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Questionnaire] SET  MULTI_USER 
GO
ALTER DATABASE [Questionnaire] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Questionnaire] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Questionnaire] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Questionnaire] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Questionnaire] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Questionnaire] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Questionnaire] SET QUERY_STORE = OFF
GO
USE [Questionnaire]
GO
/****** Object:  Table [dbo].[Answer_D1]    Script Date: 2021/11/17 上午 08:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer_D1](
	[Ad1_id] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[AM_id] [nchar](100) NULL,
	[D1_id] [int] NULL,
 CONSTRAINT [PK_Answer_D1] PRIMARY KEY CLUSTERED 
(
	[Ad1_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answer_M]    Script Date: 2021/11/17 上午 08:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer_M](
	[AM_id] [nchar](100) NOT NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nchar](50) NULL,
	[email] [nchar](50) NULL,
	[age] [int] NULL,
	[M_id] [int] NOT NULL,
	[writeTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Inpeople] PRIMARY KEY CLUSTERED 
(
	[AM_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[My_save]    Script Date: 2021/11/17 上午 08:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[My_save](
	[save_id] [int] IDENTITY(1,1) NOT NULL,
	[save_name] [nvarchar](50) NULL,
	[save_question] [nvarchar](50) NULL,
	[save_answer] [nvarchar](50) NULL,
	[save_type] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_D1]    Script Date: 2021/11/17 上午 08:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_D1](
	[D1_id] [int] IDENTITY(1,1) NOT NULL,
	[M_id] [int] NOT NULL,
	[D1_title] [nvarchar](50) NOT NULL,
	[D1_summary] [nvarchar](250) NULL,
	[D1_type] [nvarchar](3) NOT NULL,
	[D1_mustKeyin] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_D2]    Script Date: 2021/11/17 上午 08:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_D2](
	[D2_id] [int] IDENTITY(1,1) NOT NULL,
	[D1_id] [int] NOT NULL,
	[M_id] [int] NOT NULL,
	[answer] [nvarchar](max) NULL,
 CONSTRAINT [PK_Question_D2] PRIMARY KEY CLUSTERED 
(
	[D2_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_M]    Script Date: 2021/11/17 上午 08:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_M](
	[M_id] [int] IDENTITY(1,1) NOT NULL,
	[M_title] [nvarchar](200) NOT NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[M_summary] [nvarchar](250) NULL,
	[M_open] [bit] NULL,
 CONSTRAINT [PK_Question_M] PRIMARY KEY CLUSTERED 
(
	[M_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer_D1] ON 

INSERT [dbo].[Answer_D1] ([Ad1_id], [Answer], [AM_id], [D1_id]) VALUES (64, N'鳳梨', N'4a00dd51-7781-4209-a154-8fa1d7fc345e                                                                ', 84)
INSERT [dbo].[Answer_D1] ([Ad1_id], [Answer], [AM_id], [D1_id]) VALUES (65, N'哈密瓜;葡萄;', N'4a00dd51-7781-4209-a154-8fa1d7fc345e                                                                ', 85)
SET IDENTITY_INSERT [dbo].[Answer_D1] OFF
GO
INSERT [dbo].[Answer_M] ([AM_id], [name], [phone], [email], [age], [M_id], [writeTime]) VALUES (N'4a00dd51-7781-4209-a154-8fa1d7fc345e                                                                ', N'jack', N'02-0000-0000                                      ', N'dddd123@gmail.com                                 ', 33, 41, CAST(N'2021-11-17T08:28:20.413' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[My_save] ON 

INSERT [dbo].[My_save] ([save_id], [save_name], [save_question], [save_answer], [save_type]) VALUES (23, N'選項1', N'你喜歡的職業', N'律師;法師;醫生', N'RB        ')
SET IDENTITY_INSERT [dbo].[My_save] OFF
GO
SET IDENTITY_INSERT [dbo].[Question_D1] ON 

INSERT [dbo].[Question_D1] ([D1_id], [M_id], [D1_title], [D1_summary], [D1_type], [D1_mustKeyin]) VALUES (84, 41, N'亞洲水果', NULL, N'RB', 0)
INSERT [dbo].[Question_D1] ([D1_id], [M_id], [D1_title], [D1_summary], [D1_type], [D1_mustKeyin]) VALUES (85, 41, N'美洲水果', NULL, N'CB', 1)
SET IDENTITY_INSERT [dbo].[Question_D1] OFF
GO
SET IDENTITY_INSERT [dbo].[Question_D2] ON 

INSERT [dbo].[Question_D2] ([D2_id], [D1_id], [M_id], [answer]) VALUES (79, 84, 41, N'香蕉;鳳梨;橘子')
INSERT [dbo].[Question_D2] ([D2_id], [D1_id], [M_id], [answer]) VALUES (80, 85, 41, N'哈密瓜;葡萄;奇異果')
SET IDENTITY_INSERT [dbo].[Question_D2] OFF
GO
SET IDENTITY_INSERT [dbo].[Question_M] ON 

INSERT [dbo].[Question_M] ([M_id], [M_title], [start_time], [end_time], [M_summary], [M_open]) VALUES (41, N'你喜歡的水果', CAST(N'2021-11-17T00:00:00.000' AS DateTime), CAST(N'2021-11-30T00:00:00.000' AS DateTime), N'說出你喜愛的水果', 1)
SET IDENTITY_INSERT [dbo].[Question_M] OFF
GO
ALTER TABLE [dbo].[Answer_M] ADD  CONSTRAINT [DF_Inpeople_writeTime]  DEFAULT (getdate()) FOR [writeTime]
GO
USE [master]
GO
ALTER DATABASE [Questionnaire] SET  READ_WRITE 
GO
