USE [master]
GO
/****** Object:  Database [Sanatorium]    Script Date: 22.05.2022 21:09:00 ******/
CREATE DATABASE [Sanatorium]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sanatorium', FILENAME = N'D:\Microsoft SQL Server Tools 18\MSSQL15.SQLEXPRESS\MSSQL\DATA\Sanatorium.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sanatorium_log', FILENAME = N'D:\Microsoft SQL Server Tools 18\MSSQL15.SQLEXPRESS\MSSQL\DATA\Sanatorium_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Sanatorium] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sanatorium].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sanatorium] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sanatorium] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sanatorium] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sanatorium] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sanatorium] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sanatorium] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sanatorium] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sanatorium] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sanatorium] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sanatorium] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sanatorium] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sanatorium] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sanatorium] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sanatorium] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sanatorium] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sanatorium] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sanatorium] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sanatorium] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sanatorium] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sanatorium] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sanatorium] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sanatorium] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sanatorium] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Sanatorium] SET  MULTI_USER 
GO
ALTER DATABASE [Sanatorium] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sanatorium] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sanatorium] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sanatorium] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sanatorium] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sanatorium] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Sanatorium] SET QUERY_STORE = OFF
GO
USE [Sanatorium]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CabinetId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[VisitDate] [date] NOT NULL,
	[DateRegistration] [date] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cabinet]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabinet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CabinetNumber] [int] NOT NULL,
	[Appointment] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cabinet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Born] [date] NOT NULL,
	[PhoneNumber] [nvarchar](18) NOT NULL,
	[BloodType] [nvarchar](3) NOT NULL,
	[PolicyNumber] [nvarchar](12) NOT NULL,
	[Adress] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PositionId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](18) NOT NULL,
	[Adress] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Symptoms] [nvarchar](50) NOT NULL,
	[Diagnosis] [nvarchar](50) NOT NULL,
	[Medicine] [nvarchar](50) NOT NULL,
	[VisitDate] [date] NOT NULL,
	[DischargeDate] [date] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Workday] [date] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionId] [int] NOT NULL,
	[Appointment] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22.05.2022 21:09:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Log_in] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (1, 1, 4, 1, 1, CAST(N'2022-03-06' AS Date), CAST(N'2022-03-01' AS Date))
INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (2, 1, 4, 1, 1, CAST(N'2022-03-07' AS Date), CAST(N'2022-03-06' AS Date))
INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (3, 3, 2, 2, 2, CAST(N'2022-03-08' AS Date), CAST(N'2022-03-01' AS Date))
INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (4, 3, 2, 2, 3, CAST(N'2022-03-11' AS Date), CAST(N'2022-03-08' AS Date))
INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (5, 2, 4, 1, 1, CAST(N'2022-03-14' AS Date), CAST(N'2022-03-11' AS Date))
INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (6, 1, 4, 1, 1, CAST(N'2022-03-06' AS Date), CAST(N'2022-03-01' AS Date))
INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (18, 1, 2, 1, 2, CAST(N'2022-05-21' AS Date), CAST(N'2022-05-22' AS Date))
INSERT [dbo].[Appointment] ([Id], [ClientId], [EmployeeId], [CabinetId], [ServiceId], [VisitDate], [DateRegistration]) VALUES (25, 4, 2, 1, 4, CAST(N'2022-05-21' AS Date), CAST(N'2022-05-22' AS Date))
SET IDENTITY_INSERT [dbo].[Appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[Cabinet] ON 

INSERT [dbo].[Cabinet] ([Id], [CabinetNumber], [Appointment]) VALUES (1, 1, N'Физиотерапия')
INSERT [dbo].[Cabinet] ([Id], [CabinetNumber], [Appointment]) VALUES (2, 2, N'Неврология')
INSERT [dbo].[Cabinet] ([Id], [CabinetNumber], [Appointment]) VALUES (3, 3, N'Педиатрия')
INSERT [dbo].[Cabinet] ([Id], [CabinetNumber], [Appointment]) VALUES (4, 4, N'Терапия')
INSERT [dbo].[Cabinet] ([Id], [CabinetNumber], [Appointment]) VALUES (5, 5, N'Кардиология')
SET IDENTITY_INSERT [dbo].[Cabinet] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name], [Born], [PhoneNumber], [BloodType], [PolicyNumber], [Adress]) VALUES (1, N'Ляхов Григорий Алексеевич', CAST(N'1994-01-10' AS Date), N'+7 (923) 460-09-43', N'0+', N'10 60 288855', N'Лубянский пр-д, 21 строение 5 , кв 27')
INSERT [dbo].[Client] ([Id], [Name], [Born], [PhoneNumber], [BloodType], [PolicyNumber], [Adress]) VALUES (2, N'Шуров Роман Николаевич', CAST(N'1996-08-31' AS Date), N'+7 (971) 144-54-68', N'A-', N'10 60 288856', N'Большой Спасоглинищевский пер., 9/1 строение 4, кв 98')
INSERT [dbo].[Client] ([Id], [Name], [Born], [PhoneNumber], [BloodType], [PolicyNumber], [Adress]) VALUES (3, N'Никитин Артем Павлович', CAST(N'1996-02-02' AS Date), N'+7 (912) 081-40-52', N'A-', N'10 60 288857', N'Большой Спасоглинищевский пер., 5/4 строение 8, кв 52')
INSERT [dbo].[Client] ([Id], [Name], [Born], [PhoneNumber], [BloodType], [PolicyNumber], [Adress]) VALUES (4, N'Роберт Платиус', CAST(N'1995-04-19' AS Date), N'+7 (967) 731-49-03', N'B+', N'10 60 288858', N'Лучников пер., 7/4c7, кв 11')
INSERT [dbo].[Client] ([Id], [Name], [Born], [PhoneNumber], [BloodType], [PolicyNumber], [Adress]) VALUES (5, N'Померанцев Владислав Александрович', CAST(N'1995-11-19' AS Date), N'+7 (972) 152-82-27', N'B-', N'10 60 288859', N'Большой Каретный пер., 4 строение 3, кв 8')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [PhoneNumber], [Adress]) VALUES (1, N'Шпагина Катерина Владиславовна', 5, N'+7 (965) 980-74-43', N'Проточный пер., 8/2 строение 2, кв. 19')
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [PhoneNumber], [Adress]) VALUES (2, N'Кольцов Клавдий Тарасович', 2, N'+7 (907) 640-55-11', N'Трубниковский пер., 32, кв. 72')
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [PhoneNumber], [Adress]) VALUES (3, N'Веселкова Регина Вячеславовна', 3, N'+7 (980) 561-60-72', N'Поварская ул., 25 строение 1, кв. 64')
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [PhoneNumber], [Adress]) VALUES (4, N'Галицына Лиана Романовна', 1, N'+7 (913) 161-64-27', N'Поварская ул., 40, кв. 31')
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [PhoneNumber], [Adress]) VALUES (5, N'Калашников Милан Федорович', 4, N'+7 (913) 163-62-83', N'Трубниковский пер., 19,  кв.13')
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [PhoneNumber], [Adress]) VALUES (6, N'ChiefTest', 6, N'+7 (977) 123-64-32', N'Москва')
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [PhoneNumber], [Adress]) VALUES (7, N'AdminTest', 7, N'+7 (964) 132-68-72', N'Москва')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[History] ON 

INSERT [dbo].[History] ([Id], [ClientId], [EmployeeId], [Symptoms], [Diagnosis], [Medicine], [VisitDate], [DischargeDate]) VALUES (1, 1, 4, N'Боль в пояснице', N'Сколиоз', N'Массаж', CAST(N'2022-03-06' AS Date), CAST(N'2022-03-06' AS Date))
INSERT [dbo].[History] ([Id], [ClientId], [EmployeeId], [Symptoms], [Diagnosis], [Medicine], [VisitDate], [DischargeDate]) VALUES (2, 1, 4, N'Боль в пояснице ', N'Сколиоз', N'Массаж', CAST(N'2022-03-07' AS Date), CAST(N'2022-03-07' AS Date))
INSERT [dbo].[History] ([Id], [ClientId], [EmployeeId], [Symptoms], [Diagnosis], [Medicine], [VisitDate], [DischargeDate]) VALUES (3, 2, 4, N'Боль в пояснице ', N'Сколиоз', N'Массаж', CAST(N'2022-03-14' AS Date), CAST(N'2022-03-14' AS Date))
INSERT [dbo].[History] ([Id], [ClientId], [EmployeeId], [Symptoms], [Diagnosis], [Medicine], [VisitDate], [DischargeDate]) VALUES (4, 3, 2, N'Головокружение, шум в ушах', N'ЦВП', N'Повторная консультация', CAST(N'2022-03-08' AS Date), CAST(N'2022-03-08' AS Date))
INSERT [dbo].[History] ([Id], [ClientId], [EmployeeId], [Symptoms], [Diagnosis], [Medicine], [VisitDate], [DischargeDate]) VALUES (5, 3, 2, N'Головокружение, шум в ушах', N'ЦВП', N'Хирургическое вмешательство', CAST(N'2022-03-11' AS Date), CAST(N'2022-03-14' AS Date))
SET IDENTITY_INSERT [dbo].[History] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([Id], [Title]) VALUES (1, N'Физиотерапевт')
INSERT [dbo].[Position] ([Id], [Title]) VALUES (2, N'Невролог')
INSERT [dbo].[Position] ([Id], [Title]) VALUES (3, N'Педиатр')
INSERT [dbo].[Position] ([Id], [Title]) VALUES (4, N'Терапевт')
INSERT [dbo].[Position] ([Id], [Title]) VALUES (5, N'Кардиолог')
INSERT [dbo].[Position] ([Id], [Title]) VALUES (6, N'Главный врач')
INSERT [dbo].[Position] ([Id], [Title]) VALUES (7, N'Администратор')
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([Id], [EmployeeId], [Workday]) VALUES (1, 2, CAST(N'2022-05-21' AS Date))
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [PositionId], [Appointment], [Price]) VALUES (1, 1, N'Массаж', 3600)
INSERT [dbo].[Service] ([Id], [PositionId], [Appointment], [Price]) VALUES (2, 2, N'Первичная консультация', 3000)
INSERT [dbo].[Service] ([Id], [PositionId], [Appointment], [Price]) VALUES (3, 2, N'Повторная консультация', 2000)
INSERT [dbo].[Service] ([Id], [PositionId], [Appointment], [Price]) VALUES (4, 3, N'Профилактический прием', 1400)
INSERT [dbo].[Service] ([Id], [PositionId], [Appointment], [Price]) VALUES (5, 3, N'Первичный прием', 2500)
INSERT [dbo].[Service] ([Id], [PositionId], [Appointment], [Price]) VALUES (6, 3, N'Повторный прием', 2000)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [EmployeeId], [Role], [Login], [Password]) VALUES (1, 6, N'Главный врач', N'SanT', N'163')
INSERT [dbo].[User] ([Id], [EmployeeId], [Role], [Login], [Password]) VALUES (2, 7, N'Администратор', N'Admin', N'21')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Cabinet] FOREIGN KEY([CabinetId])
REFERENCES [dbo].[Cabinet] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Cabinet]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Client]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Employee]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Service]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Client1] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Client1]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Employee1]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Employee]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Position]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Log_in_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Log_in_Employee]
GO
USE [master]
GO
ALTER DATABASE [Sanatorium] SET  READ_WRITE 
GO
