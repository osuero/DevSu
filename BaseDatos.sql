USE [master]
GO
/****** Object:  Database [DevsuOS]    Script Date: 8/7/2023 11:31:05 AM ******/
CREATE DATABASE [DevsuOS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DevsuOS', FILENAME = N'C:\Users\HP\DevsuOS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DevsuOS_log', FILENAME = N'C:\Users\HP\DevsuOS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DevsuOS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DevsuOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DevsuOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DevsuOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DevsuOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DevsuOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DevsuOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [DevsuOS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DevsuOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DevsuOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DevsuOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DevsuOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DevsuOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DevsuOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DevsuOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DevsuOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DevsuOS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DevsuOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DevsuOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DevsuOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DevsuOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DevsuOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DevsuOS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DevsuOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DevsuOS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DevsuOS] SET  MULTI_USER 
GO
ALTER DATABASE [DevsuOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DevsuOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DevsuOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DevsuOS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DevsuOS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DevsuOS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DevsuOS] SET QUERY_STORE = OFF
GO
USE [DevsuOS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/7/2023 11:31:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 8/7/2023 11:31:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](max) NOT NULL,
	[Contrasena] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 8/7/2023 11:31:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [int] NOT NULL,
	[TipoCuenta] [int] NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[SaldoDisponible] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaActualizacion] [datetime2](7) NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 8/7/2023 11:31:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[TipoMovimiento] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[CuentaId] [int] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230807003011_firstMigration', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230807003028_Update-Database', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230807093201_UpdateRelation', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230807101640_formatingData', N'6.0.20')
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Nombres], [Contrasena], [Estado], [Direccion], [Telefono]) VALUES (4, N'Jose Lema', N'1234', 1, N'Otavalo sn y principal', N'098254785')
INSERT [dbo].[Clientes] ([Id], [Nombres], [Contrasena], [Estado], [Direccion], [Telefono]) VALUES (5, N'Marianela Montalvo', N'5678', 1, N'Amazonas y NNUU', N'097548965')
INSERT [dbo].[Clientes] ([Id], [Nombres], [Contrasena], [Estado], [Direccion], [Telefono]) VALUES (6, N'Juan Osorio', N'1245', 1, N'13 junio y Equinoccial', N'098874587')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [FechaCreacion], [FechaActualizacion], [ClienteId]) VALUES (11, 478758, 1, CAST(2000.00 AS Decimal(18, 2)), CAST(1425.00 AS Decimal(18, 2)), 1, CAST(N'2023-08-07T12:32:03.3401876' AS DateTime2), CAST(N'2023-08-07T12:32:20.1086767' AS DateTime2), 4)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [FechaCreacion], [FechaActualizacion], [ClienteId]) VALUES (12, 225487, 2, CAST(100.00 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)), 1, CAST(N'2023-08-07T12:32:06.4269815' AS DateTime2), CAST(N'2023-08-07T12:32:24.1702561' AS DateTime2), 5)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [FechaCreacion], [FechaActualizacion], [ClienteId]) VALUES (13, 495878, 1, CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 1, CAST(N'2023-08-07T12:32:09.5901304' AS DateTime2), CAST(N'2023-08-07T12:32:27.3419305' AS DateTime2), 6)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [FechaCreacion], [FechaActualizacion], [ClienteId]) VALUES (14, 496825, 1, CAST(540.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, CAST(N'2023-08-07T12:32:11.5607091' AS DateTime2), CAST(N'2023-08-07T12:32:29.6869853' AS DateTime2), 5)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [SaldoDisponible], [Estado], [FechaCreacion], [FechaActualizacion], [ClienteId]) VALUES (15, 585545, 2, CAST(1000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), 1, CAST(N'2023-08-07T12:32:13.5530039' AS DateTime2), CAST(N'2023-08-07T12:32:13.5530038' AS DateTime2), 4)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (12, CAST(N'2023-08-07T12:32:20.1374116' AS DateTime2), 1, CAST(575.00 AS Decimal(18, 2)), CAST(1425.00 AS Decimal(18, 2)), 478758)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (13, CAST(N'2023-08-07T12:32:24.1850508' AS DateTime2), 2, CAST(600.00 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)), 225487)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (14, CAST(N'2023-08-07T12:32:27.3566406' AS DateTime2), 2, CAST(150.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 495878)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (15, CAST(N'2023-08-07T12:32:29.7033256' AS DateTime2), 1, CAST(540.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 496825)
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
/****** Object:  Index [AK_Cuentas_NumeroCuenta]    Script Date: 8/7/2023 11:31:05 AM ******/
ALTER TABLE [dbo].[Cuentas] ADD  CONSTRAINT [AK_Cuentas_NumeroCuenta] UNIQUE NONCLUSTERED 
(
	[NumeroCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cuentas_ClienteId]    Script Date: 8/7/2023 11:31:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_ClienteId] ON [dbo].[Cuentas]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_CuentaId]    Script Date: 8/7/2023 11:31:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_CuentaId] ON [dbo].[Movimientos]
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes_ClienteId]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_CuentaId] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuentas] ([NumeroCuenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_CuentaId]
GO
USE [master]
GO
ALTER DATABASE [DevsuOS] SET  READ_WRITE 
GO
