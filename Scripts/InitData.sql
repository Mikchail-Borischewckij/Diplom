
USE [master]

SET LANGUAGE English;

GO
/****** Object:  Database [HomeFinance]    Script Date: 05.06.2016 23:02:20 ******/
CREATE DATABASE [HomeFinance]
GO
ALTER DATABASE [HomeFinance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeFinance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeFinance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeFinance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeFinance] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeFinance] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HomeFinance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeFinance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeFinance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeFinance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeFinance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeFinance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeFinance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeFinance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeFinance] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HomeFinance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeFinance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeFinance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeFinance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeFinance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeFinance] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HomeFinance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeFinance] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HomeFinance] SET  MULTI_USER 
GO
ALTER DATABASE [HomeFinance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeFinance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeFinance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeFinance] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HomeFinance] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HomeFinance]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Account]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AmountMoney] [float] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Costs]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Costs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[TransactionType] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[CostCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Costs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CostsCategories]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostsCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CostsCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CostsPlaning]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostsPlaning](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CostsCategoryId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[Date] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CostsPlaning] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currency]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Income]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[TransactionType] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[IncomeCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Income] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomeCategories]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomeCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.IncomeCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomePlaning]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomePlaning](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IncomeCategoryId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[Date] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.IncomePlaning] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AuthToken] [nvarchar](max) NULL,
	[IssuedOn] [datetime] NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Tokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 05.06.2016 23:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_CurrencyId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_CurrencyId] ON [dbo].[Account]
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Account]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Costs]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CostCategoryId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_CostCategoryId] ON [dbo].[Costs]
(
	[CostCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[CostsCategories]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[CostsPlaning]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CostsCategoryId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_CostsCategoryId] ON [dbo].[CostsPlaning]
(
	[CostsCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Income]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IncomeCategoryId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_IncomeCategoryId] ON [dbo].[Income]
(
	[IncomeCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[IncomeCategories]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[IncomePlaning]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IncomeCategoryId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_IncomeCategoryId] ON [dbo].[IncomePlaning]
(
	[IncomeCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 05.06.2016 23:02:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Tokens]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Account_dbo.Currency_CurrencyId] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_dbo.Account_dbo.Currency_CurrencyId]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Account_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_dbo.Account_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Costs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Costs_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Costs] CHECK CONSTRAINT [FK_dbo.Costs_dbo.Account_AccountId]
GO
ALTER TABLE [dbo].[Costs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Costs_dbo.CostsCategories_CostCategoryId] FOREIGN KEY([CostCategoryId])
REFERENCES [dbo].[CostsCategories] ([Id])
GO
ALTER TABLE [dbo].[Costs] CHECK CONSTRAINT [FK_dbo.Costs_dbo.CostsCategories_CostCategoryId]
GO
ALTER TABLE [dbo].[CostsCategories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CostsCategories_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CostsCategories] CHECK CONSTRAINT [FK_dbo.CostsCategories_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[CostsPlaning]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CostsPlaning_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[CostsPlaning] CHECK CONSTRAINT [FK_dbo.CostsPlaning_dbo.Account_AccountId]
GO
ALTER TABLE [dbo].[CostsPlaning]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CostsPlaning_dbo.CostsCategories_CostsCategoryId] FOREIGN KEY([CostsCategoryId])
REFERENCES [dbo].[CostsCategories] ([Id])
GO
ALTER TABLE [dbo].[CostsPlaning] CHECK CONSTRAINT [FK_dbo.CostsPlaning_dbo.CostsCategories_CostsCategoryId]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Income_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_dbo.Income_dbo.Account_AccountId]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Income_dbo.IncomeCategories_IncomeCategoryId] FOREIGN KEY([IncomeCategoryId])
REFERENCES [dbo].[IncomeCategories] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_dbo.Income_dbo.IncomeCategories_IncomeCategoryId]
GO
ALTER TABLE [dbo].[IncomeCategories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IncomeCategories_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[IncomeCategories] CHECK CONSTRAINT [FK_dbo.IncomeCategories_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[IncomePlaning]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IncomePlaning_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[IncomePlaning] CHECK CONSTRAINT [FK_dbo.IncomePlaning_dbo.Account_AccountId]
GO
ALTER TABLE [dbo].[IncomePlaning]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IncomePlaning_dbo.IncomeCategories_IncomeCategoryId] FOREIGN KEY([IncomeCategoryId])
REFERENCES [dbo].[IncomeCategories] ([Id])
GO
ALTER TABLE [dbo].[IncomePlaning] CHECK CONSTRAINT [FK_dbo.IncomePlaning_dbo.IncomeCategories_IncomeCategoryId]
GO
ALTER TABLE [dbo].[Tokens]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tokens_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tokens] CHECK CONSTRAINT [FK_dbo.Tokens_dbo.Users_UserId]
go
ALTER DATABASE [HomeFinance] SET  READ_WRITE 
GO

SET IDENTITY_INSERT [dbo].[Currency] On
INSERT [dbo].[Currency] ([Id], [Name]) VALUES (1, N'RUB')
INSERT [dbo].[Currency] ([Id], [Name]) VALUES (2, N'BLR')
INSERT [dbo].[Currency] ([Id], [Name]) VALUES (3, N'USD')
INSERT [dbo].[Currency] ([Id], [Name]) VALUES (4, N'EUR')
SET IDENTITY_INSERT [dbo].[Currency] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] On
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (1, N'admin', N'mik12094921@yandex.ru', N'ACioSS1CO6KG/sRsgqqu2/slJIQFOuYjkVVuGmjhZXDcutYUNqsLTnOqJswvCzi7ug==')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Tokens] ON 
INSERT [dbo].[Tokens] ([Id], [UserId], [AuthToken], [IssuedOn], [ExpiresOn]) VALUES (29, 1, N'57a67a43-df87-476a-9cb4-acdd3d48b20d','06/05/2016 12:00:00 AM','06/05/2016 12:00:00 AM')
SET IDENTITY_INSERT [dbo].[Tokens] OFF

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (7, N'Prior', 413,'05/17/2016 12:00:00 AM', 1, 3)
INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (8, N'University', 10130000,'05/17/2016 12:00:00 AM', 1, 2)
INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (9, N'webmoney', 34, '05/17/2016 12:00:00 AM', 1, 4)
INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (10, N'43534', 4343, '05/26/2016 12:00:00 AM', 1, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF

GO

SET IDENTITY_INSERT [dbo].[IncomeCategories] ON 
INSERT [dbo].[IncomeCategories] ([Id], [Name], [UserId]) VALUES (4, N'Salary', 1)
INSERT [dbo].[IncomeCategories] ([Id], [Name], [UserId]) VALUES (5, N'Parents help', 1)
INSERT [dbo].[IncomeCategories] ([Id], [Name], [UserId]) VALUES (6, N'Freelance', 1)
SET IDENTITY_INSERT [dbo].[IncomeCategories] OFF
GO


SET IDENTITY_INSERT [dbo].[IncomePlaning] ON 
INSERT [dbo].[IncomePlaning] ([Id], [IncomeCategoryId], [Amount], [Date], [AccountId]) VALUES (8, 5, 300000,  '05/09/2016 12:00:00 AM', 8)
INSERT [dbo].[IncomePlaning] ([Id], [IncomeCategoryId], [Amount], [Date], [AccountId]) VALUES (9, 4, 3250000,'05/09/2016 12:00:00 AM', 8)
INSERT [dbo].[IncomePlaning] ([Id], [IncomeCategoryId], [Amount], [Date], [AccountId]) VALUES (10, 6, 100000,'05/09/2016 12:00:00 AM', 8)
SET IDENTITY_INSERT [dbo].[IncomePlaning] OFF
GO

SET IDENTITY_INSERT [dbo].[CostsCategories] ON 

INSERT [dbo].[CostsCategories] ([Id], [Name], [UserId]) VALUES (5, N'ByFly', 1)
INSERT [dbo].[CostsCategories] ([Id], [Name], [UserId]) VALUES (6, N'Mobile', 1)
INSERT [dbo].[CostsCategories] ([Id], [Name], [UserId]) VALUES (7, N'Food', 1)
SET IDENTITY_INSERT [dbo].[CostsCategories] OFF
SET IDENTITY_INSERT [dbo].[CostsPlaning] ON 

INSERT [dbo].[CostsPlaning] ([Id], [CostsCategoryId], [Amount], [Date], [AccountId]) VALUES (4, 7, 1000000,'05/09/2016 12:00:00 AM', 8)
INSERT [dbo].[CostsPlaning] ([Id], [CostsCategoryId], [Amount], [Date], [AccountId]) VALUES (5, 5, 150000, '05/09/2016 12:00:00 AM', 8)
SET IDENTITY_INSERT [dbo].[CostsPlaning] OFF

SET IDENTITY_INSERT [dbo].[Income] ON 

INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (3, 200, N'salary','05/24/2016 12:00:00 AM','06/23/2016 12:00:00 AM', 2, 7, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (4, 50, N'Help','05/17/2016 12:00:00 AM', NULL, 1, 7, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (5, 10, N'Test project','05/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (6, 300000, N'parents gave me money','05/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (7, 30000, N'help','05/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (8, 550000, N'The customer has paid for the project','05/17/2016 12:00:00 AM', NULL, 1, 8, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (10, 3000000, N'Salary-new','05/17/2016 12:00:00 AM','05/06/2016 12:00:00 AM', 2, 8, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (11, 10, N'salary', '05/24/2016 12:00:00 AM','06/23/2016 12:00:00 AM', 2, 7, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (12, 250, N'Help', '04/17/2016 12:00:00 AM', NULL, 1, 7, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (13, 130, N'Test project', '04/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (14, 500000, N'parents gave me money', '04/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (15, 10000, N'help', '04/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (16, 100000, N'The customer has paid for the project', '04/17/2016 12:00:00 AM', NULL, 1, 8, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (17, 4000000, N'Salary-new', '05/24/2016 12:00:00 AM', '06/23/2016 12:00:00 AM', 2, 8, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (18, 170, N'salary', '05/17/2016 12:00:00 AM', '03/31/2016 12:00:00 AM', 2, 7, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (19, 30, N'Help', '03/17/2016 12:00:00 AM', NULL, 1, 7, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (20, 25, N'Test project', '03/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (21, 240000, N'parents gave me money', '03/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (22, 10000, N'help', '03/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (23, 150000, N'The customer has paid for the project', '03/17/2016 12:00:00 AM', NULL, 1, 8, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (24, 3200000, N'Salary-new', '02/17/2016 12:00:00 AM', '05/06/2016 12:00:00 AM', 2, 8, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (26, 20, N'Help', '02/17/2016 12:00:00 AM' , NULL, 1, 7, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (27, 40, N'Test project', '01/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (28, 300000, N'parents gave me money', '01/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (29, 100000, N'help', '01/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (30, 200000, N'The customer has paid for the project', '01/17/2016 12:00:00 AM', NULL, 1, 8, 6)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (31, 3250000, N'Salary-new', '05/24/2016 12:00:00 AM', '06/23/2016 12:00:00 AM', 2, 8, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (32, 200, N'salary', '05/24/2016 12:00:00 AM', NULL, 1, 7, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (33, 10, N'salary', '05/24/2016 12:00:00 AM', NULL, 1, 7, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (34, 4000000, N'Salary-new', '05/24/2016 12:00:00 AM', NULL, 1, 8, 4)
INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (35, 3250000, N'Salary-new', '05/24/2016 12:00:00 AM', NULL, 1, 8, 4)
SET IDENTITY_INSERT [dbo].[Income] OFF


SET IDENTITY_INSERT [dbo].[Costs] ON 

INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (2, 5, N'mob', '05/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (3, 10, N'restaurant', '05/17/2016 12:00:00 AM', NULL, 1, 7, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (4, 40, N'pizza', '05/17/2016 12:00:00 AM', NULL, 1, 7, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (5, 400000, N':(', '05/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (6, 100000, N'Internet', '05/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (7, 500000, N'food', '05/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (8, 500000, N';(', '05/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (9, 15, N'mob', '04/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (11, 50, N'pizza', '04/17/2016 12:00:00 AM', NULL, 1, 7, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (12, 540000, N':(', '04/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (13, 70000, N'Internet', '04/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (14, 800000, N'food', '04/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (15, 1300000, N';(', '04/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (16, 20, N'mob', '03/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (17, 7, N'restaurant', '03/17/2016 12:00:00 AM', NULL, 1, 7, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (18, 60, N'pizza', '02/17/2016 12:00:00 AM', NULL, 1, 7, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (19, 800000, N':(', '03/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (20, 40000, N'Internet', '03/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (21, 400000, N'food', '02/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (22, 800000, N';(', '02/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (23, 30, N'mob', '01/17/2016 12:00:00 AM', NULL, 1, 7, 6)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (24, 50, N'pizza', '01/17/2016 12:00:00 AM'
, NULL, 1, 7, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (25, 740000, N':(', '01/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (26, 170000, N'Internet', '01/17/2016 12:00:00 AM', NULL, 1, 8, 5)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (27, 180000, N'food', '04/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (28, 300000, N';(', '04/17/2016 12:00:00 AM', NULL, 1, 8, 7)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (29, 2, N'_____', '05/26/2016 12:00:00 AM','06/26/2016 12:00:00 AM', 2, 7, 5)
INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (30, 2, N'_____', '05/26/2016 12:00:00 AM', NULL, 1, 7, 5)
SET IDENTITY_INSERT [dbo].[Costs] OFF