/*
   Sunday, November 17, 20198:52:44 PM
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
ALTER TABLE dbo.IncomeOrderPayment
	DROP CONSTRAINT FK_IncomeOrderPayment_IncomeOrder
GO
ALTER TABLE dbo.IncomeOrder SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_IncomeOrderPayment
	(
	Id int NOT NULL IDENTITY (1700, 1),
	IncomeOrderId int NOT NULL,
	StaffId int NOT NULL,
	StoreId int NOT NULL,
	Paid money NOT NULL,
	Date datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_IncomeOrderPayment SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_IncomeOrderPayment ON
GO
IF EXISTS(SELECT * FROM dbo.IncomeOrderPayment)
	 EXEC('INSERT INTO dbo.Tmp_IncomeOrderPayment (Id, IncomeOrderId, Paid, Date)
		SELECT Id, IncomeOrderId, Paid, Date FROM dbo.IncomeOrderPayment WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_IncomeOrderPayment OFF
GO
DROP TABLE dbo.IncomeOrderPayment
GO
EXECUTE sp_rename N'dbo.Tmp_IncomeOrderPayment', N'IncomeOrderPayment', 'OBJECT' 
GO
ALTER TABLE dbo.IncomeOrderPayment ADD CONSTRAINT
	PK_IncomeOrderPayment PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.IncomeOrderPayment ADD CONSTRAINT
	FK_IncomeOrderPayment_IncomeOrder FOREIGN KEY
	(
	IncomeOrderId
	) REFERENCES dbo.IncomeOrder
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'CONTROL') as Contr_Per 