USE [master]
GO
/****** Object:  Database [YashilDb]    Script Date: 2/23/2020 1:05:24 PM ******/
CREATE DATABASE [YashilDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YashilDashnoardDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\YashilDashnoardDb.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
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
/****** Object:  Schema [base]    Script Date: 2/23/2020 1:05:24 PM ******/
CREATE SCHEMA [base]
GO
/****** Object:  Schema [dash]    Script Date: 2/23/2020 1:05:24 PM ******/
CREATE SCHEMA [dash]
GO
/****** Object:  Schema [dms]    Script Date: 2/23/2020 1:05:24 PM ******/
CREATE SCHEMA [dms]
GO
/****** Object:  Schema [rpt]    Script Date: 2/23/2020 1:05:24 PM ******/
CREATE SCHEMA [rpt]
GO
/****** Object:  Schema [tms]    Script Date: 2/23/2020 1:05:24 PM ******/
CREATE SCHEMA [tms]
GO
/****** Object:  Schema [um]    Script Date: 2/23/2020 1:05:24 PM ******/
CREATE SCHEMA [um]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateToShamsiDatePart]    Script Date: 2/23/2020 1:05:24 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[getColDesc]    Script Date: 2/23/2020 1:05:24 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[getTableDesc]    Script Date: 2/23/2020 1:05:24 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[getTableTitleColumn]    Script Date: 2/23/2020 1:05:24 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ShamsiToGregorian]    Script Date: 2/23/2020 1:05:24 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ToPersianDate]    Script Date: 2/23/2020 1:05:24 PM ******/
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
/****** Object:  Table [base].[AccessLevel]    Script Date: 2/23/2020 1:05:24 PM ******/
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
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
	[ApplicationId] [int] NOT NULL,
 CONSTRAINT [PK_AccessLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[AppEntity]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [base].[AppEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[ObjectId] [int] NOT NULL,
	[TitlePropertyName] [nvarchar](300) NULL,
	[IsLarge] [bit] NULL,
	[IsVirtualEntity] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[Props] [nvarchar](max) NULL,
	[PersianTitle] [nvarchar](300) NULL,
	[EnglishTitle] [nvarchar](300) NULL,
	[ApplicationBased] [nchar](10) NULL,
 CONSTRAINT [PK_TableDesc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[City]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [base].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[ParentId] [int] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[CustomCategoryId] [int] NULL,
	[CountryDivisionTypeId] [int] NULL,
	[ProvinceCenter] [bit] NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[CommonBaseData]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [base].[CommonBaseData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[ParentId] [int] NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Value] [int] NOT NULL,
	[CommonBaseTypeId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_CommonBaseData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[CommonBaseType]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [base].[CommonBaseType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NULL,
	[Title] [nvarchar](300) NOT NULL,
	[TreeBased] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_CommonBaseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[YashilConnectionString]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_YashilConnectionString] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [base].[YashilDataProvider]    Script Date: 2/23/2020 1:05:25 PM ******/
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
 CONSTRAINT [PK_YashilDataProvider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dash].[DashboardConnectionString]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DashboardConnectionString] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dash].[DashboardGroup]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[DashboardGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[EnglishTitle] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_DashboardGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dash].[DashboardGroupDashboard]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dash].[DashboardGroupDashboard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dash].[DashboardStore]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[Picture] [varbinary](max) NULL,
	[Color] [varchar](50) NULL,
	[Animation] [bit] NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_Dashboard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dash].[RoleDashboard]    Script Date: 2/23/2020 1:05:25 PM ******/
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
/****** Object:  Table [dash].[UserDashboard]    Script Date: 2/23/2020 1:05:25 PM ******/
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
/****** Object:  Table [dbo].[Schemas]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schemas](
	[Name] [sysname] NOT NULL,
	[Title] [varchar](1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dms].[AppDocument]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dms].[AppDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocTypeId] [int] NOT NULL,
	[Title] [nvarchar](300) NULL,
	[OrginalName] [nvarchar](200) NULL,
	[DocumentCategoryId] [int] NOT NULL,
	[ObjectId] [bigint] NOT NULL,
	[DocumentFile] [varbinary](max) NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[DisplayOrder] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Extension] [varchar](50) NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_AppDocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dms].[DocFormat]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dms].[DocFormat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Extensions] [nvarchar](300) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DocFormat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dms].[DocType]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dms].[DocType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[AppEntityId] [int] NOT NULL,
	[DisplayOrder] [int] NULL,
	[SaveToDisk] [bit] NOT NULL,
	[MaxSize] [int] NOT NULL,
	[MaxCount] [int] NOT NULL,
	[DocFormatId] [int] NOT NULL,
	[IsImage] [bit] NOT NULL,
	[CropImage] [bit] NOT NULL,
	[AspectRatio] [float] NOT NULL,
	[IsTitleRequired] [bit] NOT NULL,
	[IsCategorized] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DocType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dms].[DocumentCategory]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dms].[DocumentCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
	[AppEntityId] [int] NOT NULL,
	[ObjectId] [bigint] NOT NULL,
	[DisplayOrder] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [rpt].[ReportConnectionString]    Script Date: 2/23/2020 1:05:25 PM ******/
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
 CONSTRAINT [PK_ReportConnectionString] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rpt].[ReportGroup]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[ReportGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[EnglishTitle] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_ReportGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [rpt].[ReportGroupReport]    Script Date: 2/23/2020 1:05:25 PM ******/
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
/****** Object:  Table [rpt].[ReportStore]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rpt].[ReportStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[ReportFile] [varbinary](max) NULL,
	[CssClass] [varchar](50) NULL,
	[Picture] [varbinary](max) NULL,
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
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_ReportStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [rpt].[RoleReport]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_RoleReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rpt].[UserReport]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tms].[Course]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tms].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[Title] [nvarchar](300) NOT NULL,
	[CourseCategory] [int] NOT NULL,
	[EducationalCenterId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Topic] [nvarchar](max) NULL,
	[Prerequisite] [nvarchar](max) NULL,
	[Target] [nvarchar](max) NULL,
	[Requirements] [nvarchar](max) NULL,
	[Skill] [nvarchar](max) NULL,
	[Duration] [int] NOT NULL,
	[Audience] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_Dashboard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [tms].[CourseCategory]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tms].[CourseCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Code] [nvarchar](150) NULL,
	[Title] [nvarchar](300) NOT NULL,
	[EducationalCenterId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_CourseCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [tms].[CoursesPlanning]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tms].[CoursesPlanning](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[RepresentationId] [int] NULL,
	[Price] [int] NULL,
	[CourseId] [int] NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[ImplementaionType] [int] NOT NULL,
	[CourceType] [int] NOT NULL,
	[StartDate] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_CoursesPlanning] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [tms].[EducationalCenter]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tms].[EducationalCenter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_EducationalCenter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [tms].[HumanResource]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tms].[HumanResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[RepresentationId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
	[FromDate] [int] NULL,
	[ToDate] [int] NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_HumanResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [tms].[Representation]    Script Date: 2/23/2020 1:05:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tms].[Representation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[Title] [nvarchar](300) NOT NULL,
	[EducationalCenterId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[AgentId] [int] NULL,
	[Email] [nvarchar](300) NULL,
	[Telephone] [varchar](20) NULL,
	[FaxNumber] [varchar](20) NULL,
	[LicenseNumber] [nvarchar](200) NULL,
	[LicenseTypeId] [int] NULL,
	[Area] [int] NULL,
	[OwnershipTypeId] [int] NULL,
	[PostalCode] [char](10) NULL,
	[Address] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_Representation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[AppAction]    Script Date: 2/23/2020 1:05:25 PM ******/
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
/****** Object:  Table [um].[AppConfig]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_AppConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[Application]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[Menu]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[Deleted] [bit] NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_Menue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [um].[Organization]    Script Date: 2/23/2020 1:05:25 PM ******/
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
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[Post]    Script Date: 2/23/2020 1:05:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NULL,
	[Title] [nvarchar](300) NOT NULL,
	[ParentId] [int] NOT NULL,
	[IsVirtual] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[Resource]    Script Date: 2/23/2020 1:05:26 PM ******/
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
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[ResourceAppAction]    Script Date: 2/23/2020 1:05:26 PM ******/
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
/****** Object:  Table [um].[Role]    Script Date: 2/23/2020 1:05:26 PM ******/
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
	[ApplicationId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[RoleResourceAction]    Script Date: 2/23/2020 1:05:26 PM ******/
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
/****** Object:  Table [um].[User]    Script Date: 2/23/2020 1:05:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [um].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](400) NOT NULL,
	[NationalCode] [char](10) NULL,
	[Email] [nvarchar](300) NULL,
	[Password] [varbinary](400) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[MobileNumber] [varchar](20) NULL,
	[OrganizationId] [int] NOT NULL,
	[PasswordSalt] [varbinary](400) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[ApplicationId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatorOrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [um].[UserRole]    Script Date: 2/23/2020 1:05:26 PM ******/
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
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_YashilConnectionString]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_YashilConnectionString] ON [base].[YashilConnectionString]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DashboardConnectionString]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardConnectionString] ON [dash].[DashboardConnectionString]
(
	[ConnectionStringId] ASC,
	[DashboardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DashboardGroup]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardGroup] ON [dash].[DashboardGroup]
(
	[ApplicationId] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DashboardGroup_1]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardGroup_1] ON [dash].[DashboardGroup]
(
	[EnglishTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DashboardGroupDashboard]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_DashboardGroupDashboard] ON [dash].[DashboardGroupDashboard]
(
	[DashboardGroupId] ASC,
	[DashboardStoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DashboardStore]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardStore] ON [dash].[DashboardStore]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserDashboard]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserDashboard] ON [dash].[UserDashboard]
(
	[DashboardId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DocFormat]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_DocFormat] ON [dms].[DocFormat]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReportConnectionString]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReportConnectionString] ON [rpt].[ReportConnectionString]
(
	[ReportId] ASC,
	[ConnectionStringId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReportGroup]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReportGroup] ON [rpt].[ReportGroup]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReportGroup_1]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReportGroup_1] ON [rpt].[ReportGroup]
(
	[EnglishTitle] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReportGroupReport]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReportGroupReport] ON [rpt].[ReportGroupReport]
(
	[ReportGroupId] ASC,
	[ReportStoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReportStore]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReportStore] ON [rpt].[ReportStore]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleReport]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RoleReport] ON [rpt].[RoleReport]
(
	[ReportId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserReport]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserReport] ON [rpt].[UserReport]
(
	[ReportId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AppConfig]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_AppConfig] ON [um].[AppConfig]
(
	[ApplicationId] ASC,
	[KeyTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Role]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Role] ON [um].[Role]
(
	[Title] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User]    Script Date: 2/23/2020 1:05:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User] ON [um].[User]
(
	[UserName] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [base].[AccessLevel] ADD  CONSTRAINT [DF_AccessLevel_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [base].[AppEntity] ADD  CONSTRAINT [DF_AppEntity_IsVirtualEntity]  DEFAULT ((0)) FOR [IsVirtualEntity]
GO
ALTER TABLE [base].[AppEntity] ADD  CONSTRAINT [DF_TableDesc_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [base].[AppEntity] ADD  CONSTRAINT [DF_AppEntity_ApplicationBased]  DEFAULT ((1)) FOR [ApplicationBased]
GO
ALTER TABLE [base].[City] ADD  CONSTRAINT [DF_City_ProvinceCenter]  DEFAULT ((0)) FOR [ProvinceCenter]
GO
ALTER TABLE [base].[City] ADD  CONSTRAINT [DF_City_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [base].[CommonBaseData] ADD  CONSTRAINT [DF_CommonBaseData_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [base].[CommonBaseType] ADD  CONSTRAINT [DF_CommonBaseType_TreeBased]  DEFAULT ((0)) FOR [TreeBased]
GO
ALTER TABLE [base].[CommonBaseType] ADD  CONSTRAINT [DF_CommonBaseType_Deleted]  DEFAULT ((0)) FOR [Deleted]
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
ALTER TABLE [dms].[AppDocument] ADD  CONSTRAINT [DF_AppDocument_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dms].[DocFormat] ADD  CONSTRAINT [DF_DocFormat_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_RelatedObject_1]  DEFAULT ((1)) FOR [AppEntityId]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_SaveToDisk]  DEFAULT ((0)) FOR [SaveToDisk]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_MaxSize_1]  DEFAULT ((1024)) FOR [MaxSize]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_MaxCount_1]  DEFAULT ((1)) FOR [MaxCount]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_IsImage]  DEFAULT ((0)) FOR [IsImage]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_CropImage]  DEFAULT ((0)) FOR [CropImage]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_AspectRatio]  DEFAULT ((1)) FOR [AspectRatio]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_IsTitleRequired]  DEFAULT ((1)) FOR [IsTitleRequired]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_IsCetegorized]  DEFAULT ((1)) FOR [IsCategorized]
GO
ALTER TABLE [dms].[DocType] ADD  CONSTRAINT [DF_DocType_Deleted_1]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dms].[DocumentCategory] ADD  CONSTRAINT [DF_DocumentCategory_IsActive_1]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dms].[DocumentCategory] ADD  CONSTRAINT [DF_DocumentCategory_Deleted_1]  DEFAULT ((0)) FOR [Deleted]
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
ALTER TABLE [tms].[Course] ADD  CONSTRAINT [DF_Course_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [tms].[CourseCategory] ADD  CONSTRAINT [DF_CourseCategory_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [tms].[CoursesPlanning] ADD  CONSTRAINT [DF_CoursesPlanning_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [tms].[EducationalCenter] ADD  CONSTRAINT [DF_EducationalCenter_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [tms].[HumanResource] ADD  CONSTRAINT [DF_HumanResource_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [tms].[Representation] ADD  CONSTRAINT [DF_Representation_Deleted]  DEFAULT ((0)) FOR [Deleted]
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
ALTER TABLE [um].[Post] ADD  CONSTRAINT [DF_Post_IsVirtual]  DEFAULT ((0)) FOR [IsVirtual]
GO
ALTER TABLE [um].[Post] ADD  CONSTRAINT [DF_Post_Deleted]  DEFAULT ((0)) FOR [Deleted]
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
ALTER TABLE [base].[AccessLevel]  WITH CHECK ADD  CONSTRAINT [FK_AccessLevel_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [base].[AccessLevel] CHECK CONSTRAINT [FK_AccessLevel_Organization]
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
ALTER TABLE [base].[AppEntity]  WITH CHECK ADD  CONSTRAINT [FK_AppEntity_DocFormat] FOREIGN KEY([CreateBy])
REFERENCES [dms].[DocFormat] ([Id])
GO
ALTER TABLE [base].[AppEntity] CHECK CONSTRAINT [FK_AppEntity_DocFormat]
GO
ALTER TABLE [base].[AppEntity]  WITH CHECK ADD  CONSTRAINT [FK_AppEntity_DocFormat1] FOREIGN KEY([ModifyBy])
REFERENCES [dms].[DocFormat] ([Id])
GO
ALTER TABLE [base].[AppEntity] CHECK CONSTRAINT [FK_AppEntity_DocFormat1]
GO
ALTER TABLE [base].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_City] FOREIGN KEY([ParentId])
REFERENCES [base].[City] ([Id])
GO
ALTER TABLE [base].[City] CHECK CONSTRAINT [FK_City_City]
GO
ALTER TABLE [base].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_CommonBaseData] FOREIGN KEY([CustomCategoryId])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [base].[City] CHECK CONSTRAINT [FK_City_CommonBaseData]
GO
ALTER TABLE [base].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_CommonBaseData1] FOREIGN KEY([CountryDivisionTypeId])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [base].[City] CHECK CONSTRAINT [FK_City_CommonBaseData1]
GO
ALTER TABLE [base].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[City] CHECK CONSTRAINT [FK_City_User]
GO
ALTER TABLE [base].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[City] CHECK CONSTRAINT [FK_City_User1]
GO
ALTER TABLE [base].[CommonBaseData]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseData_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [base].[CommonBaseData] CHECK CONSTRAINT [FK_CommonBaseData_AccessLevel]
GO
ALTER TABLE [base].[CommonBaseData]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseData_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [base].[CommonBaseData] CHECK CONSTRAINT [FK_CommonBaseData_Application]
GO
ALTER TABLE [base].[CommonBaseData]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseData_CommonBaseData] FOREIGN KEY([ParentId])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [base].[CommonBaseData] CHECK CONSTRAINT [FK_CommonBaseData_CommonBaseData]
GO
ALTER TABLE [base].[CommonBaseData]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseData_CommonBaseType] FOREIGN KEY([CommonBaseTypeId])
REFERENCES [base].[CommonBaseType] ([Id])
GO
ALTER TABLE [base].[CommonBaseData] CHECK CONSTRAINT [FK_CommonBaseData_CommonBaseType]
GO
ALTER TABLE [base].[CommonBaseData]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseData_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [base].[CommonBaseData] CHECK CONSTRAINT [FK_CommonBaseData_Organization]
GO
ALTER TABLE [base].[CommonBaseData]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseData_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[CommonBaseData] CHECK CONSTRAINT [FK_CommonBaseData_User]
GO
ALTER TABLE [base].[CommonBaseData]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseData_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[CommonBaseData] CHECK CONSTRAINT [FK_CommonBaseData_User1]
GO
ALTER TABLE [base].[CommonBaseType]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseType_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [base].[CommonBaseType] CHECK CONSTRAINT [FK_CommonBaseType_AccessLevel]
GO
ALTER TABLE [base].[CommonBaseType]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseType_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [base].[CommonBaseType] CHECK CONSTRAINT [FK_CommonBaseType_Application]
GO
ALTER TABLE [base].[CommonBaseType]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseType_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [base].[CommonBaseType] CHECK CONSTRAINT [FK_CommonBaseType_Organization]
GO
ALTER TABLE [base].[CommonBaseType]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseType_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[CommonBaseType] CHECK CONSTRAINT [FK_CommonBaseType_User]
GO
ALTER TABLE [base].[CommonBaseType]  WITH CHECK ADD  CONSTRAINT [FK_CommonBaseType_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [base].[CommonBaseType] CHECK CONSTRAINT [FK_CommonBaseType_User1]
GO
ALTER TABLE [base].[YashilConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_YashilConnectionString_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [base].[YashilConnectionString] CHECK CONSTRAINT [FK_YashilConnectionString_Application]
GO
ALTER TABLE [base].[YashilConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_YashilConnectionString_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [base].[YashilConnectionString] CHECK CONSTRAINT [FK_YashilConnectionString_Organization]
GO
ALTER TABLE [base].[YashilConnectionString]  WITH CHECK ADD  CONSTRAINT [FK_YashilConnectionString_YashilDataProvider] FOREIGN KEY([DataProviderId])
REFERENCES [base].[YashilDataProvider] ([Id])
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
ALTER TABLE [dash].[DashboardGroup]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroup_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [dash].[DashboardGroup] CHECK CONSTRAINT [FK_DashboardGroup_Application]
GO
ALTER TABLE [dash].[DashboardGroup]  WITH CHECK ADD  CONSTRAINT [FK_DashboardGroup_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [dash].[DashboardGroup] CHECK CONSTRAINT [FK_DashboardGroup_Organization]
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
ALTER TABLE [dash].[DashboardStore]  WITH CHECK ADD  CONSTRAINT [FK_DashboardStore_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [dash].[DashboardStore] CHECK CONSTRAINT [FK_DashboardStore_Organization]
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
ALTER TABLE [dms].[AppDocument]  WITH CHECK ADD  CONSTRAINT [FK_AppDocument_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [dms].[AppDocument] CHECK CONSTRAINT [FK_AppDocument_Application]
GO
ALTER TABLE [dms].[AppDocument]  WITH CHECK ADD  CONSTRAINT [FK_AppDocument_DocType] FOREIGN KEY([DocTypeId])
REFERENCES [dms].[DocType] ([Id])
GO
ALTER TABLE [dms].[AppDocument] CHECK CONSTRAINT [FK_AppDocument_DocType]
GO
ALTER TABLE [dms].[AppDocument]  WITH CHECK ADD  CONSTRAINT [FK_AppDocument_DocumentCategory] FOREIGN KEY([DocumentCategoryId])
REFERENCES [dms].[DocumentCategory] ([Id])
GO
ALTER TABLE [dms].[AppDocument] CHECK CONSTRAINT [FK_AppDocument_DocumentCategory]
GO
ALTER TABLE [dms].[AppDocument]  WITH CHECK ADD  CONSTRAINT [FK_AppDocument_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [dms].[AppDocument] CHECK CONSTRAINT [FK_AppDocument_Organization]
GO
ALTER TABLE [dms].[AppDocument]  WITH CHECK ADD  CONSTRAINT [FK_AppDocument_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[AppDocument] CHECK CONSTRAINT [FK_AppDocument_User]
GO
ALTER TABLE [dms].[AppDocument]  WITH CHECK ADD  CONSTRAINT [FK_AppDocument_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[AppDocument] CHECK CONSTRAINT [FK_AppDocument_User1]
GO
ALTER TABLE [dms].[DocFormat]  WITH CHECK ADD  CONSTRAINT [FK_DocFormat_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[DocFormat] CHECK CONSTRAINT [FK_DocFormat_User]
GO
ALTER TABLE [dms].[DocFormat]  WITH CHECK ADD  CONSTRAINT [FK_DocFormat_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[DocFormat] CHECK CONSTRAINT [FK_DocFormat_User1]
GO
ALTER TABLE [dms].[DocType]  WITH CHECK ADD  CONSTRAINT [FK_DocType_AppEntity] FOREIGN KEY([AppEntityId])
REFERENCES [base].[AppEntity] ([Id])
GO
ALTER TABLE [dms].[DocType] CHECK CONSTRAINT [FK_DocType_AppEntity]
GO
ALTER TABLE [dms].[DocType]  WITH CHECK ADD  CONSTRAINT [FK_DocType_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [dms].[DocType] CHECK CONSTRAINT [FK_DocType_Application]
GO
ALTER TABLE [dms].[DocType]  WITH CHECK ADD  CONSTRAINT [FK_DocType_DocFormat] FOREIGN KEY([DocFormatId])
REFERENCES [dms].[DocFormat] ([Id])
GO
ALTER TABLE [dms].[DocType] CHECK CONSTRAINT [FK_DocType_DocFormat]
GO
ALTER TABLE [dms].[DocType]  WITH CHECK ADD  CONSTRAINT [FK_DocType_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [dms].[DocType] CHECK CONSTRAINT [FK_DocType_Organization]
GO
ALTER TABLE [dms].[DocType]  WITH CHECK ADD  CONSTRAINT [FK_DocType_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[DocType] CHECK CONSTRAINT [FK_DocType_User]
GO
ALTER TABLE [dms].[DocType]  WITH CHECK ADD  CONSTRAINT [FK_DocType_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[DocType] CHECK CONSTRAINT [FK_DocType_User1]
GO
ALTER TABLE [dms].[DocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCategory_AppEntity] FOREIGN KEY([AppEntityId])
REFERENCES [base].[AppEntity] ([Id])
GO
ALTER TABLE [dms].[DocumentCategory] CHECK CONSTRAINT [FK_DocumentCategory_AppEntity]
GO
ALTER TABLE [dms].[DocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCategory_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [dms].[DocumentCategory] CHECK CONSTRAINT [FK_DocumentCategory_Application]
GO
ALTER TABLE [dms].[DocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCategory_DocumentCategory] FOREIGN KEY([ParentId])
REFERENCES [dms].[DocumentCategory] ([Id])
GO
ALTER TABLE [dms].[DocumentCategory] CHECK CONSTRAINT [FK_DocumentCategory_DocumentCategory]
GO
ALTER TABLE [dms].[DocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCategory_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [dms].[DocumentCategory] CHECK CONSTRAINT [FK_DocumentCategory_Organization]
GO
ALTER TABLE [dms].[DocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCategory_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[DocumentCategory] CHECK CONSTRAINT [FK_DocumentCategory_User]
GO
ALTER TABLE [dms].[DocumentCategory]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCategory_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [dms].[DocumentCategory] CHECK CONSTRAINT [FK_DocumentCategory_User1]
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
ALTER TABLE [rpt].[ReportGroup]  WITH CHECK ADD  CONSTRAINT [FK_ReportGroup_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [rpt].[ReportGroup] CHECK CONSTRAINT [FK_ReportGroup_Application]
GO
ALTER TABLE [rpt].[ReportGroup]  WITH CHECK ADD  CONSTRAINT [FK_ReportGroup_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [rpt].[ReportGroup] CHECK CONSTRAINT [FK_ReportGroup_Organization]
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
ALTER TABLE [rpt].[ReportStore]  WITH CHECK ADD  CONSTRAINT [FK_ReportStore_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [rpt].[ReportStore] CHECK CONSTRAINT [FK_ReportStore_Application]
GO
ALTER TABLE [rpt].[ReportStore]  WITH CHECK ADD  CONSTRAINT [FK_ReportStore_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [rpt].[ReportStore] CHECK CONSTRAINT [FK_ReportStore_Organization]
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
ALTER TABLE [tms].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [tms].[Course] CHECK CONSTRAINT [FK_Course_AccessLevel]
GO
ALTER TABLE [tms].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [tms].[Course] CHECK CONSTRAINT [FK_Course_Application]
GO
ALTER TABLE [tms].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_CourseCategory] FOREIGN KEY([CourseCategory])
REFERENCES [tms].[CourseCategory] ([Id])
GO
ALTER TABLE [tms].[Course] CHECK CONSTRAINT [FK_Course_CourseCategory]
GO
ALTER TABLE [tms].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_EducationalCenter] FOREIGN KEY([EducationalCenterId])
REFERENCES [tms].[EducationalCenter] ([Id])
GO
ALTER TABLE [tms].[Course] CHECK CONSTRAINT [FK_Course_EducationalCenter]
GO
ALTER TABLE [tms].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [tms].[Course] CHECK CONSTRAINT [FK_Course_Organization]
GO
ALTER TABLE [tms].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[Course] CHECK CONSTRAINT [FK_Course_User]
GO
ALTER TABLE [tms].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[Course] CHECK CONSTRAINT [FK_Course_User1]
GO
ALTER TABLE [tms].[CourseCategory]  WITH CHECK ADD  CONSTRAINT [FK_CourseCategory_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [tms].[CourseCategory] CHECK CONSTRAINT [FK_CourseCategory_AccessLevel]
GO
ALTER TABLE [tms].[CourseCategory]  WITH CHECK ADD  CONSTRAINT [FK_CourseCategory_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [tms].[CourseCategory] CHECK CONSTRAINT [FK_CourseCategory_Application]
GO
ALTER TABLE [tms].[CourseCategory]  WITH CHECK ADD  CONSTRAINT [FK_CourseCategory_CourseCategory] FOREIGN KEY([ParentId])
REFERENCES [tms].[CourseCategory] ([Id])
GO
ALTER TABLE [tms].[CourseCategory] CHECK CONSTRAINT [FK_CourseCategory_CourseCategory]
GO
ALTER TABLE [tms].[CourseCategory]  WITH CHECK ADD  CONSTRAINT [FK_CourseCategory_EducationalCenter] FOREIGN KEY([EducationalCenterId])
REFERENCES [tms].[EducationalCenter] ([Id])
GO
ALTER TABLE [tms].[CourseCategory] CHECK CONSTRAINT [FK_CourseCategory_EducationalCenter]
GO
ALTER TABLE [tms].[CourseCategory]  WITH CHECK ADD  CONSTRAINT [FK_CourseCategory_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [tms].[CourseCategory] CHECK CONSTRAINT [FK_CourseCategory_Organization]
GO
ALTER TABLE [tms].[CourseCategory]  WITH CHECK ADD  CONSTRAINT [FK_CourseCategory_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[CourseCategory] CHECK CONSTRAINT [FK_CourseCategory_User]
GO
ALTER TABLE [tms].[CourseCategory]  WITH CHECK ADD  CONSTRAINT [FK_CourseCategory_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[CourseCategory] CHECK CONSTRAINT [FK_CourseCategory_User1]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_AccessLevel]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_Application]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_CommonBaseData] FOREIGN KEY([ImplementaionType])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_CommonBaseData]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_CommonBaseData1] FOREIGN KEY([CourceType])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_CommonBaseData1]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_CommonBaseData2] FOREIGN KEY([Gender])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_CommonBaseData2]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_Course] FOREIGN KEY([CourseId])
REFERENCES [tms].[Course] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_Course]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_Organization]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_Representation] FOREIGN KEY([RepresentationId])
REFERENCES [tms].[Representation] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_Representation]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_User]
GO
ALTER TABLE [tms].[CoursesPlanning]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPlanning_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[CoursesPlanning] CHECK CONSTRAINT [FK_CoursesPlanning_User1]
GO
ALTER TABLE [tms].[EducationalCenter]  WITH CHECK ADD  CONSTRAINT [FK_EducationalCenter_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [tms].[EducationalCenter] CHECK CONSTRAINT [FK_EducationalCenter_AccessLevel]
GO
ALTER TABLE [tms].[EducationalCenter]  WITH CHECK ADD  CONSTRAINT [FK_EducationalCenter_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [tms].[EducationalCenter] CHECK CONSTRAINT [FK_EducationalCenter_Application]
GO
ALTER TABLE [tms].[EducationalCenter]  WITH CHECK ADD  CONSTRAINT [FK_EducationalCenter_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [tms].[EducationalCenter] CHECK CONSTRAINT [FK_EducationalCenter_Organization]
GO
ALTER TABLE [tms].[EducationalCenter]  WITH CHECK ADD  CONSTRAINT [FK_EducationalCenter_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[EducationalCenter] CHECK CONSTRAINT [FK_EducationalCenter_User]
GO
ALTER TABLE [tms].[EducationalCenter]  WITH CHECK ADD  CONSTRAINT [FK_EducationalCenter_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[EducationalCenter] CHECK CONSTRAINT [FK_EducationalCenter_User1]
GO
ALTER TABLE [tms].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [tms].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_AccessLevel]
GO
ALTER TABLE [tms].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [tms].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_Application]
GO
ALTER TABLE [tms].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [tms].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_Organization]
GO
ALTER TABLE [tms].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_Representation] FOREIGN KEY([RepresentationId])
REFERENCES [tms].[Representation] ([Id])
GO
ALTER TABLE [tms].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_Representation]
GO
ALTER TABLE [tms].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_User]
GO
ALTER TABLE [tms].[HumanResource]  WITH CHECK ADD  CONSTRAINT [FK_HumanResource_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[HumanResource] CHECK CONSTRAINT [FK_HumanResource_User1]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_AccessLevel]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_Application]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_City] FOREIGN KEY([CityId])
REFERENCES [base].[City] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_City]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_CommonBaseData] FOREIGN KEY([LicenseTypeId])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_CommonBaseData]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_CommonBaseData1] FOREIGN KEY([OwnershipTypeId])
REFERENCES [base].[CommonBaseData] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_CommonBaseData1]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_EducationalCenter] FOREIGN KEY([EducationalCenterId])
REFERENCES [tms].[EducationalCenter] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_EducationalCenter]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_Organization]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_User]
GO
ALTER TABLE [tms].[Representation]  WITH CHECK ADD  CONSTRAINT [FK_Representation_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [tms].[Representation] CHECK CONSTRAINT [FK_Representation_User1]
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
ALTER TABLE [um].[AppConfig]  WITH CHECK ADD  CONSTRAINT [FK_AppConfig_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [um].[AppConfig] CHECK CONSTRAINT [FK_AppConfig_Organization]
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
ALTER TABLE [um].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Application] FOREIGN KEY([ParentId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[Application] CHECK CONSTRAINT [FK_Application_Application]
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
ALTER TABLE [um].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_AccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [base].[AccessLevel] ([Id])
GO
ALTER TABLE [um].[Post] CHECK CONSTRAINT [FK_Post_AccessLevel]
GO
ALTER TABLE [um].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Application] FOREIGN KEY([ApplicationId])
REFERENCES [um].[Application] ([Id])
GO
ALTER TABLE [um].[Post] CHECK CONSTRAINT [FK_Post_Application]
GO
ALTER TABLE [um].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [um].[Post] CHECK CONSTRAINT [FK_Post_Organization]
GO
ALTER TABLE [um].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Post] FOREIGN KEY([ParentId])
REFERENCES [um].[Post] ([Id])
GO
ALTER TABLE [um].[Post] CHECK CONSTRAINT [FK_Post_Post]
GO
ALTER TABLE [um].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([CreateBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [um].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User1] FOREIGN KEY([ModifyBy])
REFERENCES [um].[User] ([Id])
GO
ALTER TABLE [um].[Post] CHECK CONSTRAINT [FK_Post_User1]
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
ALTER TABLE [um].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Organization] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [um].[Role] CHECK CONSTRAINT [FK_Role_Organization]
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
ALTER TABLE [um].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Organization1] FOREIGN KEY([CreatorOrganizationId])
REFERENCES [um].[Organization] ([Id])
GO
ALTER TABLE [um].[User] CHECK CONSTRAINT [FK_User_Organization1]
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
/****** Object:  StoredProcedure [dbo].[INSERT_AppEntity]    Script Date: 2/23/2020 1:05:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 10/29/2019 9:54:08 PM
 ************************************************************/
 
 
CREATE PROCEDURE [dbo].[INSERT_AppEntity]
AS
-- DROP TABLE IF EXISTS #t
SELECT t.name             Title,
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


INSERT INTO base.AppEntity 
  (
    Title,
    ObjectId,
    TitlePropertyName,
    IsLarge,
    CreateBy,
    CreationDate
  )
SELECT title,
       [object_id],
       TitleColumn,
       IsLargTable,
       1,
       GETDATE()
FROM   #t t
WHERE  t.title NOT IN (SELECT title
                           FROM   base.AppEntity)
                           
DELETE FROM base.AppEntity WHERE Title NOT IN (SELECT Title
											  FROM   #t) 
GO
/****** Object:  StoredProcedure [dbo].[INSERT_TableDesc]    Script Date: 2/23/2020 1:05:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Sp_alter]    Script Date: 2/23/2020 1:05:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 1/23/2020 9:00:39 AM
 ************************************************************/

CREATE PROCEDURE [dbo].[Sp_alter](
    @tableNameWithSchema     NVARCHAR(MAX),
    @tableName               NVARCHAR(MAX)
    
)
AS
	DECLARE @query NVARCHAR(MAX)
	SET @query = '
ALTER TABLE ' + @tableNameWithSchema +
	    ' ADD
	CreatorOrganizationId int NULL
GO
ALTER TABLE ' + @tableNameWithSchema + ' ADD CONSTRAINT
	FK_' + @tableName + 
	    '_Organization FOREIGN KEY
	(
	CreatorOrganizationId
	) REFERENCES um.Organization
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
 '
	
	PRINT  @query
GO
/****** Object:  StoredProcedure [dbo].[Sp_Udare_not_null]    Script Date: 2/23/2020 1:05:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 1/23/2020 9:54:50 AM
 ************************************************************/

CREATE PROCEDURE [dbo].[Sp_Udare_not_null](
    @tableNameWithSchema     NVARCHAR(MAX),
    @tableName               NVARCHAR(MAX)
)
AS
	DECLARE @query NVARCHAR(MAX)
	 
	SET @query = ' ALTER TABLE  ' + @tableNameWithSchema +
	    '   ALTER COLUMN 	ApplicationId  int NOT NULL'
	
	EXECUTE (@query)
	


	
GO
/****** Object:  StoredProcedure [dbo].[Sp_Udare_OrgCreator]    Script Date: 2/23/2020 1:05:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 1/23/2020 9:54:50 AM
 ************************************************************/

CREATE PROCEDURE [dbo].[Sp_Udare_OrgCreator](
    @tableNameWithSchema     NVARCHAR(MAX),
    @tableName               NVARCHAR(MAX)
)
AS
	DECLARE @query NVARCHAR(MAX)
	SET @query = ' update  ' + @tableNameWithSchema +
	    '   SET 	CreatorOrganizationId =1'
	
	EXECUTE (@query)
	


	
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AccessLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان انگلیسی جدول' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سیستمی جدول' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'ObjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان ستون نمایشی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'TitlePropertyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'با تعداد رکوردهای بزرگتر از 1000' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'IsLarge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'جدول مجازی-نتیجه شکست یک جدول  واقعی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'IsVirtualEntity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فیلد json ویژگی ها' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'Props'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان فارسی جدول' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'PersianTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان انگلیسی جدول' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'EnglishTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رکورهای جدول به تفکیک برنامه می باشد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity', @level2type=N'COLUMN',@level2name=N'ApplicationBased'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موجودیت ها' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'AppEntity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عرض جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'طول جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'CustomCategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تقسیمات کشوری' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'CountryDivisionTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مرکز استان' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'ProvinceCenter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شهر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مقدار' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع اطلاعات پايه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'CommonBaseTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مقادير اقلام پايه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع اطلاعات پايه' , @level0type=N'SCHEMA',@level0name=N'base', @level1type=N'TABLE',@level1name=N'CommonBaseType'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته های اتصال داشبورد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardConnectionString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان انگلیسی' , @level0type=N'SCHEMA',@level0name=N'dash', @level1type=N'TABLE',@level1name=N'DashboardGroup', @level2type=N'COLUMN',@level2name=N'EnglishTitle'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'DocTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام واقعی سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'OrginalName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'DocumentCategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد مالک سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'ObjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'DocumentFile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح کوتاه' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'ShortDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ترتیب نمایش' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'DisplayOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح کامل' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اسناد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'AppDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فرمت های قابل قبول' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'Extensions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فرمت سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocFormat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موجودیت' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'AppEntityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ترتیب نمایش' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'DisplayOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیا فایل روی دیسک ذخیره شود؟' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'SaveToDisk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حداکثر اندازه' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'MaxSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حداکثر تعداد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'MaxCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فرمت سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'DocFormatId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیا فایل تصویر است؟' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'IsImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیا تصویر کراپ شود؟' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'CropImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نسبت تصویر' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'AspectRatio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیا عنوان اجبرای است؟' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'IsTitleRequired'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیا نیاز به دسته بندی سند وجود دارد؟' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'IsCategorized'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد پدر' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موجودیت' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'AppEntityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد مالک' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'ObjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ترتیب نمایش' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'DisplayOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح کامل' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال بودن' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده سند' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'dms', @level1type=N'TABLE',@level1name=N'DocumentCategory', @level2type=N'COLUMN',@level2name=N'Deleted'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رشته های اتصال گزارش' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportConnectionString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان انگلیسی' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'ReportGroup', @level2type=N'COLUMN',@level2name=N'EnglishTitle'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تخصیص گزارش به کاربر' , @level0type=N'SCHEMA',@level0name=N'rpt', @level1type=N'TABLE',@level1name=N'UserReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گروه آموزشی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'CourseCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مرکز آموشی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'EducationalCenterId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'معرفی دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سرفصل دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Topic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'پیش نیاز' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Prerequisite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اهداف دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Target'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'الزامات دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Requirements'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مهارت در انتهای دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Skill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مدت دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مخاطب دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Audience'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Course'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مرکز آموزشی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'EducationalCenterId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'دسته بندي ' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CourseCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نمایندگی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'RepresentationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'قیمت دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'CourseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع برگزاری' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'ImplementaionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'CourceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ شروع' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'جنسیت' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه ريزي دوره' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'CoursesPlanning'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مرکز آموشي' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'EducationalCenter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نمایندگی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'RepresentationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سمت' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'PostId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ جذب' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'FromDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ رهایی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'ToDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'منابع انساني' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'HumanResource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مرکز آموشي' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'EducationalCenterId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شهر' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'CityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نماینده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'AgentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رایانامه (Email)' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره تلفن' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'دور نگار' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'FaxNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره مجوز' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'LicenseNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع مجوز' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'LicenseTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'متراژ' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع مالکیت' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'OwnershipTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد پستی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آدرس' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نمایندگی' , @level0type=N'SCHEMA',@level0name=N'tms', @level1type=N'TABLE',@level1name=N'Representation'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'ModifyBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان ایجاد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'CreationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان تغییر' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'برنامه' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'AccessLevelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان ایجاد کننده رکورد' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'CreatorOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سمت' , @level0type=N'SCHEMA',@level0name=N'um', @level1type=N'TABLE',@level1name=N'Post'
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
