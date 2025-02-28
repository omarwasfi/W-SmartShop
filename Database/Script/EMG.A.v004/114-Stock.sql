/*
   Friday, November 29, 20194:02:50 PM
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
ALTER TABLE dbo.Stock
	DROP CONSTRAINT FK_Stock_Product
GO
ALTER TABLE dbo.Product SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Product', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Stock
	DROP CONSTRAINT FK_Stock_Store
GO
ALTER TABLE dbo.Store SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Store', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Stock
	DROP CONSTRAINT DF_Stock_Quantity
GO
CREATE TABLE dbo.Tmp_Stock
	(
	Id int NOT NULL IDENTITY (12000, 1),
	StoreId int NOT NULL,
	ProductId int NOT NULL,
	IncomePrice money NULL,
	SalePrice money NULL,
	Date datetime NULL,
	ExpirationPeriodHours float(53) NULL,
	ExpirationAlarmEnabled bit NULL,
	Quantity float(53) NOT NULL,
	AlarmQuantity int NULL,
	QuantityAlarmEnabled bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Stock SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Stock ADD CONSTRAINT
	DF_Stock_Quantity DEFAULT ((0)) FOR Quantity
GO
SET IDENTITY_INSERT dbo.Tmp_Stock ON
GO
IF EXISTS(SELECT * FROM dbo.Stock)
	 EXEC('INSERT INTO dbo.Tmp_Stock (Id, StoreId, ProductId, IncomePrice, SalePrice, Date, ExpirationPeriodHours, ExpirationAlarmEnabled, Quantity, AlarmQuantity, QuantityAlarmEnabled)
		SELECT Id, StoreId, ProductId, IncomePrice, SalePrice, Date, CONVERT(float(53), ExpirationPeriod), ExpirationAlarmEnabled, Quantity, AlarmQuantity, QuantityAlarmEnabled FROM dbo.Stock WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Stock OFF
GO
DROP TABLE dbo.Stock
GO
EXECUTE sp_rename N'dbo.Tmp_Stock', N'Stock', 'OBJECT' 
GO
ALTER TABLE dbo.Stock ADD CONSTRAINT
	PK_Stock PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Stock ADD CONSTRAINT
	FK_Stock_Store FOREIGN KEY
	(
	StoreId
	) REFERENCES dbo.Store
	(
	Id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.Stock ADD CONSTRAINT
	FK_Stock_Product FOREIGN KEY
	(
	ProductId
	) REFERENCES dbo.Product
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Stock', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Stock', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Stock', 'Object', 'CONTROL') as Contr_Per 