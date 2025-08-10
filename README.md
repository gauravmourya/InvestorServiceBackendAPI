We can run below SQL script to create database with some seeded data

USE [master]
GO
/****** Object:  Database [Investments]    Script Date: 10-08-2025 13:10:09 ******/
CREATE DATABASE [Investments]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Investments', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Investments.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Investments_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Investments_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Investments] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Investments].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Investments] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Investments] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Investments] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Investments] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Investments] SET ARITHABORT OFF 
GO
ALTER DATABASE [Investments] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Investments] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Investments] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Investments] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Investments] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Investments] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Investments] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Investments] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Investments] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Investments] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Investments] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Investments] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Investments] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Investments] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Investments] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Investments] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Investments] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Investments] SET RECOVERY FULL 
GO
ALTER DATABASE [Investments] SET  MULTI_USER 
GO
ALTER DATABASE [Investments] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Investments] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Investments] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Investments] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Investments] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Investments] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Investments', N'ON'
GO
ALTER DATABASE [Investments] SET QUERY_STORE = ON
GO
ALTER DATABASE [Investments] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Investments]
GO
/****** Object:  Table [dbo].[Commitment]    Script Date: 10-08-2025 13:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commitment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvestorID] [int] NOT NULL,
	[AssetClassID] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommitmentAssetClass]    Script Date: 10-08-2025 13:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommitmentAssetClass](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommitmentCurrency]    Script Date: 10-08-2025 13:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommitmentCurrency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [char](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Investor]    Script Date: 10-08-2025 13:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Investor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[InvestorTypeID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[LastUpdated] [date] NOT NULL,
	[Email] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestorAddress]    Script Date: 10-08-2025 13:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestorAddress](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvestorID] [int] NOT NULL,
	[Address] [nvarchar](400) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestorCountry]    Script Date: 10-08-2025 13:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestorCountry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestorType]    Script Date: 10-08-2025 13:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestorType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Commitment] ON 
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (1, 1, 1, CAST(154123000.00 AS Decimal(18, 2)), 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (2, 2, 1, CAST(31233300.00 AS Decimal(18, 2)), 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (3, 3, 2, CAST(589456612.00 AS Decimal(18, 2)), 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (4, 4, 3, CAST(721233219.89 AS Decimal(18, 2)), 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (5, 4, 4, CAST(1000000.00 AS Decimal(18, 2)), 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (6, 1, 1, CAST(15000000.00 AS Decimal(18, 2)), 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (7, 1, 1, CAST(15000000.00 AS Decimal(18, 2)), 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (8, 2, 1, CAST(31000000.00 AS Decimal(18, 2)), 1, CAST(N'2024-12-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (9, 3, 2, CAST(58000000.00 AS Decimal(18, 2)), 1, CAST(N'2023-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (10, 4, 3, CAST(72000000.00 AS Decimal(18, 2)), 1, CAST(N'2025-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (11, 4, 4, CAST(1000000.00 AS Decimal(18, 2)), 1, CAST(N'2020-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (12, 4, 4, CAST(12312433.21 AS Decimal(18, 2)), 1, CAST(N'2025-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (13, 4, 2, CAST(1232133.00 AS Decimal(18, 2)), 1, CAST(N'2025-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (14, 4, 1, CAST(12223499.99 AS Decimal(18, 2)), 1, CAST(N'2025-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (15, 4, 1, CAST(123432411.34 AS Decimal(18, 2)), 1, CAST(N'2025-02-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (19, 4, 5, CAST(900000000.99 AS Decimal(18, 2)), 1, CAST(N'2025-02-09T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (20, 4, 5, CAST(1222.23 AS Decimal(18, 2)), 1, CAST(N'2024-02-09T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Commitment] ([ID], [InvestorID], [AssetClassID], [Amount], [CurrencyID], [Date]) VALUES (21, 4, 5, CAST(123123.22 AS Decimal(18, 2)), 1, CAST(N'2020-02-02T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Commitment] OFF
GO
SET IDENTITY_INSERT [dbo].[CommitmentAssetClass] ON 
GO
INSERT [dbo].[CommitmentAssetClass] ([ID], [Name]) VALUES (2, N'Hedge Funds')
GO
INSERT [dbo].[CommitmentAssetClass] ([ID], [Name]) VALUES (1, N'Infrastructure')
GO
INSERT [dbo].[CommitmentAssetClass] ([ID], [Name]) VALUES (4, N'Natural Resources')
GO
INSERT [dbo].[CommitmentAssetClass] ([ID], [Name]) VALUES (3, N'Private Equity')
GO
INSERT [dbo].[CommitmentAssetClass] ([ID], [Name]) VALUES (5, N'Real Estate')
GO
SET IDENTITY_INSERT [dbo].[CommitmentAssetClass] OFF
GO
SET IDENTITY_INSERT [dbo].[CommitmentCurrency] ON 
GO
INSERT [dbo].[CommitmentCurrency] ([ID], [CurrencyCode]) VALUES (1, N'GBP')
GO
SET IDENTITY_INSERT [dbo].[CommitmentCurrency] OFF
GO
SET IDENTITY_INSERT [dbo].[Investor] ON 
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (1, N'Ioo Gryffindor fund', 1, 1, CAST(N'2000-07-06' AS Date), CAST(N'2024-02-21' AS Date), N'test@email.com')
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (2, N'Ibx Skywalker ltd', 2, 2, CAST(N'1997-07-21' AS Date), CAST(N'2024-02-21' AS Date), N'test2@email.com')
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (3, N'Cza Weasley fund', 3, 3, CAST(N'2002-05-29' AS Date), CAST(N'2024-02-21' AS Date), N'test3@email.com')
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (4, N'Mjd Jedi fund', 4, 4, CAST(N'2010-06-08' AS Date), CAST(N'2024-02-21' AS Date), N'test4@email.com')
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (5, N'Ioo Gryffindor fund', 1, 1, CAST(N'2000-07-06' AS Date), CAST(N'2024-02-21' AS Date), N'tes2t@test.com')
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (6, N'Ibx Skywalker ltd', 2, 2, CAST(N'1997-07-21' AS Date), CAST(N'2024-02-21' AS Date), N'test01@test.com')
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (7, N'Cza Weasley fund', 3, 3, CAST(N'2002-05-29' AS Date), CAST(N'2024-02-21' AS Date), N't2est@test.com')
GO
INSERT [dbo].[Investor] ([ID], [Name], [InvestorTypeID], [CountryID], [DateAdded], [LastUpdated], [Email]) VALUES (8, N'Mjd Jedi fund', 4, 4, CAST(N'2010-06-08' AS Date), CAST(N'2024-02-21' AS Date), N'tes2t3@test.com')
GO
SET IDENTITY_INSERT [dbo].[Investor] OFF
GO
SET IDENTITY_INSERT [dbo].[InvestorAddress] ON 
GO
INSERT [dbo].[InvestorAddress] ([ID], [InvestorID], [Address], [IsActive]) VALUES (1, 1, N'Times square', 1)
GO
INSERT [dbo].[InvestorAddress] ([ID], [InvestorID], [Address], [IsActive]) VALUES (2, 2, N'New square', 1)
GO
INSERT [dbo].[InvestorAddress] ([ID], [InvestorID], [Address], [IsActive]) VALUES (3, 3, N'town square', 1)
GO
INSERT [dbo].[InvestorAddress] ([ID], [InvestorID], [Address], [IsActive]) VALUES (4, 4, N'Wall street square', 0)
GO
INSERT [dbo].[InvestorAddress] ([ID], [InvestorID], [Address], [IsActive]) VALUES (5, 4, N'Some street', 1)
GO
SET IDENTITY_INSERT [dbo].[InvestorAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[InvestorCountry] ON 
GO
INSERT [dbo].[InvestorCountry] ([ID], [Name]) VALUES (4, N'China')
GO
INSERT [dbo].[InvestorCountry] ([ID], [Name]) VALUES (1, N'Singapore')
GO
INSERT [dbo].[InvestorCountry] ([ID], [Name]) VALUES (3, N'United Kingdom')
GO
INSERT [dbo].[InvestorCountry] ([ID], [Name]) VALUES (2, N'United States')
GO
SET IDENTITY_INSERT [dbo].[InvestorCountry] OFF
GO
SET IDENTITY_INSERT [dbo].[InvestorType] ON 
GO
INSERT [dbo].[InvestorType] ([ID], [Name]) VALUES (2, N'Asset Manager')
GO
INSERT [dbo].[InvestorType] ([ID], [Name]) VALUES (4, N'Bank')
GO
INSERT [dbo].[InvestorType] ([ID], [Name]) VALUES (1, N'Fund Manager')
GO
INSERT [dbo].[InvestorType] ([ID], [Name]) VALUES (3, N'Wealth Manager')
GO
SET IDENTITY_INSERT [dbo].[InvestorType] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Commitme__737584F6B2388E50]    Script Date: 10-08-2025 13:10:10 ******/
ALTER TABLE [dbo].[CommitmentAssetClass] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Commitme__408426BF02DB0DFA]    Script Date: 10-08-2025 13:10:10 ******/
ALTER TABLE [dbo].[CommitmentCurrency] ADD UNIQUE NONCLUSTERED 
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Email]    Script Date: 10-08-2025 13:10:10 ******/
ALTER TABLE [dbo].[Investor] ADD  CONSTRAINT [UQ_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_InvestorAddress_InvestorID_Active]    Script Date: 10-08-2025 13:10:10 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_InvestorAddress_InvestorID_Active] ON [dbo].[InvestorAddress]
(
	[InvestorID] ASC
)
WHERE ([IsActive]=(1))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Investor__737584F63D33C449]    Script Date: 10-08-2025 13:10:10 ******/
ALTER TABLE [dbo].[InvestorCountry] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Investor__737584F6DDEE131D]    Script Date: 10-08-2025 13:10:10 ******/
ALTER TABLE [dbo].[InvestorType] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD FOREIGN KEY([AssetClassID])
REFERENCES [dbo].[CommitmentAssetClass] ([ID])
GO
ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[CommitmentCurrency] ([ID])
GO
ALTER TABLE [dbo].[Commitment]  WITH CHECK ADD FOREIGN KEY([InvestorID])
REFERENCES [dbo].[Investor] ([ID])
GO
ALTER TABLE [dbo].[Investor]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[InvestorCountry] ([ID])
GO
ALTER TABLE [dbo].[Investor]  WITH CHECK ADD FOREIGN KEY([InvestorTypeID])
REFERENCES [dbo].[InvestorType] ([ID])
GO
ALTER TABLE [dbo].[InvestorAddress]  WITH CHECK ADD FOREIGN KEY([InvestorID])
REFERENCES [dbo].[Investor] ([ID])
GO
USE [master]
GO
ALTER DATABASE [Investments] SET  READ_WRITE 
GO
