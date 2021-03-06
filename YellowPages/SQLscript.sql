USE [master]
GO
/****** Object:  Database [GalleryYellowbook]    Script Date: 5/11/2018 12:21:36 PM ******/
CREATE DATABASE [GalleryYellowbook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GalleryYellowbook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\GalleryYellowbook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GalleryYellowbook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\GalleryYellowbook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GalleryYellowbook] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GalleryYellowbook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GalleryYellowbook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET ARITHABORT OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GalleryYellowbook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GalleryYellowbook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GalleryYellowbook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GalleryYellowbook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GalleryYellowbook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GalleryYellowbook] SET  MULTI_USER 
GO
ALTER DATABASE [GalleryYellowbook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GalleryYellowbook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GalleryYellowbook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GalleryYellowbook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GalleryYellowbook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GalleryYellowbook] SET QUERY_STORE = OFF
GO
USE [GalleryYellowbook]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [GalleryYellowbook]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/11/2018 12:21:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[Order] [int] NULL,
	[Active] [bit] NOT NULL,
	[Type] [varchar](10) NULL,
	[Timestamp] [datetime] NULL,
	[Keywords] [varchar](50) NULL,
	[CategoryID] [bigint] NULL,
	[Picturelink] [varchar](50) NULL,
	[UnitID] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 5/11/2018 12:21:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
	[Body] [varchar](50) NULL,
	[Order] [int] NULL,
	[isBanner] [varchar](10) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Price] [numeric](20, 4) NULL,
	[Email] [varchar](20) NULL,
	[Website] [varchar](200) NULL,
	[FacebookLink] [varchar](200) NULL,
	[InstagramLink] [varchar](200) NULL,
	[OtherLinks] [varchar](200) NULL,
	[Notes] [varchar](100) NULL,
	[Timestamp] [datetime] NULL,
	[Keywords] [varchar](50) NULL,
	[CategoryID] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 5/11/2018 12:21:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Picturelink] [varchar](20) NULL,
	[isMain] [bit] NOT NULL,
	[ThumbLink] [varchar](20) NULL,
	[Active] [bit] NOT NULL,
	[Order] [int] NULL,
	[Notes] [varchar](100) NULL,
	[Timestamp] [datetime] NULL,
	[ItemID] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 5/11/2018 12:21:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UnitName] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[RegionName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Notes] [varchar](100) NULL,
	[Timestamp] [datetime] NULL,
	[Keywords] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [CategoryName], [Order], [Active], [Type], [Timestamp], [Keywords], [CategoryID], [Picturelink], [UnitID]) VALUES (3, N'b', 3, 1, N'aaa', CAST(N'2018-05-11T09:31:50.983' AS DateTime), N'aa', 2, NULL, 2)
INSERT [dbo].[Categories] ([ID], [CategoryName], [Order], [Active], [Type], [Timestamp], [Keywords], [CategoryID], [Picturelink], [UnitID]) VALUES (17, N'aa', 2, 1, N'asd', CAST(N'2018-04-20T10:08:25.787' AS DateTime), N'asd', NULL, N'download.jpg', 1)
INSERT [dbo].[Categories] ([ID], [CategoryName], [Order], [Active], [Type], [Timestamp], [Keywords], [CategoryID], [Picturelink], [UnitID]) VALUES (27, N'a', 1, 0, N'a', CAST(N'2018-04-20T09:14:47.230' AS DateTime), N'aaaa', NULL, N'download.jpg', 1)
INSERT [dbo].[Categories] ([ID], [CategoryName], [Order], [Active], [Type], [Timestamp], [Keywords], [CategoryID], [Picturelink], [UnitID]) VALUES (28, N'bb', 4, 1, N'aa', CAST(N'2018-04-20T09:58:25.140' AS DateTime), N'aa', NULL, NULL, 2)
INSERT [dbo].[Categories] ([ID], [CategoryName], [Order], [Active], [Type], [Timestamp], [Keywords], [CategoryID], [Picturelink], [UnitID]) VALUES (32, N'c', 5, 1, N'asd', CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'asd', NULL, NULL, 3)
INSERT [dbo].[Categories] ([ID], [CategoryName], [Order], [Active], [Type], [Timestamp], [Keywords], [CategoryID], [Picturelink], [UnitID]) VALUES (33, N'g', 6, 1, N'asd', NULL, NULL, NULL, N'download (1).jpg', 3)
INSERT [dbo].[Categories] ([ID], [CategoryName], [Order], [Active], [Type], [Timestamp], [Keywords], [CategoryID], [Picturelink], [UnitID]) VALUES (34, N'gg', 7, 1, N'asdfas', NULL, NULL, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([ID], [ItemName], [Subject], [Body], [Order], [isBanner], [PhoneNumber], [Price], [Email], [Website], [FacebookLink], [InstagramLink], [OtherLinks], [Notes], [Timestamp], [Keywords], [CategoryID]) VALUES (14, N'ali', N'a', N'a', 2, N'1', N'00', CAST(0.0000 AS Numeric(20, 4)), N'a@gmail.com', N'asd', N'jj', N'jj', N'j', N'jj', CAST(N'2018-05-11T09:33:51.107' AS DateTime), N'aloush', 3)
INSERT [dbo].[Items] ([ID], [ItemName], [Subject], [Body], [Order], [isBanner], [PhoneNumber], [Price], [Email], [Website], [FacebookLink], [InstagramLink], [OtherLinks], [Notes], [Timestamp], [Keywords], [CategoryID]) VALUES (16, N'mohammad', N'aa', N'aa', 5, N'1', N'0000', CAST(0.0000 AS Numeric(20, 4)), N'm@gmail.com', N'a.com', N'asd', N'asddas', NULL, N'aaaa', CAST(N'2018-04-20T09:59:45.580' AS DateTime), N'mhmd,m7md', 3)
INSERT [dbo].[Items] ([ID], [ItemName], [Subject], [Body], [Order], [isBanner], [PhoneNumber], [Price], [Email], [Website], [FacebookLink], [InstagramLink], [OtherLinks], [Notes], [Timestamp], [Keywords], [CategoryID]) VALUES (17, N'mohammad', N'sankari', N'test body', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-04-20T10:09:18.180' AS DateTime), NULL, 3)
SET IDENTITY_INSERT [dbo].[Items] OFF
SET IDENTITY_INSERT [dbo].[Pictures] ON 

INSERT [dbo].[Pictures] ([ID], [Picturelink], [isMain], [ThumbLink], [Active], [Order], [Notes], [Timestamp], [ItemID]) VALUES (19, N'download.jpg', 1, NULL, 1, 1, NULL, CAST(N'2018-04-27T10:39:38.523' AS DateTime), 14)
INSERT [dbo].[Pictures] ([ID], [Picturelink], [isMain], [ThumbLink], [Active], [Order], [Notes], [Timestamp], [ItemID]) VALUES (23, N'download (1).jpg', 0, NULL, 1, 2, N'a', CAST(N'2018-04-27T10:39:24.670' AS DateTime), 14)
INSERT [dbo].[Pictures] ([ID], [Picturelink], [isMain], [ThumbLink], [Active], [Order], [Notes], [Timestamp], [ItemID]) VALUES (25, N'download.jpg', 0, NULL, 1, 3, NULL, NULL, 14)
INSERT [dbo].[Pictures] ([ID], [Picturelink], [isMain], [ThumbLink], [Active], [Order], [Notes], [Timestamp], [ItemID]) VALUES (26, N'download (1).jpg', 0, NULL, 1, 4, NULL, NULL, 14)
INSERT [dbo].[Pictures] ([ID], [Picturelink], [isMain], [ThumbLink], [Active], [Order], [Notes], [Timestamp], [ItemID]) VALUES (27, N'download.jpg', 0, NULL, 1, 5, NULL, NULL, 14)
SET IDENTITY_INSERT [dbo].[Pictures] OFF
SET IDENTITY_INSERT [dbo].[Units] ON 

INSERT [dbo].[Units] ([ID], [UnitName], [Country], [City], [RegionName], [Address], [Notes], [Timestamp], [Keywords]) VALUES (1, N'Beirut', N'Lebanon', N'Beirut', N'Leb', N'aa', N'aa', CAST(N'2018-05-11T09:31:16.583' AS DateTime), N'beirut,beyy')
INSERT [dbo].[Units] ([ID], [UnitName], [Country], [City], [RegionName], [Address], [Notes], [Timestamp], [Keywords]) VALUES (2, N'Saida', N'Lebanon', N'Saida', N'Leb', N'aaa', N'aaa', CAST(N'2018-04-27T09:58:10.683' AS DateTime), N'sayda')
INSERT [dbo].[Units] ([ID], [UnitName], [Country], [City], [RegionName], [Address], [Notes], [Timestamp], [Keywords]) VALUES (3, N'tyre', N'Lebanon', N'tyre', N'Leb', N'aaa', N'aaa', CAST(N'2018-04-19T18:41:48.843' AS DateTime), N'sour')
SET IDENTITY_INSERT [dbo].[Units] OFF
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD FOREIGN KEY([UnitID])
REFERENCES [dbo].[Units] ([ID])
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
USE [master]
GO
ALTER DATABASE [GalleryYellowbook] SET  READ_WRITE 
GO
