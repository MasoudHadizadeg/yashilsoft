/*
   Friday, February 28, 20207:50:11 AM
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
ALTER TABLE dms.DocFormat ADD
	AllowEdit bit NULL
GO
ALTER TABLE dms.DocFormat SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
