USE [master]
GO
/****** Object:  Database [Finance5917]    Script Date: 17/12/2561 20:52:57 ******/
CREATE DATABASE [Finance5917]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Finance5917', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Finance5917.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Finance5917_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Finance5917_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Finance5917] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Finance5917].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Finance5917] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Finance5917] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Finance5917] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Finance5917] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Finance5917] SET ARITHABORT OFF 
GO
ALTER DATABASE [Finance5917] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Finance5917] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Finance5917] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Finance5917] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Finance5917] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Finance5917] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Finance5917] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Finance5917] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Finance5917] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Finance5917] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Finance5917] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Finance5917] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Finance5917] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Finance5917] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Finance5917] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Finance5917] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Finance5917] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Finance5917] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Finance5917] SET  MULTI_USER 
GO
ALTER DATABASE [Finance5917] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Finance5917] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Finance5917] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Finance5917] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Finance5917] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Finance5917] SET QUERY_STORE = OFF
GO
USE [Finance5917]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Finance5917]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 17/12/2561 20:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ContractID] [nchar](22) NOT NULL,
	[LicenseID] [int] NULL,
	[ID_Card_m] [char](13) NULL,
	[ID_Card_g] [char](13) NULL,
	[Date_Start] [date] NULL,
	[Date_End] [date] NULL,
	[Date_Last] [date] NULL,
	[Balance] [decimal](10, 2) NULL,
	[Out_Balance] [decimal](10, 2) NULL,
	[Per_Month_Amount] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID_Card_m] [char](13) NOT NULL,
	[titleid] [int] NULL,
	[Name_m] [nvarchar](50) NULL,
	[Lname_m] [nvarchar](50) NULL,
	[tel] [nchar](10) NULL,
	[Address_m] [varchar](30) NULL,
	[District_m] [varchar](30) NULL,
	[Amphur_m] [varchar](30) NULL,
	[Province_m] [varchar](30) NULL,
	[Zipcode_m] [char](5) NULL,
	[Career_m] [nchar](30) NULL,
	[Salary_m] [money] NULL,
	[Status_m] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID_Card_m] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuaranteeCustomers]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuaranteeCustomers](
	[ID_Card_g] [char](13) NOT NULL,
	[titleid] [int] NULL,
	[Name_g] [nvarchar](50) NULL,
	[Lname_g] [nvarchar](50) NULL,
	[tel] [nchar](10) NULL,
	[Address_g] [varchar](30) NULL,
	[District_g] [varchar](30) NULL,
	[Amphur_g] [varchar](30) NULL,
	[Province_g] [varchar](30) NULL,
	[Zipcode_g] [char](5) NULL,
	[Career_g] [nchar](30) NULL,
	[Salary_g] [money] NULL,
	[Status_g] [int] NULL,
 CONSTRAINT [PK_GuaranteeCustomers] PRIMARY KEY CLUSTERED 
(
	[ID_Card_g] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[License]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[License](
	[LicenseID] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nchar](10) NULL,
	[LicenseName] [nvarchar](20) NULL,
	[KeepAddressID] [varchar](30) NULL,
	[District_l] [varchar](30) NULL,
	[Amphur_l] [varchar](30) NULL,
	[Province_l] [varchar](30) NULL,
	[Zipcode_l] [char](5) NULL,
	[LicenseType] [int] NULL,
	[LicenseStatusID] [int] NULL,
 CONSTRAINT [PK_License] PRIMARY KEY CLUSTERED 
(
	[LicenseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseStatusDisplay]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseStatusDisplay](
	[LicenseStatusID] [int] IDENTITY(1,1) NOT NULL,
	[LicenseStatusName] [varchar](20) NULL,
 CONSTRAINT [PK_LicenseStatus] PRIMARY KEY CLUSTERED 
(
	[LicenseStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseTypes]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseTypes](
	[LicenseType] [int] IDENTITY(1,1) NOT NULL,
	[InterestName] [varchar](30) NULL,
	[InterestRate] [decimal](3, 2) NULL,
 CONSTRAINT [PK_LicenseType] PRIMARY KEY CLUSTERED 
(
	[LicenseType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [nchar](20) NOT NULL,
	[ID_Card_m] [char](13) NULL,
	[NameUser] [varchar](50) NULL,
	[ContractID] [nchar](22) NOT NULL,
	[PaymentDate] [date] NULL,
	[Payment Money] [decimal](9, 2) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusCustomer]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusCustomer](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusType] [varchar](20) NULL,
 CONSTRAINT [PK_StatusType] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusUser]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusUser](
	[StatusUser] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NULL,
 CONSTRAINT [PK_StatusUser] PRIMARY KEY CLUSTERED 
(
	[StatusUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[title]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[title](
	[titleid] [int] IDENTITY(1,1) NOT NULL,
	[titlename] [nchar](10) NULL,
 CONSTRAINT [PK_title] PRIMARY KEY CLUSTERED 
(
	[titleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Finance]    Script Date: 17/12/2561 20:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Finance](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[StatusUser] [int] NULL,
 CONSTRAINT [PK_User_Finance] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Customers] FOREIGN KEY([ID_Card_m])
REFERENCES [dbo].[Customers] ([ID_Card_m])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Customers]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_GuaranteeCustomers] FOREIGN KEY([ID_Card_g])
REFERENCES [dbo].[GuaranteeCustomers] ([ID_Card_g])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_GuaranteeCustomers]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_License] FOREIGN KEY([LicenseID])
REFERENCES [dbo].[License] ([LicenseID])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_License]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_StatusType] FOREIGN KEY([Status_m])
REFERENCES [dbo].[StatusCustomer] ([StatusID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_StatusType]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_title] FOREIGN KEY([titleid])
REFERENCES [dbo].[title] ([titleid])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_title]
GO
ALTER TABLE [dbo].[GuaranteeCustomers]  WITH CHECK ADD  CONSTRAINT [FK_GuaranteeCustomers_StatusType] FOREIGN KEY([Status_g])
REFERENCES [dbo].[StatusCustomer] ([StatusID])
GO
ALTER TABLE [dbo].[GuaranteeCustomers] CHECK CONSTRAINT [FK_GuaranteeCustomers_StatusType]
GO
ALTER TABLE [dbo].[GuaranteeCustomers]  WITH CHECK ADD  CONSTRAINT [FK_GuaranteeCustomers_title] FOREIGN KEY([titleid])
REFERENCES [dbo].[title] ([titleid])
GO
ALTER TABLE [dbo].[GuaranteeCustomers] CHECK CONSTRAINT [FK_GuaranteeCustomers_title]
GO
ALTER TABLE [dbo].[License]  WITH CHECK ADD  CONSTRAINT [FK_License_LicenseStatus] FOREIGN KEY([LicenseStatusID])
REFERENCES [dbo].[LicenseStatusDisplay] ([LicenseStatusID])
GO
ALTER TABLE [dbo].[License] CHECK CONSTRAINT [FK_License_LicenseStatus]
GO
ALTER TABLE [dbo].[License]  WITH CHECK ADD  CONSTRAINT [FK_License_LicenseType] FOREIGN KEY([LicenseType])
REFERENCES [dbo].[LicenseTypes] ([LicenseType])
GO
ALTER TABLE [dbo].[License] CHECK CONSTRAINT [FK_License_LicenseType]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Contracts] FOREIGN KEY([ContractID])
REFERENCES [dbo].[Contracts] ([ContractID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Contracts]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Customers] FOREIGN KEY([ID_Card_m])
REFERENCES [dbo].[Customers] ([ID_Card_m])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Customers]
GO
ALTER TABLE [dbo].[User_Finance]  WITH CHECK ADD  CONSTRAINT [FK_User_Finance_StatusUser] FOREIGN KEY([StatusUser])
REFERENCES [dbo].[StatusUser] ([StatusUser])
GO
ALTER TABLE [dbo].[User_Finance] CHECK CONSTRAINT [FK_User_Finance_StatusUser]
GO
USE [master]
GO
ALTER DATABASE [Finance5917] SET  READ_WRITE 
GO
