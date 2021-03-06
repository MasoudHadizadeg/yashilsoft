/*
   Wednesday, February 5, 20205:44:01 PM
   User: sa
   Server: HADIZADEH
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
DROP INDEX IX_DashboardStore_1 ON dash.DashboardStore
GO
ALTER TABLE dash.DashboardStore SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
