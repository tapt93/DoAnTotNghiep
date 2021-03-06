/****** Object:  Database [PLW]    Script Date: 1/13/2021 7:31:06 PM ******/
CREATE DATABASE [PLW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PLW', FILENAME = N'D:\SqlServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\PLW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PLW_log', FILENAME = N'D:\SqlServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\PLW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PLW] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PLW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PLW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PLW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PLW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PLW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PLW] SET ARITHABORT OFF 
GO
ALTER DATABASE [PLW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PLW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PLW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PLW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PLW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PLW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PLW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PLW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PLW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PLW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PLW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PLW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PLW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PLW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PLW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PLW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PLW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PLW] SET RECOVERY FULL 
GO
ALTER DATABASE [PLW] SET  MULTI_USER 
GO
ALTER DATABASE [PLW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PLW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PLW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PLW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PLW] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PLW', N'ON'
GO
ALTER DATABASE [PLW] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 1/13/2021 7:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[IsCorrect] [bit] NULL,
	[QuestionId] [int] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 1/13/2021 7:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[AnswerId] [int] NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[TemplateId] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 1/13/2021 7:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Score] [decimal](18, 0) NULL,
	[Account] [varchar](100) NULL,
	[Created] [datetime] NULL,
	[TemplateId] [int] NULL,
	[Updated] [datetime] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Template]    Script Date: 1/13/2021 7:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Template](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Duration] [int] NULL,
	[Level] [int] NULL,
	[PassScore] [decimal](18, 0) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Skill] [varchar](100) NULL,
 CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/13/2021 7:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](100) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Password] [varchar](max) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (1, N'chama-se', NULL, NULL, 0, 1)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (2, N'chamas', NULL, NULL, 0, 1)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (3, N'te chamas', NULL, NULL, 1, 1)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (4, N'se chama', NULL, NULL, 0, 1)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (5, N'conhecido', NULL, NULL, 0, 2)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (6, N'conheco', NULL, NULL, 1, 2)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (7, N'conhecendo', NULL, NULL, 0, 2)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (8, N'conheceres', NULL, NULL, 0, 2)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (9, N'compraram', NULL, NULL, 0, 3)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (10, N'têm', NULL, NULL, 0, 3)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (11, N'tem', NULL, NULL, 1, 3)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (12, N'gosta', NULL, NULL, 0, 3)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (13, N'ouvido', NULL, NULL, 0, 4)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (14, N'ouvi', NULL, NULL, 0, 4)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (15, N'ouvir', NULL, NULL, 0, 4)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (16, N'ouço', NULL, NULL, 1, 4)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (17, N'estão', NULL, NULL, 0, 5)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (18, N'es', NULL, NULL, 0, 5)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (19, N'ao lado', NULL, NULL, 0, 5)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (20, N'fica', NULL, NULL, 1, 5)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (21, N'em seu', NULL, NULL, 0, 6)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (22, N'no meu', NULL, NULL, 1, 6)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (23, N'em meu', NULL, NULL, 0, 6)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (24, N'na minha', NULL, NULL, 0, 6)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (25, N'ano', NULL, NULL, 0, 7)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (26, N'anos', NULL, NULL, 0, 7)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (27, N'presente', NULL, NULL, 0, 7)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (28, N'presentes', NULL, NULL, 1, 7)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (29, N'estejamos', NULL, NULL, 0, 8)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (30, N'estao', NULL, NULL, 0, 8)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (31, N'estavamos', NULL, NULL, 1, 8)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (32, N'tinhamos estado', NULL, NULL, 0, 8)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (33, N'nossas', NULL, NULL, 1, 9)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (34, N'nossos', NULL, NULL, 0, 9)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (35, N'nossa', NULL, NULL, 0, 9)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (36, N'nosso', NULL, NULL, 0, 9)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (37, N'dae', NULL, NULL, 0, 10)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (38, N'da', NULL, NULL, 1, 10)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (39, N'de a', NULL, NULL, 0, 10)
INSERT [dbo].[Answer] ([ID], [Content], [Created], [Updated], [IsCorrect], [QuestionId]) VALUES (40, N'dea', NULL, NULL, 0, 10)
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (1, NULL, N'Como é que tu ...?', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (2, NULL, N'Eu ... a cidade do Porto muito bem', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (3, NULL, N'Voce ... dois carros novos', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (4, NULL, N'À noite ... sempre rádio', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (5, NULL, N'O Porto ... perto de Vila Nova de Gaia', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (6, NULL, N'A minha irmã vai comigo ... carro', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (7, NULL, N'Quantos ... recebeste hoje?', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (8, NULL, N'Nós decidimos fazer férias, porque ... muito cansados.', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (9, NULL, N'De quem são as canetas que estao dentro da pasta? São ...', 0, NULL, NULL, 1)
INSERT [dbo].[Question] ([ID], [Title], [Content], [AnswerId], [Created], [Updated], [TemplateId]) VALUES (10, NULL, N'De quem es o livro verde? É ... senhora', 0, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (1, CAST(7 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-21T23:57:15.157' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (2, CAST(7 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-21T23:58:46.023' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (3, CAST(7 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-21T23:59:39.150' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (4, CAST(9 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:00:17.590' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (5, CAST(5 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:01:18.430' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (6, CAST(2 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:03:18.953' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (7, CAST(1 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:03:47.390' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (8, CAST(4 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:04:05.910' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (9, CAST(4 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:04:55.150' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (10, CAST(0 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:05:56.993' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (11, CAST(4 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:06:08.787' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (12, CAST(9 AS Decimal(18, 0)), N'hoanq2', CAST(N'2020-12-22T00:06:26.860' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (1002, CAST(7 AS Decimal(18, 0)), N'hoanq2', CAST(N'2021-01-04T20:45:49.400' AS DateTime), 1, NULL)
INSERT [dbo].[Result] ([ID], [Score], [Account], [Created], [TemplateId], [Updated]) VALUES (1003, CAST(9 AS Decimal(18, 0)), N'hoanq2', CAST(N'2021-01-04T20:47:19.477' AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[Result] OFF
SET IDENTITY_INSERT [dbo].[Template] ON 

INSERT [dbo].[Template] ([ID], [Content], [Duration], [Level], [PassScore], [Created], [Updated], [Skill]) VALUES (1, N'Luyện ngữ pháp 2019', 90, 0, CAST(8 AS Decimal(18, 0)), NULL, NULL, N'writing')
SET IDENTITY_INSERT [dbo].[Template] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (1, N'anhnt141', N'tuan anh', N'nguyen', N'ta.pt93@gmail.com', CAST(N'2020-10-19T21:28:09.740' AS DateTime), CAST(N'2020-10-19T21:28:09.740' AS DateTime), N'E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E', 1)
INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (2, N'dung', N'dung', N'quang', N'dung@gmail.com', CAST(N'2020-10-21T00:11:13.647' AS DateTime), CAST(N'2020-10-21T00:11:13.647' AS DateTime), N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', NULL)
INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (3, N'anh1', N'anh', N'nguyen', N'anh1@mail.com', CAST(N'2020-10-21T20:39:10.443' AS DateTime), CAST(N'2020-10-21T20:39:10.443' AS DateTime), N'81-DC-9B-DB-52-D0-4D-C2-00-36-DB-D8-31-3E-D0-55', NULL)
INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (4, N'anh2', N'anh', N'tung', N'anh2@mail.com', CAST(N'2020-10-21T20:40:48.780' AS DateTime), CAST(N'2020-10-21T20:40:48.780' AS DateTime), N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', NULL)
INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (5, N'long', N'long', N'ly', N'long@mail.com', CAST(N'2020-10-21T20:42:17.610' AS DateTime), CAST(N'2020-10-21T20:42:17.610' AS DateTime), N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', NULL)
INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (6, N'asdfasdf', N'asdfds', N'asdfsadf', N'asdfsd@fsdf.asdf', CAST(N'2020-10-21T20:43:46.460' AS DateTime), CAST(N'2020-10-21T20:43:46.460' AS DateTime), N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', NULL)
INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (7, N'werwer', N'rwer', N'erwer', N'rwer@ere.ytg', CAST(N'2020-10-21T20:46:11.333' AS DateTime), CAST(N'2020-10-21T20:46:11.333' AS DateTime), N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', NULL)
INSERT [dbo].[User] ([ID], [Account], [FirstName], [LastName], [Email], [Created], [Updated], [Password], [IsAdmin]) VALUES (8, N'hoanq2', N'ádas', N'ádas', N'hoan@fdf.cdf', CAST(N'2020-12-21T23:50:28.283' AS DateTime), CAST(N'2020-12-21T23:50:28.283' AS DateTime), N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  StoredProcedure [dbo].[Proc_CheckUserLogin]    Script Date: 1/13/2021 7:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_CheckUserLogin]
@account nvarchar(MAX),
@password nvarchar(MAX)
as
begin
	SELECT 
	CASE WHEN EXISTS(SELECT ID FROM [User] WHERE Account = @account AND Password = @password)
		THEN 1 
		ELSE 0
	END
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_RegisterUser]    Script Date: 1/13/2021 7:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_RegisterUser]
@account varchar(MAX),
@password nvarchar(MAX),
@email varchar(MAX) ,
@lastName nvarchar(MAX),
@firstName nvarchar(MAX)
as
begin
	INSERT INTO [User] (Account, FirstName, LastName, Email, Created, Updated, Password)
	VALUES (@account, @firstName, @lastName, @email, GETDATE(), GETDATE(), @password)

	SELECT @account;
end
GO
ALTER DATABASE [PLW] SET  READ_WRITE 
GO
