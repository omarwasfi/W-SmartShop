/*
   Thursday, December 19, 20199:22:46 AM
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
ALTER TABLE dbo.StaffSalary
	DROP CONSTRAINT FK_StaffSalary_Store
GO
ALTER TABLE dbo.Store SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Store', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.StaffSalary
	DROP CONSTRAINT FK_StaffSalary_Staff
GO
ALTER TABLE dbo.StaffSalary
	DROP CONSTRAINT FK_StaffSalary_Staff1
GO
ALTER TABLE dbo.Staff SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Staff', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Staff', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Staff', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_StaffSalary
	(
	Id int NOT NULL IDENTITY (700000, 1),
	StaffId int NOT NULL,
	StoreId int NOT NULL,
	Date datetime NOT NULL,
	Salary money NOT NULL,
	Details nvarchar(500) NULL,
	ToStaffId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_StaffSalary SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_StaffSalary ON
GO
IF EXISTS(SELECT * FROM dbo.StaffSalary)
	 EXEC('INSERT INTO dbo.Tmp_StaffSalary (Id, StaffId, StoreId, Date, Salary, ToStaffId)
		SELECT Id, StaffId, StoreId, Date, Salary, ToStaffId FROM dbo.StaffSalary WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_StaffSalary OFF
GO
DROP TABLE dbo.StaffSalary
GO
EXECUTE sp_rename N'dbo.Tmp_StaffSalary', N'StaffSalary', 'OBJECT' 
GO
ALTER TABLE dbo.StaffSalary ADD CONSTRAINT
	PK_StaffSalary PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.StaffSalary ADD CONSTRAINT
	FK_StaffSalary_Staff FOREIGN KEY
	(
	StaffId
	) REFERENCES dbo.Staff
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.StaffSalary ADD CONSTRAINT
	FK_StaffSalary_Staff1 FOREIGN KEY
	(
	ToStaffId
	) REFERENCES dbo.Staff
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.StaffSalary ADD CONSTRAINT
	FK_StaffSalary_Store FOREIGN KEY
	(
	StoreId
	) REFERENCES dbo.Store
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.StaffSalary', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.StaffSalary', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.StaffSalary', 'Object', 'CONTROL') as Contr_Per 