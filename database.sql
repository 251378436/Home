USE [master]
GO
/****** Object:  Database [HomeDB]    Script Date: 4/1/2022 5:22:10 PM ******/
CREATE DATABASE [HomeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeDB', FILENAME = N'C:\Users\zjgsl\HomeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HomeDB_log', FILENAME = N'C:\Users\zjgsl\HomeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HomeDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HomeDB] SET  MULTI_USER 
GO
ALTER DATABASE [HomeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HomeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HomeDB] SET QUERY_STORE = OFF
GO
USE [HomeDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [HomeDB]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 4/1/2022 5:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Data] [varchar](max) NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrder]    Script Date: 4/1/2022 5:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
	[Customer] [varchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[Discount] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrderItem]    Script Date: 4/1/2022 5:22:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
	[Item] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[Discount] [decimal](18, 0) NULL,
	[SalesOrderID] [int] NULL,
 CONSTRAINT [PK_SalesOrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [HomeDB] SET  READ_WRITE 
GO
