USE [Train_schedule]
GO
/****** Object:  Database [Train_schedule]    Script Date: 06.12.2022 11:29:15 ******/

ALTER DATABASE [Train_schedule] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Train_schedule].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Train_schedule] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Train_schedule] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Train_schedule] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Train_schedule] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Train_schedule] SET ARITHABORT OFF 
GO
ALTER DATABASE [Train_schedule] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Train_schedule] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Train_schedule] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Train_schedule] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Train_schedule] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Train_schedule] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Train_schedule] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Train_schedule] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Train_schedule] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Train_schedule] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Train_schedule] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Train_schedule] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Train_schedule] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Train_schedule] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Train_schedule] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Train_schedule] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Train_schedule] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Train_schedule] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Train_schedule] SET  MULTI_USER 
GO
ALTER DATABASE [Train_schedule] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Train_schedule] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Train_schedule] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Train_schedule] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Train_schedule] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Train_schedule] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Train_schedule] SET QUERY_STORE = OFF
GO
USE [Train_schedule]
GO
/****** Object:  Table [dbo].[Pessenger]    Script Date: 06.12.2022 11:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessenger](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fio] [nvarchar](255) NULL,
	[passport] [nchar](10) NULL,
	[phone] [nchar](11) NULL,
 CONSTRAINT [PK_Pessenger] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 06.12.2022 11:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price] [money] NULL,
	[idTrain] [int] NULL,
	[idPassenger] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Train]    Script Date: 06.12.2022 11:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[des] [nvarchar](255) NULL,
	[dep_point] [nvarchar](255) NULL,
	[num] [int] NULL,
	[dep_time] [time](7) NULL,
	[trav_time] [int] NULL,
	[stations] [nvarchar](255) NULL,
 CONSTRAINT [PK_Train] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pessenger] ON 

INSERT [dbo].[Pessenger] ([id], [fio], [passport], [phone]) VALUES (1, N'Немтырёва К.А.', N'4618999999', N'89778888888')
INSERT [dbo].[Pessenger] ([id], [fio], [passport], [phone]) VALUES (2, N'Птицына Е.О.', N'4915777777', N'89994444444')
INSERT [dbo].[Pessenger] ([id], [fio], [passport], [phone]) VALUES (3, N'Иванов И.И.', N'4619666666', N'89035555555')
INSERT [dbo].[Pessenger] ([id], [fio], [passport], [phone]) VALUES (4, N'Бросалина Ю.Е.', N'4915744444', N'89994451233')
INSERT [dbo].[Pessenger] ([id], [fio], [passport], [phone]) VALUES (5, N'Бросалин В.Н.', N'461955566 ', N'89031111555')
SET IDENTITY_INSERT [dbo].[Pessenger] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (11, 100.0000, 1, 3)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (12, 70.0000, 2, 2)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (13, 60.0000, 2, 1)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (14, 100.0000, 5, 5)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (15, 70.0000, 4, 4)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (16, 60.0000, 3, 4)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (17, 100.0000, 1, 5)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (18, 70.0000, 3, 1)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (19, 60.0000, 4, 2)
INSERT [dbo].[Ticket] ([id], [price], [idTrain], [idPassenger]) VALUES (20, 45.0000, 5, 3)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[Train] ON 

INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (1, N'Курский вокзал', N'Петушки', 6927, CAST(N'18:23:00' AS Time), 153, N'Орехово-Зуево, Дрезна, Вохна, Есино ')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (2, N'Казанский вокзал', N'Черусти', 6857, CAST(N'09:13:00' AS Time), 180, N'Шатура, Авсюнино, Куровское')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (3, N'Курский вокзал', N'Петушки', 6927, CAST(N'10:23:00' AS Time), 105, N'Орехово-Зуево, Дрезна, Вохна, Есино ')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (4, N'Казанский вокзал', N'Черусти', 6857, CAST(N'19:03:00' AS Time), 145, N'Шатура, Авсюнино, Куровское')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (5, N'Казанский вокзал', N'Черусти', 6857, CAST(N'00:23:00' AS Time), 195, N'Шатура, Авсюнино, Куровское')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (6, N'Курский вокзал', N'Петушки', 6927, CAST(N'18:23:00' AS Time), 153, N'Орехово-Зуево, Дрезна, Вохна, Есино ')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (7, N'Казанский вокзал', N'Черусти', 6857, CAST(N'09:13:00' AS Time), 180, N'Шатура, Авсюнино, Куровское')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (8, N'Курский вокзал', N'Петушки', 6927, CAST(N'10:23:00' AS Time), 105, N'Орехово-Зуево, Дрезна, Вохна, Есино ')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (9, N'Казанский вокзал', N'Черусти', 6857, CAST(N'19:03:00' AS Time), 145, N'Шатура, Авсюнино, Куровское')
INSERT [dbo].[Train] ([id], [des], [dep_point], [num], [dep_time], [trav_time], [stations]) VALUES (10, N'Казанский вокзал', N'Черусти', 6857, CAST(N'00:23:00' AS Time), 195, N'Шатура, Авсюнино, Куровское')
SET IDENTITY_INSERT [dbo].[Train] OFF
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Pessenger] FOREIGN KEY([idPassenger])
REFERENCES [dbo].[Pessenger] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Pessenger]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Train] FOREIGN KEY([idTrain])
REFERENCES [dbo].[Train] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Train]
GO
USE [master]
GO
ALTER DATABASE [Train_schedule] SET  READ_WRITE 
GO
