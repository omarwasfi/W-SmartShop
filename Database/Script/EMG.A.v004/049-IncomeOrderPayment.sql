/*
   Wednesday, November 13, 201912:53:53 AM
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
ALTER TABLE dbo.IncomeOrder SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.IncomeOrderPayment SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'CONTROL') as Contr_Per 