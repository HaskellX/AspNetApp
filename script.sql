USE [master]
GO
/****** Object:  Database [Library]    Script Date: 10/20/2016 12:13:30 AM ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Library_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY FULL 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Library', N'ON'
GO
ALTER DATABASE [Library] SET QUERY_STORE = OFF
GO
USE [Library]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [test_login]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [test_login] WITH PASSWORD=N'JYg8E4m1b0nCJ9WU7trJtc43J0BJpn5z4xU6SzMLkuc=', DEFAULT_DATABASE=[Library], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [test_login] DISABLE
GO
/****** Object:  Login [SARATOV\Rushan_Tugushev]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [SARATOV\Rushan_Tugushev] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\Winmgmt]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [NT SERVICE\Winmgmt] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\SQLTELEMETRY]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [NT SERVICE\SQLTELEMETRY] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\SQLSERVERAGENT]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [NT SERVICE\SQLSERVERAGENT] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT Service\MSSQLSERVER]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [NT Service\MSSQLSERVER] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'wB6DNhz/eVPVV3RxIyJolVjnuYpVx/0004dYtZ13Au0=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'XTjlzxN/Ru9H5wRglfgm8uixGNe3/o3JTMFEX6rYJFU=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
ALTER AUTHORIZATION ON DATABASE::[Library] TO [SARATOV\Rushan_Tugushev]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [SARATOV\Rushan_Tugushev]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\Winmgmt]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLWriter]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLSERVERAGENT]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT Service\MSSQLSERVER]
GO
USE [Library]
GO
/****** Object:  User [xxx]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE USER [xxx] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [test_login]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE USER [test_login] FOR LOGIN [test_login] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [user]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE ROLE [user]
GO
/****** Object:  DatabaseRole [librarian]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE ROLE [librarian]
GO
/****** Object:  DatabaseRole [administrator]    Script Date: 10/20/2016 12:13:31 AM ******/
CREATE ROLE [administrator]
GO
ALTER AUTHORIZATION ON ROLE::[user] TO [dbo]
GO
ALTER AUTHORIZATION ON ROLE::[librarian] TO [dbo]
GO
ALTER AUTHORIZATION ON ROLE::[administrator] TO [dbo]
GO
ALTER ROLE [administrator] ADD MEMBER [test_login]
GO
ALTER ROLE [db_owner] ADD MEMBER [test_login]
GO
ALTER ROLE [db_owner] ADD MEMBER [administrator]
GO
GRANT VIEW ANY COLUMN ENCRYPTION KEY DEFINITION TO [public] AS [dbo]
GO
GRANT VIEW ANY COLUMN MASTER KEY DEFINITION TO [public] AS [dbo]
GO
GRANT CONNECT TO [test_login] AS [dbo]
GO
GRANT CONNECT TO [xxx] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAuthorsForBook]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetAuthorsForBook]
(
	@id int
)
RETURNS xml
AS
BEGIN

RETURN 
			(
				 SELECT 
				 ath.Id as '@Id', 
				 ath.Firstname as '@Firstname' , 
				 ath.Lastname as '@Lastname'
				 FROM dbo.Book_authors ba
				 INNER JOIN dbo.Authors ath
				 ON ba.author_Id = ath.Id
				 WHERE ba.book_item_ID = @id
				 FOR XML PATH ('Author') , ROOT ('Authors')
			)

END


GO
ALTER AUTHORIZATION ON [dbo].[GetAuthorsForBook] TO  SCHEMA OWNER 
GO
/****** Object:  UserDefinedFunction [dbo].[GetAuthorsForPatent]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetAuthorsForPatent]
(
	@id int
)
RETURNS xml
AS
BEGIN

RETURN 
			(
				 SELECT 
				 ath.Id as '@Id', 
				 ath.Firstname as '@Firstname' , 
				 ath.Lastname as '@Lastname'
				 FROM dbo.Patent_authors pa
				 INNER JOIN dbo.Authors ath
				 ON pa.author_Id = ath.Id
				 WHERE pa.patent_ID = @id
				 FOR XML PATH ('Author') , ROOT ('Authors')
			)

END


GO
ALTER AUTHORIZATION ON [dbo].[GetAuthorsForPatent] TO  SCHEMA OWNER 
GO
/****** Object:  UserDefinedFunction [dbo].[ProcessDeleting]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[ProcessDeleting]
(
	@id int
)
RETURNS int
AS
BEGIN
	EXEC dbo.LogChanges @id
	return 0
END


GO
ALTER AUTHORIZATION ON [dbo].[ProcessDeleting] TO  SCHEMA OWNER 
GO
/****** Object:  UserDefinedFunction [dbo].[UniqueAuthorsForBook]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[UniqueAuthorsForBook]
(	
	@authors nvarchar(MAX),
	@id int
)
RETURNS BIT 
AS
BEGIN

	IF NOT EXISTS
	(
			SELECT ba.author_Id
			FROM Book_authors ba
			WHERE ba.book_item_ID = @id

			EXCEPT

			SELECT tb.value
			FROM
			(SELECT * FROM string_split(@authors, ',')) tb

		UNION
	
			SELECT tb.value
			FROM
			(SELECT * FROM string_split(@authors, ',')) tb

			EXCEPT

			SELECT ba.author_Id
			FROM Book_authors ba
			WHERE ba.book_item_ID = @id
	)
	BEGIN
		RETURN 1
	END

		RETURN 0

END


GO
ALTER AUTHORIZATION ON [dbo].[UniqueAuthorsForBook] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Books]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[library_item_ID] [int] NOT NULL,
	[title] [nvarchar](300) NULL,
	[city_of_publishing] [nvarchar](200) NULL,
	[publisher_Id] [int] NOT NULL,
	[number_of_pages] [int] NOT NULL,
	[note] [nvarchar](2000) NULL,
	[ISBN] [nvarchar](18) NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Books] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Books] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Books] TO [administrator] AS [dbo]
GO
/****** Object:  Table [dbo].[LibraryItem]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryItem](
	[library_item_ID] [int] IDENTITY(1,1) NOT NULL,
	[YearOfPublication] [int] NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_library_item] PRIMARY KEY CLUSTERED 
(
	[library_item_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[LibraryItem] TO  SCHEMA OWNER 
GO
GRANT CONTROL ON [dbo].[LibraryItem] TO [administrator] AS [dbo]
GO
GRANT DELETE ON [dbo].[LibraryItem] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[LibraryItem] TO [administrator] AS [dbo]
GO
/****** Object:  View [dbo].[BookRegularView]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BookRegularView]
AS
SELECT        dbo.Books.library_item_ID, dbo.Books.title, dbo.Books.city_of_publishing, dbo.Books.publisher_Id, dbo.Books.number_of_pages, dbo.Books.note, dbo.Books.ISBN
FROM            dbo.LibraryItem INNER JOIN
                         dbo.Books ON dbo.LibraryItem.library_item_ID = dbo.Books.library_item_ID
WHERE        (dbo.LibraryItem.isDeleted <> 1)


GO
ALTER AUTHORIZATION ON [dbo].[BookRegularView] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[BookAdminView]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BookAdminView]
AS
SELECT        dbo.Books.library_item_ID, dbo.Books.title, dbo.Books.city_of_publishing, dbo.Books.publisher_Id, dbo.Books.number_of_pages, dbo.Books.note, dbo.Books.ISBN
FROM            dbo.LibraryItem INNER JOIN
                         dbo.Books ON dbo.LibraryItem.library_item_ID = dbo.Books.library_item_ID


GO
ALTER AUTHORIZATION ON [dbo].[BookAdminView] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[PaperIssues]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaperIssues](
	[library_item_ID] [int] NOT NULL,
	[paperId] [int] NOT NULL,
	[cityOfPublication] [nvarchar](200) NULL,
	[publisher_Id] [int] NOT NULL,
	[number_of_pages] [int] NOT NULL,
	[note] [nvarchar](2000) NULL,
	[number_of_issue] [int] NULL,
	[dateOfIssue] [date] NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[PaperIssues] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[PaperIssues] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[PaperIssues] TO [administrator] AS [dbo]
GO
/****** Object:  View [dbo].[PaperIssueRegularView]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PaperIssueRegularView]
AS
SELECT        dbo.PaperIssues.library_item_ID, dbo.PaperIssues.paperId, dbo.PaperIssues.cityOfPublication, dbo.PaperIssues.publisher_Id, dbo.PaperIssues.number_of_pages, dbo.PaperIssues.note, 
                         dbo.PaperIssues.number_of_issue, dbo.PaperIssues.dateOfIssue
FROM            dbo.PaperIssues INNER JOIN
                         dbo.LibraryItem ON dbo.PaperIssues.library_item_ID = dbo.LibraryItem.library_item_ID
WHERE        (dbo.LibraryItem.isDeleted <> 1)


GO
ALTER AUTHORIZATION ON [dbo].[PaperIssueRegularView] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[PaperIssueAdminView]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PaperIssueAdminView]
AS
SELECT        dbo.PaperIssues.library_item_ID, dbo.PaperIssues.paperId, dbo.PaperIssues.cityOfPublication, dbo.PaperIssues.publisher_Id, dbo.PaperIssues.number_of_pages, dbo.PaperIssues.note, 
                         dbo.PaperIssues.number_of_issue, dbo.PaperIssues.dateOfIssue
FROM            dbo.PaperIssues INNER JOIN
                         dbo.LibraryItem ON dbo.PaperIssues.library_item_ID = dbo.LibraryItem.library_item_ID


GO
ALTER AUTHORIZATION ON [dbo].[PaperIssueAdminView] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Patents]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patents](
	[library_item_ID] [int] NOT NULL,
	[title] [nvarchar](300) NULL,
	[country] [nvarchar](200) NULL,
	[reg_number] [nvarchar](9) NULL,
	[date_of_submission] [date] NULL,
	[date_of_publication] [date] NOT NULL,
	[number_of_pages] [int] NOT NULL,
	[note] [nvarchar](2000) NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Patents] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Patents] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Patents] TO [administrator] AS [dbo]
GO
/****** Object:  View [dbo].[PatentRegularView]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PatentRegularView]
AS
SELECT        dbo.Patents.library_item_ID, dbo.Patents.title, dbo.Patents.country, dbo.Patents.reg_number, dbo.Patents.date_of_submission, dbo.Patents.date_of_publication, dbo.Patents.number_of_pages, 
                         dbo.Patents.note
FROM            dbo.LibraryItem INNER JOIN
                         dbo.Patents ON dbo.LibraryItem.library_item_ID = dbo.Patents.library_item_ID
WHERE        (dbo.LibraryItem.isDeleted <> 1)


GO
ALTER AUTHORIZATION ON [dbo].[PatentRegularView] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[PatentAdminView]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PatentAdminView]
AS
SELECT        dbo.Patents.library_item_ID, dbo.Patents.title, dbo.Patents.country, dbo.Patents.reg_number, dbo.Patents.date_of_submission, dbo.Patents.date_of_publication, dbo.Patents.number_of_pages, 
                         dbo.Patents.note
FROM            dbo.LibraryItem INNER JOIN
                         dbo.Patents ON dbo.LibraryItem.library_item_ID = dbo.Patents.library_item_ID


GO
ALTER AUTHORIZATION ON [dbo].[PatentAdminView] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Authors] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Authors] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Authors] TO [administrator] AS [dbo]
GO
/****** Object:  Table [dbo].[Book_authors]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_authors](
	[book_item_ID] [int] NOT NULL,
	[author_Id] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Book_authors] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Book_authors] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Book_authors] TO [administrator] AS [dbo]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[date] [datetime] NOT NULL,
	[itemType] [nvarchar](50) NOT NULL,
	[itemId] [int] NOT NULL,
	[description] [nvarchar](2000) NOT NULL,
	[user] [nvarchar](255) NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Log] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Log] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Log] TO [administrator] AS [dbo]
GO
/****** Object:  Table [dbo].[Paper]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](300) NULL,
	[ISSN] [nvarchar](14) NULL,
 CONSTRAINT [PK_Paper] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Paper] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Paper] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Paper] TO [administrator] AS [dbo]
GO
/****** Object:  Table [dbo].[Patent_authors]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patent_authors](
	[patent_ID] [int] NOT NULL,
	[author_ID] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Patent_authors] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Patent_authors] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Patent_authors] TO [administrator] AS [dbo]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[publisher_Id] [int] IDENTITY(1,1) NOT NULL,
	[publisherName] [nvarchar](300) NULL,
 CONSTRAINT [PK_publishers] PRIMARY KEY CLUSTERED 
(
	[publisher_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Publishers] TO  SCHEMA OWNER 
GO
GRANT DELETE ON [dbo].[Publishers] TO [administrator] AS [dbo]
GO
GRANT INSERT ON [dbo].[Publishers] TO [administrator] AS [dbo]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[login] [nvarchar](50) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
	[hash] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Users] TO  SCHEMA OWNER 
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (1, N'Алексей', N'Толстой')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (2, N'Alexandr', N'Pushkin')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (3, N'Михаил', N'Лермонтов')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (4, N'Nikola', N'Tesla')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (5, N'Tomas', N'Edison')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (6, N'Лев', N'Толcтой')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (7, N'Herman', N'Melvill')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (8, N'Алия', N'Чекмарева')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (9, N'Алия', N'Чекмарева')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (10, N'Алия', N'Чекмарева')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (11, N'Алия', N'Чекмарева')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (12, N'Алия', N'Чекмарева')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (13, N'Али', N'Чекмарева')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (14, N'Ффывфыв', N'Ффывфыв')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (15, N'Фывафы', N'Фывфыв')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (16, N'Фывафы', N'Фывфыв')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (17, N'Ффывфыв', N'Ффывфыв')
INSERT [dbo].[Authors] ([Id], [Firstname], [Lastname]) VALUES (18, N'Светлана', N'Иванова')
SET IDENTITY_INSERT [dbo].[Authors] OFF
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (1, 1)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (2, 7)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (2, 2)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (3, 1)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (10, 2)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (10, 5)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (1, 4)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (1, 6)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (3, 4)
INSERT [dbo].[Book_authors] ([book_item_ID], [author_Id]) VALUES (3, 6)
INSERT [dbo].[Books] ([library_item_ID], [title], [city_of_publishing], [publisher_Id], [number_of_pages], [note], [ISBN]) VALUES (1, N'Война и Мир', N'Саратов', 1, 1500, N'фывавыа', N'ISBN 1-111-11111-3')
INSERT [dbo].[Books] ([library_item_ID], [title], [city_of_publishing], [publisher_Id], [number_of_pages], [note], [ISBN]) VALUES (2, N'Moby Dick', N'New-York', 4, 500, N'note', N'ISBN 22222-22222')
INSERT [dbo].[Books] ([library_item_ID], [title], [city_of_publishing], [publisher_Id], [number_of_pages], [note], [ISBN]) VALUES (3, N'Война и Мир', N'Саратов', 3, 1500, N'фывавыа', N'ISBN 1-111-11111-3')
INSERT [dbo].[Books] ([library_item_ID], [title], [city_of_publishing], [publisher_Id], [number_of_pages], [note], [ISBN]) VALUES (10, N'Cookbook', N'Саратов', 2, 3, N'фывавыа', N'ISBN 1-111-11111-3')
SET IDENTITY_INSERT [dbo].[LibraryItem] ON 

INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (1, 2008, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (2, 2009, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (3, 2008, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (4, 2010, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (5, 1910, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (6, 1910, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (7, 1910, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (8, 1940, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (9, 1920, 0)
INSERT [dbo].[LibraryItem] ([library_item_ID], [YearOfPublication], [isDeleted]) VALUES (10, 2000, 0)
SET IDENTITY_INSERT [dbo].[LibraryItem] OFF
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.917' AS DateTime), N'book', 1, N'ItembooknamedВойна и Мирwith ISBNISBN 11111-11111published in2008was inserted.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.917' AS DateTime), N'book', 2, N'ItembooknamedMoby Dickwith ISBNISBN 22222-22222published in2009was inserted.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.920' AS DateTime), N'book', 3, N'ItembooknamedКапитанская дочкаwith ISBNpublished in2010was inserted.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.923' AS DateTime), N'paper', 4, N' Item paper named New-York Times with ISSN ISSN 4444-4444 published in 2010 and # 23 was inserted.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.923' AS DateTime), N'paper', 5, N' Item paper named Washington Post with ISSN empty published in 1910 and # 1 was inserted.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.923' AS DateTime), N'paper', 6, N' Item paper named Wall-Street Journal with ISSN ISSN 1111-1111 published in 1910 and # 2 was inserted.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.927' AS DateTime), N'patent', 7, N'ItempatentnamedЛампочкаfromUSAwith reg number1published in1910was updated', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.927' AS DateTime), N'patent', 8, N'ItempatentnamedВечный двигательfromUSAwith reg number200published in1940was updated', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-15T00:29:31.927' AS DateTime), N'patent', 9, N'ItempatentnamedБашня УордклиффfromUSAwith reg number500published in1920was updated', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-16T12:09:55.980' AS DateTime), N'book', 10, N'ItembooknamedCookbookwith ISBNISBN 1-111-11111published in2000was inserted.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-17T14:13:00.517' AS DateTime), N'book', 1, N'ItembooknamedВойна и Мирwith ISBNISBN 1-111-11111published in2008was modified.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-17T14:17:57.033' AS DateTime), N'book', 1, N'ItembooknamedВойна и Мирwith ISBNISBN 1-111-11111published in2008was modified.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-17T19:36:33.540' AS DateTime), N'book', 3, N'ItembooknamedВойна и Мирwith ISBNISBN 1-111-11111published in2008was modified.', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-19T20:35:22.057' AS DateTime), N'patent', 9, N'ItempatentnamedБашня УордклиффfromUSAwith reg number500published in1920was updated', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-19T20:35:42.500' AS DateTime), N'patent', 8, N'ItempatentnamedВечный двигательfromNetherlandswith reg number200published in1940was updated', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-19T20:35:47.647' AS DateTime), N'patent', 8, N'ItempatentnamedВечный двигательfromNetherlandswith reg number200published in1940was updated', N'test_login')
INSERT [dbo].[Log] ([date], [itemType], [itemId], [description], [user]) VALUES (CAST(N'2016-10-19T20:26:24.197' AS DateTime), N'patent', 8, N'ItempatentnamedВечный двигательfromNetherlandswith reg number200published in1940was updated', N'test_login')
SET IDENTITY_INSERT [dbo].[Paper] ON 

INSERT [dbo].[Paper] ([id], [title], [ISSN]) VALUES (1, N'New-York Times', N'ISSN 4444-4444')
INSERT [dbo].[Paper] ([id], [title], [ISSN]) VALUES (2, N'Washington Post', NULL)
INSERT [dbo].[Paper] ([id], [title], [ISSN]) VALUES (3, N'Wall-Street Journal', N'ISSN 1111-1111')
INSERT [dbo].[Paper] ([id], [title], [ISSN]) VALUES (4, N'Associated Press', N'ISSN 3333-9999')
SET IDENTITY_INSERT [dbo].[Paper] OFF
INSERT [dbo].[PaperIssues] ([library_item_ID], [paperId], [cityOfPublication], [publisher_Id], [number_of_pages], [note], [number_of_issue], [dateOfIssue]) VALUES (4, 1, N'New-York', 1, 100, N'Some note', 23, CAST(N'2010-10-10' AS Date))
INSERT [dbo].[PaperIssues] ([library_item_ID], [paperId], [cityOfPublication], [publisher_Id], [number_of_pages], [note], [number_of_issue], [dateOfIssue]) VALUES (5, 2, N'Washington', 5, 20, N'bbb', 1, CAST(N'1910-02-03' AS Date))
INSERT [dbo].[PaperIssues] ([library_item_ID], [paperId], [cityOfPublication], [publisher_Id], [number_of_pages], [note], [number_of_issue], [dateOfIssue]) VALUES (6, 3, N'New-York', 5, 22, N'xxx', 2, CAST(N'1910-01-01' AS Date))
INSERT [dbo].[Patent_authors] ([patent_ID], [author_ID]) VALUES (7, 5)
INSERT [dbo].[Patent_authors] ([patent_ID], [author_ID]) VALUES (8, 1)
INSERT [dbo].[Patent_authors] ([patent_ID], [author_ID]) VALUES (9, 1)
INSERT [dbo].[Patent_authors] ([patent_ID], [author_ID]) VALUES (9, 4)
INSERT [dbo].[Patent_authors] ([patent_ID], [author_ID]) VALUES (8, 2)
INSERT [dbo].[Patent_authors] ([patent_ID], [author_ID]) VALUES (9, 5)
INSERT [dbo].[Patent_authors] ([patent_ID], [author_ID]) VALUES (8, 3)
INSERT [dbo].[Patents] ([library_item_ID], [title], [country], [reg_number], [date_of_submission], [date_of_publication], [number_of_pages], [note]) VALUES (7, N'Лампочка', N'USA', N'1', CAST(N'1907-02-02' AS Date), CAST(N'1910-01-09' AS Date), 300, N'Note')
INSERT [dbo].[Patents] ([library_item_ID], [title], [country], [reg_number], [date_of_submission], [date_of_publication], [number_of_pages], [note]) VALUES (8, N'Вечный двигатель', N'Netherlands', N'200', CAST(N'1939-05-05' AS Date), CAST(N'1940-08-08' AS Date), 322, N'some note')
INSERT [dbo].[Patents] ([library_item_ID], [title], [country], [reg_number], [date_of_submission], [date_of_publication], [number_of_pages], [note]) VALUES (9, N'Башня Уордклифф', N'USA', N'500', CAST(N'1919-03-03' AS Date), CAST(N'1920-02-02' AS Date), 1500, N'Note')
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([publisher_Id], [publisherName]) VALUES (1, N'URSS')
INSERT [dbo].[Publishers] ([publisher_Id], [publisherName]) VALUES (2, N'Свобода')
INSERT [dbo].[Publishers] ([publisher_Id], [publisherName]) VALUES (3, N'Правда')
INSERT [dbo].[Publishers] ([publisher_Id], [publisherName]) VALUES (4, N'US books')
INSERT [dbo].[Publishers] ([publisher_Id], [publisherName]) VALUES (5, N'Fairwood Press')
INSERT [dbo].[Publishers] ([publisher_Id], [publisherName]) VALUES (6, N'Желтая пресса')
SET IDENTITY_INSERT [dbo].[Publishers] OFF
INSERT [dbo].[Users] ([login], [role], [hash]) VALUES (N'Admin', N'Admin', N'NieQminDE4Ggcewn98nKl3Jhgq7Smn3dLlQ1MyLPswq7njpt8qwsIP4jQ2MR1nhWTQyNMFkwV19g4tPQSBhNeQ==')
INSERT [dbo].[Users] ([login], [role], [hash]) VALUES (N'Nadya', N'Admin', N'NieQminDE4Ggcewn98nKl3Jhgq7Smn3dLlQ1MyLPswq7njpt8qwsIP4jQ2MR1nhWTQyNMFkwV19g4tPQSBhNeQ==')
INSERT [dbo].[Users] ([login], [role], [hash]) VALUES (N'Rushan', N'User', N'NieQminDE4Ggcewn98nKl3Jhgq7Smn3dLlQ1MyLPswq7njpt8qwsIP4jQ2MR1nhWTQyNMFkwV19g4tPQSBhNeQ==')
ALTER TABLE [dbo].[LibraryItem] ADD  CONSTRAINT [DF_LibraryItem_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_user]  DEFAULT (user_name()) FOR [user]
GO
ALTER TABLE [dbo].[Book_authors]  WITH CHECK ADD  CONSTRAINT [FK_book_authors_authors] FOREIGN KEY([author_Id])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book_authors] CHECK CONSTRAINT [FK_book_authors_authors]
GO
ALTER TABLE [dbo].[Book_authors]  WITH CHECK ADD  CONSTRAINT [FK_book_authors_library_item] FOREIGN KEY([book_item_ID])
REFERENCES [dbo].[LibraryItem] ([library_item_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book_authors] CHECK CONSTRAINT [FK_book_authors_library_item]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_books_library_item] FOREIGN KEY([library_item_ID])
REFERENCES [dbo].[LibraryItem] ([library_item_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_books_library_item]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_books_publishers] FOREIGN KEY([publisher_Id])
REFERENCES [dbo].[Publishers] ([publisher_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_books_publishers]
GO
ALTER TABLE [dbo].[Paper]  WITH CHECK ADD  CONSTRAINT [FK_Paper_Paper] FOREIGN KEY([id])
REFERENCES [dbo].[Paper] ([id])
GO
ALTER TABLE [dbo].[Paper] CHECK CONSTRAINT [FK_Paper_Paper]
GO
ALTER TABLE [dbo].[PaperIssues]  WITH CHECK ADD  CONSTRAINT [FK_PaperIssues_LibraryItem] FOREIGN KEY([library_item_ID])
REFERENCES [dbo].[LibraryItem] ([library_item_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaperIssues] CHECK CONSTRAINT [FK_PaperIssues_LibraryItem]
GO
ALTER TABLE [dbo].[PaperIssues]  WITH CHECK ADD  CONSTRAINT [FK_PaperIssues_Paper1] FOREIGN KEY([paperId])
REFERENCES [dbo].[Paper] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaperIssues] CHECK CONSTRAINT [FK_PaperIssues_Paper1]
GO
ALTER TABLE [dbo].[PaperIssues]  WITH CHECK ADD  CONSTRAINT [FK_PaperIssues_Publishers] FOREIGN KEY([publisher_Id])
REFERENCES [dbo].[Publishers] ([publisher_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaperIssues] CHECK CONSTRAINT [FK_PaperIssues_Publishers]
GO
ALTER TABLE [dbo].[Patent_authors]  WITH CHECK ADD  CONSTRAINT [FK_patent_authors_authors] FOREIGN KEY([author_ID])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patent_authors] CHECK CONSTRAINT [FK_patent_authors_authors]
GO
ALTER TABLE [dbo].[Patent_authors]  WITH CHECK ADD  CONSTRAINT [FK_patent_authors_library_item] FOREIGN KEY([patent_ID])
REFERENCES [dbo].[LibraryItem] ([library_item_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patent_authors] CHECK CONSTRAINT [FK_patent_authors_library_item]
GO
ALTER TABLE [dbo].[Patents]  WITH CHECK ADD  CONSTRAINT [FK_patents_library_item] FOREIGN KEY([library_item_ID])
REFERENCES [dbo].[LibraryItem] ([library_item_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patents] CHECK CONSTRAINT [FK_patents_library_item]
GO
/****** Object:  StoredProcedure [dbo].[AddAuthor]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAuthor]
@id int OUTPUT,
@firstName nvarchar(50),
@lastName nvarchar(200)

AS
BEGIN
	INSERT INTO Authors (Firstname, Lastname) VALUES (@firstName, @lastName)
	SET @id = SCOPE_IDENTITY()
END


GO
ALTER AUTHORIZATION ON [dbo].[AddAuthor] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[AddAuthor] TO [administrator] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddBook]
	@bookId int OUTPUT,
	@authors nvarchar(max),
	@yearOfPublishing int,
	@title nvarchar(300), 
	@cityOfPublishing nvarchar(200),
	@publisher_ID int,
	@numberOfPages int,
	@note nvarchar(2000),
	@ISBN nvarchar(18)
	


AS
BEGIN

	DECLARE @bookCount int

		BEGIN TRAN

		INSERT INTO LibraryItem (YearOfPublication) VALUES (@yearOfPublishing)
		SET @bookId = SCOPE_IDENTITY()

		INSERT INTO Books (library_item_ID, title, city_of_publishing, publisher_Id, number_of_pages, note, ISBN) VALUES (@bookId, @title, @cityOfPublishing, @publisher_ID, @numberOfPages, @note, @ISBN)


		
		INSERT INTO [Book_authors](author_Id, book_item_ID)
		SELECT * ,@bookID as 'book_item_ID' FROM string_split(@authors, ',')


		EXEC dbo.BookCount @bookCount OUTPUT, @ISBN, @authors, @title, @yearOfPublishing
		if @bookCount > 1
		BEGIN
			SET @bookId = -1
			ROLLBACK
		END

		ELSE

		BEGIN
			COMMIT
		END
		
		

END


GO
ALTER AUTHORIZATION ON [dbo].[AddBook] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[AddBook] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[AddBook] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[AddPaper]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPaper]
@id int OUTPUT,
@title nvarchar(300),
@ISSN nvarchar(14)

AS
BEGIN
	INSERT INTO 
		Paper (title, ISSN) 
	VALUES 
		(@title, @ISSN)
	SET @id = SCOPE_IDENTITY()
END

GO
ALTER AUTHORIZATION ON [dbo].[AddPaper] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[AddPaper] TO [administrator] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[AddPaperIssue]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPaperIssue]
@id int output,
@paperId int,
@cityOfPublication nvarchar(200),
@publisherId int,
@numberOfPages int,
@note nvarchar(2000),
@number_of_issue int,
@yearOfPublishing int,
@dateOfIssue date

	
AS
BEGIN

DECLARE 
@numberOfEntries int,
@title nvarchar(300)

	BEGIN TRAN

		INSERT INTO LibraryItem (YearOfPublication) VALUES (@yearOfPublishing)
		SET @id = SCOPE_IDENTITY()

		INSERT INTO PaperIssues (library_item_ID, paperId, cityOfPublication, publisher_Id, number_of_pages, note, number_of_issue, dateOfIssue) VALUES (@id, @paperId, @cityOfPublication, @publisherId, @numberOfPages, @note, @number_of_issue, @dateOfIssue)

		SET @title = (SELECT Paper.title FROM Paper WHERE Paper.id = @paperId)
		EXEC dbo.PaperCount @numberOfEntries OUTPUT, @publisherId, @dateOfIssue, @title
		IF @numberOfEntries > 1
			BEGIN 
				SET @id = -1
				ROLLBACK
			END
		ELSE
			BEGIN
				COMMIT
			END
	
END


GO
ALTER AUTHORIZATION ON [dbo].[AddPaperIssue] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[AddPaperIssue] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[AddPaperIssue] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[AddPatent]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPatent]
	@authors nvarchar(MAX),
	@id int OUTPUT,
	@title nvarchar(300),
	@country nvarchar(200),
	@regnumber nvarchar(9),
	@date_of_submission datetime,
	@date_of_publication datetime, 
	@number_of_pages int,
	@note nvarchar(2000),
	@yearOfPublication int


AS
BEGIN
	DECLARE	@resultOfProcedure int
	--start of transaction
	BEGIN TRAN

		INSERT INTO LibraryItem (YearOfPublication) VALUES (@yearOfPublication)
		SET @id = SCOPE_IDENTITY()
		INSERT INTO Patents(library_item_ID, title, country, reg_number, date_of_submission, date_of_publication, number_of_pages, note) 
		VALUES (@id, @title, @country, @regnumber, @date_of_submission, @date_of_publication, @number_of_pages, @note)


		declare cursor_substr cursor static local for select * from string_split (@authors, ',')
		declare @ch varchar(10), @i int 
		open cursor_substr 
		fetch next from cursor_substr into @ch 
		while @@FETCH_STATUS = 0 
		begin 
			set @i = CAST(@ch as int) 
	
			INSERT INTO Patent_authors(patent_ID, author_ID) VALUES (@id, @i)

			fetch next from cursor_substr into @ch 
		end 
		close cursor_substr 
		deallocate cursor_substr


		EXEC PatentCount @resultOfProcedure OUTPUT, @country, @regnumber
		IF @resultOfProcedure > 1
		BEGIN
			SET @id = -1
			ROLLBACK
		END

		ELSE
		
		BEGIN
			COMMIT
		END


END


GO
ALTER AUTHORIZATION ON [dbo].[AddPatent] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[AddPatent] TO [administrator] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[AddPublisher]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPublisher]
	@id int OUTPUT,
	@PublisherName nvarchar(300)
AS
BEGIN
	INSERT INTO	Publishers (publisherName) VALUES (@PublisherName)
	SET @id = SCOPE_IDENTITY()
END


GO
ALTER AUTHORIZATION ON [dbo].[AddPublisher] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[AddPublisher] TO [administrator] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
@login nvarchar(50),
@role nvarchar(50),
@hash nvarchar(255)
AS
BEGIN

	INSERT INTO Users (login, role, hash) VALUES (@login, @role, @hash)

END

GO
ALTER AUTHORIZATION ON [dbo].[AddUser] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[BookCount]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BookCount]
@result int OUTPUT,
@ISBN nvarchar(18),
@authors nvarchar(MAX),
@title nvarchar(200),
@yearOfPublishing int


AS
BEGIN


	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
			IF @ISBN IS NOT NULL
			BEGIN
			 SET @result = 
			(
				SELECT COUNT(*) 
				FROM LibraryItem 
				INNER JOIN BookAdminView Books 
				ON LibraryItem.library_item_ID = Books.library_item_ID 
				WHERE ISBN = @ISBN 
			 )
			END

			ELSE
			BEGIN
					SET @result =
					(
						SELECT 
						COUNT(*)
						FROM LibraryItem 
						INNER JOIN BookAdminView Books 
						ON LibraryItem.library_item_ID = Books.library_item_ID 
						WHERE Books.title = @title
						AND LibraryItem.YearOfPublication = @yearOfPublishing
						AND dbo.UniqueAuthorsForBook(@authors, LibraryItem.library_item_ID) = 1
					)

			END
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
			IF @ISBN IS NOT NULL
			BEGIN
			 SET @result = 
			(
				SELECT COUNT(*) 
				FROM LibraryItem 
				INNER JOIN BookRegularView Books 
				ON LibraryItem.library_item_ID = Books.library_item_ID 
				WHERE ISBN = @ISBN 
			 )
			END

			ELSE
			BEGIN
					SET @result =
					(
						SELECT 
						COUNT(*)
						FROM LibraryItem 
						INNER JOIN BookRegularView Books 
						ON LibraryItem.library_item_ID = Books.library_item_ID 
						WHERE Books.title = @title
						AND LibraryItem.YearOfPublication = @yearOfPublishing
						AND dbo.UniqueAuthorsForBook(@authors, LibraryItem.library_item_ID) = 1
					)

			END	
	END


END



GO
ALTER AUTHORIZATION ON [dbo].[BookCount] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[BookCount] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[BookCount] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[BookExists]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BookExists]
@result bit OUTPUT,
@ISBN nvarchar(18),
@authors nvarchar(MAX),
@title nvarchar(200),
@yearOfPublishing int




AS
BEGIN


	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
							IF @ISBN is NULL
						BEGIN
								IF EXISTS
									(
									--Equality of YearOfPublication and Title
										SELECT 
											LibraryItem.library_item_ID
										FROM LibraryItem 
										INNER JOIN BookAdminView Books 
										ON LibraryItem.library_item_ID = Books.library_item_ID 
										WHERE Books.title = @title
										AND LibraryItem.YearOfPublication = @yearOfPublishing
									)

									--Equality of authors
									AND
									NOT EXISTS
									(
										SELECT value as x FROM string_split(@authors, ',')
											EXCEPT
										SELECT Book_authors.book_item_ID
											FROM LibraryItem 
											INNER JOIN BookAdminView Books 
											ON LibraryItem.library_item_ID = Books.library_item_ID 
											INNER JOIN Book_authors
											ON LibraryItem.library_item_ID = Book_authors.book_item_ID
											WHERE Books.title = @title
											AND LibraryItem.YearOfPublication = @yearOfPublishing

											UNION

										SELECT Book_authors.book_item_ID
											FROM LibraryItem 
											INNER JOIN BookAdminView Books 
											ON LibraryItem.library_item_ID = Books.library_item_ID 
											INNER JOIN Book_authors
											ON LibraryItem.library_item_ID = Book_authors.book_item_ID
											WHERE Books.title = @title
											AND LibraryItem.YearOfPublication = @yearOfPublishing
											EXCEPT
										SELECT value as x FROM string_split(@authors, ',')
									)
									BEGIN
										SET @result = 1
									END
									ELSE
									BEGIN
										SET @result = 0
									END

						END
	
	
						ELSE
						BEGIN
							IF EXISTS
							(	
								SELECT 
									LibraryItem.library_item_ID
								FROM LibraryItem 
								INNER JOIN BookAdminView Books 
								ON LibraryItem.library_item_ID = Books.library_item_ID 
								WHERE ISBN = @ISBN
							)
								BEGIN
									SET @result = 1
								END
							ELSE
								BEGIN
									SET @result = 0
								END
						END


	END




	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
							IF @ISBN is NULL
						BEGIN
								IF EXISTS
									(
									--Equality of YearOfPublication and Title
										SELECT 
											LibraryItem.library_item_ID
										FROM LibraryItem 
										INNER JOIN BookRegularView Books 
										ON LibraryItem.library_item_ID = Books.library_item_ID 
										WHERE Books.title = @title
										AND LibraryItem.YearOfPublication = @yearOfPublishing
									)

									--Equality of authors
									AND
									NOT EXISTS
									(
										SELECT value as x FROM string_split(@authors, ',')
											EXCEPT
										SELECT Book_authors.book_item_ID
											FROM LibraryItem 
											INNER JOIN BookRegularView Books 
											ON LibraryItem.library_item_ID = Books.library_item_ID 
											INNER JOIN Book_authors
											ON LibraryItem.library_item_ID = Book_authors.book_item_ID
											WHERE Books.title = @title
											AND LibraryItem.YearOfPublication = @yearOfPublishing

											UNION

										SELECT Book_authors.book_item_ID
											FROM LibraryItem 
											INNER JOIN BookRegularView Books 
											ON LibraryItem.library_item_ID = Books.library_item_ID 
											INNER JOIN Book_authors
											ON LibraryItem.library_item_ID = Book_authors.book_item_ID
											WHERE Books.title = @title
											AND LibraryItem.YearOfPublication = @yearOfPublishing
											EXCEPT
										SELECT value as x FROM string_split(@authors, ',')
									)
									BEGIN
										SET @result = 1
									END
									ELSE
									BEGIN
										SET @result = 0
									END

						END
	
	
						ELSE
						BEGIN
							IF EXISTS
							(	
								SELECT 
									LibraryItem.library_item_ID
								FROM LibraryItem 
								INNER JOIN BookRegularView Books 
								ON LibraryItem.library_item_ID = Books.library_item_ID 
								WHERE ISBN = @ISBN
							)
								BEGIN
									SET @result = 1
								END
							ELSE
								BEGIN
									SET @result = 0
								END
						END


	END











END


GO
ALTER AUTHORIZATION ON [dbo].[BookExists] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[BookExists] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[BookExists] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[CanLogin]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CanLogin]
@login nvarchar(50), 
@hash nvarchar(255),
@canLogin bit output
AS
BEGIN
	if(EXISTS (SELECT * FROM dbo.Users WHERE login = @login AND hash = @hash))
	BEGIN
		SET @canLogin = 1
	END
	
	ELSE
	
	BEGIN
		SET @canLogin = 0
	END

END

GO
ALTER AUTHORIZATION ON [dbo].[CanLogin] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[ChangeRole]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeRole]
	@login nvarchar(50),
	@role nvarchar(50)
AS
BEGIN
	UPDATE Users SET role = @role WHERE login = @login
END

GO
ALTER AUTHORIZATION ON [dbo].[ChangeRole] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[DeleteAuthor]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAuthor]
	@id int
AS
BEGIN
	DELETE FROM Authors WHERE Id = @id 
END


GO
ALTER AUTHORIZATION ON [dbo].[DeleteAuthor] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[DeleteAuthor] TO [administrator] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[DeleteLibraryItem]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLibraryItem] 
	@id int
AS
BEGIN
	DELETE FROM LibraryItem WHERE library_item_ID = @id
END


GO
ALTER AUTHORIZATION ON [dbo].[DeleteLibraryItem] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[DeleteLibraryItem] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[DeleteLibraryItem] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[DeletePublisher]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePublisher]
	@id int
AS
BEGIN
	DELETE FROM Publishers WHERE publisher_Id = @id
END


GO
ALTER AUTHORIZATION ON [dbo].[DeletePublisher] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[DeletePublisher] TO [administrator] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll]
	@sortParam int

AS
BEGIN

IF @sortParam = 0
BEGIN


	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookAdminView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueAdminView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId


										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue, 

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentAdminView  pt 
												ON li.library_item_ID = pt.library_item_ID 

										END






										IF @sortParam = 1
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue, 

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookAdminView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueAdminView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentAdminView  pt 
												ON li.library_item_ID = pt.library_item_ID 
												ORDER BY YearOfPublication ASC

										END







										IF @sortParam = 2
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookAdminView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueAdminView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentAdminView  pt 
												ON li.library_item_ID = pt.library_item_ID
												ORDER BY YearOfPublication DESC 
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
										if @sortParam = 0
										begin
											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookRegularView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueRegularView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId


										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue, 

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentRegularView  pt 
												ON li.library_item_ID = pt.library_item_ID 

										END






										IF @sortParam = 1
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue, 

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookRegularView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueRegularView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentRegularView  pt 
												ON li.library_item_ID = pt.library_item_ID 
												ORDER BY YearOfPublication ASC

										END







										IF @sortParam = 2
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookRegularView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueRegularView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentRegularView  pt 
												ON li.library_item_ID = pt.library_item_ID
												ORDER BY YearOfPublication DESC 	
	END



	END

END















END


GO
ALTER AUTHORIZATION ON [dbo].[GetAll] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetAll] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAll] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAll] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAllAuthors]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAuthors]

AS
BEGIN

	SELECT 
		a.Id, 
		a.Firstname,
		a.Lastname
	FROM 
		Authors a

END

GO
ALTER AUTHORIZATION ON [dbo].[GetAllAuthors] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllBooks]

AS
BEGIN

	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
			SELECT 
			li.library_item_ID, 
			li.YearOfPublication, 
			b.title, 
			b.city_of_publishing, 
			b.ISBN, 
			b.note, 
			b.number_of_pages,
			pb.publisher_Id,
			pb.publisherName,
			dbo.GetAuthorsForBook(li.library_item_ID) as authors	  
	FROM 
			LibraryItem li 
			INNER JOIN 
			BookAdminView b 
			ON li.library_item_ID = b.library_item_ID 
			INNER JOIN 
			Publishers pb 
			ON b.publisher_Id = pb.publisher_Id
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
			SELECT 
			li.library_item_ID, 
			li.YearOfPublication, 
			b.title, 
			b.city_of_publishing, 
			b.ISBN, 
			b.note, 
			b.number_of_pages,
			pb.publisher_Id,
			pb.publisherName,	 
			dbo.GetAuthorsForBook(li.library_item_ID) as authors
	FROM 
			LibraryItem li 
			INNER JOIN 
			BookRegularView b 
			ON li.library_item_ID = b.library_item_ID 
			INNER JOIN 
			Publishers pb 
			ON b.publisher_Id = pb.publisher_Id
	END
END


GO
ALTER AUTHORIZATION ON [dbo].[GetAllBooks] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetAllBooks] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllBooks] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllBooks] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAllIdAndType]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllIdAndType]
AS
BEGIN




	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
			SELECT 'book' as type, li.library_item_ID FROM LibraryItem li INNER JOIN BookAdminView b ON li.library_item_ID = b.library_item_ID
			UNION
			SELECT 'paper' as type, li.library_item_ID FROM LibraryItem li INNER JOIN PaperIssueAdminView pi ON li.library_item_ID = pi.library_item_ID
			UNION
			SELECT 'patent' as type,  li.library_item_ID FROM LibraryItem li INNER JOIN PatentAdminView p ON li.library_item_ID = p.library_item_ID
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
			SELECT 'book' as type, li.library_item_ID FROM LibraryItem li INNER JOIN BookRegularView b ON li.library_item_ID = b.library_item_ID
			UNION
			SELECT 'paper' as type, li.library_item_ID FROM LibraryItem li INNER JOIN PaperIssueRegularView pi ON li.library_item_ID = pi.library_item_ID
			UNION
			SELECT 'patent' as type,  li.library_item_ID FROM LibraryItem li INNER JOIN PatentRegularView p ON li.library_item_ID = p.library_item_ID
	END


END


GO
ALTER AUTHORIZATION ON [dbo].[GetAllIdAndType] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetAllIdAndType] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllIdAndType] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllIdAndType] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAllItemsByTitle]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllItemsByTitle]
	@title nvarchar(300)

AS
BEGIN

	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
											SELECT 
												'Book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookAdminView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id
												WHERE b.title LIKE '%' + @title + '%'

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors 
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueAdminView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId
												WHERE p.title LIKE '%' + @title + '%'

										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue, 

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentAdminView  pt 
												ON li.library_item_ID = pt.library_item_ID 
												WHERE pt.title LIKE '%' + @title + '%'
										END


	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)

		BEGIN
											
											SELECT 
												'Book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors
												 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookRegularView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id
												WHERE b.title LIKE '%' + @title + '%'

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors 
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueRegularView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId
												WHERE p.title LIKE '%' + @title + '%'

										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue, 

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors
												 

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentRegularView  pt 
												ON li.library_item_ID = pt.library_item_ID 
												WHERE pt.title LIKE '%' + @title + '%'
										END

END

GO
ALTER AUTHORIZATION ON [dbo].[GetAllItemsByTitle] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetAllItemsByTitle] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllItemsByTitle] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllItemsByTitle] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAllOffset]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllOffset]
	@sortParam int,
	@offset int,
	@page int,
	@totalResult int OUTPUT
AS
BEGIN

IF @sortParam = 0
BEGIN


	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN

										IF @sortParam = 0

										SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookAdminView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueAdminView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId


										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue, 

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentAdminView  pt 
												ON li.library_item_ID = pt.library_item_ID
												 
										ORDER BY library_item_ID
										Offset @offset Row
										Fetch Next @page Row Only

										END






										IF @sortParam = 1
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue, 

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookAdminView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueAdminView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentAdminView  pt 
												ON li.library_item_ID = pt.library_item_ID 
												ORDER BY YearOfPublication ASC

										
										Offset @offset Rows
										Fetch Next @page Rows Only

										END







										IF @sortParam = 2
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookAdminView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueAdminView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentAdminView  pt 
												ON li.library_item_ID = pt.library_item_ID
												ORDER BY YearOfPublication DESC 

										
										Offset @offset Rows
										Fetch Next @page Rows Only


	SET @totalResult = (SELECT COUNT(*) FROM LibraryItem)

	END


		SET @totalResult = (SELECT COUNT(*) FROM LibraryItem)


	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
										IF @sortParam = 0
										BEGIN
											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookRegularView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueRegularView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId


										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue, 

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentRegularView  pt 
												ON li.library_item_ID = pt.library_item_ID 

										ORDER BY library_item_ID
										Offset @offset Rows
										Fetch Next @page Rows Only

										END






										IF @sortParam = 1
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue, 
												null as dateOfIssue, 

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookRegularView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueRegularView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentRegularView  pt 
												ON li.library_item_ID = pt.library_item_ID 
												ORDER BY YearOfPublication ASC

										
												Offset @offset Rows
												Fetch Next @page Rows Only

										END






										IF @sortParam = 2
										BEGIN

											SELECT 
												'book' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												b.title, 
												b.city_of_publishing, 
												b.ISBN, 
												b.note, 
												b.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	 

										FROM 
												LibraryItem li 
												INNER JOIN 
												BookRegularView b 
												ON li.library_item_ID = b.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON b.publisher_Id = pl.publisher_Id

										UNION


										SELECT 
												'paper' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												p.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pi.note, 
												pi.number_of_pages, 
												pl.publisher_Id,
												pl.publisherName,

												pi.cityOfPublication, 
												p.ISSN,  
												pi.number_of_issue, 
												pi.dateOfIssue,

												null as country, 
												null as date_of_publication, 
												null as date_of_submission, 
												null as reg_number,
												null as authors  
										FROM 
												LibraryItem li 
												INNER JOIN 
												PaperIssueRegularView pi
												ON li.library_item_ID = pi.library_item_ID 
												INNER JOIN 
												Publishers pl
												ON pi.publisher_Id = pl.publisher_Id
												INNER JOIN Paper p
												ON p.id = pi.paperId



										UNION

												SELECT
 
												'patent' as Type,
												li.library_item_ID, 
												li.YearOfPublication, 
												pt.title, 
												null as city_of_publishing, 
												null as ISBN, 
												pt.note, 
												pt.number_of_pages, 
												null as publisher_Id,
												null as publisherName,

												null as cityOfPublication, 
												null as ISSN, 
												null as number_of_issue,
												null as dateOfIssue,  

												pt.country, 
												pt.date_of_publication, 
												pt.date_of_submission, 
												pt.reg_number,
												cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	  

										FROM 
												LibraryItem li 
												INNER JOIN 
												PatentRegularView  pt 
												ON li.library_item_ID = pt.library_item_ID
												ORDER BY YearOfPublication DESC 	

										
										Offset @offset Rows
										Fetch Next @page Rows Only
	END

		SET @totalResult = (SELECT COUNT(*) FROM LibraryItem WHERE isDeleted = 0)

	END

END















END


GO
ALTER AUTHORIZATION ON [dbo].[GetAllOffset] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetAllOffset] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllOffset] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllOffset] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPaperIssues]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPaperIssues]

AS
BEGIN


	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
				SELECT 
					li.library_item_ID, 
					li.YearOfPublication, 
					pi.cityOfPublication, 
					pi.note, 
					pi.number_of_issue, 
					pi.number_of_pages,
					pi.dateOfIssue,
					pl.publisher_Id, 
					pl.publisherName,
					p.id,
					p.title,
					p.ISSN 
				FROM LibraryItem li 
				INNER JOIN PaperIssueAdminView pi 
				ON li.library_item_ID = pi.library_item_ID 
				INNER JOIN Publishers pl 
				ON pi.publisher_Id = pl.publisher_Id
				INNER JOIN Paper p
				ON p.id = pi.paperId 
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
				SELECT 
					li.library_item_ID, 
					li.YearOfPublication, 
					pi.cityOfPublication, 
					pi.note, 
					pi.number_of_issue, 
					pi.number_of_pages,
					pi.dateOfIssue,
					pl.publisher_Id, 
					pl.publisherName,
					p.id,
					p.title,
					p.ISSN 
				FROM LibraryItem li 
				INNER JOIN PaperIssueRegularView pi 
				ON li.library_item_ID = pi.library_item_ID 
				INNER JOIN Publishers pl 
				ON pi.publisher_Id = pl.publisher_Id
				INNER JOIN Paper p
				ON p.id = pi.paperId 
	END

END


GO
ALTER AUTHORIZATION ON [dbo].[GetAllPaperIssues] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetAllPaperIssues] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllPaperIssues] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllPaperIssues] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPatents]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPatents]
AS
BEGIN

	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
			SELECT 
			li.library_item_ID, 
			li.YearOfPublication, 
			pt.country, 
			pt.date_of_publication, 
			pt.date_of_submission, 
			pt.note, 
			pt.number_of_pages, 
			pt.reg_number, 
			pt.title,
			dbo.GetAuthorsForPatent(li.library_item_ID)	as 'authors'
			FROM LibraryItem li 
			INNER JOIN PatentAdminView pt 
			ON li.library_item_ID = pt.library_item_ID
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
			SELECT 
			li.library_item_ID, 
			li.YearOfPublication, 
			pt.country, 
			pt.date_of_publication, 
			pt.date_of_submission, 
			pt.note, 
			pt.number_of_pages, 
			pt.reg_number, 
			pt.title,
			dbo.GetAuthorsForPatent(li.library_item_ID)	as 'authors'
			FROM LibraryItem li 
			INNER JOIN PatentRegularView pt 
			ON li.library_item_ID = pt.library_item_ID
	END





--SELECT patent_ID, author_ID FROM Patent_authors

END


GO
ALTER AUTHORIZATION ON [dbo].[GetAllPatents] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetAllPatents] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllPatents] TO [guest] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetAllPatents] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPublishers]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPublishers]
AS
BEGIN
	SELECT p.publisher_Id, p.publisherName
	FROM dbo.Publishers p
END


GO
ALTER AUTHORIZATION ON [dbo].[GetAllPublishers] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SELECT login, role FROM Users
END

GO
ALTER AUTHORIZATION ON [dbo].[GetAllUsers] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorById]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuthorById]

@id int

AS
BEGIN

	SELECT 
		a.Id, 
		a.Firstname,
		a.Lastname
	FROM 
		Authors a
	WHERE 
		a.Id = @id

END


GO
ALTER AUTHORIZATION ON [dbo].[GetAuthorById] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorsByName]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuthorsByName]

@authorName nvarchar(MAX)

AS
BEGIN

	SELECT 
		a.Id, 
		a.Firstname,
		a.Lastname
	FROM 
		Authors a
	WHERE 
		a.Firstname LIKE '%' + @authorName + '%' OR a.Lastname LIKE '%' + @authorName + '%'

END


GO
ALTER AUTHORIZATION ON [dbo].[GetAuthorsByName] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetBookById]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBookById]
@id int

AS
BEGIN

	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
		SELECT
			'book' as Type, 
			LibraryItem.library_item_ID, 
			LibraryItem.YearOfPublication, 
			Books.title, 
			Books.city_of_publishing, 
			Books.ISBN, 
			Books.note, 
			Books.number_of_pages, 
			Publishers.publisher_Id, 
			Publishers.publisherName,
			dbo.GetAuthorsForBook(@id) as authors  
		FROM LibraryItem 
		INNER JOIN dbo.BookAdminView Books 
		ON LibraryItem.library_item_ID = Books.library_item_ID 
		INNER JOIN Publishers 
		ON Books.publisher_Id = Publishers.publisher_Id 
		WHERE LibraryItem.library_item_ID = @id
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN

				SELECT 
				'book' as Type,
				LibraryItem.library_item_ID, 
				LibraryItem.YearOfPublication, 
				Books.title, 
				Books.city_of_publishing, 
				Books.ISBN, 
				Books.note, 
				Books.number_of_pages, 
				Publishers.publisher_Id, 
				Publishers.publisherName,
				dbo.GetAuthorsForBook(@id) as authors  
			FROM LibraryItem 
			INNER JOIN dbo.BookRegularView Books 
			ON LibraryItem.library_item_ID = Books.library_item_ID 
			INNER JOIN Publishers 
			ON Books.publisher_Id = Publishers.publisher_Id 
			WHERE LibraryItem.library_item_ID = @id

	END






--SELECT Authors.Id, Authors.Firstname, Authors.Lastname
--FROM Book_authors 
--INNER JOIN Authors
--ON Book_authors.author_Id = Authors.Id
--WHERE Book_authors.book_item_ID = @id



END


GO
ALTER AUTHORIZATION ON [dbo].[GetBookById] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetBookById] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBookById] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBookById] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetBooksAndPatentsByAuthor]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBooksAndPatentsByAuthor]
	
@authorId int

AS
BEGIN





	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
				SELECT 
						'Type' = 'book',
						li.library_item_ID, 
						li.YearOfPublication, 
						b.title, 
						b.city_of_publishing, 
						b.ISBN, 
						b.note, 
						b.number_of_pages, 
						pl.publisher_Id,
						pl.publisherName,


						null as country, 
						null as date_of_publication, 
						null as date_of_submission, 
						--pt.note, 
						--pt.number_of_pages, 
						null as reg_number, 
						--pt.title
		
						--ba.author_Id,
						--ba.book_item_ID
						cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	
				FROM 
						LibraryItem li 
						INNER JOIN 
						BookAdminView b 
						ON li.library_item_ID = b.library_item_ID 
						INNER JOIN 
						Publishers pl
						ON b.publisher_Id = pl.publisher_Id
						INNER JOIN
						Book_authors ba
						ON ba.book_item_ID = li.library_item_ID
						WHERE ba.author_Id = @authorId
				UNION

				SELECT
 
						'Type' = 'patent',
						li.library_item_ID, 
						li.YearOfPublication, 
						pt.title, 
						null as city_of_publishing, 
						null as ISBN, 
						pt.note, 
						pt.number_of_pages, 
						null as publisher_Id,
						null as publisherName,

						pt.country, 
						pt.date_of_publication, 
						pt.date_of_submission, 
						--pt.note, 
						--pt.number_of_pages, 
						pt.reg_number, 
						--pt.title

						--pa.author_Id,
						--pa.patent_ID
						cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	 
				FROM 
						LibraryItem li 
						INNER JOIN 
						PatentAdminView  pt 
						ON li.library_item_ID = pt.library_item_ID
						INNER JOIN
						Patent_authors pa
						ON pa.patent_ID = li.library_item_ID
						WHERE pa.author_Id = @authorId
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
					SELECT 
							'Type' = 'book',
							li.library_item_ID, 
							li.YearOfPublication, 
							b.title, 
							b.city_of_publishing, 
							b.ISBN, 
							b.note, 
							b.number_of_pages, 
							pl.publisher_Id,
							pl.publisherName,


							null as country, 
							null as date_of_publication, 
							null as date_of_submission, 
							--pt.note, 
							--pt.number_of_pages, 
							null as reg_number, 
							--pt.title
		
							--ba.author_Id,
							--ba.book_item_ID
							cast (dbo.GetAuthorsForBook(li.library_item_ID) as nvarchar(MAX)) as authors	
					FROM 
							LibraryItem li 
							INNER JOIN 
							BookRegularView b 
							ON li.library_item_ID = b.library_item_ID 
							INNER JOIN 
							Publishers pl
							ON b.publisher_Id = pl.publisher_Id
							INNER JOIN
							Book_authors ba
							ON ba.book_item_ID = li.library_item_ID
							WHERE ba.author_Id = @authorId
					UNION

					SELECT
 
							'Type' = 'patent',
							li.library_item_ID, 
							li.YearOfPublication, 
							pt.title, 
							null as city_of_publishing, 
							null as ISBN, 
							pt.note, 
							pt.number_of_pages, 
							null as publisher_Id,
							null as publisherName,

							pt.country, 
							pt.date_of_publication, 
							pt.date_of_submission, 
							--pt.note, 
							--pt.number_of_pages, 
							pt.reg_number, 
							--pt.title

							--pa.author_Id,
							--pa.patent_ID
							cast (dbo.GetAuthorsForPatent(li.library_item_ID) as nvarchar(MAX)) as authors	 
					FROM 
							LibraryItem li 
							INNER JOIN 
							PatentRegularView  pt 
							ON li.library_item_ID = pt.library_item_ID
							INNER JOIN
							Patent_authors pa
							ON pa.patent_ID = li.library_item_ID
							WHERE pa.author_Id = @authorId	
	END











END


GO
ALTER AUTHORIZATION ON [dbo].[GetBooksAndPatentsByAuthor] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetBooksAndPatentsByAuthor] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBooksAndPatentsByAuthor] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBooksAndPatentsByAuthor] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetBooksByAuthor]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBooksByAuthor]

@authorId int

AS
BEGIN

	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
		SELECT 
			li.library_item_ID, 
			li.YearOfPublication, 
			b.title, 
			b.city_of_publishing, 
			b.ISBN, 
			b.note, 
			b.number_of_pages,
			pb.publisher_Id, 
			pb.publisherName,
			--ba.author_Id,
			--ba.book_item_ID
			dbo.GetAuthorsForBook(li.library_item_ID) as authors   
	FROM 
			LibraryItem li 
			INNER JOIN 
			dbo.BookAdminView b 
			ON li.library_item_ID = b.library_item_ID 
			INNER JOIN 
			Publishers pb 
			ON b.publisher_Id = pb.publisher_Id
			INNER JOIN
			Book_authors ba
			ON
			ba.book_item_ID = li.library_item_ID
			WHERE ba.author_Id = @authorId

	END

	IF (1 = IS_ROLEMEMBER('guest') OR IS_ROLEMEMBER('librarian') = 1)
	BEGIN
					SELECT 
				li.library_item_ID, 
				li.YearOfPublication, 
				b.title, 
				b.city_of_publishing, 
				b.ISBN, 
				b.note, 
				b.number_of_pages,
				pb.publisher_Id, 
				pb.publisherName,
				--ba.author_Id,
				--ba.book_item_ID
				dbo.GetAuthorsForBook(li.library_item_ID) as authors   
		FROM 
				LibraryItem li 
				INNER JOIN 
				dbo.BookRegularView b 
				ON li.library_item_ID = b.library_item_ID 
				INNER JOIN 
				Publishers pb 
				ON b.publisher_Id = pb.publisher_Id
				INNER JOIN
				Book_authors ba
				ON
				ba.book_item_ID = li.library_item_ID
				WHERE ba.author_Id = @authorId
	END
	

END

GO
ALTER AUTHORIZATION ON [dbo].[GetBooksByAuthor] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetBooksByAuthor] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBooksByAuthor] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBooksByAuthor] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetBooksWherePublisherStartsWith]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBooksWherePublisherStartsWith]

@publisherName nvarchar(MAX)

AS
BEGIN
IF (IS_ROLEMEMBER('administrator') = 1)

BEGIN
	SELECT 
			li.library_item_ID, 
			li.YearOfPublication, 
			b.title, 
			b.city_of_publishing, 
			b.ISBN, 
			b.note, 
			b.number_of_pages, 
			pb.publisherName,
			dbo.GetAuthorsForBook(li.library_item_ID) as authors   
	FROM 
			LibraryItem li 
			INNER JOIN 
			BookAdminView b 
			ON li.library_item_ID = b.library_item_ID 
			INNER JOIN 
			Publishers pb 
			ON b.publisher_Id = pb.publisher_Id
			WHERE pb.publisherName LIKE '%' + @publisherName + '%'
END


IF (1 = IS_ROLEMEMBER('guest') OR IS_ROLEMEMBER('librarian') = 1)
BEGIN
	SELECT 
			li.library_item_ID, 
			li.YearOfPublication, 
			b.title, 
			b.city_of_publishing, 
			b.ISBN, 
			b.note, 
			b.number_of_pages, 
			pb.publisherName,
			dbo.GetAuthorsForBook(li.library_item_ID) as authors   
	FROM 
			LibraryItem li 
			INNER JOIN 
			BookRegularView b 
			ON li.library_item_ID = b.library_item_ID 
			INNER JOIN 
			Publishers pb 
			ON b.publisher_Id = pb.publisher_Id
			WHERE pb.publisherName LIKE '%' + @publisherName + '%'
END


END


GO
ALTER AUTHORIZATION ON [dbo].[GetBooksWherePublisherStartsWith] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetBooksWherePublisherStartsWith] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBooksWherePublisherStartsWith] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetBooksWherePublisherStartsWith] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetItemById]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemById] 
@id int
AS
BEGIN

	IF (IS_ROLEMEMBER('administrator') = 1) 
		BEGIN

			IF EXISTS (SELECT library_item_ID FROM dbo.BookAdminView WHERE library_item_ID = @id)
				BEGIN
				SELECT
						'book' as Type, 
						LibraryItem.library_item_ID, 
						LibraryItem.YearOfPublication, 
						Books.title, 
						Books.city_of_publishing, 
						Books.ISBN, 
						Books.note, 
						Books.number_of_pages, 
						Publishers.publisher_Id, 
						Publishers.publisherName,
						dbo.GetAuthorsForBook(@id) as authors  
					FROM LibraryItem 
					INNER JOIN dbo.BookAdminView Books 
					ON LibraryItem.library_item_ID = Books.library_item_ID 
					INNER JOIN Publishers 
					ON Books.publisher_Id = Publishers.publisher_Id 
					WHERE LibraryItem.library_item_ID = @id
				END
			ELSE IF EXISTS (SELECT library_item_ID FROM dbo.PaperIssueAdminView WHERE library_item_ID = @id)
				BEGIN
					SELECT 
					'paper' as Type,
					li.library_item_ID, 
					li.YearOfPublication, 
					p.cityOfPublication,
					pp.id,
					pp.title, 
					pp.ISSN, 
					p.note, 
					p.number_of_issue, 
					p.number_of_pages,
					p.dateOfIssue, 
					pl.publisher_Id, 
					pl.publisherName 
					FROM LibraryItem li 
					INNER JOIN dbo.PaperIssueAdminView p ON li.library_item_ID = p.library_item_ID 
					INNER JOIN Publishers pl ON p.publisher_Id = pl.publisher_Id
					INNER JOIN Paper pp ON pp.id = p.paperId
					WHERE li.library_item_ID = @id
				END
			ELSE IF EXISTS (SELECT library_item_ID FROM dbo.PatentAdminView WHERE library_item_ID = @id)  BEGIN
					SELECT 
						'patent' as Type,
						li.library_item_ID, 
						li.YearOfPublication, 
						pt.country, 
						pt.date_of_publication, 
						pt.date_of_submission, 
						pt.note, 
						pt.number_of_pages, 
						pt.reg_number, 
						pt.title,
						dbo.GetAuthorsForPatent(@id) as authors
					FROM LibraryItem li 
					INNER JOIN dbo.PatentAdminView pt 
					ON li.library_item_ID = pt.library_item_ID 
					WHERE li.library_item_ID = @id
				END	
					
		END


	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
		BEGIN

			IF EXISTS (SELECT library_item_ID FROM dbo.BookRegularView WHERE library_item_ID = @id)
				BEGIN
							SELECT 
							'book' as Type,
							LibraryItem.library_item_ID, 
							LibraryItem.YearOfPublication, 
							Books.title, 
							Books.city_of_publishing, 
							Books.ISBN, 
							Books.note, 
							Books.number_of_pages, 
							Publishers.publisher_Id, 
							Publishers.publisherName,
							dbo.GetAuthorsForBook(@id) as authors  
						FROM LibraryItem 
						INNER JOIN dbo.BookRegularView Books 
						ON LibraryItem.library_item_ID = Books.library_item_ID 
						INNER JOIN Publishers 
						ON Books.publisher_Id = Publishers.publisher_Id 
						WHERE LibraryItem.library_item_ID = @id
				END
			ELSE IF EXISTS (SELECT library_item_ID FROM dbo.PaperIssueRegularView WHERE library_item_ID = @id)
				BEGIN
						SELECT
						'paper' as Type, 
						li.library_item_ID, 
						li.YearOfPublication, 
						p.cityOfPublication,
						pp.id,
						pp.title, 
						pp.ISSN, 
						p.note, 
						p.number_of_issue, 
						p.number_of_pages,
						p.dateOfIssue, 
						pl.publisher_Id, 
						pl.publisherName 
						FROM LibraryItem li 
						INNER JOIN dbo.PaperIssueRegularView p ON li.library_item_ID = p.library_item_ID 
						INNER JOIN Publishers pl ON p.publisher_Id = pl.publisher_Id
						INNER JOIN Paper pp ON pp.id = p.paperId
						WHERE li.library_item_ID = @id
				END
			ELSE IF EXISTS (SELECT library_item_ID FROM dbo.PatentRegularView WHERE library_item_ID = @id)  
			BEGIN
						SELECT
							'patent' as Type, 
							li.library_item_ID, 
							li.YearOfPublication, 
							pt.country, 
							pt.date_of_publication, 
							pt.date_of_submission, 
							pt.note, 
							pt.number_of_pages, 
							pt.reg_number, 
							pt.title,
							dbo.GetAuthorsForPatent(@id) as authors	
						FROM LibraryItem li 
						INNER JOIN dbo.PatentRegularView pt 
						ON li.library_item_ID = pt.library_item_ID 
						WHERE li.library_item_ID = @id
				END	
			
		END


END

GO
ALTER AUTHORIZATION ON [dbo].[GetItemById] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetPaperById]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPaperById]
@id int
AS
BEGIN
	SELECT id, title, ISSN
	FROM dbo.Paper
	WHERE id = @id
END


GO
ALTER AUTHORIZATION ON [dbo].[GetPaperById] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetPaperIssueById]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPaperIssueById]
@id int

AS
BEGIN



IF IS_ROLEMEMBER('administrator') = 1
	BEGIN
		SELECT 
		'paper' as Type,
		li.library_item_ID, 
		li.YearOfPublication, 
		p.cityOfPublication,
		pp.id,
		pp.title, 
		pp.ISSN, 
		p.note, 
		p.number_of_issue, 
		p.number_of_pages,
		p.dateOfIssue, 
		pl.publisher_Id, 
		pl.publisherName 
		FROM LibraryItem li 
		INNER JOIN dbo.PaperIssueAdminView p ON li.library_item_ID = p.library_item_ID 
		INNER JOIN Publishers pl ON p.publisher_Id = pl.publisher_Id
		INNER JOIN Paper pp ON pp.id = p.paperId
		WHERE li.library_item_ID = @id
	END

IF (1 = IS_ROLEMEMBER('user') OR IS_ROLEMEMBER('librarian') = 1)
	BEGIN
		SELECT
		'paper' as Type, 
		li.library_item_ID, 
		li.YearOfPublication, 
		p.cityOfPublication,
		pp.id,
		pp.title, 
		pp.ISSN, 
		p.note, 
		p.number_of_issue, 
		p.number_of_pages,
		p.dateOfIssue, 
		pl.publisher_Id, 
		pl.publisherName 
		FROM LibraryItem li 
		INNER JOIN dbo.PaperIssueRegularView p ON li.library_item_ID = p.library_item_ID 
		INNER JOIN Publishers pl ON p.publisher_Id = pl.publisher_Id
		INNER JOIN Paper pp ON pp.id = p.paperId
		WHERE li.library_item_ID = @id
	END




END


GO
ALTER AUTHORIZATION ON [dbo].[GetPaperIssueById] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetPaperIssueById] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPaperIssueById] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPaperIssueById] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetPaperIssuesByPaperId]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPaperIssuesByPaperId]
@id int

AS
BEGIN



IF IS_ROLEMEMBER('administrator') = 1
	BEGIN
		SELECT 
		'paper' as Type,
		li.library_item_ID, 
		li.YearOfPublication, 
		p.cityOfPublication,
		pp.id,
		pp.title, 
		pp.ISSN, 
		p.note, 
		p.number_of_issue, 
		p.number_of_pages,
		p.dateOfIssue, 
		pl.publisher_Id, 
		pl.publisherName 
		FROM LibraryItem li 
		INNER JOIN dbo.PaperIssueAdminView p ON li.library_item_ID = p.library_item_ID 
		INNER JOIN Publishers pl ON p.publisher_Id = pl.publisher_Id
		INNER JOIN Paper pp ON pp.id = p.paperId
		WHERE p.paperId = @id
	END

IF (1 = IS_ROLEMEMBER('user') OR IS_ROLEMEMBER('librarian') = 1)
	BEGIN
		SELECT
		'paper' as Type, 
		li.library_item_ID, 
		li.YearOfPublication, 
		p.cityOfPublication,
		pp.id,
		pp.title, 
		pp.ISSN, 
		p.note, 
		p.number_of_issue, 
		p.number_of_pages,
		p.dateOfIssue, 
		pl.publisher_Id, 
		pl.publisherName 
		FROM LibraryItem li 
		INNER JOIN dbo.PaperIssueRegularView p ON li.library_item_ID = p.library_item_ID 
		INNER JOIN Publishers pl ON p.publisher_Id = pl.publisher_Id
		INNER JOIN Paper pp ON pp.id = p.paperId
		WHERE p.paperId = @id
	END




END

GO
ALTER AUTHORIZATION ON [dbo].[GetPaperIssuesByPaperId] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetPaperIssuesByPaperId] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPaperIssuesByPaperId] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPaperIssuesByPaperId] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetPapersByName]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPapersByName]
@name nvarchar(255)
AS
BEGIN
	SELECT Id, title, ISSN FROM Paper WHERE paper.title like '%' + @name + '%'
END

GO
ALTER AUTHORIZATION ON [dbo].[GetPapersByName] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetPatentById]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPatentById]
@id int
AS
BEGIN

IF (IS_ROLEMEMBER('administrator') = 1)
BEGIN
	SELECT 
		'patent' as Type,
		li.library_item_ID, 
		li.YearOfPublication, 
		pt.country, 
		pt.date_of_publication, 
		pt.date_of_submission, 
		pt.note, 
		pt.number_of_pages, 
		pt.reg_number, 
		pt.title,
		dbo.GetAuthorsForPatent(@id) as authors
	FROM LibraryItem li 
	INNER JOIN dbo.PatentAdminView pt 
	ON li.library_item_ID = pt.library_item_ID 
	WHERE li.library_item_ID = @id
END


IF (1 = IS_ROLEMEMBER('user') OR IS_ROLEMEMBER('librarian') = 1)
BEGIN
	SELECT
		'patent' as Type, 
		li.library_item_ID, 
		li.YearOfPublication, 
		pt.country, 
		pt.date_of_publication, 
		pt.date_of_submission, 
		pt.note, 
		pt.number_of_pages, 
		pt.reg_number, 
		pt.title,
		dbo.GetAuthorsForPatent(@id) as authors	
	FROM LibraryItem li 
	INNER JOIN dbo.PatentRegularView pt 
	ON li.library_item_ID = pt.library_item_ID 
	WHERE li.library_item_ID = @id
END



--SELECT author_ID FROM Patent_authors WHERE patent_ID = @id

END


GO
ALTER AUTHORIZATION ON [dbo].[GetPatentById] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetPatentById] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPatentById] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPatentById] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetPatentsByAuthor]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPatentsByAuthor]
@authorId int

AS
BEGIN


	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
					SELECT
 
							li.library_item_ID, 
							li.YearOfPublication, 
							pt.title, 
							pt.note, 
							pt.number_of_pages, 
							pt.country, 
							pt.date_of_publication, 
							pt.date_of_submission, 
							pt.reg_number, 
							--pa.author_Id,
							--auth.Firstname,
							--auth.Lastname
							dbo.GetAuthorsForPatent(li.library_item_ID) as authors
					FROM 
							LibraryItem li 
							INNER JOIN 
							PatentAdminView  pt 
							ON li.library_item_ID = pt.library_item_ID
							INNER JOIN
							Patent_authors pa
							ON pa.patent_ID = li.library_item_ID
							INNER JOIN
							dbo.Authors auth
							ON auth.Id = pa.author_ID
							WHERE pa.author_Id = @authorId	
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN

					SELECT
 
							li.library_item_ID, 
							li.YearOfPublication, 
							pt.title, 
							pt.note, 
							pt.number_of_pages, 
							pt.country, 
							pt.date_of_publication, 
							pt.date_of_submission, 
							pt.reg_number, 
							--pa.author_Id,
							--auth.Firstname,
							--auth.Lastname
							dbo.GetAuthorsForPatent(li.library_item_ID) as authors
					FROM 
							LibraryItem li 
							INNER JOIN 
							PatentRegularView  pt 
							ON li.library_item_ID = pt.library_item_ID
							INNER JOIN
							Patent_authors pa
							ON pa.patent_ID = li.library_item_ID
							INNER JOIN
							dbo.Authors auth
							ON auth.Id = pa.author_ID
							WHERE pa.author_Id = @authorId	
	END


END


GO
ALTER AUTHORIZATION ON [dbo].[GetPatentsByAuthor] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[GetPatentsByAuthor] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPatentsByAuthor] TO [librarian] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[GetPatentsByAuthor] TO [user] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[GetPublisherById]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPublisherById]
@id int
AS
BEGIN
	SELECT p.publisher_Id, p.publisherName
	FROM dbo.Publishers p
	WHERE p.publisher_Id = @id
END


GO
ALTER AUTHORIZATION ON [dbo].[GetPublisherById] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetPublishersByName]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPublishersByName]
@publisherName nvarchar(MAX)
AS
BEGIN
	SELECT p.publisher_Id, p.publisherName
	FROM dbo.Publishers p
	WHERE p.publisherName LIKE '%' + @publisherName + '%'
END


GO
ALTER AUTHORIZATION ON [dbo].[GetPublishersByName] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetRolesForUser]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRolesForUser]
@login nvarchar(255)
AS
BEGIN
	select role from Users where login = @login
END

GO
ALTER AUTHORIZATION ON [dbo].[GetRolesForUser] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[GetUserByLogin]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByLogin]
@login nvarchar(50)
AS
BEGIN
	SELECT login, role FROM Users WHERE login = @login
END

GO
ALTER AUTHORIZATION ON [dbo].[GetUserByLogin] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[IsUserInRole]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsUserInRole]

@login nvarchar(255),
@role nvarchar(255),
@isInRole bit output

AS
BEGIN

if exists(select * from Users where login = @login and role = @role)
begin
	SET @isInRole = 1
END

else
begin
	SET @isInRole = 0
end

END

GO
ALTER AUTHORIZATION ON [dbo].[IsUserInRole] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[LogChanges]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LogChanges]
@id int
AS
BEGIN
--Here we define the type of the deleted entry
	DECLARE @tempTable TABLE (type nvarchar(50), Id int)
	DECLARE 
	@type nvarchar(50),
	@description nvarchar(MAX),
	@yearOfPublication int

--Here we end our preliminary work

INSERT  INTO @tempTable EXEC GetAllIdAndType

--SELECT type, Id FROM @tempTable tt Where tt.Id  = @id

--SET @id = (SELECT library_item_ID FROM deleted)
--SET @type = (SELECT type From @tempTable Where id = @id)

		IF (IS_ROLEMEMBER('librarian') = 1 OR IS_ROLEMEMBER('administrator') = 1) 
			BEGIN
				SET @type = (SELECT type From @tempTable Where id = @id)
			END

if(@type = 'book')
BEGIN
	DECLARE
	@bookTitle nvarchar(300),
	@ISBN nvarchar(16)

		IF (IS_ROLEMEMBER('librarian') = 1 OR IS_ROLEMEMBER('administrator') = 1) 
			BEGIN
					SELECT 
					@yearOfPublication = li.YearOfPublication, 
					@bookTitle = b.title, 
					@ISBN = b.ISBN 
					FROM LibraryItem li 
					INNER JOIN Books b 
					ON li.library_item_ID = b.library_item_ID
					WHERE li.library_item_ID = @id


						IF (IS_ROLEMEMBER('librarian') = 1)
							BEGIN
								SET @description = 'Item' + @type + 'named' + @bookTitle + 'with ISBN' + @ISBN + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was softly deleted'

								INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
								UPDATE dbo.LibraryItem SET isDeleted = 1 WHERE LibraryItem.library_item_ID = @id
							END

						IF(IS_ROLEMEMBER('administrator') = 1)
							BEGIN
								SET @description = 'Item' + @type + 'named' + @bookTitle + 'with ISBN' + @ISBN + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was deleted permanently'

								INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
								DELETE FROM LibraryItem WHERE LibraryItem.library_item_ID = @id
							END
			END
END

IF(@type = 'paper')
BEGIN
	

	DECLARE
		@paperTitle nvarchar(300),
		@ISSN nvarchar(16),
		@paperIssueNumber int

		IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('administrator') = 1) 
			BEGIN
					SELECT 
						@yearOfPublication = li.YearOfPublication, 
						@paperTitle = p.title, 
						@ISSN = p.ISSN,
						@paperIssueNumber = pi.number_of_issue
					FROM LibraryItem li 
					INNER JOIN PaperIssues pi 
					ON li.library_item_ID = pi.library_item_ID
					INNER JOIN Paper p
					ON pi.paperId = p.id
					WHERE li.library_item_ID = @id


						IF (IS_ROLEMEMBER('librarian') = 1)
							BEGIN
								SET @description = 'Item' + @type + 'named' + @paperTitle + 'with ISSN' + @ISSN + 'published in' + CAST(@yearOfPublication as nvarchar) +  'and #' + @paperIssueNumber +  'was softly deleted'

								INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
								UPDATE dbo.LibraryItem SET isDeleted = 1 WHERE LibraryItem.library_item_ID = @id
							END

						IF(IS_ROLEMEMBER('administrator') = 1)
							BEGIN
								SET @description = 'Item' + @type + 'named' + @paperTitle + 'with ISSN' + @ISSN + 'published in' + CAST(@yearOfPublication as nvarchar) +  'and #' + @paperIssueNumber +  'was deleted permanently'

								INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
								DELETE FROM LibraryItem WHERE LibraryItem.library_item_ID = @id
							END
			END
END

if(@type = 'patent')
BEGIN

	DECLARE 
	@country nvarchar(200),
	@regNumber int,
	@title nvarchar(300)

	IF (IS_ROLEMEMBER('librarian') = 1 OR IS_ROLEMEMBER('administrator') = 1) 
		BEGIN

			SELECT 
				@country = pt.country,
				@regNumber = pt.reg_number,
				@title = pt.title,
				@yearOfPublication = li.YearOfPublication 
			FROM LibraryItem li 
			INNER JOIN Patents pt 
			ON li.library_item_ID = pt.library_item_ID 
			WHERE li.library_item_ID = @id




			IF (IS_ROLEMEMBER('librarian') = 1)

			BEGIN
				SET @description = 'Item' + @type + 'named' + @title + 'from' + @country + 'with reg number' + CAST(@regNumber as nvarchar) + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was softly deleted'
				INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
				UPDATE dbo.LibraryItem SET isDeleted = 1 WHERE LibraryItem.library_item_ID = @Id
			END

			IF(IS_ROLEMEMBER('administrator') = 1)
			BEGIN
				SET @description = 'Item' + @type + 'named' + @title + 'from' + @country + 'with reg number' + CAST(@regNumber as nvarchar) + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was deleted permanently'
				INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
				DELETE FROM LibraryItem WHERE LibraryItem.library_item_ID = @id
			END
		END
END

END


GO
ALTER AUTHORIZATION ON [dbo].[LogChanges] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[LogChanges] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[LogChanges] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[PaperCount]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PaperCount]
	@Count int OUTPUT,
	@publisherID int,
	@dateOfIssue date,
	@title nvarchar(MAX)
AS
BEGIN


	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
			SET @Count = 
			(SELECT COUNT(*) FROM 
				PaperIssueAdminView PaperIssues 
			INNER JOIN 
				Publishers 
			ON 
				PaperIssues.publisher_Id = Publishers.publisher_Id
				INNER JOIN Paper
				ON PaperIssues.paperId = Paper.id 
			WHERE
				PaperIssues.dateOfIssue = @dateOfIssue AND Publishers.publisher_Id = @publisherId AND Paper.title = @title)
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
			SET @Count = 
			(SELECT COUNT(*) FROM 
				PaperIssueRegularView PaperIssues 
			INNER JOIN 
				Publishers 
			ON 
				PaperIssues.publisher_Id = Publishers.publisher_Id
				INNER JOIN Paper
				ON PaperIssues.paperId = Paper.id 
			WHERE
				PaperIssues.dateOfIssue = @dateOfIssue AND Publishers.publisher_Id = @publisherId AND Paper.title = @title)
	END



END


GO
ALTER AUTHORIZATION ON [dbo].[PaperCount] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[PaperCount] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[PaperCount] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[PaperIssueExists]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PaperIssueExists]
	@Exists int OUTPUT,
	@publisherID int,
	@dateOfIssue date,
	@title nvarchar(MAX)
AS
BEGIN





	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
				IF EXISTS (
				SELECT library_item_ID FROM 
				PaperIssueAdminView PaperIssues 
				INNER JOIN 
				Publishers 
				ON 
				PaperIssues.publisher_Id = Publishers.publisher_Id
				INNER JOIN Paper
				ON PaperIssues.paperId = Paper.id 
				WHERE
				PaperIssues.dateOfIssue = @dateOfIssue AND Publishers.publisher_Id = @publisherId AND Paper.title = @title
				)
				BEGIN
					SET @Exists = 1
				END
				 
				ELSE
				
				BEGIN
					SET @Exists = 0
				END
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
				IF EXISTS (
				SELECT library_item_ID FROM 
					PaperIssueRegularView PaperIssues 
				INNER JOIN 
					Publishers 
				ON 
					PaperIssues.publisher_Id = Publishers.publisher_Id
					INNER JOIN Paper
					ON PaperIssues.paperId = Paper.id 
				WHERE
					PaperIssues.dateOfIssue = @dateOfIssue AND Publishers.publisher_Id = @publisherId AND Paper.title = @title
				)
				BEGIN
					SET @Exists = 1
				END
				 
				ELSE
				
				BEGIN
					SET @Exists = 0
				END	
	END








END


GO
ALTER AUTHORIZATION ON [dbo].[PaperIssueExists] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[PaperIssueExists] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[PaperIssueExists] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[PatentCount]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PatentCount]
@Count int OUTPUT,
@Country nvarchar(MAX), 
@Regnumber int

AS
BEGIN




	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
		SET @Count = (SELECT COUNT (*) FROM PatentAdminView WHERE country = @Country AND reg_number = @Regnumber)
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
		SET @Count = (SELECT COUNT (*) FROM PatentRegularView WHERE country = @Country AND reg_number = @Regnumber)
	END







END


GO
ALTER AUTHORIZATION ON [dbo].[PatentCount] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[PatentCount] TO [administrator] AS [dbo]
GO
GRANT EXECUTE ON [dbo].[PatentCount] TO [librarian] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[PatentExists]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatentExists]
@Exists int OUTPUT,
@Country nvarchar(MAX), 
@Regnumber int

AS
BEGIN




	IF (IS_ROLEMEMBER('administrator') = 1)
	BEGIN
		 IF EXISTS (SELECT COUNT (*) FROM PatentAdminView WHERE country = @Country AND reg_number = @Regnumber)
 
		 BEGIN
			SET @EXISTS = 1
		 END
		 ELSE
		 BEGIN
			SET @EXISTS = 0
		 END
	END

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('user') = 1)
	BEGIN
		 IF EXISTS (SELECT COUNT (*) FROM PatentRegularView WHERE country = @Country AND reg_number = @Regnumber)
 
		 BEGIN
			SET @EXISTS = 1
		 END
		 ELSE
		 BEGIN
			SET @EXISTS = 0
		 END
	END












END


GO
ALTER AUTHORIZATION ON [dbo].[PatentExists] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdateAuthor]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAuthor]
@id int,
@firstName nvarchar(50),
@lastName nvarchar(200)

AS
BEGIN
	UPDATE Authors SET Firstname = @firstName, Lastname = @lastName WHERE Id = @id   
END


GO
ALTER AUTHORIZATION ON [dbo].[UpdateAuthor] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBook]
	@bookId int,
	@authors nvarchar(max),
	@yearOfPublishing int,
	@title nvarchar(300), 
	@cityOfPublishing nvarchar(200),
	@publisher_ID int,
	@numberOfPages int,
	@note nvarchar(2000),
	@ISBN nvarchar(18)
	


AS
BEGIN

		
		UPDATE LibraryItem SET YearOfPublication = @yearOfPublishing WHERE library_item_ID = @bookId

		UPDATE Books 
		SET
			title = @title, 
			city_of_publishing = @cityOfPublishing, 
			publisher_Id = @publisher_ID, 
			number_of_pages = @numberOfPages, 
			note = @note, 
			ISBN = @ISBN
		WHERE library_item_ID = @bookId

		EXECUTE dbo.UpdateBookAuthorRelations @bookId, @authors

END

GO
ALTER AUTHORIZATION ON [dbo].[UpdateBook] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdateBookAuthorRelations]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBookAuthorRelations]
@bookID int,
@authors nvarchar(MAX)
AS
BEGIN
		DELETE FROM Book_authors WHERE book_item_ID = @bookID

		INSERT INTO [Book_authors](author_Id, book_item_ID)
		SELECT *, @bookID as 'book_item_ID' FROM string_split(@authors, ',')
END

GO
ALTER AUTHORIZATION ON [dbo].[UpdateBookAuthorRelations] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdatePaper]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePaper]
	@id int,
	@title nvarchar(MAX),
	@ISSN nvarchar(MAX)
AS
BEGIN
	UPDATE Paper SET title = @title, ISSN = @ISSN WHERE id = @id
END

GO
ALTER AUTHORIZATION ON [dbo].[UpdatePaper] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdatePaperIssue]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePaperIssue]
@id int,
@paperId int,
@cityOfPublication nvarchar(200),
@publisherId int,
@numberOfPages int,
@note nvarchar(2000),
@number_of_issue int,
@yearOfPublishing int,
@dateOfIssue date

	
AS
BEGIN

		UPDATE LibraryItem SET YearOfPublication = @yearOfPublishing WHERE library_item_ID = @id

		UPDATE PaperIssues 
		SET
			paperId = @paperId, 
			cityOfPublication = @cityOfPublication, 
			publisher_Id = @publisherId, 
			number_of_pages = @numberOfPages, 
			note = @note, 
			number_of_issue = @number_of_issue, 
			dateOfIssue = @dateOfIssue
		WHERE
			library_item_ID = @id

		
END


GO
ALTER AUTHORIZATION ON [dbo].[UpdatePaperIssue] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdatePatent]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePatent]
	@authors nvarchar(MAX),
	@id int,
	@title nvarchar(300),
	@country nvarchar(200),
	@regnumber nvarchar(9),
	@date_of_submission datetime,
	@date_of_publication datetime, 
	@number_of_pages int,
	@note nvarchar(2000),
	@yearOfPublication int
AS
BEGIN



		UPDATE LibraryItem SET YearOfPublication = @yearOfPublication WHERE library_item_ID = @id

		UPDATE Patents 
		SET 
		title = @title, 
		country = @country, 
		reg_number = @regnumber, 
		date_of_submission = @date_of_submission, 
		date_of_publication = @date_of_publication, 
		number_of_pages = @number_of_pages, 
		note = @note
		WHERE library_item_ID = @id 


		EXEC UpdatePatentAuthorRelations @id, @authors
END

GO
ALTER AUTHORIZATION ON [dbo].[UpdatePatent] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdatePatentAuthorRelations]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePatentAuthorRelations]
@patentId int,
@authors nvarchar(MAX)
AS
BEGIN
		DELETE FROM Patent_authors WHERE patent_ID = @patentId

		INSERT INTO [Patent_authors](author_Id, patent_ID)
		SELECT *, @patentId as 'patent_ID' FROM string_split(@authors, ',')
END

GO
ALTER AUTHORIZATION ON [dbo].[UpdatePatentAuthorRelations] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UpdatePublisher]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePublisher]
	@id int,
	@PublisherName nvarchar(300)
AS
BEGIN
	UPDATE Publishers SET publisherName = @PublisherName WHERE publisher_Id = @id
END


GO
ALTER AUTHORIZATION ON [dbo].[UpdatePublisher] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[UserExists]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserExists]
@exists bit output,
@login nvarchar(255)
AS
BEGIN
	if exists(
		SELECT * from Users where login = @login
	)
	BEGIN 
	 SET @exists = 1
	END
	ELSE
	BEGIN
		set @exists = 0
	END
END

GO
ALTER AUTHORIZATION ON [dbo].[UserExists] TO  SCHEMA OWNER 
GO
/****** Object:  Trigger [dbo].[LogBookInsert]    Script Date: 10/20/2016 12:13:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[LogBookInsert]
   ON  [dbo].[Books]
   AFTER INSERT
AS 
BEGIN

	DECLARE 
	@id int,
	@type nvarchar(50),
	@description nvarchar(MAX),
	@yearOfPublication int,
	@bookTitle nvarchar(300),
	@ISBN nvarchar(16)


			IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('administrator') = 1) 
			BEGIN

					SET @id = (Select library_item_ID FROM inserted)
					SET @type = 'book'

					SELECT 
					@yearOfPublication = li.YearOfPublication, 
					@bookTitle = b.title, 
					@ISBN = b.ISBN 
					FROM LibraryItem li 
					INNER JOIN Books b 
					ON li.library_item_ID = b.library_item_ID
					WHERE li.library_item_ID = @id


								SET @description = 'Item' + @type + 'named' + @bookTitle + 'with ISBN' + COALESCE(@ISBN, '') + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was inserted.'

								INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)

			END


END


GO
ALTER TABLE [dbo].[Books] ENABLE TRIGGER [LogBookInsert]
GO
/****** Object:  Trigger [dbo].[LogBookUpdate]    Script Date: 10/20/2016 12:13:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[LogBookUpdate]
   ON  [dbo].[Books]
   AFTER UPDATE
AS 
BEGIN

	DECLARE 
	@id int,
	@type nvarchar(50),
	@description nvarchar(MAX),
	@yearOfPublication int,
	@bookTitle nvarchar(300),
	@ISBN nvarchar(16)


			IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('administrator') = 1) 
			BEGIN

					SET @id = (Select library_item_ID FROM inserted)
					SET @type = 'book'

					SELECT 
					@yearOfPublication = li.YearOfPublication, 
					@bookTitle = b.title, 
					@ISBN = b.ISBN 
					FROM LibraryItem li 
					INNER JOIN Books b 
					ON li.library_item_ID = b.library_item_ID
					WHERE li.library_item_ID = @id


								SET @description = 'Item' + @type + 'named' + @bookTitle + 'with ISBN' + @ISBN + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was modified.'

								INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)

			END


END


GO
ALTER TABLE [dbo].[Books] ENABLE TRIGGER [LogBookUpdate]
GO
/****** Object:  Trigger [dbo].[SafeItemDelete]    Script Date: 10/20/2016 12:13:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[SafeItemDelete]
ON	[dbo].[LibraryItem]
INSTEAD OF DELETE
AS

BEGIN


IF IS_ROLEMEMBER('administrator') = 1 OR IS_ROLEMEMBER('db_owner') = 1 OR IS_ROLEMEMBER('librarian') = 1 
		BEGIN


			INSERT INTO [Log](itemType, itemId, [description])
			SELECT 
					CASE
						WHEN b.library_item_ID IS NOT NULL THEN 'Book'
						WHEN p.library_item_ID IS NOT NULL THEN 'Patent'
						WHEN ps.library_item_ID IS NOT NULL THEN 'Issue'
					END as ItemType,
					d.library_item_ID,
					CASE
						WHEN b.library_item_ID IS NOT NULL THEN 'Book with title '+ b.title + ' was deleted' + 
							CASE WHEN IS_ROLEMEMBER('librarian') = 1 THEN ' softly.'
								 ELSE ' permanently.'
							END
						WHEN p.library_item_ID IS NOT NULL THEN 'Patent with title ' + p.title + ' was deleted ' + 
							CASE WHEN IS_ROLEMEMBER('librarian') = 1 THEN ' softly.'
								 ELSE ' permanently.'
							END
						WHEN ps.library_item_ID IS NOT NULL THEN 'Issue with title ' + (SELECT Paper.title  FROM Paper INNER JOIN PaperIssues ON Paper.id = PaperIssues.paperId WHERE PaperIssues.library_item_ID = ps.library_item_ID) + ' was deleted ' +
							CASE WHEN IS_ROLEMEMBER('librarian') = 1 THEN ' softly.'
								 ELSE ' permanently.'
							END

					
					END
			FROM 
					deleted d 
					LEFT JOIN
					Books b
					ON b.library_item_ID = d.library_item_ID
					LEFT JOIN
					Patents p
					ON p.library_item_ID = d.library_item_ID
					LEFT JOIN
					PaperIssues ps
					ON ps.library_item_ID = d.library_item_ID


		END






		IF IS_ROLEMEMBER('administrator') = 1 OR IS_ROLEMEMBER('db_owner')  = 1
		BEGIN
			DELETE LibraryItem
			WHERE library_item_ID IN (SELECT library_item_ID FROM DELETED)
		END
		IF IS_ROLEMEMBER('librarian') = 1
		BEGIN
			UPDATE LibraryItem
			SET isDeleted = 1
			WHERE library_item_ID in (SELECT library_item_ID FROM DELETED)
		END
END

GO
ALTER TABLE [dbo].[LibraryItem] ENABLE TRIGGER [SafeItemDelete]
GO
/****** Object:  Trigger [dbo].[LogPaperIssueInsert]    Script Date: 10/20/2016 12:13:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[LogPaperIssueInsert]
ON	[dbo].[PaperIssues]
AFTER INSERT
AS 
BEGIN
		DECLARE
		@paperTitle nvarchar(300),
		@ISSN nvarchar(16),
		@paperIssueNumber int,
		@yearOfPublication int,
		@id int,
		@type nvarchar(50),
		@description nvarchar(MAX)
	


			IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('administrator') = 1) 
			BEGIN

						SET @Id = (Select library_item_ID FROM inserted)
						SET @type = 'paper'

					SELECT 
						@yearOfPublication = li.YearOfPublication, 
						@paperTitle = p.title, 
						@ISSN = p.ISSN,
						@paperIssueNumber = pi.number_of_issue
						FROM LibraryItem li 
						INNER JOIN PaperIssues pi 
						ON li.library_item_ID = pi.library_item_ID
						INNER JOIN Paper p
						ON pi.paperId = p.id
						WHERE li.library_item_ID = @id



					SET @description = ' Item ' + @type + ' named ' + @paperTitle + ' with ISSN ' + COALESCE(@ISSN, 'empty' ) + ' published in ' + CAST(@yearOfPublication as nvarchar) +  ' and # ' + CAST(@paperIssueNumber as nvarchar) +  ' was inserted.'

					INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
			END

END


GO
ALTER TABLE [dbo].[PaperIssues] ENABLE TRIGGER [LogPaperIssueInsert]
GO
/****** Object:  Trigger [dbo].[LogPaperIssueUpdate]    Script Date: 10/20/2016 12:13:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[LogPaperIssueUpdate]
ON	[dbo].[PaperIssues]
AFTER UPDATE
AS 
BEGIN
		DECLARE
		@paperTitle nvarchar(300),
		@ISSN nvarchar(16),
		@paperIssueNumber int,
		@yearOfPublication int,
		@id int,
		@type nvarchar(50),
		@description nvarchar(MAX)
	


			IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('administrator') = 1) 
			BEGIN

						SET @Id = (Select library_item_ID FROM inserted)
						SET @type = 'paper'

					SELECT 
						@yearOfPublication = li.YearOfPublication, 
						@paperTitle = p.title, 
						@ISSN = p.ISSN,
						@paperIssueNumber = pi.number_of_issue
					FROM LibraryItem li 
					INNER JOIN PaperIssues pi 
					ON li.library_item_ID = pi.library_item_ID
					INNER JOIN Paper p
					ON pi.paperId = p.id
					WHERE li.library_item_ID = @id



					SET @description = 'Item' + @type + 'named' + @paperTitle + 'with ISSN' + @ISSN + 'published in' + CAST(@yearOfPublication as nvarchar) +  'and #' + @paperIssueNumber +  'modified'

					INSERT INTO dbo.Log (itemType, itemId, [description]) VALUES (@type, @id, @description)
			END

END


GO
ALTER TABLE [dbo].[PaperIssues] ENABLE TRIGGER [LogPaperIssueUpdate]
GO
/****** Object:  Trigger [dbo].[LogPatentInsert]    Script Date: 10/20/2016 12:13:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER	[dbo].[LogPatentInsert]
ON	[dbo].[Patents]
AFTER INSERT
AS
BEGIN

	DECLARE 
	@description nvarchar(MAX),
	@itemType nvarchar(50), 
	@itemId int, 
	@country nvarchar(200),
	@regNumber int,
	@title nvarchar(300),
	@yearOfPublication int,
	@Id int

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('administrator') = 1) 
		BEGIN
			SET @Id = (Select library_item_ID FROM inserted)
			SET @itemType = 'patent'

			SELECT 
				@itemId = li.library_item_ID, 
				@country = pt.country,
				@regNumber = pt.reg_number,
				@title = pt.title,
				@yearOfPublication = li.YearOfPublication 
			FROM LibraryItem li 
			INNER JOIN Patents pt 
			ON li.library_item_ID = pt.library_item_ID 
			WHERE li.library_item_ID = @id


			SET @description = 'Item' + @itemType + 'named' + @title + 'from' + @country + 'with reg number' + CAST(@regNumber as nvarchar) + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was updated'

			INSERT INTO dbo.Log (itemType, itemId, description) VALUES (@itemType, @itemId, @description)
		END
END


GO
ALTER TABLE [dbo].[Patents] ENABLE TRIGGER [LogPatentInsert]
GO
/****** Object:  Trigger [dbo].[LogPatentUpdate]    Script Date: 10/20/2016 12:13:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [dbo].[SafePatentUpdate]    Script Date: 8/3/2016 11:43:02 PM ******/
CREATE TRIGGER	[dbo].[LogPatentUpdate]
ON	[dbo].[Patents]
AFTER UPDATE
AS
BEGIN

	DECLARE 
	@description nvarchar(MAX),
	@itemType nvarchar(50), 
	@itemId int, 
	@country nvarchar(200),
	@regNumber int,
	@title nvarchar(300),
	@yearOfPublication int,
	@Id int

	IF (1 = IS_ROLEMEMBER('librarian') OR IS_ROLEMEMBER('administrator') = 1) 
		BEGIN
			SET @Id = (Select library_item_ID FROM inserted)
			SET @itemType = 'patent'

			SELECT 
				@itemId = li.library_item_ID, 
				@country = pt.country,
				@regNumber = pt.reg_number,
				@title = pt.title,
				@yearOfPublication = li.YearOfPublication 
			FROM LibraryItem li 
			INNER JOIN Patents pt 
			ON li.library_item_ID = pt.library_item_ID 
			WHERE li.library_item_ID = @id


			SET @description = 'Item' + @itemType + 'named' + @title + 'from' + @country + 'with reg number' + CAST(@regNumber as nvarchar) + 'published in' + CAST(@yearOfPublication as nvarchar) + 'was updated'

			INSERT INTO dbo.Log (itemType, itemId, description) VALUES (@itemType, @itemId, @description)
		END
END


GO
ALTER TABLE [dbo].[Patents] ENABLE TRIGGER [LogPatentUpdate]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LibraryItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Books"
            Begin Extent = 
               Top = 6
               Left = 261
               Bottom = 136
               Right = 446
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BookAdminView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BookAdminView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LibraryItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Books"
            Begin Extent = 
               Top = 5
               Left = 352
               Bottom = 230
               Right = 557
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BookRegularView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BookRegularView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PaperIssues"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LibraryItem"
            Begin Extent = 
               Top = 6
               Left = 259
               Bottom = 119
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PaperIssueAdminView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PaperIssueAdminView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PaperIssues"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 221
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LibraryItem"
            Begin Extent = 
               Top = 6
               Left = 259
               Bottom = 119
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PaperIssueRegularView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PaperIssueRegularView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LibraryItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patents"
            Begin Extent = 
               Top = 6
               Left = 261
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PatentAdminView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PatentAdminView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LibraryItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patents"
            Begin Extent = 
               Top = 6
               Left = 261
               Bottom = 224
               Right = 520
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PatentRegularView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PatentRegularView'
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
