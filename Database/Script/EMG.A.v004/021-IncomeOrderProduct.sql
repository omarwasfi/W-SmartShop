/*
   Sunday, November 10, 20199:06:47 AM
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
ALTER TABLE dbo.IncomeOrderProduct
	DROP CONSTRAINT FK_IncomeOrderProduct_Product
GO
ALTER TABLE dbo.Product SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Product', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.IncomeOrderProduct
	DROP CONSTRAINT FK_IncomeOrderProduct_IncomeOrder
GO
ALTER TABLE dbo.IncomeOrder SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrder', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_IncomeOrderProduct
	(
	Id int NOT NULL IDENTITY (70000, 1),
	IncomeOrderId int NOT NULL,
	ProductId int NOT NULL,
	IncomePrice money NOT NULL,
	Quantity float(53) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_IncomeOrderProduct SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_IncomeOrderProduct ON
GO
IF EXISTS(SELECT * FROM dbo.IncomeOrderProduct)
	 EXEC('INSERT INTO dbo.Tmp_IncomeOrderProduct (Id, IncomeOrderId, ProductId, IncomePrice, Quantity)
		SELECT Id, IncomeOrderId, ProductId, IncomePrice, CONVERT(float(53), Quantity) FROM dbo.IncomeOrderProduct WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_IncomeOrderProduct OFF
GO
DROP TABLE dbo.IncomeOrderProduct
GO
EXECUTE sp_rename N'dbo.Tmp_IncomeOrderProduct', N'IncomeOrderProduct', 'OBJECT' 
GO
ALTER TABLE dbo.IncomeOrderProduct ADD CONSTRAINT
	PK_IncomeOrderProduct PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.IncomeOrderProduct ADD CONSTRAINT
	FK_IncomeOrderProduct_IncomeOrder FOREIGN KEY
	(
	IncomeOrderId
	) REFERENCES dbo.IncomeOrder
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.IncomeOrderProduct ADD CONSTRAINT
	FK_IncomeOrderProduct_Product FOREIGN KEY
	(
	ProductId
	) REFERENCES dbo.Product
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrderProduct', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrderProduct', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrderProduct', 'Object', 'CONTROL') as Contr_Per 