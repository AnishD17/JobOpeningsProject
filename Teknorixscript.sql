USE [master]
GO
/****** Object:  Database [JobOpeningsDb]    Script Date: 18-10-2024 23:43:12 ******/
CREATE DATABASE [JobOpeningsDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobOpeningsDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JobOpeningsDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JobOpeningsDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JobOpeningsDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JobOpeningsDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobOpeningsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JobOpeningsDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [JobOpeningsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JobOpeningsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JobOpeningsDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JobOpeningsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JobOpeningsDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [JobOpeningsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JobOpeningsDb] SET  MULTI_USER 
GO
ALTER DATABASE [JobOpeningsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JobOpeningsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JobOpeningsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JobOpeningsDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JobOpeningsDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JobOpeningsDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [JobOpeningsDb] SET QUERY_STORE = OFF
GO
USE [JobOpeningsDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18-10-2024 23:43:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 18-10-2024 23:43:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentTitle] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobOpenings]    Script Date: 18-10-2024 23:43:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobOpenings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobCode] [nvarchar](max) NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[JobDescription] [nvarchar](max) NOT NULL,
	[JobPostedDate] [datetime2](7) NULL,
	[JobClosingDate] [datetime2](7) NULL,
	[DepartmentId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_JobOpenings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 18-10-2024 23:43:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationTitle] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Zipcode] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241016151235_Initial Migration', N'8.0.10')
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentId], [DepartmentTitle]) VALUES (1, N'Testing')
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentTitle]) VALUES (2, N'Development')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[JobOpenings] ON 

INSERT [dbo].[JobOpenings] ([Id], [JobCode], [JobTitle], [JobDescription], [JobPostedDate], [JobClosingDate], [DepartmentId], [LocationId]) VALUES (1, N'JOB-01', N'Dot net developer', N'Devloping software', CAST(N'2024-10-16T19:12:27.9280000' AS DateTime2), CAST(N'2024-10-16T19:12:27.9280000' AS DateTime2), 1, 1)
INSERT [dbo].[JobOpenings] ([Id], [JobCode], [JobTitle], [JobDescription], [JobPostedDate], [JobClosingDate], [DepartmentId], [LocationId]) VALUES (2, N'JOB-02', N'React Developer', N'Developing frontend', CAST(N'2024-10-16T19:15:51.7230000' AS DateTime2), CAST(N'2024-10-16T19:15:51.7230000' AS DateTime2), 1, 1)
INSERT [dbo].[JobOpenings] ([Id], [JobCode], [JobTitle], [JobDescription], [JobPostedDate], [JobClosingDate], [DepartmentId], [LocationId]) VALUES (3, N'JOB-03', N'QA Engineer', N'Testing software', CAST(N'2024-10-16T19:17:08.9270000' AS DateTime2), CAST(N'2024-10-16T19:17:08.9270000' AS DateTime2), 2, 1)
SET IDENTITY_INSERT [dbo].[JobOpenings] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([LocationId], [LocationTitle], [City], [State], [Country], [Zipcode]) VALUES (1, N'Verna Industrial', N'Verna', N'Goa', N'India', N'403511')
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
/****** Object:  Index [IX_JobOpenings_DepartmentId]    Script Date: 18-10-2024 23:43:13 ******/
CREATE NONCLUSTERED INDEX [IX_JobOpenings_DepartmentId] ON [dbo].[JobOpenings]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobOpenings_LocationId]    Script Date: 18-10-2024 23:43:13 ******/
CREATE NONCLUSTERED INDEX [IX_JobOpenings_LocationId] ON [dbo].[JobOpenings]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JobOpenings]  WITH CHECK ADD  CONSTRAINT [FK_JobOpenings_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobOpenings] CHECK CONSTRAINT [FK_JobOpenings_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[JobOpenings]  WITH CHECK ADD  CONSTRAINT [FK_JobOpenings_Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([LocationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobOpenings] CHECK CONSTRAINT [FK_JobOpenings_Locations_LocationId]
GO
USE [master]
GO
ALTER DATABASE [JobOpeningsDb] SET  READ_WRITE 
GO
