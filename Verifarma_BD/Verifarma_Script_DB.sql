USE [master]
GO
/****** Object:  Database [Verifarma_Challenge_DB]    Script Date: 10/07/2024 23:21:32 ******/
CREATE DATABASE [Verifarma_Challenge_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Verifarma_Challenge_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Verifarma_Challenge_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Verifarma_Challenge_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Verifarma_Challenge_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Verifarma_Challenge_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Verifarma_Challenge_DB', N'ON'
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Verifarma_Challenge_DB]
GO
/****** Object:  Table [dbo].[Farmacia]    Script Date: 10/07/2024 23:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Farmacia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](15) NOT NULL,
	[direccion] [nvarchar](15) NOT NULL,
	[latitud] [decimal](9, 6) NOT NULL,
	[longitud] [decimal](9, 6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Farmacia] ON 

INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (1, N'Elias', N'Lavalle 90', CAST(-34.811853 AS Decimal(9, 6)), CAST(-58.276340 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (2, N'Elias', N'Lavalle 90', CAST(-34.811853 AS Decimal(9, 6)), CAST(-58.276340 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (3, N'Farmacia Y', N'Direccion 281', CAST(81.692360 AS Decimal(9, 6)), CAST(139.628486 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (4, N'Farmacia R', N'Direccion 359', CAST(36.626802 AS Decimal(9, 6)), CAST(109.891351 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (5, N'Farmacia X', N'Direccion 400', CAST(1.929187 AS Decimal(9, 6)), CAST(12.312698 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (6, N'string', N'string', CAST(0.000000 AS Decimal(9, 6)), CAST(0.000000 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (7, N'string', N'string', CAST(0.000000 AS Decimal(9, 6)), CAST(0.000000 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (8, N'FarmaCity', N'Moreno 150', CAST(90.600000 AS Decimal(9, 6)), CAST(50.700000 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (9, N'Farmacia Q', N'Direccion 172', CAST(-32.344161 AS Decimal(9, 6)), CAST(24.823388 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (10, N'Farmacia Prueba', N'Calle Falsa 123', CAST(40.712800 AS Decimal(9, 6)), CAST(-74.006000 AS Decimal(9, 6)))
INSERT [dbo].[Farmacia] ([id], [nombre], [direccion], [latitud], [longitud]) VALUES (11, N'Farmacia B', N'Direccion 276', CAST(25.292435 AS Decimal(9, 6)), CAST(-113.634554 AS Decimal(9, 6)))
SET IDENTITY_INSERT [dbo].[Farmacia] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarFarmaciasAleatorias]    Script Date: 10/07/2024 23:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarFarmaciasAleatorias]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @i INT = 1;
    DECLARE @nombre NVARCHAR(255);
    DECLARE @direccion NVARCHAR(255);
    DECLARE @latitud DECIMAL(9, 6);
    DECLARE @longitud DECIMAL(9, 6);

    BEGIN
        -- Generar datos aleatorios
        SET @nombre = 'Farmacia ' + CHAR(65 + FLOOR(RAND() * 26));  -- Generar un nombre aleatorio
        SET @direccion = 'Direccion ' + CAST(ABS(CHECKSUM(NEWID())) % 1000 AS NVARCHAR(255));  -- Direccion aleatoria
        SET @latitud = -90 + (RAND() * 180);  -- Latitud aleatoria entre -90 y 90
        SET @longitud = -180 + (RAND() * 360);  -- Longitud aleatoria entre -180 y 180

        -- Insertar datos en la tabla
        INSERT INTO Farmacia (nombre, direccion, latitud, longitud)
        VALUES (@nombre, @direccion, @latitud, @longitud);

        SET @i = @i + 1;
    END
END;
GO
USE [master]
GO
ALTER DATABASE [Verifarma_Challenge_DB] SET  READ_WRITE 
GO
