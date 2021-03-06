USE [master]
GO
/****** Object:  Database [PracticalTest]    Script Date: 13-02-2021 04:27:07 PM ******/
CREATE DATABASE [PracticalTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PracticalTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PracticalTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PracticalTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PracticalTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PracticalTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PracticalTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PracticalTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PracticalTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PracticalTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PracticalTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PracticalTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [PracticalTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PracticalTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PracticalTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PracticalTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PracticalTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PracticalTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PracticalTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PracticalTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PracticalTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PracticalTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PracticalTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PracticalTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PracticalTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PracticalTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PracticalTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PracticalTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PracticalTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PracticalTest] SET RECOVERY FULL 
GO
ALTER DATABASE [PracticalTest] SET  MULTI_USER 
GO
ALTER DATABASE [PracticalTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PracticalTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PracticalTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PracticalTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PracticalTest] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PracticalTest', N'ON'
GO
ALTER DATABASE [PracticalTest] SET QUERY_STORE = OFF
GO
USE [PracticalTest]
GO
/****** Object:  Table [dbo].[tbl_rolemaster]    Script Date: 13-02-2021 04:27:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_rolemaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_rolemaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usermaster]    Script Date: 13-02-2021 04:27:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usermaster](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[Birthdate] [date] NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [nvarchar](10) NULL,
	[Age] [int] NULL,
	[Gender] [char](1) NULL,
	[RoleId] [int] NULL,
	[ProfileUrl] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_usermaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_rolemaster] ON 

INSERT [dbo].[tbl_rolemaster] ([Id], [Name], [IsActive]) VALUES (1, N'Manager', 1)
INSERT [dbo].[tbl_rolemaster] ([Id], [Name], [IsActive]) VALUES (2, N'HR', 1)
INSERT [dbo].[tbl_rolemaster] ([Id], [Name], [IsActive]) VALUES (3, N'BDE', 1)
INSERT [dbo].[tbl_rolemaster] ([Id], [Name], [IsActive]) VALUES (4, N'Developer', 1)
INSERT [dbo].[tbl_rolemaster] ([Id], [Name], [IsActive]) VALUES (5, N'Team Lead', 1)
SET IDENTITY_INSERT [dbo].[tbl_rolemaster] OFF
GO
INSERT [dbo].[tbl_usermaster] ([Id], [Name], [Birthdate], [Email], [Mobile], [Age], [Gender], [RoleId], [ProfileUrl], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'56e86b03-fd10-475e-acb0-0966efd087d9', N'sahil', CAST(N'1997-11-01' AS Date), N'sahil@gmail.com', N'9876543210', 25, N'M', 1, N'~/Content/Files/20210213-vegetarian.jpg', 1, CAST(N'2021-02-13T15:03:49.763' AS DateTime), CAST(N'2021-02-13T16:02:42.467' AS DateTime))
INSERT [dbo].[tbl_usermaster] ([Id], [Name], [Birthdate], [Email], [Mobile], [Age], [Gender], [RoleId], [ProfileUrl], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'be3198aa-d970-475f-a05a-4a8fdec3cc59', N'Ankit', CAST(N'2021-02-02' AS Date), N'ankit@gmail.com', N'9876543210', 25, N'M', 3, N'test', 1, CAST(N'2021-02-13T14:42:46.300' AS DateTime), CAST(N'2021-02-13T15:03:17.487' AS DateTime))
INSERT [dbo].[tbl_usermaster] ([Id], [Name], [Birthdate], [Email], [Mobile], [Age], [Gender], [RoleId], [ProfileUrl], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'7380490d-5eeb-426d-b64f-6684b4a3301b', N'test', CAST(N'1995-11-01' AS Date), N'test@gmail.com', N'9876543210', 25, N'M', 1, N'test', 0, CAST(N'2021-02-13T13:06:18.183' AS DateTime), CAST(N'2021-02-13T14:02:21.480' AS DateTime))
INSERT [dbo].[tbl_usermaster] ([Id], [Name], [Birthdate], [Email], [Mobile], [Age], [Gender], [RoleId], [ProfileUrl], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'8f0dd588-6697-43fa-90ef-bdd2f7cb8986', N'asd', CAST(N'2021-02-01' AS Date), N'asd@gmail.com', N'9876543210', 22, N'F', 1, N'~\Content\Files\20210213-milk.png', 1, CAST(N'2021-02-13T15:33:42.053' AS DateTime), CAST(N'2021-02-13T15:33:42.387' AS DateTime))
INSERT [dbo].[tbl_usermaster] ([Id], [Name], [Birthdate], [Email], [Mobile], [Age], [Gender], [RoleId], [ProfileUrl], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (N'cc37e741-5bef-4554-bb05-c6469b9d890c', N'Vishal Joshi', CAST(N'1993-11-01' AS Date), N'vishal@gmail.com', N'9876543210', 27, N'M', 1, N'~\Content\Files\20210213-milk.png', 1, NULL, NULL)
GO
ALTER TABLE [dbo].[tbl_usermaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_usermaster_tbl_rolemaster] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tbl_rolemaster] ([Id])
GO
ALTER TABLE [dbo].[tbl_usermaster] CHECK CONSTRAINT [FK_tbl_usermaster_tbl_rolemaster]
GO
USE [master]
GO
ALTER DATABASE [PracticalTest] SET  READ_WRITE 
GO
