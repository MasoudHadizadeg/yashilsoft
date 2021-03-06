/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [YashilDb]    Script Date: 02/11/1398 10:25:52 ق.ظ ******/
CREATE DATABASE [YashilDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YashilDashnoardDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\YashilDashnoardDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'YashilDashnoardDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\YashilDashnoardDb_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [YashilDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YashilDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YashilDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YashilDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YashilDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YashilDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YashilDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [YashilDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YashilDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YashilDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YashilDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YashilDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YashilDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YashilDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YashilDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YashilDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YashilDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YashilDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YashilDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YashilDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YashilDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YashilDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YashilDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YashilDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YashilDb] SET RECOVERY FULL 
GO
ALTER DATABASE [YashilDb] SET  MULTI_USER 
GO
ALTER DATABASE [YashilDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YashilDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YashilDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YashilDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [YashilDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'YashilDb', N'ON'
GO
ALTER DATABASE [YashilDb] SET QUERY_STORE = OFF
GO
USE [YashilDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [YashilDb]
GO
/****** Object:  Schema [base]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
CREATE SCHEMA [base]
GO
/****** Object:  Schema [dash]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
CREATE SCHEMA [dash]
GO
/****** Object:  Schema [rpt]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
CREATE SCHEMA [rpt]
GO
/****** Object:  Schema [um]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
CREATE SCHEMA [um]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateToShamsiDatePart]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_DateToShamsiDatePart] (@MiDate DateTime , @ADatePart char) returns int

AS

begin

  Declare @TmpY int, @Leap int

  Declare @Sh_Y int , @Sh_M int , @Sh_D int, @Result int

  if @MiDate is null 

    return 0

  --Declare @Result int

  Set @Result = convert(int, convert(float,@MiDate))

  if @Result <= 78

  begin

    Set @Sh_Y = 1278

    Set @Sh_M = (@Result + 10) / 30 + 10 

    Set @Sh_D = (@Result + 10) % 30 + 1

  end 

  else

  begin

    Set @Result = @Result - 78

    Set @Sh_Y = 1279

    while 1 = 1 

    begin

      Set @TmpY = @Sh_Y + 11

      Set @TmpY = @TmpY - ( @TmpY / 33) * 33

      if  (@TmpY <> 32) and ( (@TmpY / 4) * 4 = @TmpY )

        Set @Leap = 1

      else

        Set @Leap = 0

      if @Result <= (365+@Leap)

        break

      Set @Result = @Result -  (365+@Leap)

      Set @Sh_Y = @Sh_Y + 1

    end

    if @Result <= 31*6

    begin

      Set @Sh_M = (@Result-1) / 31 + 1

      Set @Sh_D = (@Result-1) % 31 + 1

    end

    else

    begin

      Set @Sh_M = ((@Result-1) - 31*6) / 30 + 7

      Set @Sh_D = ((@Result-1) - 31*6) % 30 + 1

    end

  end

  return

    case @ADatePart

      when 'Y' then  @Sh_Y

      when 'M' then @Sh_M

      when 'D' then @Sh_D

    else  0

    end

end






GO
/****** Object:  UserDefinedFunction [dbo].[getColDesc]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[getColDesc]
(
	@major_id     INT,
	@minor_id     INT
)
RETURNS sql_variant
AS
BEGIN
	DECLARE @res  sql_variant
	SELECT @res = sep.value
	FROM   sys.extended_properties sep
	WHERE  sep.major_id = @major_id
	       AND sep.minor_id = @minor_id
	       AND NAME = 'MS_Description'
	
	return @res
END
GO
/****** Object:  UserDefinedFunction [dbo].[getTableDesc]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[getTableDesc]
(
	@major_id     INT
)
RETURNS sql_variant
AS
BEGIN
	DECLARE @res  sql_variant
	SELECT @res = sep.value
	FROM   sys.extended_properties sep
	WHERE  sep.major_id = @major_id
	       AND sep.minor_id =0
	       AND NAME = 'MS_Description'
	
	return @res
END
GO
/****** Object:  UserDefinedFunction [dbo].[getTableTitleColumn]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[getTableTitleColumn]
(
	@objectId INT
)
RETURNS SQL_VARIANT
AS
BEGIN
	DECLARE @res SQL_VARIANT
	SELECT TOP(1) @res = c.NAME
	FROM   sys.[columns] AS c
	WHERE  c.[object_id] = @objectId
	       AND (c.NAME LIKE '%Title%' OR c.name LIKE '%Name%')
	ORDER BY c.name DESC
	
	RETURN @res 
END
GO
/****** Object:  UserDefinedFunction [dbo].[ShamsiToGregorian]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[ShamsiToGregorian](@DateStr varchar(10))
RETURNS DATE
 --WITH ENCRYPTION
AS  
  
	BEGIN 
   declare @YYear int
   declare @MMonth int
   declare @DDay int
   declare @epbase int
   declare @epyear int
   declare @mdays int
   declare @persian_jdn int
   declare @i int
   declare @j int
   declare @l int
   declare @n int
   declare @TMPRESULT varchar(10)
   declare @IsValideDate int
   declare @TempStr varchar(20)
   DECLARE @TmpDateStr varchar(10)

   SET @i=charindex('/',@DateStr)

   IF LEN(@DateStr) - CHARINDEX('/', @DateStr,CHARINDEX('/', @DateStr,1)+1) = 4
   BEGIN
   --  SET @TmpDateStr = dbo.ReversDate(@DateStr)
     IF ( ISDATE(@TmpDateStr) =1 )  
       RETURN @TmpDateStr
     ELSE
        RETURN NULL
   END
   ELSE
     SET @TmpDateStr = @DateStr

   IF ((@i<>0) and
     --  (dbo.SubStrCount('/', @TmpDateStr)=2) and
        (ISNUMERIC(REPLACE(@TmpDateStr,'/',''))=1) and 
        (charindex('.',@TmpDateStr)=0)
       )
   BEGIN
       SET @YYear=CAST(SUBSTRING(@TmpDateStr,1,@i-1) AS INT)
                IF ( @YYear< 1300 )
                      SET @YYear =@YYear + 1300
                IF @YYear > 9999
                  RETURN NULL
    
       SET @TempStr= SUBSTRING(@TmpDateStr,@i+1,Len(@TmpDateStr))
    
       SET @i=charindex('/',@TempStr)
       SET @MMonth=CAST(SUBSTRING(@TempStr,1,@i-1) AS INT)
       SET @MMonth=@MMonth-- -1
       
       SET @TempStr= SUBSTRING(@TempStr,@i+1,Len(@TempStr))   
    
       SET @DDay=CAST(@TempStr AS INT)
       SET @DDay=@DDay-- - 1
           
                 IF ( @YYear >= 0 )
                     SET @epbase = @YYear - 474
                 Else
                     SET @epbase = @YYear - 473
                 SET @epyear = 474 + (@epbase % 2820)

        IF (@MMonth <= 7 )
                       SET @mdays = ((@MMonth) - 1) * 31
        Else
            SET @mdays = ((@MMonth) - 1) * 30 + 6

        SET @persian_jdn =(@DDay)  + @mdays + CAST((((@epyear * 682) - 110) / 2816) as int)  + (@epyear - 1) * 365  +  CAST((@epbase / 2820)  as int ) * 1029983  + (1948321 - 1)

        IF (@persian_jdn > 2299160) 
                 BEGIN
            SET @l = @persian_jdn + 68569
            SET @n = CAST(((4 * @l) / 146097) as int)
            SET @l = @l -  CAST(((146097 * @n + 3) / 4) as int)
            SET @i =  CAST(((4000 * (@l + 1)) / 1461001) as int)
            SET @l = @l - CAST( ((1461 * @i) / 4) as int) + 31
            SET @j =  CAST(((80 * @l) / 2447) as int)
            SET @DDay = @l - CAST( ((2447 * @j) / 80) as int)
             SET @l =  CAST((@j / 11) as int)
            SET @MMonth = @j + 2 - 12 * @l
            SET @YYear = 100 * (@n - 49) + @i + @l
                 END

           SET @TMPRESULT=Cast(@MMonth as varchar(2))+'/'+CAST(@DDay as Varchar(2))+'/'+CAST(@YYear as varchar(4))  
           RETURN Cast(@TMPRESULT as varchar(10))

    END
    RETURN NULL      

END



GO
/****** Object:  UserDefinedFunction [dbo].[ToPersianDate]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ToPersianDate]
(
	@ChirsDate DATETIME
)
RETURNS NVarCHAR(10)
AS


BEGIN
	IF (@ChirsDate IS NULL)
	    RETURN '';
	DECLARE @SolarDate CHAR(10)
	
	DECLARE @Day CHAR(2)
	
	DECLARE @Mon CHAR(2)
	
	DECLARE @SDay INT
	
	DECLARE @SMon INT
	
	DECLARE @SYear INT
	
	SET @SYear = dbo.fn_DateToShamsiDatePart(@ChirsDate, 'Y')
	
	SET @SMon = dbo.fn_DateToShamsiDatePart(@ChirsDate, 'M')
	
	SET @SDay = dbo.fn_DateToShamsiDatePart(@ChirsDate, 'D')
	
	
	IF @SMon <= 9
	    SELECT @Mon = '0' + CONVERT(CHAR(1), @SMon)
	ELSE
	    SELECT @Mon = CONVERT(CHAR(2), @SMon)
	
	IF @SDay <= 9
	    SELECT @Day = '0' + CONVERT(CHAR(1), @SDay)
	ELSE
	    SELECT @Day = CONVERT(CHAR(2), @SDay)
	
	SELECT @SolarDate = SUBSTRING(CONVERT(CHAR(4), @SYear), 3, 2) + '/' + @Mon + '/' + @Day
	
	RETURN @SolarDate
END






GO
/****** Object:  Table [base].[AccessLevel]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [base].[AccessLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[LevelValue] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_AccessLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[YashilConnectionString]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [base].[YashilConnectionString](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[DataProviderId] [int] NOT NULL,
	[ConnectionString] [varchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[ApplicationId] [int] NULL,
	[AccessLevelId] [int] NOT NULL,
 CONSTRAINT [PK_YashilConnectionString] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[YashilDataProvider]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [base].[YashilDataProvider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[BaseType] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[ApplicationId] [int] NULL,
 CONSTRAINT [PK_YashilDataProvider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dash].[DashboardConnectionString]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[DashboardConnectionString](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DashboardId] [int] NOT NULL,
	[ConnectionStringId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DashboardConnectionString] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dash].[DashboardGroup]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[DashboardGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DashboardGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dash].[DashboardGroupDashboard]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[DashboardGroupDashboard](
	[Id] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[DashboardStoreId] [int] NOT NULL,
	[DashboardGroupId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DashboardGroupDashboard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dash].[DashboardStore]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[DashboardStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DashboardFile] [varbinary](max) NULL,
	[CssClass] [varchar](50) NULL,
	[Picture] [varchar](max) NULL,
	[Color] [varchar](50) NULL,
	[Animation] [bit] NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Dashboard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dash].[RoleDashboard]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[RoleDashboard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[DashboardId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_RoleDashboard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dash].[UserDashboard]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[UserDashboard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DashboardId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserDashboard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schemas]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schemas](
	[Name] [sysname] NOT NULL,
	[Title] [varchar](1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableDesc]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableDesc](
	[TableName] [sysname] NOT NULL,
	[object_id] [int] NOT NULL,
	[TitleColumn] [sysname] NULL,
	[IsLargTable] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [rpt].[ReportConnectionString]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[ReportConnectionString](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[ConnectionStringId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[ApplicationId] [int] NULL,
 CONSTRAINT [PK_ReportConnectionString] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rpt].[ReportGroup]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[ReportGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ReportGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [rpt].[ReportGroupReport]    Script Date: 02/11/1398 10:25:53 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[ReportGroupReport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ReportStoreId] [int] NOT NULL,
	[ReportGroupId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ReportGroupReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rpt].[ReportStore]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[ReportStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[ReportFile] [varbinary](max) NULL,
	[CssClass] [varchar](50) NULL,
	[Picture] [varchar](max) NULL,
	[Color] [varchar](50) NULL,
	[Animation] [bit] NULL,
	[Description] [nvarchar](max) NULL,
	[ReportKey] [varchar](300) NULL,
	[DesignString] [nvarchar](max) NULL,
	[ModuleKey] [varchar](300) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ReportStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [rpt].[RoleReport]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[RoleReport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ReportId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_RoleReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rpt].[UserReport]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[UserReport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ReportId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [um].[AppAction]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[AppAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SystemAction] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[AppConfig]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[AppConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KeyTitle] [nvarchar](150) NOT NULL,
	[Value] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_AppConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[Application]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[Application](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[Url] [nchar](10) NULL,
	[SecretKey] [varbinary](max) NULL,
	[AdditionalInfo] [xml] NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[Menu]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](300) NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Icon] [varchar](100) NULL,
	[Class] [varchar](100) NULL,
	[Badge] [varchar](100) NULL,
	[BadgeClass] [varchar](100) NULL,
	[IsExternalLink] [bit] NULL,
	[ParentId] [int] NULL,
	[ResourceId] [int] NULL,
	[IsVirtual] [bit] NOT NULL,
	[OrderNo] [int] NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Menue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [um].[Organization]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[ParentId] [int] NULL,
	[UniqueId] [bigint] NULL,
	[CodePath] [nvarchar](max) NULL,
	[Type] [int] NULL,
	[ProvinceId] [int] NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[Resource]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[Resource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](300) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Type] [int] NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[ResourceAppAction]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[ResourceAppAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppActionId] [int] NOT NULL,
	[ResourceId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ResourceAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [um].[Role]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[RoleResourceAction]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[RoleResourceAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceActionId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_RoleResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [um].[User]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[LastName] [nchar](10) NOT NULL,
	[NationalCode] [varchar](20) NULL,
	[Email] [nvarchar](300) NULL,
	[Password] [varbinary](200) NULL,
	[IsActive] [bit] NOT NULL,
	[MobileNumber] [int] NULL,
	[OrganizationId] [int] NULL,
	[PasswordSalt] [varbinary](200) NULL,
	[Address] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[UserRole]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [base].[AccessLevel] ON 

INSERT [base].[AccessLevel] ([Id], [Title], [LevelValue], [Description], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1, N'عادی', 1, NULL, 7, 7, CAST(N'2019-11-21T12:38:45.420' AS DateTime), CAST(N'2019-12-05T21:58:44.947' AS DateTime), NULL, 0)
INSERT [base].[AccessLevel] ([Id], [Title], [LevelValue], [Description], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (2, N'محرمانه', 2, N'', 7, 7, CAST(N'2019-12-05T22:19:53.000' AS DateTime), CAST(N'2019-12-05T22:20:45.087' AS DateTime), NULL, 0)
INSERT [base].[AccessLevel] ([Id], [Title], [LevelValue], [Description], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (3, N'خیلی محرمانه', 3, N'', 7, 7, CAST(N'2019-12-05T22:20:27.660' AS DateTime), CAST(N'2019-12-05T22:20:53.063' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [base].[AccessLevel] OFF
SET IDENTITY_INSERT [base].[YashilDataProvider] ON 

INSERT [base].[YashilDataProvider] ([Id], [Title], [BaseType], [Description], [IsActive], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted], [ApplicationId]) VALUES (24, N'MS SQL', N'MS SQL', N'Integrated Security=False; Data Source=myServerAddress; Initial Catalog=myDataBase; User ID=myUsername; Password=myPassword;', 1, 7, 7, CAST(N'2019-12-05T21:48:53.483' AS DateTime), CAST(N'2019-12-11T01:43:52.210' AS DateTime), 0, NULL)
INSERT [base].[YashilDataProvider] ([Id], [Title], [BaseType], [Description], [IsActive], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted], [ApplicationId]) VALUES (25, N'Postgres', N'Postgres', N'Pg: Server=myServerAddress; Port=5432; Database=myDataBase; User Id=myUsername; Password=myPassword;', 1, 7, 7, CAST(N'2019-12-05T21:52:08.787' AS DateTime), CAST(N'2019-12-11T00:57:17.187' AS DateTime), 0, NULL)
INSERT [base].[YashilDataProvider] ([Id], [Title], [BaseType], [Description], [IsActive], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted], [ApplicationId]) VALUES (26, N'MySql', N'MySql', N'Server=myServerAddress; Database=myDataBase; UserId=myUsername; Pwd=myPassword;', 1, 7, 7, CAST(N'2019-12-05T21:54:59.260' AS DateTime), CAST(N'2019-12-11T00:57:09.207' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [base].[YashilDataProvider] OFF
INSERT [dbo].[Schemas] ([Name], [Title]) VALUES (N'base', N'')
INSERT [dbo].[Schemas] ([Name], [Title]) VALUES (N'dash', N'')
INSERT [dbo].[Schemas] ([Name], [Title]) VALUES (N'dbo', N'')
INSERT [dbo].[Schemas] ([Name], [Title]) VALUES (N'rpt', N'')
INSERT [dbo].[Schemas] ([Name], [Title]) VALUES (N'um', N'')
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'Resource', 34099162, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'Organization', 82099333, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'User', 87671360, N'UserName', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'AppConfig', 146099561, N'KeyTitle', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'AppAction', 178099675, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'ResourceAppAction', 226099846, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'RoleResourceAction', 290100074, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'Menu', 354100302, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'AccessLevel', 615673241, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'TableDesc', 686625489, N'TableName', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'sysdiagrams', 917578307, N'name', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'Role', 951674438, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'Application', 987150562, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'UserDashboard', 1170103209, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'RoleReport', 1319675749, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'RoleDashboard', 1362103893, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'UserReport', 1415676091, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'DashboardStore', 1490104349, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'ReportGroupReport', 1543676547, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'ReportStore', 1639676889, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'ReportGroup', 1767677345, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'DashboardGroup', 1815677516, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'DashboardGroupDashboard', 1847677630, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'UserRole', 2117582582, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'Schemas', 1959678029, N'Name', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'YashilDataProvider', 176719682, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'ReportConnectionString', 400720480, N'Title', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'YashilConnectionString', 608721221, N'Name', 1)
INSERT [dbo].[TableDesc] ([TableName], [object_id], [TitleColumn], [IsLargTable]) VALUES (N'DashboardConnectionString', 864722133, N'Title', 1)
SET IDENTITY_INSERT [rpt].[ReportGroup] ON 

INSERT [rpt].[ReportGroup] ([Id], [Title], [Description], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1, N'گروه 1', NULL, 7, NULL, CAST(N'2019-12-09T02:16:14.390' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [rpt].[ReportGroup] OFF
SET IDENTITY_INSERT [um].[AppAction] ON 

INSERT [um].[AppAction] ([Id], [Title], [Description], [SystemAction], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (2, N'View', N'نمایش', 0, 7, NULL, CAST(N'2641-02-15T18:40:20.430' AS DateTime), NULL, NULL, 0)
INSERT [um].[AppAction] ([Id], [Title], [Description], [SystemAction], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (3, N'Delete', N'حذف', 0, 7, NULL, CAST(N'2641-02-15T18:40:20.430' AS DateTime), NULL, NULL, 0)
INSERT [um].[AppAction] ([Id], [Title], [Description], [SystemAction], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (4, N'Insert', N'درج', 0, 7, NULL, CAST(N'2641-02-15T18:40:20.430' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [um].[AppAction] OFF
SET IDENTITY_INSERT [um].[Application] ON 

INSERT [um].[Application] ([Id], [Title], [Description], [Url], [SecretKey], [AdditionalInfo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (3, N'aaaa', N'aaaa', NULL, 0x, NULL, 7, 7, CAST(N'2019-11-21T12:38:45.420' AS DateTime), CAST(N'2019-12-01T14:40:47.063' AS DateTime), 0)
SET IDENTITY_INSERT [um].[Application] OFF
SET IDENTITY_INSERT [um].[Menu] ON 

INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1, N'', N'اطلاعات پایه', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 7, 7, CAST(N'2019-12-03T11:05:15.680' AS DateTime), CAST(N'2019-12-05T21:59:20.270' AS DateTime), NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (2, N'', N'داشبورد', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 7, 7, CAST(N'2019-12-03T11:05:15.680' AS DateTime), CAST(N'2019-12-05T21:59:31.493' AS DateTime), NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (4, N'', N'گزارشات', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 7, 7, CAST(N'2019-12-03T11:05:15.680' AS DateTime), CAST(N'2019-12-05T21:59:39.857' AS DateTime), NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (5, N'', N'مدیریت کاربران', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 7, 7, CAST(N'2019-12-03T11:05:15.680' AS DateTime), CAST(N'2019-12-05T21:59:53.723' AS DateTime), NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (7, N'/dash/userDashboards', N'داشبورد کاربران', N'ft-users', NULL, NULL, NULL, NULL, 2, 1060, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (8, N'/dash/roleDashboards', N'داشبورد نقش ها', N'ft-users', NULL, NULL, NULL, NULL, 2, 1062, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (9, N'/dash/dashboardGroups', N'گروه داشبورد', N'ft-users', NULL, NULL, NULL, NULL, 2, 1063, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (10, N'/dash/dashboardGroupDashboards', N'گروه بندی داشبورد', N'ft-users', NULL, NULL, NULL, NULL, 2, 1067, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (11, N'/dash/dashboardStores', N'داشبورد', N'ft-users', NULL, NULL, NULL, NULL, 2, 1065, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (12, N'/um/userRoles', N'نقش کاربران', N'ft-users', NULL, NULL, NULL, NULL, 5, 1071, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (13, N'/um/menus', N'منو', N'ft-users', NULL, NULL, NULL, NULL, 5, 1061, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (14, N'/um/roles', N'نقش', N'ft-users', NULL, NULL, NULL, NULL, 5, 1059, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (15, N'/um/users', N'کاربران', N'ft-users', NULL, NULL, NULL, NULL, 5, 1055, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (16, N'/um/resources', N'منابع', N'ft-users', NULL, NULL, NULL, NULL, 5, 1046, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (17, N'/um/applications', N'برنامه ', N'ft-users', NULL, NULL, NULL, NULL, 5, 1047, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (18, N'/um/organizations', N'سازمان', N'ft-users', NULL, NULL, NULL, NULL, 5, 1048, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (19, N'/um/appActions', N'عملیات', N'ft-users', NULL, NULL, NULL, NULL, 5, 1050, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (20, N'/um/resourceAppActions', N'مجوز', N'ft-users', NULL, NULL, NULL, NULL, 5, 1051, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (21, N'/um/roleResourceActions', N'تخصیص نقش به مجوز', N'ft-users', NULL, NULL, NULL, NULL, 5, 1052, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (22, N'/um/appConfigs', N'تنظیمات', N'ft-users', NULL, NULL, NULL, NULL, 5, 1053, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (24, N'/rpt/roleReports', N'تخصیص گزارش به نقش', N'ft-users', NULL, NULL, NULL, NULL, 4, 1064, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (25, N'/rpt/reportStores', N'گزارش', N'ft-users', NULL, NULL, NULL, NULL, 4, 1066, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (26, N'/rpt/reportGroups', N'گروه گزارش', N'ft-users', NULL, NULL, NULL, NULL, 4, 1068, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (27, N'/rpt/userReports', N'تخصیص گزارش به کاربر', N'ft-users', NULL, NULL, NULL, NULL, 4, 1069, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (28, N'/rpt/reportGroupReports', N'گروه بندی گزارش', N'ft-users', NULL, NULL, NULL, NULL, 4, 1070, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (29, N'/base/yashilConnectionStrings', N'رشته اتصال', N'ft-users', NULL, NULL, NULL, NULL, 1, 1056, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (30, N'/base/accessLevels', N'سطح دسترسی', N'ft-users', NULL, NULL, NULL, NULL, 1, 1057, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
INSERT [um].[Menu] ([Id], [Path], [Title], [Icon], [Class], [Badge], [BadgeClass], [IsExternalLink], [ParentId], [ResourceId], [IsVirtual], [OrderNo], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (31, N'/base/yashilDataProviders', N' انواع تامین کننده داده', N'ft-users', NULL, NULL, NULL, NULL, 1, 1049, 0, NULL, 7, NULL, CAST(N'2019-12-03T11:05:15.707' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [um].[Menu] OFF
SET IDENTITY_INSERT [um].[Resource] ON 

INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1046, N'Resource', N'منابع', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1047, N'Application', N'برنامه ', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1048, N'Organization', N'سازمان', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1049, N'YashilDataProvider', N' انواع تامین کننده داده', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1050, N'AppAction', N'عملیات', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1051, N'ResourceAppAction', N'مجوز', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1052, N'RoleResourceAction', N'تخصیص نقش به مجوز', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1053, N'AppConfig', N'تنظیمات', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1054, N'ReportConnectionString', N'رشته های اتصال گزارش', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1055, N'User', N'کاربران', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1056, N'YashilConnectionString', N'رشته اتصال', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1057, N'AccessLevel', N'سطح دسترسی', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1058, N'DashboardConnectionString', N'DashboardConnectionString', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1059, N'Role', N'نقش', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1060, N'UserDashboard', N'داشبورد کاربران', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1061, N'Menu', N'منو', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1062, N'RoleDashboard', N'داشبورد نقش ها', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1063, N'DashboardGroup', N'گروه داشبورد', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1064, N'RoleReport', N'تخصیص گزارش به نقش', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1065, N'DashboardStore', N'داشبورد', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1066, N'ReportStore', N'گزارش', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1067, N'DashboardGroupDashboard', N'گروه بندی داشبورد', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1068, N'ReportGroup', N'گروه گزارش', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1069, N'UserReport', N'تخصیص گزارش به کاربر', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1070, N'ReportGroupReport', N'گروه بندی گزارش', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
INSERT [um].[Resource] ([Id], [Title], [Description], [Type], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1071, N'UserRole', N'نقش کاربران', 1, 7, NULL, CAST(N'2019-12-03T11:05:26.787' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [um].[Resource] OFF
SET IDENTITY_INSERT [um].[ResourceAppAction] ON 

INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1068, 2, 1046, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1069, 2, 1047, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1070, 2, 1048, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1071, 2, 1049, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1072, 2, 1050, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1073, 2, 1051, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1074, 2, 1052, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1075, 2, 1053, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1076, 2, 1054, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1077, 2, 1055, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1078, 2, 1056, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1079, 2, 1057, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1080, 2, 1058, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1081, 2, 1059, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1082, 2, 1060, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1083, 2, 1061, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1084, 2, 1062, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1085, 2, 1063, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1086, 2, 1064, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1087, 2, 1065, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1088, 2, 1066, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1089, 2, 1067, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1090, 2, 1068, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1091, 2, 1069, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1092, 2, 1070, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1093, 2, 1071, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1094, 3, 1046, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1095, 3, 1047, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1096, 3, 1048, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1097, 3, 1049, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1098, 3, 1050, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1099, 3, 1051, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1100, 3, 1052, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1101, 3, 1053, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1102, 3, 1054, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1103, 3, 1055, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1104, 3, 1056, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1105, 3, 1057, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1106, 3, 1058, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1107, 3, 1059, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1108, 3, 1060, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1109, 3, 1061, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1110, 3, 1062, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1111, 3, 1063, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1112, 3, 1064, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1113, 3, 1065, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1114, 3, 1066, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1115, 3, 1067, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1116, 3, 1068, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1117, 3, 1069, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1118, 3, 1070, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1119, 3, 1071, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1120, 4, 1046, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1121, 4, 1047, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1122, 4, 1048, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1123, 4, 1049, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1124, 4, 1050, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1125, 4, 1051, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1126, 4, 1052, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1127, 4, 1053, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1128, 4, 1054, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1129, 4, 1055, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1130, 4, 1056, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1131, 4, 1057, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1132, 4, 1058, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1133, 4, 1059, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1134, 4, 1060, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1135, 4, 1061, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1136, 4, 1062, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1137, 4, 1063, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1138, 4, 1064, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1139, 4, 1065, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1140, 4, 1066, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1141, 4, 1067, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1142, 4, 1068, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1143, 4, 1069, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1144, 4, 1070, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
INSERT [um].[ResourceAppAction] ([Id], [AppActionId], [ResourceId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1145, 4, 1071, 7, NULL, CAST(N'2019-12-03T11:05:45.943' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [um].[ResourceAppAction] OFF
SET IDENTITY_INSERT [um].[Role] ON 

INSERT [um].[Role] ([Id], [Title], [Description], [IsActive], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [Deleted]) VALUES (1, N'Admin', NULL, 1, 7, 7, CAST(N'2641-02-15T18:43:31.963' AS DateTime), CAST(N'2019-12-01T11:41:08.097' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [um].[Role] OFF
SET IDENTITY_INSERT [um].[RoleResourceAction] ON 

INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (67, 1068, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (68, 1069, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (69, 1070, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (70, 1071, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (71, 1072, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (72, 1073, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (73, 1074, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (74, 1075, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (75, 1076, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (76, 1077, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (77, 1078, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (78, 1079, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (79, 1080, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (80, 1081, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (81, 1082, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (82, 1083, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (83, 1084, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (84, 1085, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (85, 1086, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (86, 1087, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (87, 1088, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (88, 1089, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (89, 1090, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (90, 1091, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (91, 1092, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (92, 1093, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (93, 1094, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (94, 1095, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (95, 1096, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (96, 1097, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (97, 1098, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (98, 1099, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (99, 1100, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (100, 1101, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (101, 1102, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (102, 1103, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (103, 1104, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (104, 1105, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (105, 1106, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (106, 1107, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (107, 1108, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (108, 1109, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (109, 1110, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (110, 1111, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (111, 1112, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (112, 1113, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (113, 1114, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (114, 1115, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (115, 1116, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (116, 1117, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (117, 1118, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (118, 1119, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (119, 1120, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (120, 1121, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (121, 1122, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (122, 1123, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (123, 1124, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (124, 1125, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (125, 1126, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (126, 1127, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (127, 1128, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (128, 1129, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (129, 1130, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (130, 1131, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (131, 1132, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (132, 1133, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (133, 1134, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (134, 1135, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (135, 1136, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (136, 1137, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (137, 1138, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (138, 1139, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (139, 1140, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (140, 1141, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (141, 1142, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (142, 1143, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (143, 1144, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
INSERT [um].[RoleResourceAction] ([Id], [ResourceActionId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (144, 1145, 1, 7, NULL, CAST(N'2019-12-03T11:05:45.947' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [um].[RoleResourceAction] OFF
SET IDENTITY_INSERT [um].[User] ON 

INSERT [um].[User] ([Id], [UserName], [FirstName], [LastName], [NationalCode], [Email], [Password], [IsActive], [MobileNumber], [OrganizationId], [PasswordSalt], [Address], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [ApplicationId], [AccessLevelId], [Deleted]) VALUES (7, N'admin', N'masoud', N'hadizadeh ', NULL, NULL, 0xEF5DEE7BB80C054E69C22E646EBBA9BBB54948AF58961710BD07D684FF4956F2AE885C2211C8669E83CC41FCB77A63C7E4391606EA90C6E1BAF086F37092BCDB, 1, NULL, NULL, 0x67C3677D35BDE9C15B5305D74F17B3DB3D9342A03A193CD5F0D3FA1DF285C660F0B1E6F854D5261B23D143C92686CA6B2B0FA118140EF2A7E9D633E1178C6B17DB86BE60A89CB0F846784AF777FA0663A1F7E739873CF171998BBE2273FE7E423741AC684CC56D1687F1839D815E035FEA8E633326A05691592AE6B00FCF0742, NULL, 7, NULL, CAST(N'2019-11-21T12:38:45.420' AS DateTime), CAST(N'2019-11-21T12:38:45.420' AS DateTime), 3, 1, 0)
SET IDENTITY_INSERT [um].[User] OFF
SET IDENTITY_INSERT [um].[UserRole] ON 

INSERT [um].[UserRole] ([Id], [UserId], [RoleId], [CreateBy], [ModifyBy], [CreationDate], [ModificationDate], [Deleted]) VALUES (1, 7, 1, 7, NULL, CAST(N'2019-12-02T10:51:48.463' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [um].[UserRole] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_YashilConnectionString]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_YashilConnectionString] ON [base].[YashilConnectionString]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DashboardConnectionString]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardConnectionString] ON [dash].[DashboardConnectionString]
(
	[ConnectionStringId] ASC,
	[DashboardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DashboardGroup]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardGroup] ON [dash].[DashboardGroup]
(
	[ApplicationId] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DashboardGroupDashboard]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE NONCLUSTERED INDEX [IX_DashboardGroupDashboard] ON [dash].[DashboardGroupDashboard]
(
	[DashboardGroupId] ASC,
	[DashboardStoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DashboardStore]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardStore] ON [dash].[DashboardStore]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DashboardStore_1]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardStore_1] ON [dash].[DashboardStore]
(
	[ApplicationId] ASC,
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserDashboard]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserDashboard] ON [dash].[UserDashboard]
(
	[DashboardId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReportConnectionString]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReportConnectionString] ON [rpt].[ReportConnectionString]
(
	[ReportId] ASC,
	[ConnectionStringId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReportGroup]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE NONCLUSTERED INDEX [IX_ReportGroup] ON [rpt].[ReportGroup]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReportGroupReport]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReportGroupReport] ON [rpt].[ReportGroupReport]
(
	[ReportGroupId] ASC,
	[ReportStoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReportStore]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE NONCLUSTERED INDEX [IX_ReportStore] ON [rpt].[ReportStore]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleReport]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RoleReport] ON [rpt].[RoleReport]
(
	[ReportId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserReport]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserReport] ON [rpt].[UserReport]
(
	[ReportId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [base].[AccessLevel] ADD  CONSTRAINT [DF_AccessLevel_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [base].[YashilConnectionString] ADD  CONSTRAINT [DF_YashilConnectionString_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [base].[YashilConnectionString] ADD  CONSTRAINT [DF_YashilConnectionString_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [base].[YashilDataProvider] ADD  CONSTRAINT [DF_YashilDataProvider_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [base].[YashilDataProvider] ADD  CONSTRAINT [DF_YashilDataProvider_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dash].[DashboardConnectionString] ADD  CONSTRAINT [DF_DashboardConnectionString_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dash].[DashboardGroup] ADD  CONSTRAINT [DF_DashboardGroup_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dash].[DashboardGroupDashboard] ADD  CONSTRAINT [DF_DashboardGroupDashboard_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dash].[DashboardStore] ADD  CONSTRAINT [DF_DashboardStore_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dash].[RoleDashboard] ADD  CONSTRAINT [DF_RoleDashboard_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dash].[UserDashboard] ADD  CONSTRAINT [DF_UserDashboard_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [rpt].[ReportConnectionString] ADD  CONSTRAINT [DF_ReportConnectionString_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [rpt].[ReportGroup] ADD  CONSTRAINT [DF_ReportGroup_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [rpt].[ReportGroupReport] ADD  CONSTRAINT [DF_ReportGroupReport_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [rpt].[ReportStore] ADD  CONSTRAINT [DF_ReportStore_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [rpt].[RoleReport] ADD  CONSTRAINT [DF_RoleReport_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [rpt].[UserReport] ADD  CONSTRAINT [DF_UserReport_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[AppAction] ADD  CONSTRAINT [DF_Action_SystemAction]  DEFAULT ((0)) FOR [SystemAction]
GO
ALTER TABLE [um].[AppAction] ADD  CONSTRAINT [DF_AppAction_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[AppConfig] ADD  CONSTRAINT [DF_AppConfig_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[Application] ADD  CONSTRAINT [DF_Application_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[Menu] ADD  CONSTRAINT [DF_Menu_IsVirtual]  DEFAULT ((0)) FOR [IsVirtual]
GO
ALTER TABLE [um].[Menu] ADD  CONSTRAINT [DF_Menu_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[Organization] ADD  CONSTRAINT [DF_Organization_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [um].[Organization] ADD  CONSTRAINT [DF_Organization_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[Resource] ADD  CONSTRAINT [DF_Resource_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[ResourceAppAction] ADD  CONSTRAINT [DF_ResourceAppAction_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[Role] ADD  CONSTRAINT [DF_Role_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [um].[Role] ADD  CONSTRAINT [DF_Role_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[RoleResourceAction] ADD  CONSTRAINT [DF_RoleResourceAction_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[User] ADD  CONSTRAINT [DF_User_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [um].[User] ADD  CONSTRAINT [DF_User_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [um].[UserRole] ADD  CONSTRAINT [DF_UserRole_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [base].[AccessLevel]  WITH CHECK ADD  CONSTRAINT [FK_AccessLevel_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[AccessLevel] CHECK CONSTRAINT [FK_AccessLevel_User]
GO
ALTER TABLE [base].[AccessLevel]  WITH CHECK ADD  CONSTRAINT [FK_AccessLevel_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[AccessLevel] CHECK CONSTRAINT [FK_AccessLevel_User1]
GO
ALTER TABLE [base].[YashilConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_YashilConnectionString_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[YashilConnectionString] CHECK CONSTRAINT [FK_YashilConnectionString_User]
GO
ALTER TABLE [base].[YashilConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_YashilConnectionString_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[YashilConnectionString] CHECK CONSTRAINT [FK_YashilConnectionString_User1]
GO
ALTER TABLE [base].[YashilConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_YashilConnectionString_YashilDataProvider] FOREIGN KEY([DataProviderId])
REFERENCES [base].[YashilDataProvider] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [base].[YashilConnectionString] CHECK CONSTRAINT [FK_YashilConnectionString_YashilDataProvider]
GO
ALTER TABLE [base].[YashilDataProvider]  WITH CHECK ADD  CONSTRAINT [FK_YashilDataProvider_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[YashilDataProvider] CHECK CONSTRAINT [FK_YashilDataProvider_User]
GO
ALTER TABLE [base].[YashilDataProvider]  WITH CHECK ADD  CONSTRAINT [FK_YashilDataProvider_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[YashilDataProvider] CHECK CONSTRAINT [FK_YashilDataProvider_User1]
GO
ALTER TABLE [dash].[DashboardConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_DashboardConnectionString_DashboardStore] FOREIGN KEY([DashboardId])
REFERENCES [dash].[DashboardStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dash].[DashboardConnectionString] CHECK CONSTRAINT [FK_DashboardConnectionString_DashboardStore]
GO
ALTER TABLE [dash].[DashboardConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_DashboardConnectionString_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[DashboardConnectionString] CHECK CONSTRAINT [FK_DashboardConnectionString_User]
GO
ALTER TABLE [dash].[DashboardConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_DashboardConnectionString_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[DashboardConnectionString] CHECK CONSTRAINT [FK_DashboardConnectionString_User1]
GO
ALTER TABLE [dash].[DashboardConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_DashboardConnectionString_YashilConnectionString] FOREIGN KEY([ConnectionStringId])
REFERENCES [base].[YashilConnectionString] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dash].[DashboardConnectionString] CHECK CONSTRAINT [FK_DashboardConnectionString_YashilConnectionString]
GO
ALTER TABLE [dash].[DashboardGroupDashboard]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroupDashboard_DashboardGroup] FOREIGN KEY([DashboardGroupId])
REFERENCES [dash].[DashboardGroup] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dash].[DashboardGroupDashboard] CHECK CONSTRAINT [FK_DashboardGroupDashboard_DashboardGroup]
GO
ALTER TABLE [dash].[DashboardGroupDashboard]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroupDashboard_DashboardStore] FOREIGN KEY([DashboardStoreId])
REFERENCES [dash].[DashboardStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dash].[DashboardGroupDashboard] CHECK CONSTRAINT [FK_DashboardGroupDashboard_DashboardStore]
GO
ALTER TABLE [dash].[DashboardGroupDashboard]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroupDashboard_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[DashboardGroupDashboard] CHECK CONSTRAINT [FK_DashboardGroupDashboard_User]
GO
ALTER TABLE [dash].[DashboardGroupDashboard]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroupDashboard_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[DashboardGroupDashboard] CHECK CONSTRAINT [FK_DashboardGroupDashboard_User1]
GO
ALTER TABLE [dash].[DashboardStore]  WITH CHECK ADD  CONSTRAINT [FK_Dashboard_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [dash].[DashboardStore] CHECK CONSTRAINT [FK_Dashboard_AccessLevel]
GO
ALTER TABLE [dash].[DashboardStore]  WITH CHECK ADD  CONSTRAINT [FK_Dashboard_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [dash].[DashboardStore] CHECK CONSTRAINT [FK_Dashboard_Application]
GO
ALTER TABLE [dash].[DashboardStore]  WITH CHECK ADD  CONSTRAINT [FK_Dashboard_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[DashboardStore] CHECK CONSTRAINT [FK_Dashboard_User]
GO
ALTER TABLE [dash].[DashboardStore]  WITH CHECK ADD  CONSTRAINT [FK_Dashboard_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[DashboardStore] CHECK CONSTRAINT [FK_Dashboard_User1]
GO
ALTER TABLE [dash].[RoleDashboard]  WITH CHECK ADD  CONSTRAINT [FK_RoleDashboard_Dashboard] FOREIGN KEY([DashboardId])
REFERENCES [dash].[DashboardStore] ([Id])
GO
ALTER TABLE [dash].[RoleDashboard] CHECK CONSTRAINT [FK_RoleDashboard_Dashboard]
GO
ALTER TABLE [dash].[RoleDashboard]  WITH CHECK ADD  CONSTRAINT [FK_RoleDashboard_Role] FOREIGN KEY([RoleId])
REFERENCES [um].[Role] ([Id])
GO
ALTER TABLE [dash].[RoleDashboard] CHECK CONSTRAINT [FK_RoleDashboard_Role]
GO
ALTER TABLE [dash].[RoleDashboard]  WITH CHECK ADD  CONSTRAINT [FK_RoleDashboard_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[RoleDashboard] CHECK CONSTRAINT [FK_RoleDashboard_User]
GO
ALTER TABLE [dash].[RoleDashboard]  WITH CHECK ADD  CONSTRAINT [FK_RoleDashboard_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[RoleDashboard] CHECK CONSTRAINT [FK_RoleDashboard_User1]
GO
ALTER TABLE [dash].[UserDashboard]  WITH CHECK ADD  CONSTRAINT [FK_UserDashboard_Dashboard] FOREIGN KEY([DashboardId])
REFERENCES [dash].[DashboardStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dash].[UserDashboard] CHECK CONSTRAINT [FK_UserDashboard_Dashboard]
GO
ALTER TABLE [dash].[UserDashboard]  WITH CHECK ADD  CONSTRAINT [FK_UserDashboard_User] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[UserDashboard] CHECK CONSTRAINT [FK_UserDashboard_User]
GO
ALTER TABLE [dash].[UserDashboard]  WITH CHECK ADD  CONSTRAINT [FK_UserDashboard_User2] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[UserDashboard] CHECK CONSTRAINT [FK_UserDashboard_User2]
GO
ALTER TABLE [dash].[UserDashboard]  WITH CHECK ADD  CONSTRAINT [FK_UserDashboard_User3] FOREIGN KEY([UserId])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dash].[UserDashboard] CHECK CONSTRAINT [FK_UserDashboard_User3]
GO
ALTER TABLE [rpt].[ReportConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_ReportConnectionString_ReportStore] FOREIGN KEY([ReportId])
REFERENCES [rpt].[ReportStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [rpt].[ReportConnectionString] CHECK CONSTRAINT [FK_ReportConnectionString_ReportStore]
GO
ALTER TABLE [rpt].[ReportConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_ReportConnectionString_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[ReportConnectionString] CHECK CONSTRAINT [FK_ReportConnectionString_User]
GO
ALTER TABLE [rpt].[ReportConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_ReportConnectionString_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[ReportConnectionString] CHECK CONSTRAINT [FK_ReportConnectionString_User1]
GO
ALTER TABLE [rpt].[ReportConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_ReportConnectionString_YashilConnectionString] FOREIGN KEY([ConnectionStringId])
REFERENCES [base].[YashilConnectionString] ([Id])
GO
ALTER TABLE [rpt].[ReportConnectionString] CHECK CONSTRAINT [FK_ReportConnectionString_YashilConnectionString]
GO
ALTER TABLE [rpt].[ReportGroupReport]  WITH CHECK ADD  CONSTRAINT [FK_ReportGroupReport_ReportGroup] FOREIGN KEY([ReportGroupId])
REFERENCES [rpt].[ReportGroup] ([Id])
GO
ALTER TABLE [rpt].[ReportGroupReport] CHECK CONSTRAINT [FK_ReportGroupReport_ReportGroup]
GO
ALTER TABLE [rpt].[ReportGroupReport]  WITH CHECK ADD  CONSTRAINT [FK_ReportGroupReport_ReportStore] FOREIGN KEY([ReportStoreId])
REFERENCES [rpt].[ReportStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [rpt].[ReportGroupReport] CHECK CONSTRAINT [FK_ReportGroupReport_ReportStore]
GO
ALTER TABLE [rpt].[ReportGroupReport]  WITH CHECK ADD  CONSTRAINT [FK_ReportGroupReport_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[ReportGroupReport] CHECK CONSTRAINT [FK_ReportGroupReport_User]
GO
ALTER TABLE [rpt].[ReportGroupReport]  WITH CHECK ADD  CONSTRAINT [FK_ReportGroupReport_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[ReportGroupReport] CHECK CONSTRAINT [FK_ReportGroupReport_User1]
GO
ALTER TABLE [rpt].[ReportStore]  WITH CHECK ADD  CONSTRAINT [FK_ReportStore_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [rpt].[ReportStore] CHECK CONSTRAINT [FK_ReportStore_AccessLevel]
GO
ALTER TABLE [rpt].[ReportStore]  WITH CHECK ADD  CONSTRAINT [FK_ReportStore_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[ReportStore] CHECK CONSTRAINT [FK_ReportStore_User]
GO
ALTER TABLE [rpt].[ReportStore]  WITH CHECK ADD  CONSTRAINT [FK_ReportStore_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[ReportStore] CHECK CONSTRAINT [FK_ReportStore_User1]
GO
ALTER TABLE [rpt].[RoleReport]  WITH CHECK ADD  CONSTRAINT [FK_RoleReport_Report] FOREIGN KEY([ReportId])
REFERENCES [rpt].[ReportStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [rpt].[RoleReport] CHECK CONSTRAINT [FK_RoleReport_Report]
GO
ALTER TABLE [rpt].[RoleReport]  WITH CHECK ADD  CONSTRAINT [FK_RoleReport_Role] FOREIGN KEY([RoleId])
REFERENCES [um].[Role] ([Id])
GO
ALTER TABLE [rpt].[RoleReport] CHECK CONSTRAINT [FK_RoleReport_Role]
GO
ALTER TABLE [rpt].[RoleReport]  WITH CHECK ADD  CONSTRAINT [FK_RoleReport_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[RoleReport] CHECK CONSTRAINT [FK_RoleReport_User]
GO
ALTER TABLE [rpt].[RoleReport]  WITH CHECK ADD  CONSTRAINT [FK_RoleReport_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[RoleReport] CHECK CONSTRAINT [FK_RoleReport_User1]
GO
ALTER TABLE [rpt].[UserReport]  WITH CHECK ADD  CONSTRAINT [FK_UserReport_Report] FOREIGN KEY([ReportId])
REFERENCES [rpt].[ReportStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [rpt].[UserReport] CHECK CONSTRAINT [FK_UserReport_Report]
GO
ALTER TABLE [rpt].[UserReport]  WITH CHECK ADD  CONSTRAINT [FK_UserReport_User] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[UserReport] CHECK CONSTRAINT [FK_UserReport_User]
GO
ALTER TABLE [rpt].[UserReport]  WITH CHECK ADD  CONSTRAINT [FK_UserReport_User2] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[UserReport] CHECK CONSTRAINT [FK_UserReport_User2]
GO
ALTER TABLE [rpt].[UserReport]  WITH CHECK ADD  CONSTRAINT [FK_UserReport_User3] FOREIGN KEY([UserId])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [rpt].[UserReport] CHECK CONSTRAINT [FK_UserReport_User3]
GO
ALTER TABLE [um].[AppAction]  WITH CHECK ADD  CONSTRAINT [FK_Action_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[AppAction] CHECK CONSTRAINT [FK_Action_Application]
GO
ALTER TABLE [um].[AppAction]  WITH CHECK ADD  CONSTRAINT [FK_Action_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[AppAction] CHECK CONSTRAINT [FK_Action_User]
GO
ALTER TABLE [um].[AppAction]  WITH CHECK ADD  CONSTRAINT [FK_Action_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[AppAction] CHECK CONSTRAINT [FK_Action_User1]
GO
ALTER TABLE [um].[AppConfig]  WITH CHECK ADD  CONSTRAINT [FK_AppConfig_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[AppConfig] CHECK CONSTRAINT [FK_AppConfig_Application]
GO
ALTER TABLE [um].[AppConfig]  WITH CHECK ADD  CONSTRAINT [FK_AppConfig_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[AppConfig] CHECK CONSTRAINT [FK_AppConfig_User]
GO
ALTER TABLE [um].[AppConfig]  WITH CHECK ADD  CONSTRAINT [FK_AppConfig_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[AppConfig] CHECK CONSTRAINT [FK_AppConfig_User1]
GO
ALTER TABLE [um].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Application] CHECK CONSTRAINT [FK_Application_User]
GO
ALTER TABLE [um].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Application] CHECK CONSTRAINT [FK_Application_User1]
GO
ALTER TABLE [um].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[Menu] CHECK CONSTRAINT [FK_Menu_Application]
GO
ALTER TABLE [um].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Menu] FOREIGN KEY([Id])
REFERENCES [um].[Menu] ([Id])
GO
ALTER TABLE [um].[Menu] CHECK CONSTRAINT [FK_Menu_Menu]
GO
ALTER TABLE [um].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_User] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Menu] CHECK CONSTRAINT [FK_Menu_User]
GO
ALTER TABLE [um].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_User1] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Menu] CHECK CONSTRAINT [FK_Menu_User1]
GO
ALTER TABLE [um].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menue_Menue] FOREIGN KEY([ParentId])
REFERENCES [um].[Menu] ([Id])
GO
ALTER TABLE [um].[Menu] CHECK CONSTRAINT [FK_Menue_Menue]
GO
ALTER TABLE [um].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menue_Resource] FOREIGN KEY([ResourceId])
REFERENCES [um].[Resource] ([Id])
GO
ALTER TABLE [um].[Menu] CHECK CONSTRAINT [FK_Menue_Resource]
GO
ALTER TABLE [um].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[Organization] CHECK CONSTRAINT [FK_Organization_Application]
GO
ALTER TABLE [um].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Organization] FOREIGN KEY([ParentId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [um].[Organization] CHECK CONSTRAINT [FK_Organization_Organization]
GO
ALTER TABLE [um].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Organization] CHECK CONSTRAINT [FK_Organization_User]
GO
ALTER TABLE [um].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Organization] CHECK CONSTRAINT [FK_Organization_User1]
GO
ALTER TABLE [um].[Resource]  WITH CHECK ADD  CONSTRAINT [FK_Resource_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[Resource] CHECK CONSTRAINT [FK_Resource_Application]
GO
ALTER TABLE [um].[Resource]  WITH CHECK ADD  CONSTRAINT [FK_Resource_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Resource] CHECK CONSTRAINT [FK_Resource_User]
GO
ALTER TABLE [um].[Resource]  WITH CHECK ADD  CONSTRAINT [FK_Resource_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Resource] CHECK CONSTRAINT [FK_Resource_User1]
GO
ALTER TABLE [um].[ResourceAppAction]  WITH CHECK ADD  CONSTRAINT [FK_ResourceAction_Action] FOREIGN KEY([AppActionId])
REFERENCES [um].[AppAction] ([Id])
GO
ALTER TABLE [um].[ResourceAppAction] CHECK CONSTRAINT [FK_ResourceAction_Action]
GO
ALTER TABLE [um].[ResourceAppAction]  WITH CHECK ADD  CONSTRAINT [FK_ResourceAction_Resource] FOREIGN KEY([ResourceId])
REFERENCES [um].[Resource] ([Id])
GO
ALTER TABLE [um].[ResourceAppAction] CHECK CONSTRAINT [FK_ResourceAction_Resource]
GO
ALTER TABLE [um].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[Role] CHECK CONSTRAINT [FK_Role_Application]
GO
ALTER TABLE [um].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Role] CHECK CONSTRAINT [FK_Role_User]
GO
ALTER TABLE [um].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Role] CHECK CONSTRAINT [FK_Role_User1]
GO
ALTER TABLE [um].[RoleResourceAction]  WITH CHECK ADD  CONSTRAINT [FK_RoleResourceAction_ResourceAction] FOREIGN KEY([ResourceActionId])
REFERENCES [um].[ResourceAppAction] ([Id])
GO
ALTER TABLE [um].[RoleResourceAction] CHECK CONSTRAINT [FK_RoleResourceAction_ResourceAction]
GO
ALTER TABLE [um].[RoleResourceAction]  WITH CHECK ADD  CONSTRAINT [FK_RoleResourceAction_Role] FOREIGN KEY([RoleId])
REFERENCES [um].[Role] ([Id])
GO
ALTER TABLE [um].[RoleResourceAction] CHECK CONSTRAINT [FK_RoleResourceAction_Role]
GO
ALTER TABLE [um].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [um].[User] CHECK CONSTRAINT [FK_User_AccessLevel]
GO
ALTER TABLE [um].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[User] CHECK CONSTRAINT [FK_User_Application]
GO
ALTER TABLE [um].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [um].[User] CHECK CONSTRAINT [FK_User_Organization]
GO
ALTER TABLE [um].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [um].[Role] ([Id])
GO
ALTER TABLE [um].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [um].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
ALTER TABLE [um].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User1] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[UserRole] CHECK CONSTRAINT [FK_UserRole_User1]
GO
ALTER TABLE [um].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User2] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[UserRole] CHECK CONSTRAINT [FK_UserRole_User2]
GO
/****** Object:  StoredProcedure [dbo].[INSERT_TableDesc]    Script Date: 02/11/1398 10:25:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 10/29/2019 9:54:08 PM
 ************************************************************/
CREATE PROCEDURE [dbo].[INSERT_TableDesc]
AS

SELECT t.name             TableName,
       t.[object_id],
       (
           SELECT TOP(1) c.name
           FROM   sys.[columns] AS c
           WHERE  c.[object_id] = t.[object_id]
                  AND (
                          c.name LIKE '%Title%'
                          OR c.name LIKE '%PersianName%'
                          OR c.name LIKE '%Name%'
                      )
           ORDER BY
                  (
                      CASE c.name
                           WHEN '%Title%' THEN 0
                           WHEN 'Name' THEN 1
                           WHEN 'PersinaName' THEN 2
                           ELSE 3
                      END
                  )
       )                  TitleColumn,
       CAST(1 AS BIT)  AS IsLargTable
INTO   #t
FROM   sys.tables AS t
WHERE  t.[type] = 'U'


INSERT INTO TableDesc
  (
    TableName,
    [object_id],
    TitleColumn,
    IsLargTable
  )
SELECT TableName,
       [object_id],
       TitleColumn,
       IsLargTable
FROM   #t t
WHERE  t.TableName NOT IN (SELECT TableName
                           FROM   TableDesc)
                           
DELETE FROM TableDesc WHERE TableName NOT IN (SELECT TableName
											  FROM   #t) 


UPDATE TableDesc
SET
	TitleColumn ='Title'
WHERE TitleColumn IS null
	
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مقدار سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'LevelValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تامین کننده داده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'DataProviderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته اتصال' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'ConnectionString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال بودن' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته اتصال' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilConnectionString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع پایه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'BaseType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال بودن' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' انواع تامین کننده داده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'YashilDataProvider'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'DashboardId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته اتصال' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'ConnectionStringId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته های اتصال داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'DashboardStoreId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'DashboardGroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه بندی داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroupDashboard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'DashboardFile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلاس' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'CssClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تصویر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Picture'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رنگ' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Color'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'انیمیشن' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Animation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardStore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نقش' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'DashboardId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد نقش ها' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'RoleDashboard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'DashboardId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'داشبورد کاربران' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'UserDashboard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'ReportId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته اتصال' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'ConnectionStringId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته های اتصال گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'ReportStoreId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'ReportGroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه بندی گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroupReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'ReportFile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلاس' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'CssClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تصویر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'Picture'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رنگ' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'Color'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'انیمیشن' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'Animation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلید گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'ReportKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'طراحی' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'DesignString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ماژول' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'ModuleKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportStore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نقش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'ReportId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تخصیص گزارش به نقش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'RoleReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'ReportId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تخصیص گزارش به کاربر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عملیات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'KeyTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مقدار' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تنظیمات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'AppConfig'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آدرس' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلید' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'SecretKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اطلاعات تکمیلی' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'AdditionalInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه ' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Application'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مسیر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیکون' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلاس' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Class'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نشان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Badge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلاس مشان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'BadgeClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'لینک خارجی' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'IsExternalLink'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'پدر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'منبع' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ResourceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مجازی' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'IsVirtual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ترتیب' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'منو' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان پدر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع سازمان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'استان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'ProvinceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Organization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آدرس منبع' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'منابع' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Resource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عملیات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction', @level2type=N'COLUMN',@level2name=N'AppActionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'منبع' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction', @level2type=N'COLUMN',@level2name=N'ResourceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مجوز' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'ResourceAppAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال بودن' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نقش' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'منبع عملیات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'ResourceActionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نقش' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تخصیص نقش به مجوز' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'RoleResourceAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام کاربری' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام خانوادگی' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ملی' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'NationalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایمیل' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلمه عبور' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره موبایل' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'MobileNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'OrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آدرس' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربران' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نقش' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نقش کاربران' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'UserRole'
GO
USE [master]
GO
ALTER DATABASE [YashilDb] SET  READ_WRITE 
GO
