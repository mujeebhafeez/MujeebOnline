USE [master]
GO
/****** Object:  Database [db_muj]    Script Date: 3/22/2024 3:53:17 PM ******/
CREATE DATABASE [db_muj]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_muj', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_muj.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_muj_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_muj_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_muj] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_muj].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_muj] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_muj] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_muj] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_muj] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_muj] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_muj] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_muj] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_muj] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_muj] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_muj] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_muj] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_muj] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_muj] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_muj] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_muj] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_muj] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_muj] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_muj] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_muj] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_muj] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_muj] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_muj] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_muj] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_muj] SET  MULTI_USER 
GO
ALTER DATABASE [db_muj] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_muj] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_muj] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_muj] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_muj] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_muj] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_muj', N'ON'
GO
ALTER DATABASE [db_muj] SET QUERY_STORE = OFF
GO
USE [db_muj]
GO
/****** Object:  Table [dbo].[changeset]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[changeset](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[changesetdetail] [varchar](max) NULL,
	[linktotypeid] [int] NULL,
	[statusid] [int] NULL,
	[refno] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Position] [varchar](50) NULL,
	[Office] [varchar](50) NULL,
	[Age] [int] NULL,
	[Salary] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[linktotype]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[linktotype](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[linktype] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessionalBackground]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessionalBackground](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rowid] [int] NULL,
	[officeName] [varchar](50) NULL,
	[country_det] [varchar](50) NULL,
	[City_det] [varchar](50) NULL,
	[fromDate] [date] NULL,
	[ToDate] [date] NULL,
	[userid] [int] NULL,
 CONSTRAINT [PK_ProfessionalBackground] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_city]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_city](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[countryid] [int] NULL,
	[cityname] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_country]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[countryname] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_status]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[statusdesc] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 3/22/2024 3:53:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[userid] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[gender] [varchar](50) NULL,
	[dob] [date] NULL,
	[profileimage] [varchar](50) NULL,
	[hobby] [varchar](50) NULL,
	[isadult] [bit] NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (1, N'mujeeb', N'IT', N'ICAP', 29, 15000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (12, N'zxcvz', N'asda', N'qeqeqweqw', 12, 2131)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (13, N'adsasdadasdasdasdasd', N'sfsdf', N'sf', 12131, 13123)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (14, N'SMSSSSzzzzzSM', N'SMAAAasdasdas', N'Pakzxzxaasda', 3251111, 24570664)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (2002, N'string1', N'string2', N'string3', 13, 456)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (2003, N'strinsadadg', N'strasdaasdasdsadasing', NULL, NULL, 9090)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (2004, N'strin111g', N'string23', NULL, NULL, 232)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfessionalBackground] ON 

INSERT [dbo].[ProfessionalBackground] ([id], [rowid], [officeName], [country_det], [City_det], [fromDate], [ToDate], [userid]) VALUES (1, 3, N'ICAP', N'PAK', N'ISL', CAST(N'2023-05-10' AS Date), CAST(N'2023-05-29' AS Date), 1)
INSERT [dbo].[ProfessionalBackground] ([id], [rowid], [officeName], [country_det], [City_det], [fromDate], [ToDate], [userid]) VALUES (2, 9, N'QVS', N'QAT', N'MUM', CAST(N'2023-05-29' AS Date), CAST(N'2023-05-10' AS Date), 1)
INSERT [dbo].[ProfessionalBackground] ([id], [rowid], [officeName], [country_det], [City_det], [fromDate], [ToDate], [userid]) VALUES (3, 3, N'ICAP', N'PAK', N'ISL', CAST(N'2023-05-10' AS Date), CAST(N'2023-05-29' AS Date), 2)
INSERT [dbo].[ProfessionalBackground] ([id], [rowid], [officeName], [country_det], [City_det], [fromDate], [ToDate], [userid]) VALUES (4, 9, N'QVS', N'QAT', N'MUM', CAST(N'2023-05-29' AS Date), CAST(N'2023-05-10' AS Date), 2)
INSERT [dbo].[ProfessionalBackground] ([id], [rowid], [officeName], [country_det], [City_det], [fromDate], [ToDate], [userid]) VALUES (5, 6, N'asd', N'34wd', N'asd324', CAST(N'2023-05-08' AS Date), CAST(N'2023-05-29' AS Date), 2)
SET IDENTITY_INSERT [dbo].[ProfessionalBackground] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_city] ON 

INSERT [dbo].[tbl_city] ([id], [countryid], [cityname]) VALUES (1, 1, N'kar')
INSERT [dbo].[tbl_city] ([id], [countryid], [cityname]) VALUES (2, 1, N'isl')
INSERT [dbo].[tbl_city] ([id], [countryid], [cityname]) VALUES (3, 1, N'lah')
INSERT [dbo].[tbl_city] ([id], [countryid], [cityname]) VALUES (4, 3, N'delhi')
INSERT [dbo].[tbl_city] ([id], [countryid], [cityname]) VALUES (5, 3, N'mumbai')
INSERT [dbo].[tbl_city] ([id], [countryid], [cityname]) VALUES (6, 2, N'doha')
SET IDENTITY_INSERT [dbo].[tbl_city] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_country] ON 

INSERT [dbo].[tbl_country] ([id], [countryname]) VALUES (1, N'pakistan')
INSERT [dbo].[tbl_country] ([id], [countryname]) VALUES (2, N'qatar')
INSERT [dbo].[tbl_country] ([id], [countryname]) VALUES (3, N'india')
SET IDENTITY_INSERT [dbo].[tbl_country] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_status] ON 

INSERT [dbo].[tbl_status] ([id], [statusdesc]) VALUES (1, N'pending')
INSERT [dbo].[tbl_status] ([id], [statusdesc]) VALUES (2, N'approved')
INSERT [dbo].[tbl_status] ([id], [statusdesc]) VALUES (3, N'rejected')
SET IDENTITY_INSERT [dbo].[tbl_status] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([userid], [username], [password], [email], [Phone], [country], [city], [gender], [dob], [profileimage], [hobby], [isadult]) VALUES (1, N'Mujeeb Hafeez', N'Muj123', N'muj@gmail.com', N'03343650490', N'Pak', N'Kara', N'Male', NULL, N'My Pic', N'Crickert', 1)
INSERT [dbo].[UserProfile] ([userid], [username], [password], [email], [Phone], [country], [city], [gender], [dob], [profileimage], [hobby], [isadult]) VALUES (2, N' Hafeez', N'Muj123asdfa', N'qweqemuj@gmail.com', N'03343650490 awe2', N'Pakdad', N'Karaqweqw', N'Male', NULL, N'My Picasdas', N'Crickertcvdffgdfg', 1)
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
USE [master]
GO
ALTER DATABASE [db_muj] SET  READ_WRITE 
GO
