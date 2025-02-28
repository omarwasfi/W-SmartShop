/*
   Tuesday, November 12, 201910:58:56 PM
   User: 
   Server: WASFI\SQLEXPRESS
   Database: SmartShopDatabase
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
CREATE TABLE dbo.Transform
	(
	Id int NOT NULL IDENTITY (1400, 1),
	StaffId int NOT NULL,
	StoreId int NOT NULL,
	Date datetime NOT NULL,
	TotalMoney money NOT NULL,
	ToStoreId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Transform ADD CONSTRAINT
	PK_Transform PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Transform SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Transform', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Transform', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Transform', 'Object', 'CONTROL') as Contr_Per 