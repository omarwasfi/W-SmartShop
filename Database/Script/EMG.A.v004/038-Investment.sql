/*
   Tuesday, November 12, 20198:12:58 PM
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
ALTER TABLE dbo.Investment
	DROP CONSTRAINT FK_Investment_Owner
GO
ALTER TABLE dbo.Owner SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Owner', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Owner', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Owner', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Investment
	(
	Id int NOT NULL IDENTITY (1200, 1),
	OwnerId int NOT NULL,
	Date datetime NOT NULL,
	TotalMoney money NOT NULL,
	StoreId int NOT NULL,
	StaffId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Investment SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Investment ON
GO
IF EXISTS(SELECT * FROM dbo.Investment)
	 EXEC('INSERT INTO dbo.Tmp_Investment (Id, OwnerId, Date, TotalMoney)
		SELECT Id, OwnerId, Date, TotalMoney FROM dbo.Investment WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Investment OFF
GO
DROP TABLE dbo.Investment
GO
EXECUTE sp_rename N'dbo.Tmp_Investment', N'Investment', 'OBJECT' 
GO
ALTER TABLE dbo.Investment ADD CONSTRAINT
	PK_Investment PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Investment ADD CONSTRAINT
	FK_Investment_Owner FOREIGN KEY
	(
	OwnerId
	) REFERENCES dbo.Owner
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Investment', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Investment', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Investment', 'Object', 'CONTROL') as Contr_Per 