
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/19/2021 21:16:20
-- Generated from EDMX file: C:\Users\rabii\OneDrive\Masaüstü\cSharpOtomasyon\OkulOtomasyon\OkulOtomasyon\OkulModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbo.OkulOtomasyon];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TBL_AYARLAR_TBL_OGRETMENLER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TBL_AYARLAR] DROP CONSTRAINT [FK_TBL_AYARLAR_TBL_OGRETMENLER];
GO
IF OBJECT_ID(N'[dbo].[FK_TBL_OGRAYARLAR_TBL_OGRENCILER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TBL_OGRAYARLAR] DROP CONSTRAINT [FK_TBL_OGRAYARLAR_TBL_OGRENCILER];
GO
IF OBJECT_ID(N'[dbo].[FK_TBL_OGRENCILER_TBL_VELILER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TBL_OGRENCILER] DROP CONSTRAINT [FK_TBL_OGRENCILER_TBL_VELILER];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TBL_AYARLAR]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_AYARLAR];
GO
IF OBJECT_ID(N'[dbo].[TBL_BRANSLAR]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_BRANSLAR];
GO
IF OBJECT_ID(N'[dbo].[TBL_ILCELER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_ILCELER];
GO
IF OBJECT_ID(N'[dbo].[TBL_ILLER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_ILLER];
GO
IF OBJECT_ID(N'[dbo].[TBL_NOT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_NOT];
GO
IF OBJECT_ID(N'[dbo].[TBL_OGRAYARLAR]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_OGRAYARLAR];
GO
IF OBJECT_ID(N'[dbo].[TBL_OGRENCILER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_OGRENCILER];
GO
IF OBJECT_ID(N'[dbo].[TBL_OGRETMENLER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_OGRETMENLER];
GO
IF OBJECT_ID(N'[dbo].[TBL_VELILER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TBL_VELILER];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TBL_AYARLAR'
CREATE TABLE [dbo].[TBL_AYARLAR] (
    [AYARLARID] int  NOT NULL,
    [OGRTSIFRE] varchar(30)  NULL
);
GO

-- Creating table 'TBL_BRANSLAR'
CREATE TABLE [dbo].[TBL_BRANSLAR] (
    [BRANSID] int IDENTITY(1,1) NOT NULL,
    [BRANSAD] varchar(100)  NULL
);
GO

-- Creating table 'TBL_ILCELER'
CREATE TABLE [dbo].[TBL_ILCELER] (
    [id] int  NOT NULL,
    [ilce] nvarchar(255)  NULL,
    [sehir] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TBL_ILLER'
CREATE TABLE [dbo].[TBL_ILLER] (
    [id] int IDENTITY(1,1) NOT NULL,
    [sehir] nvarchar(255)  NULL
);
GO

-- Creating table 'TBL_OGRAYARLAR'
CREATE TABLE [dbo].[TBL_OGRAYARLAR] (
    [AYARLAROGRID] int  NOT NULL,
    [OGRSIFRE] varchar(30)  NULL
);
GO

-- Creating table 'TBL_OGRENCILER'
CREATE TABLE [dbo].[TBL_OGRENCILER] (
    [OGRID] int IDENTITY(1,1) NOT NULL,
    [OGRAD] varchar(30)  NULL,
    [OGRNO] char(4)  NULL,
    [OGRSINIF] char(7)  NULL,
    [OGRDOGTAR] char(10)  NULL,
    [OGRCINSIYET] char(1)  NULL,
    [OGRSOYAD] varchar(30)  NULL,
    [OGRTC] char(11)  NULL,
    [OGRVELIID] int  NULL,
    [OGRIL] varchar(13)  NULL,
    [OGRILCE] varchar(20)  NULL,
    [OGRADRES] varchar(100)  NULL,
    [OGRFOTO] varchar(500)  NULL
);
GO

-- Creating table 'TBL_OGRETMENLER'
CREATE TABLE [dbo].[TBL_OGRETMENLER] (
    [OGRTID] int  NOT NULL,
    [OGRTAD] varchar(30)  NULL,
    [OGRTSOYAD] varchar(30)  NULL,
    [OGRTTC] char(11)  NULL,
    [OGRTTEL] char(15)  NULL,
    [OGRTMAIL] varchar(40)  NULL,
    [OGRTIL] varchar(13)  NULL,
    [OGRTILCE] varchar(20)  NULL,
    [OGRTADRES] varchar(100)  NULL,
    [OGRTBRANS] varchar(30)  NULL,
    [OGRTFOTO] varchar(500)  NULL
);
GO

-- Creating table 'TBL_VELILER'
CREATE TABLE [dbo].[TBL_VELILER] (
    [VELIID] int IDENTITY(1,1) NOT NULL,
    [VELIANNE] varchar(30)  NULL,
    [VELIBABA] varchar(30)  NULL,
    [VELITEL] char(15)  NULL,
    [VELITEL2] char(15)  NULL,
    [VELIMAIL] varchar(50)  NULL
);
GO

-- Creating table 'TBL_NOT'
CREATE TABLE [dbo].[TBL_NOT] (
    [NOTID] int IDENTITY(1,1) NOT NULL,
    [NOTSINIF] varchar(7)  NULL,
    [NOTADSOYAD] varchar(100)  NULL,
    [NOTTC] char(11)  NULL,
    [NOTBRANS] varchar(30)  NULL,
    [SINAV1] char(3)  NULL,
    [SINAV2] char(3)  NULL,
    [PROJE] char(3)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [AYARLARID] in table 'TBL_AYARLAR'
ALTER TABLE [dbo].[TBL_AYARLAR]
ADD CONSTRAINT [PK_TBL_AYARLAR]
    PRIMARY KEY CLUSTERED ([AYARLARID] ASC);
GO

-- Creating primary key on [BRANSID] in table 'TBL_BRANSLAR'
ALTER TABLE [dbo].[TBL_BRANSLAR]
ADD CONSTRAINT [PK_TBL_BRANSLAR]
    PRIMARY KEY CLUSTERED ([BRANSID] ASC);
GO

-- Creating primary key on [id] in table 'TBL_ILCELER'
ALTER TABLE [dbo].[TBL_ILCELER]
ADD CONSTRAINT [PK_TBL_ILCELER]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TBL_ILLER'
ALTER TABLE [dbo].[TBL_ILLER]
ADD CONSTRAINT [PK_TBL_ILLER]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [AYARLAROGRID] in table 'TBL_OGRAYARLAR'
ALTER TABLE [dbo].[TBL_OGRAYARLAR]
ADD CONSTRAINT [PK_TBL_OGRAYARLAR]
    PRIMARY KEY CLUSTERED ([AYARLAROGRID] ASC);
GO

-- Creating primary key on [OGRID] in table 'TBL_OGRENCILER'
ALTER TABLE [dbo].[TBL_OGRENCILER]
ADD CONSTRAINT [PK_TBL_OGRENCILER]
    PRIMARY KEY CLUSTERED ([OGRID] ASC);
GO

-- Creating primary key on [OGRTID] in table 'TBL_OGRETMENLER'
ALTER TABLE [dbo].[TBL_OGRETMENLER]
ADD CONSTRAINT [PK_TBL_OGRETMENLER]
    PRIMARY KEY CLUSTERED ([OGRTID] ASC);
GO

-- Creating primary key on [VELIID] in table 'TBL_VELILER'
ALTER TABLE [dbo].[TBL_VELILER]
ADD CONSTRAINT [PK_TBL_VELILER]
    PRIMARY KEY CLUSTERED ([VELIID] ASC);
GO

-- Creating primary key on [NOTID] in table 'TBL_NOT'
ALTER TABLE [dbo].[TBL_NOT]
ADD CONSTRAINT [PK_TBL_NOT]
    PRIMARY KEY CLUSTERED ([NOTID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AYARLARID] in table 'TBL_AYARLAR'
ALTER TABLE [dbo].[TBL_AYARLAR]
ADD CONSTRAINT [FK_TBL_AYARLAR_TBL_OGRETMENLER]
    FOREIGN KEY ([AYARLARID])
    REFERENCES [dbo].[TBL_OGRETMENLER]
        ([OGRTID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AYARLAROGRID] in table 'TBL_OGRAYARLAR'
ALTER TABLE [dbo].[TBL_OGRAYARLAR]
ADD CONSTRAINT [FK_TBL_OGRAYARLAR_TBL_OGRENCILER]
    FOREIGN KEY ([AYARLAROGRID])
    REFERENCES [dbo].[TBL_OGRENCILER]
        ([OGRID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OGRVELIID] in table 'TBL_OGRENCILER'
ALTER TABLE [dbo].[TBL_OGRENCILER]
ADD CONSTRAINT [FK_TBL_OGRENCILER_TBL_VELILER]
    FOREIGN KEY ([OGRVELIID])
    REFERENCES [dbo].[TBL_VELILER]
        ([VELIID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TBL_OGRENCILER_TBL_VELILER'
CREATE INDEX [IX_FK_TBL_OGRENCILER_TBL_VELILER]
ON [dbo].[TBL_OGRENCILER]
    ([OGRVELIID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------