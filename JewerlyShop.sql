USE [master]
GO
/****** Object:  Database [JewerlyShop]    Script Date: 06.06.2022 4:53:46 ******/
CREATE DATABASE [JewerlyShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JewerlyShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JewerlyShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JewerlyShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JewerlyShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JewerlyShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JewerlyShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JewerlyShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JewerlyShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JewerlyShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JewerlyShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JewerlyShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [JewerlyShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JewerlyShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JewerlyShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JewerlyShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JewerlyShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JewerlyShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JewerlyShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JewerlyShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JewerlyShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JewerlyShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JewerlyShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JewerlyShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JewerlyShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JewerlyShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JewerlyShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JewerlyShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JewerlyShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JewerlyShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JewerlyShop] SET  MULTI_USER 
GO
ALTER DATABASE [JewerlyShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JewerlyShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JewerlyShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JewerlyShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JewerlyShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JewerlyShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [JewerlyShop] SET QUERY_STORE = OFF
GO
USE [JewerlyShop]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 06.06.2022 4:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06.06.2022 4:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 06.06.2022 4:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProvider] [int] NOT NULL,
	[IdTypeProducts] [int] NOT NULL,
	[IdMaterial] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Weight] [decimal](4, 2) NOT NULL,
	[Proba] [int] NOT NULL,
	[PurchasePrice] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[ImageProduct] [nvarchar](max) NOT NULL,
	[Size] [decimal](5, 2) NOT NULL,
	[Volume] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 06.06.2022 4:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 06.06.2022 4:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduct] [int] NOT NULL,
	[IdClient] [int] NOT NULL,
	[DateSale] [datetime] NOT NULL,
	[Price] [bigint] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeProducts]    Script Date: 06.06.2022 4:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeProducts](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [FIO], [Phone]) VALUES (1, N'Шайдуров Никита Александрович', N'7(495)409-95-33')
INSERT [dbo].[Clients] ([Id], [FIO], [Phone]) VALUES (2, N'Никитин Демид Андреевич', N'7(495)550-82-76')
INSERT [dbo].[Clients] ([Id], [FIO], [Phone]) VALUES (3, N'Муравьева Есения Давидовна', N'7(495)279-03-92')
INSERT [dbo].[Clients] ([Id], [FIO], [Phone]) VALUES (4, N'Островский Владислав Максимович', N'7(495)867-12-75')
INSERT [dbo].[Clients] ([Id], [FIO], [Phone]) VALUES (5, N'Самойлов Богдан Гордеевич', N'7(495)855-38-92')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Materials] ON 

INSERT [dbo].[Materials] ([Id], [Name]) VALUES (1, N'Красное золото')
INSERT [dbo].[Materials] ([Id], [Name]) VALUES (2, N'Серебро')
INSERT [dbo].[Materials] ([Id], [Name]) VALUES (3, N'Белое золото')
INSERT [dbo].[Materials] ([Id], [Name]) VALUES (4, N'Комбинированное золото')
INSERT [dbo].[Materials] ([Id], [Name]) VALUES (5, N'Жёлтое золото')
SET IDENTITY_INSERT [dbo].[Materials] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (1, 1, 1, 1, N'Кольцо из золота с бриллиантом', CAST(1.64 AS Decimal(4, 2)), 585, 10000, 15000, N'\Products\Product1.jpg', CAST(15.50 AS Decimal(5, 2)), 4)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (2, 2, 2, 2, N'Цепь из серебра с алмазной гранью', CAST(20.38 AS Decimal(4, 2)), 925, 2000, 5000, N'\Products\Product2.jpg', CAST(12.50 AS Decimal(5, 2)), 10)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (3, 3, 3, 3, N'Серьги из белого золота с бриллиантами', CAST(2.10 AS Decimal(4, 2)), 585, 29000, 37500, N'\Products\Product3.jpg', CAST(3.15 AS Decimal(5, 2)), 3)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (4, 4, 4, 4, N'Браслет из золота', CAST(7.48 AS Decimal(4, 2)), 585, 35000, 45000, N'\Products\Product4.jpg', CAST(160.00 AS Decimal(5, 2)), 5)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (5, 5, 5, 5, N'Подвеска из желтого золота "Медвежонок"', CAST(0.64 AS Decimal(4, 2)), 585, 1500, 4500, N'\Products\Product5.jpg', CAST(20.00 AS Decimal(5, 2)), 15)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (6, 4, 1, 3, N'Помолвочное кольцо из белого золота с бриллиантом', CAST(1.20 AS Decimal(4, 2)), 585, 25000, 35000, N'\Products\Product6.jpg', CAST(17.50 AS Decimal(5, 2)), 8)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (10, 1, 1, 1, N'Кольцо из золота с бриллиантами и танзанитом', CAST(1.45 AS Decimal(4, 2)), 585, 20000, 30000, N'\Products\Product7.jpg', CAST(18.00 AS Decimal(5, 2)), 7)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (11, 3, 3, 1, N'Серьги из золота с бриллиантами и танзанитами', CAST(2.10 AS Decimal(4, 2)), 585, 15000, 25000, N'\Products\Product8.jpg', CAST(3.15 AS Decimal(5, 2)), 5)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (12, 2, 1, 2, N'Кольцо из серебра с кристаллом и фианитами', CAST(3.22 AS Decimal(4, 2)), 925, 1000, 3500, N'\Products\Product9.jpg', CAST(17.50 AS Decimal(5, 2)), 20)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (13, 1, 5, 2, N'Подвеска крестик с фианитами', CAST(0.59 AS Decimal(4, 2)), 925, 500, 1500, N'\Products\Product10.jpg', CAST(20.00 AS Decimal(5, 2)), 15)
INSERT [dbo].[Products] ([Id], [IdProvider], [IdTypeProducts], [IdMaterial], [Name], [Weight], [Proba], [PurchasePrice], [Price], [ImageProduct], [Size], [Volume]) VALUES (16, 2, 1, 3, N'Кольцо из белого золота с топазом и фианитом', CAST(1.45 AS Decimal(4, 2)), 585, 20000, 35000, N'\Products\Product11.jpg', CAST(16.50 AS Decimal(5, 2)), 6)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Providers] ON 

INSERT [dbo].[Providers] ([Id], [Name], [City], [Address], [Phone]) VALUES (1, N'VERONIKA', N'Кострома', N'ул. Деминская, 4', N'7(4942)440-889')
INSERT [dbo].[Providers] ([Id], [Name], [City], [Address], [Phone]) VALUES (2, N'Златогор', N'Москва', N'ул. Марксистская, 34', N'7(967)138-54-13')
INSERT [dbo].[Providers] ([Id], [Name], [City], [Address], [Phone]) VALUES (3, N'Паллада', N'Санкт-Петербург', N'​ул. Парковая 15-я, 10', N'7(981)185-59-94')
INSERT [dbo].[Providers] ([Id], [Name], [City], [Address], [Phone]) VALUES (4, N'Ювэлди', N'Москва', N'Б. Новодмитровская, 14', N'7(495)730-74-34')
INSERT [dbo].[Providers] ([Id], [Name], [City], [Address], [Phone]) VALUES (5, N'Эстет', N'Москва', N'ул. Веткина, 4', N'7(495)988-77-55')
SET IDENTITY_INSERT [dbo].[Providers] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([Id], [IdProduct], [IdClient], [DateSale], [Price], [Count]) VALUES (1, 1, 1, CAST(N'2022-05-09T10:01:00.000' AS DateTime), 15000, 1)
INSERT [dbo].[Sales] ([Id], [IdProduct], [IdClient], [DateSale], [Price], [Count]) VALUES (2, 2, 2, CAST(N'2022-05-09T10:10:00.000' AS DateTime), 5000, 1)
INSERT [dbo].[Sales] ([Id], [IdProduct], [IdClient], [DateSale], [Price], [Count]) VALUES (3, 3, 3, CAST(N'2022-05-09T10:12:00.000' AS DateTime), 37500, 1)
INSERT [dbo].[Sales] ([Id], [IdProduct], [IdClient], [DateSale], [Price], [Count]) VALUES (4, 4, 4, CAST(N'2022-05-09T10:21:00.000' AS DateTime), 45000, 1)
INSERT [dbo].[Sales] ([Id], [IdProduct], [IdClient], [DateSale], [Price], [Count]) VALUES (5, 5, 5, CAST(N'2022-05-09T10:54:00.000' AS DateTime), 4500, 1)
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
INSERT [dbo].[TypeProducts] ([Id], [Name]) VALUES (1, N'Кольцо')
INSERT [dbo].[TypeProducts] ([Id], [Name]) VALUES (2, N'Цепь')
INSERT [dbo].[TypeProducts] ([Id], [Name]) VALUES (3, N'Серьги')
INSERT [dbo].[TypeProducts] ([Id], [Name]) VALUES (4, N'Браслет')
INSERT [dbo].[TypeProducts] ([Id], [Name]) VALUES (5, N'Подвеска')
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Materials] FOREIGN KEY([IdMaterial])
REFERENCES [dbo].[Materials] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Materials]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Providers] FOREIGN KEY([IdProvider])
REFERENCES [dbo].[Providers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Providers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_TypeProducts] FOREIGN KEY([IdTypeProducts])
REFERENCES [dbo].[TypeProducts] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_TypeProducts]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Client]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Products] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Products]
GO
USE [master]
GO
ALTER DATABASE [JewerlyShop] SET  READ_WRITE 
GO
