/*
   Wednesday, November 13, 201912:52:40 AM
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
CREATE TABLE dbo.IncomeOrderPayment
	(
	Id int NOT NULL IDENTITY (1700, 1),
	IncomeOrderId int NOT NULL,
	Paid money NOT NULL,
	Date datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.IncomeOrderPayment ADD CONSTRAINT
	PK_IncomeOrderPayment PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.IncomeOrderPayment SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrderPayment', 'Object', 'CONTROL') as Contr_Per 