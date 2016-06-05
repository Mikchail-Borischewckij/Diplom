USE [master]
GO
/****** Object:  Database [HomeFinance]    Script Date: 05.06.2016 20:22:01 ******/
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201605161209364_InitialCreate', N'HomeFinance.Data.Impl.DatabaseContext', 0x1F8B0800000000000400ED1DD96EE4B8F13D40FE41D05312CCBAED1964B131BA77E1B4C78991F57830ED5DE46D404B745B888E8EA49ED858E463F21D79C82FE44FF20BA15A17EF43A28EDE6D0C30704B64B158178B5554F17FFFFECFF2BB972874BEC0340B9278E55E9C9DBB0E8CBDC40FE2EDCADDE74F5F7DE37EF7EDAF7FB57CEF472FCE8F75BB77453BD433CE56EE739EEF2E178BCC7B8611C8CEA2C04B932C79CACFBC245A003F59BC3D3FFFC3E2E26201110817C1729CE5A77D9C07113CFC403FD749ECC15DBE07E15DE2C330AB9EA3379B0354E7038860B6031E5CB97F4E227813C400F538BB063938BB8D76A1EB5C850140C86C60F8E43A208E931CE408D5CB1F32B8C9D324DE6E76E801081F5E7710B57B026106AB295CB6CD756773FEB698CDA2ED5883F2F6599E4486002FDE55E459D0DD3B11D96DC88708F81E113A7F2D667D20E2CABDF2BC0451DF75E8B12ED7615AB4E390F81AB50BE2B3AAEB1B876EF0A6910C2440C5BF37CE7A1FE6FB14AE62B8CF5310BE713EEE1FC3C0FB0B7C7D48FE06E315B8F8FAF19BDFBF3B7F7CBA00F0D13FC7914668A376C403F4E8639AEC609ABF7E824FD5546E7DD75990FD1674C7A61BD6A79CE56D9CBF7BEB3A1FF661081E43D8C80446914D9EA4F04F308629C8A1FF11E4394CE302063C5095199D1AABF8BF1E0D09215229D7B9032FDFC3789B3FAF5CF4A7EBDC042FD0AF9F5418FC1007480351A73CDD430E86F251AFA2824977490C5FEBC1AF13447C7348EB1416F3461C6EA651FCFD1044E6B0901EA66ADA2BF0D9A729324EAFC6703E802FC1F6C0520144D7F904C34383EC39D89566A416F7CF6DA39B34893E2561AB45CDBBCF9B649F7A059912418307906E61AE8FDA2DB2C211FC188218C94DC6459068F2B951EC164B6E8306931A557EAB7A4266F8CA101563A840AD334E85D049595B3660D95A3C17B2F4F0D2949DFFFD1742601FED0E8870715A2759CE2311FE9C2110F192479EE5A25D01A4EB422BE5E60B43DDF7B4328CBB32746234A1EE5DB84D0038B15C93E525D5D6A8EF3649CD9730EE22DF737DB7B2B057C6C7DE9ADC98407B2B1E6DC9E5EBA2D98A577354035FBA83086DB29D027BAA316F1286A6A145B0AB6DA8219C8CC3AC770A9D7C727B0E6B477590BBAF02DDE9ED311E9C3E02785038BB2DCEDC060CB2FC56BD1CB7126573552DFA9D1474D60AFA1E312A1C7FD88F20CBFE91A4FE08238B77E6686393E19A26D831658DAAD37B39F62D77F74435E9B6ED5520DAD178D00BBFDCC474DBF5E114E8B4F5C3019CCCC9ACCD89DDF55EB8541AAB252DE712CDEDE1D67677674F62AD29D67676A530F3D26057A63FAC8648068E70EF7C312C79D78714C419F08A29171D7B86063A6EC8EDC62B7A6CEF35E2C4FC2DF1F03B79E59E456FEF6E75D35E58CBAE2BF7C9B29D2CDB2FCEB215823FAE5DD34AEDF0BCA0CE160D9FA31825B2158517FE928F1CD1A2FF36A4474A02EF7FB2699A368D70B34F0989CE9A9D49F211BCF7FCFD4EDF6C04B59357E14A3517604CEEC4A478934D7B5983830A763103878E27FDD7D47F1B4772AEF6F973C5AE811D9ADB2CDB43FF3EEE6D1FDEBFEC8214665D2099C7420EB4616220ED5346A7B057263A74956589171C4627AD567B7A899CCAFBD8775447994A8662E765105B91DE043BA429088795FB3B864212B04DF0B505DB9E3921E15E30709156C1B4106B10AE118191CE0671CEAA60107BC10E840A14A87E9ACA5B10BF19817E730D77302EF44E41549DA1F1636E2C0ACD489465515168B9C064442E3AFC2CBB88D18A947BCB6DEAE089BE28298EB129C5D4923849D11841A6A484D6191FF38C26912B4E6058C472599418B31FA413A32F51B2DC500BBE34DB83C89218811104494C5C9DC16BB7611211E267D2446C56A4D54C39AD02CC11213A5EA812D14EC2249DE608F224A5C6EC454A7A28456F4912057DADAF7DA2A330BA0237C84AC8476AF40591CF042D349854C78482A8E96FA91D2D73299BDAB59ACCA73A46678A9F90523058D75075909D5999A6A96DD2F11B23E20B19D51E5FE49FF7081B4CE093F3861E315470547E3891D192EDB264EB5499B936DBB54DB746F1461F69B3768CEB139B6094B2959F6DEC292BDC04A56EFCC0A6D8F010194B767894D50A435269F2E94246BA914879B28D627B87BD98344F37AA1D12613156F0E8D88390FC2CA816DF052951CBD2C5CFA64E60BAE4188D2D6F5CE2EB1AB36C726B8665034552C04B0DB65CAF52ADFA42C549278EE34CB3038F202B2CF166E64897C95BD427473D60DA1E7B018F2083C573F8C23BCC8950AC0E3F6455B69C667801770373D2C866AED3A68BE9C589911912449D85E4C168F3B60A2054D8930144BDD782867F412300D8DA4505C482F53C30A562A828447FA2C4D28934D25AD313CF4A0980AA31C145476F56628E91AF15B00EFAC8C3A4B26354774C691851C6AAB060CD44955A684DD638EDD0E08E6B0F631234CE376080301DA20F029173D5A083E0D37796181AD97B498681769BB1D948955503248740224A77A00FEFAB239638AA1434EB91F193D03893693320218C24EF8C41ACAC526F92083E3B64A9A2915525A621CFABAA66A2018A4314761E96558A5E3A549A258BBC4BB4411082B7A0678208FC183454DB236D43A4B640728112A4B286313A82AF8284443094196D61D122C924F24156DA122FDD0A53CCCD34745DB287B6BBE4E71EFC4548431FB8E1730C5DCADD532C3B232EC3D4772502028863C39AD1E1EEA4E0C685F597F4AEDE8986F3A68E77EA473CE909E9AC28D210E7808E9BE0B304058124E13BD3005E6F62F12376830A157EB89CA59428D8A40A376128D7FB37090D3801A61E16B53EDEDE44489A77CB45590AB87AB05C086A062FEFC06E5714206A7B564F9C4D594078FDD5C6BCAC6E54C25878845B4CC7739A91F224055B48BD2D44C08737419AE575C4C775D67EC434A3E341824D763D1A15F26179556FBEEB0EC5DF65276E31E53381DD6949798366171561B7C31728AC59607B3A452967108294F3BDCB3A09F7512C0E008A7B976534F0FEE5137D0844B15C1C10F1421F1EF1D92D0E8F78A10FAF8E4DE2A044F14A0956D817050452922F0D0A1DA3D8CDC44719D1A2F49C16552D416E8326FD25591410D2106571D7A9657922BE90DBD2FEBC91C2D36090A2FF305C624F6711B09467B7C490EB0F685923640285353CA61607CBCF12A888D3B6134BA43462D54D28452EA5B6548A014C6D3CEC2C341331BC7427FB7399E7146BF096DF6DAE1CAD8A07E220AA47FA30DA4A803898F6E96C2483DE5C59701D647B4B1DFF41DE7FAE52731476A00E7ADAB2F79DEDFC587CB5E41CE0F587081F017F31E16607AF33440820FE421F1E537C0887C9BC1CD6451ACEA19C4807C990AB1D7BDBD1CC9EB4F0A485FDB4903EEB4C9051710E7A5A9FC7DE7E5C064ED7DF197937CE9CEAA4F9263DF22911ADD35EDC5418AB54417F312C8F8699CB9FA0DF308267272C8B154F22D8DB3E36F0239AF248C4AC9AA706FBC6B63E12B1776C1F8F2C744C52886ED28CDE2487A824D0B24AC8A86F976432346513D74144FA12F8457666F39AE5302A2576F3F7701D06B0B00B75833B64019F60969775C4DCB7E7176FA9DB29E77353E422CBFC50EFBA48925D23D43F0B0AA22A2B9C19D6FE2A77C3E500F117907ACF20FD4D045E7E6BE396C5A73001B98D4B160B372BEF7FC962C0BDE5F336F6E1CBCAFDE9D0E5D2B9FDEBE7B2D71BE73E45E27BE99C3BFFB47033A3EEE06D4F0304CC2FB5FB0589AFB5ABE17E1E3463B7D066024AF7EFA5276495D46E06C38AA5608AA4EA92A3E93884BA4A8B591CAB00DA5B734632EF66374F9D98C44DBBD80045DFC36402ADE30D40276ECE5BE5786987A3659395D590BD53C1C0331AD81D67EF4DE0C1D2414B708FC2812D735EFA67E58F995DA972D2B1938E1DA98EF16F38D1DE9213BD87D22F7EAEE068F54C70998609CDB3D326738C4D26275170B4523759C08FB9F7A1D78240DFEDD059E298BB1D34210D70AD425BAF805B3843BFD674F3B598BAC294A57AD29253F343553FFC395E8C60C03819FFA9CFC1C5D55306910513FED82CE77C3CB5C4F42E3428BFD233AEBD24281DD1E71684CE25E647BF9A606ED59B6C5C47D04B06E83A0392C247472D05CAAF306626063DAE10E8C0CCF92E161DF836FA9A3193FADA9AC5FEADFA109D0ABD1F87D77014EE429792FD83D887F104612A8B704CA640ABD47E6FDF61FC6DE458DE8289B1997FD17C4B16BFACF5C8147F3C766B2FF84A647EB6DEACFC7D878DDD5C986FBE631B4B048EAF80BD45DDCF787B00B3D2E4C7600B241FACCCD32674293D6FDF384C251D93180B2319399A42F1BD1D42F2DA6E83EAF2B37606459F0F4DEA0A52DFAF34A2465703A3594556D36E5682365745AF11E5D72A2BD77F4C1067CB749769C17769BD77DE00435583E78DD5A3603C6F627403F19092C27DF4A8A5223263958F7923F0ABE431FC210D3ECB24F23D97538A12847CFA490AD28BE9A5351D618D7A21F27A54D22D5F2F1CC6A8C0BDB8BE3D0F3EBFA6E228B5EF690D27EB9CB18690E398621D45766546A5ED0DD09645D1B1DE72FB338BAAF5B8F969CB16C9A6CBB52C9C2236FDA73B68457AB349F3D7065E0D2FDB023E70A1F90E539A48F82DD68EEFA7E99C59DA9BDE50C5E1EDF07998A95BAAFA6EAED5C32E54960ABB771556DC656A8BDF589A96ED9AED1D1694D1263B4025F63E3CA5FD556515F2195759B7C0F531C861A174BAB97122760B58D112FDE918D447674B5E2C179F9034065179C275790DB360DB8258229831F488D045D3E6367E4AEA080A8551DD843A897B0773E0831C5CA579F004BC1CBDF660961DB8F72308F7B0F852F211FAB7F1FD3EDFED733465183D868474149118D9F88722F024CECBFBB220998D29203483E2FCF07DFCC77D10FA0DDE379CF3C302104588A73AEE5DF0322F8E7D6F5F1B481F9258135045BE2632F500A35D888065F7F1067C815D7043E2FA3DDC02EFB5AE5C2206A2660449F6E57500B62988B20A46DB1FFD4432EC472FDFFE1FB2CDE5647DB80000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Account] ON 

USE [master]
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
INSERT [dbo].[Tokens] ([Id], [UserId], [AuthToken], [IssuedOn], [ExpiresOn]) VALUES (29, 1, N'57a67a43-df87-476a-9cb4-acdd3d48b20d', 2016-06-05 19:58:27.870, 2016-06-06 23:58:27.870)
SET IDENTITY_INSERT [dbo].[Tokens] OFF

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (7, N'Prior', 413,2016-05-17, 1, 3)
INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (8, N'University', 10130000,2016-05-17, 1, 2)
INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (9, N'webmoney', 34, 2016-05-17, 1, 4)
INSERT [dbo].[Account] ([Id], [Name], [AmountMoney], [CreatedDate], [UserId], [CurrencyId]) VALUES (10, N'43534', 4343, 2016-05-26, 1, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF

GO

SET IDENTITY_INSERT [dbo].[IncomeCategories] ON 
INSERT [dbo].[IncomeCategories] ([Id], [Name], [UserId]) VALUES (4, N'Salary', 1)
INSERT [dbo].[IncomeCategories] ([Id], [Name], [UserId]) VALUES (5, N'Parents help', 1)
INSERT [dbo].[IncomeCategories] ([Id], [Name], [UserId]) VALUES (6, N'Freelance', 1)
SET IDENTITY_INSERT [dbo].[IncomeCategories] OFF
GO

----
----SET IDENTITY_INSERT [dbo].[IncomePlaning] ON 
----INSERT [dbo].[IncomePlaning] ([Id], [IncomeCategoryId], [Amount], [Date], [AccountId]) VALUES (8, 5, 300000,  2016-05-09, 8)
----INSERT [dbo].[IncomePlaning] ([Id], [IncomeCategoryId], [Amount], [Date], [AccountId]) VALUES (9, 4, 3250000,2016-05-09, 8)
----INSERT [dbo].[IncomePlaning] ([Id], [IncomeCategoryId], [Amount], [Date], [AccountId]) VALUES (10, 6, 100000,2016-05-09, 8)
----SET IDENTITY_INSERT [dbo].[IncomePlaning] OFF
----GO

SET IDENTITY_INSERT [dbo].[CostsCategories] ON 

INSERT [dbo].[CostsCategories] ([Id], [Name], [UserId]) VALUES (5, N'ByFly', 1)
INSERT [dbo].[CostsCategories] ([Id], [Name], [UserId]) VALUES (6, N'Mobile', 1)
INSERT [dbo].[CostsCategories] ([Id], [Name], [UserId]) VALUES (7, N'Food', 1)
SET IDENTITY_INSERT [dbo].[CostsCategories] OFF
----SET IDENTITY_INSERT [dbo].[CostsPlaning] ON 
----
----INSERT [dbo].[CostsPlaning] ([Id], [CostsCategoryId], [Amount], [Date], [AccountId]) VALUES (4, 7, 1000000,2016-05-09, 8)
----INSERT [dbo].[CostsPlaning] ([Id], [CostsCategoryId], [Amount], [Date], [AccountId]) VALUES (5, 5, 150000, 2016-05-09, 8)
----SET IDENTITY_INSERT [dbo].[CostsPlaning] OFF

----SET IDENTITY_INSERT [dbo].[Income] ON 
----
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (3, 200, N'salary',2016-05-24,2016-06-23, 2, 7, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (4, 50, N'Help',2016-05-17, NULL, 1, 7, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (5, 10, N'Test project',2016-05-17, NULL, 1, 7, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (6, 300000, N'parents gave me money',2016-05-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (7, 30000, N'help',2016-05-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (8, 550000, N'The customer has paid for the project',2016-05-17, NULL, 1, 8, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (10, 3000000, N'Salary-new',2016-05-17,2016-05-06, 2, 8, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (11, 10, N'salary', 2016-05-24,2016-06-23, 2, 7, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (12, 250, N'Help', 2016-04-17, NULL, 1, 7, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (13, 130, N'Test project', 2016-04-17, NULL, 1, 7, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (14, 500000, N'parents gave me money', 2016-04-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (15, 10000, N'help', 2016-04-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (16, 100000, N'The customer has paid for the project', 2016-04-17, NULL, 1, 8, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (17, 4000000, N'Salary-new', 2016-05-24, 2016-06-23, 2, 8, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (18, 170, N'salary', 2016-05-17, 2016-03-31, 2, 7, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (19, 30, N'Help', 2016-03-17, NULL, 1, 7, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (20, 25, N'Test project', 2016-03-17, NULL, 1, 7, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (21, 240000, N'parents gave me money', 2016-03-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (22, 10000, N'help', 2016-03-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (23, 150000, N'The customer has paid for the project', 2016-03-17, NULL, 1, 8, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (24, 3200000, N'Salary-new', 2016-02-17, 2016-05-06, 2, 8, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (26, 20, N'Help', 2016-02-17 , NULL, 1, 7, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (27, 40, N'Test project', 2016-01-17, NULL, 1, 7, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (28, 300000, N'parents gave me money', 2016-01-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (29, 100000, N'help', 2016-01-17, NULL, 1, 8, 5)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (30, 200000, N'The customer has paid for the project', 2016-01-17, NULL, 1, 8, 6)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (31, 3250000, N'Salary-new', 2016-05-24, 2016-06-23, 2, 8, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (32, 200, N'salary', 2016-05-24, NULL, 1, 7, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (33, 10, N'salary', 2016-05-24, NULL, 1, 7, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (34, 4000000, N'Salary-new', 2016-05-24, NULL, 1, 8, 4)
----INSERT [dbo].[Income] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [IncomeCategoryId]) VALUES (35, 3250000, N'Salary-new', 2016-05-24, NULL, 1, 8, 4)
----SET IDENTITY_INSERT [dbo].[Income] OFF
----
----
----SET IDENTITY_INSERT [dbo].[Costs] ON 
----
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (2, 5, N'mob', 2016-05-17, NULL, 1, 7, 6)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (3, 10, N'restaurant', 2016-05-177, NULL, 1, 7, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (4, 40, N'pizza', 2016-05-17, NULL, 1, 7, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (5, 400000, N':(', 2016-05-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (6, 100000, N'Internet', 2016-05-17, NULL, 1, 8, 5)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (7, 500000, N'food', 2016-05-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (8, 500000, N';(', 2016-05-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (9, 15, N'mob', 2016-04-17, NULL, 1, 7, 6)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (11, 50, N'pizza', 2016-04-17, NULL, 1, 7, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (12, 540000, N':(', 2016-04-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (13, 70000, N'Internet', 2016-04-17, NULL, 1, 8, 5)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (14, 800000, N'food', 2016-04-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (15, 1300000, N';(', 2016-04-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (16, 20, N'mob', 2016-03-17, NULL, 1, 7, 6)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (17, 7, N'restaurant', 2016-03-17, NULL, 1, 7, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (18, 60, N'pizza', 2016-02-17, NULL, 1, 7, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (19, 800000, N':(', 2016-03-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (20, 40000, N'Internet', 2016-03-17, NULL, 1, 8, 5)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (21, 400000, N'food', 2016-02-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (22, 800000, N';(', 2016-02-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (23, 30, N'mob', 2016-01-17, NULL, 1, 7, 6)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (24, 50, N'pizza', 2016-01-17
----, NULL, 1, 7, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (25, 740000, N':(', 2016-01-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (26, 170000, N'Internet', 2016-01-17, NULL, 1, 8, 5)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (27, 180000, N'food', 2016-04-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (28, 300000, N';(', 2016-04-17, NULL, 1, 8, 7)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (29, 2, N'_____', 2016-05-26,2016-06-26, 2, 7, 5)
----INSERT [dbo].[Costs] ([Id], [Amount], [Description], [CreatedDate], [UpdatedDate], [TransactionType], [AccountId], [CostCategoryId]) VALUES (30, 2, N'_____', 2016-05-26, NULL, 1, 7, 5)
----SET IDENTITY_INSERT [dbo].[Costs] OFF