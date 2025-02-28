/*
   Tuesday, November 12, 20198:09:02 PM
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
ALTER TABLE dbo.Store SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Store', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Staff SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Staff', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Staff', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Staff', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Revenue
	DROP CONSTRAINT FK_Revenue_Owner
GO
ALTER TABLE dbo.Owner SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Owner', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Owner', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Owner', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Revenue
	(
	Id int NOT NULL IDENTITY (1300, 1),
	OwnerId int NOT NULL,
	Date datetime NOT NULL,
	TotalMoney money NOT NULL,
	StaffId int NOT NULL,
	StoreId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Revenue SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Revenue ON
GO
IF EXISTS(SELECT * FROM dbo.Revenue)
	 EXEC('INSERT INTO dbo.Tmp_Revenue (Id, OwnerId, Date, TotalMoney)
		SELECT Id, OwnerId, Date, TotalMoney FROM dbo.Revenue WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Revenue OFF
GO
DROP TABLE dbo.Revenue
GO
EXECUTE sp_rename N'dbo.Tmp_Revenue', N'Revenue', 'OBJECT' 
GO
ALTER TABLE dbo.Revenue ADD CONSTRAINT
	PK_Revenue PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Revenue ADD CONSTRAINT
	FK_Revenue_Owner FOREIGN KEY
	(
	OwnerId
	) REFERENCES dbo.Owner
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Revenue ADD CONSTRAINT
	FK_Revenue_Staff FOREIGN KEY
	(
	StaffId
	) REFERENCES dbo.Staff
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Revenue ADD CONSTRAINT
	FK_Revenue_Store FOREIGN KEY
	(
	StoreId
	) REFERENCES dbo.Store
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Revenue', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Revenue', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Revenue', 'Object', 'CONTROL') as Contr_Per 