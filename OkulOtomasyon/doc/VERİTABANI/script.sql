USE [master]
GO
/****** Object:  Database [dbo.OkulOtomasyon]    Script Date: 12/19/2021 10:15:18 PM ******/
CREATE DATABASE [dbo.OkulOtomasyon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbo.OkulOtomasyon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbo.OkulOtomasyon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbo.OkulOtomasyon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbo.OkulOtomasyon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbo.OkulOtomasyon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET  MULTI_USER 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET QUERY_STORE = OFF
GO
USE [dbo.OkulOtomasyon]
GO
/****** Object:  Table [dbo].[TBL_AYARLAR]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_AYARLAR](
	[AYARLARID] [int] NOT NULL,
	[OGRTSIFRE] [varchar](30) NULL,
 CONSTRAINT [PK_TBL_AYARLAR] PRIMARY KEY CLUSTERED 
(
	[AYARLARID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_BRANSLAR]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_BRANSLAR](
	[BRANSID] [int] IDENTITY(1,1) NOT NULL,
	[BRANSAD] [varchar](100) NULL,
 CONSTRAINT [PK_TBL_BRANSLAR] PRIMARY KEY CLUSTERED 
(
	[BRANSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_ILCELER]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ILCELER](
	[id] [int] NOT NULL,
	[ilce] [nvarchar](255) NULL,
	[sehir] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ilceler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_ILLER]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ILLER](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sehir] [nvarchar](255) NULL,
 CONSTRAINT [PK_iller] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_NOT]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_NOT](
	[NOTID] [int] IDENTITY(1,1) NOT NULL,
	[NOTSINIF] [varchar](7) NULL,
	[NOTADSOYAD] [varchar](100) NULL,
	[NOTTC] [char](11) NULL,
	[NOTBRANS] [varchar](30) NULL,
	[SINAV1] [char](3) NULL,
	[SINAV2] [char](3) NULL,
	[PROJE] [char](3) NULL,
 CONSTRAINT [PK_TBL_NOT] PRIMARY KEY CLUSTERED 
(
	[NOTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_OGRAYARLAR]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_OGRAYARLAR](
	[AYARLAROGRID] [int] NOT NULL,
	[OGRSIFRE] [varchar](30) NULL,
 CONSTRAINT [PK_TBL_OGRAYARLAR] PRIMARY KEY CLUSTERED 
(
	[AYARLAROGRID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_OGRENCILER]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_OGRENCILER](
	[OGRID] [int] IDENTITY(1,1) NOT NULL,
	[OGRAD] [varchar](30) NULL,
	[OGRNO] [char](4) NULL,
	[OGRSINIF] [char](7) NULL,
	[OGRDOGTAR] [char](10) NULL,
	[OGRCINSIYET] [char](1) NULL,
	[OGRSOYAD] [varchar](30) NULL,
	[OGRTC] [char](11) NULL,
	[OGRVELIID] [int] NULL,
	[OGRIL] [varchar](13) NULL,
	[OGRILCE] [varchar](20) NULL,
	[OGRADRES] [varchar](100) NULL,
	[OGRFOTO] [varchar](500) NULL,
 CONSTRAINT [PK_TBL_OGRENCILER] PRIMARY KEY CLUSTERED 
(
	[OGRID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_OGRETMENLER]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_OGRETMENLER](
	[OGRTID] [int] NOT NULL,
	[OGRTAD] [varchar](30) NULL,
	[OGRTSOYAD] [varchar](30) NULL,
	[OGRTTC] [char](11) NULL,
	[OGRTTEL] [char](15) NULL,
	[OGRTMAIL] [varchar](40) NULL,
	[OGRTIL] [varchar](13) NULL,
	[OGRTILCE] [varchar](20) NULL,
	[OGRTADRES] [varchar](100) NULL,
	[OGRTBRANS] [varchar](30) NULL,
	[OGRTFOTO] [varchar](500) NULL,
 CONSTRAINT [PK_TBL_OGRETMENLER] PRIMARY KEY CLUSTERED 
(
	[OGRTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_VELILER]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_VELILER](
	[VELIID] [int] IDENTITY(1,1) NOT NULL,
	[VELIANNE] [varchar](30) NULL,
	[VELIBABA] [varchar](30) NULL,
	[VELITEL] [char](15) NULL,
	[VELITEL2] [char](15) NULL,
	[VELIMAIL] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_VELILER] PRIMARY KEY CLUSTERED 
(
	[VELIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBL_OGRETMENLER] ADD  CONSTRAINT [DF_TBL_OGRETMENLER_OGRTID]  DEFAULT ((0)) FOR [OGRTID]
GO
ALTER TABLE [dbo].[TBL_AYARLAR]  WITH CHECK ADD  CONSTRAINT [FK_TBL_AYARLAR_TBL_OGRETMENLER] FOREIGN KEY([AYARLARID])
REFERENCES [dbo].[TBL_OGRETMENLER] ([OGRTID])
GO
ALTER TABLE [dbo].[TBL_AYARLAR] CHECK CONSTRAINT [FK_TBL_AYARLAR_TBL_OGRETMENLER]
GO
ALTER TABLE [dbo].[TBL_OGRAYARLAR]  WITH CHECK ADD  CONSTRAINT [FK_TBL_OGRAYARLAR_TBL_OGRENCILER] FOREIGN KEY([AYARLAROGRID])
REFERENCES [dbo].[TBL_OGRENCILER] ([OGRID])
GO
ALTER TABLE [dbo].[TBL_OGRAYARLAR] CHECK CONSTRAINT [FK_TBL_OGRAYARLAR_TBL_OGRENCILER]
GO
ALTER TABLE [dbo].[TBL_OGRENCILER]  WITH CHECK ADD  CONSTRAINT [FK_TBL_OGRENCILER_TBL_VELILER] FOREIGN KEY([OGRVELIID])
REFERENCES [dbo].[TBL_VELILER] ([VELIID])
GO
ALTER TABLE [dbo].[TBL_OGRENCILER] CHECK CONSTRAINT [FK_TBL_OGRENCILER_TBL_VELILER]
GO
/****** Object:  StoredProcedure [dbo].[AyarlarOgrenciler]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AyarlarOgrenciler]
as
Select AYARLAROGRID, (OGRAD+' '+OGRSOYAD) as OGRADSOYAD,OGRSINIF,OGRTC,OGRSIFRE,OGRFOTO from TBL_OGRAYARLAR
inner join TBL_OGRENCILER
on
TBL_OGRAYARLAR.AYARLAROGRID=TBL_OGRENCILER.OGRID
GO
/****** Object:  StoredProcedure [dbo].[AyarlarOgretmenler]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AyarlarOgretmenler]
as
Select AYARLARID, (OGRTAD+ ' '+OGRTSOYAD) as OGRTADSOYAD, OGRTBRANS,OGRTTC,OGRTSIFRE,OGRTFOTO from TBL_AYARLAR
inner join TBL_OGRETMENLER
on 
TBL_AYARLAR.AYARLARID=TBL_OGRETMENLER.OGRTID

GO
/****** Object:  StoredProcedure [dbo].[OgrenciVeli5]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[OgrenciVeli5]
as
Select OGRID,OGRAD,OGRSOYAD,OGRTC,OGRSINIF,OGRNO,OGRDOGTAR,OGRCINSIYET,OGRIL,OGRILCE,OGRADRES,OGRFOTO,(VELIANNE + ' | ' + VELIBABA) as VELIANNEBABA from TBL_OGRENCILER
inner join TBL_VELILER
on
TBL_OGRENCILER.OGRVELIID=TBL_VELILER.VELIID
where 
OGRSINIF='5.SINIF'
GO
/****** Object:  StoredProcedure [dbo].[OgrenciVeli6]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[OgrenciVeli6]
as
Select OGRID,OGRAD,OGRSOYAD,OGRTC,OGRSINIF,OGRNO,OGRDOGTAR,OGRCINSIYET,OGRIL,OGRILCE,OGRADRES,OGRFOTO,(VELIANNE + ' | ' + VELIBABA) as VELIANNEBABA from TBL_OGRENCILER
inner join TBL_VELILER
on
TBL_OGRENCILER.OGRVELIID=TBL_VELILER.VELIID
where 
OGRSINIF='6.SINIF'
GO
/****** Object:  StoredProcedure [dbo].[OgrenciVeli7]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[OgrenciVeli7]
as
Select OGRID,OGRAD,OGRSOYAD,OGRTC,OGRSINIF,OGRNO,OGRDOGTAR,OGRCINSIYET,OGRIL,OGRILCE,OGRADRES,OGRFOTO,(VELIANNE + ' | ' + VELIBABA) as VELIANNEBABA from TBL_OGRENCILER
inner join TBL_VELILER
on
TBL_OGRENCILER.OGRVELIID=TBL_VELILER.VELIID
where 
OGRSINIF='7.SINIF'
GO
/****** Object:  StoredProcedure [dbo].[OgrenciVeli8]    Script Date: 12/19/2021 10:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[OgrenciVeli8]
as
Select OGRID,OGRAD,OGRSOYAD,OGRTC,OGRSINIF,OGRNO,OGRDOGTAR,OGRCINSIYET,OGRIL,OGRILCE,OGRADRES,OGRFOTO,(VELIANNE + ' | ' + VELIBABA) as VELIANNEBABA from TBL_OGRENCILER
inner join TBL_VELILER
on
TBL_OGRENCILER.OGRVELIID=TBL_VELILER.VELIID
where 
OGRSINIF='8.SINIF'
GO
USE [master]
GO
ALTER DATABASE [dbo.OkulOtomasyon] SET  READ_WRITE 
GO
