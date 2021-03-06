/*
   Friday, February 28, 202012:03:43 AM
   User: 
   Server: DESKTOP-J835L8T
   Database: YashilDb
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT FK_CommonBaseData_CommonBaseType
GO
ALTER TABLE base.CommonBaseType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT FK_CommonBaseData_User
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT FK_CommonBaseData_User1
GO
ALTER TABLE um.[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT FK_CommonBaseData_Organization
GO
ALTER TABLE um.Organization SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT FK_CommonBaseData_Application
GO
ALTER TABLE um.Application SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT FK_CommonBaseData_AccessLevel
GO
ALTER TABLE base.AccessLevel SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT DF_CommonBaseData_Deleted
GO
CREATE TABLE base.Tmp_CommonBaseData
	(
	Id int NOT NULL IDENTITY (1, 1),
	Code nvarchar(150) NULL,
	ParentId int NULL,
	Title nvarchar(300) NOT NULL,
	Value int NOT NULL,
	ExtendedProps nvarchar(MAX) NULL,
	CommonBaseTypeId int NOT NULL,
	Description nvarchar(MAX) NULL,
	CreateBy int NOT NULL,
	ModifyBy int NULL,
	CreationDate datetime NOT NULL,
	ModificationDate datetime NULL,
	ApplicationId int NOT NULL,
	AccessLevelId int NOT NULL,
	Deleted bit NOT NULL,
	CreatorOrganizationId int NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE base.Tmp_CommonBaseData SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'مقادير اقلام پايه'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', NULL, NULL
GO
DECLARE @v sql_variant 
SET @v = N''
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'Id'
GO
DECLARE @v sql_variant 
SET @v = N'کد'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'Code'
GO
DECLARE @v sql_variant 
SET @v = N'عنوان'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'Title'
GO
DECLARE @v sql_variant 
SET @v = N'مقدار'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'Value'
GO
DECLARE @v sql_variant 
SET @v = N'نوع اطلاعات پايه'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'CommonBaseTypeId'
GO
DECLARE @v sql_variant 
SET @v = N'توضیحات'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'Description'
GO
DECLARE @v sql_variant 
SET @v = N'ایجاد کننده'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'CreateBy'
GO
DECLARE @v sql_variant 
SET @v = N'ویرایش کننده'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'ModifyBy'
GO
DECLARE @v sql_variant 
SET @v = N'زمان ایجاد'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'CreationDate'
GO
DECLARE @v sql_variant 
SET @v = N'زمان تغییر'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'ModificationDate'
GO
DECLARE @v sql_variant 
SET @v = N'برنامه'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'ApplicationId'
GO
DECLARE @v sql_variant 
SET @v = N'سطح دسترسی'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'AccessLevelId'
GO
DECLARE @v sql_variant 
SET @v = N'حذف شده'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'Deleted'
GO
DECLARE @v sql_variant 
SET @v = N'سازمان ایجاد کننده رکورد'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'base', N'TABLE', N'Tmp_CommonBaseData', N'COLUMN', N'CreatorOrganizationId'
GO
ALTER TABLE base.Tmp_CommonBaseData ADD CONSTRAINT
	DF_CommonBaseData_Deleted DEFAULT ((0)) FOR Deleted
GO
SET IDENTITY_INSERT base.Tmp_CommonBaseData ON
GO
IF EXISTS(SELECT * FROM base.CommonBaseData)
	 EXEC('INSERT INTO base.Tmp_CommonBaseData (Id, Code, ParentId, Title, Value, CommonBaseTypeId, Description, CreateBy, ModifyBy, CreationDate, ModificationDate, ApplicationId, AccessLevelId, Deleted, CreatorOrganizationId)
		SELECT Id, Code, ParentId, Title, Value, CommonBaseTypeId, Description, CreateBy, ModifyBy, CreationDate, ModificationDate, ApplicationId, AccessLevelId, Deleted, CreatorOrganizationId FROM base.CommonBaseData WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT base.Tmp_CommonBaseData OFF
GO
ALTER TABLE base.City
	DROP CONSTRAINT FK_City_CommonBaseData
GO
ALTER TABLE base.City
	DROP CONSTRAINT FK_City_CommonBaseData1
GO
ALTER TABLE um.Person
	DROP CONSTRAINT FK_Person_CommonBaseData
GO
ALTER TABLE um.Person
	DROP CONSTRAINT FK_Person_CommonBaseData1
GO
ALTER TABLE base.CommonBaseData
	DROP CONSTRAINT FK_CommonBaseData_CommonBaseData
GO
ALTER TABLE tms.Course
	DROP CONSTRAINT FK_Course_CommonBaseData
GO
ALTER TABLE tms.Course
	DROP CONSTRAINT FK_Course_CommonBaseData1
GO
ALTER TABLE tms.Course
	DROP CONSTRAINT FK_Course_CommonBaseData2
GO
ALTER TABLE tms.RepresentationPerson
	DROP CONSTRAINT FK_RepresentationPerson_CommonBaseData
GO
ALTER TABLE tms.CoursesPlanning
	DROP CONSTRAINT FK_CoursesPlanning_CommonBaseData1
GO
ALTER TABLE tms.CoursesPlanning
	DROP CONSTRAINT FK_CoursesPlanning_CommonBaseData2
GO
ALTER TABLE tms.Representation
	DROP CONSTRAINT FK_Representation_CommonBaseData
GO
ALTER TABLE tms.Representation
	DROP CONSTRAINT FK_Representation_CommonBaseData1
GO
ALTER TABLE tms.CoursesPlanning
	DROP CONSTRAINT FK_CoursesPlanning_CommonBaseData
GO
ALTER TABLE tms.CoursesPlanning
	DROP CONSTRAINT FK_CoursesPlanning_CommonBaseData3
GO
DROP TABLE base.CommonBaseData
GO
EXECUTE sp_rename N'base.Tmp_CommonBaseData', N'CommonBaseData', 'OBJECT' 
GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	PK_CommonBaseData PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	FK_CommonBaseData_AccessLevel FOREIGN KEY
	(
	AccessLevelId
	) REFERENCES base.AccessLevel
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	FK_CommonBaseData_Application FOREIGN KEY
	(
	ApplicationId
	) REFERENCES um.Application
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	FK_CommonBaseData_CommonBaseData FOREIGN KEY
	(
	ParentId
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	FK_CommonBaseData_Organization FOREIGN KEY
	(
	CreatorOrganizationId
	) REFERENCES um.Organization
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	FK_CommonBaseData_User FOREIGN KEY
	(
	CreateBy
	) REFERENCES um.[User]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	FK_CommonBaseData_User1 FOREIGN KEY
	(
	ModifyBy
	) REFERENCES um.[User]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.CommonBaseData ADD CONSTRAINT
	FK_CommonBaseData_CommonBaseType FOREIGN KEY
	(
	CommonBaseTypeId
	) REFERENCES base.CommonBaseType
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE tms.Representation ADD CONSTRAINT
	FK_Representation_CommonBaseData FOREIGN KEY
	(
	LicenseType
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.Representation ADD CONSTRAINT
	FK_Representation_CommonBaseData1 FOREIGN KEY
	(
	OwnershipTypeId
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.Representation SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE tms.CoursesPlanning ADD CONSTRAINT
	FK_CoursesPlanning_CommonBaseData1 FOREIGN KEY
	(
	CourceType
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.CoursesPlanning ADD CONSTRAINT
	FK_CoursesPlanning_CommonBaseData2 FOREIGN KEY
	(
	CustomGender
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.CoursesPlanning ADD CONSTRAINT
	FK_CoursesPlanning_CommonBaseData FOREIGN KEY
	(
	ImplementaionType
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.CoursesPlanning ADD CONSTRAINT
	FK_CoursesPlanning_CommonBaseData3 FOREIGN KEY
	(
	CourceStatus
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.CoursesPlanning SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE tms.RepresentationPerson ADD CONSTRAINT
	FK_RepresentationPerson_CommonBaseData FOREIGN KEY
	(
	CooperationType
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.RepresentationPerson SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE tms.Course ADD CONSTRAINT
	FK_Course_CommonBaseData FOREIGN KEY
	(
	SkillType
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.Course ADD CONSTRAINT
	FK_Course_CommonBaseData1 FOREIGN KEY
	(
	CertificateType
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.Course ADD CONSTRAINT
	FK_Course_CommonBaseData2 FOREIGN KEY
	(
	EvaluationMethod
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE tms.Course SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE um.Person ADD CONSTRAINT
	FK_Person_CommonBaseData FOREIGN KEY
	(
	EducationGrade
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE um.Person ADD CONSTRAINT
	FK_Person_CommonBaseData1 FOREIGN KEY
	(
	Gender
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE um.Person SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE base.City ADD CONSTRAINT
	FK_City_CommonBaseData FOREIGN KEY
	(
	CustomCategory
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.City ADD CONSTRAINT
	FK_City_CommonBaseData1 FOREIGN KEY
	(
	CountryDivisionType
	) REFERENCES base.CommonBaseData
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE base.City SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
