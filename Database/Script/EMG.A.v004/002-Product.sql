/*
   Tuesday, November 5, 20192:56:26 PM
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
ALTER TABLE dbo.Product
	DROP CONSTRAINT FK_Product_Category
GO
ALTER TABLE dbo.Category SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Category', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Category', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Category', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Product
	DROP CONSTRAINT FK_Product_Brand
GO
ALTER TABLE dbo.Brand SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Brand', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Brand', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Brand', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Product
	DROP CONSTRAINT DF_Product_CategoryId
GO
ALTER TABLE dbo.Product
	DROP CONSTRAINT DF_Product_BrandId
GO
CREATE TABLE dbo.Tmp_Product
	(
	Id int NOT NULL IDENTITY (100000, 1),
	Name nvarchar(200) NOT NULL,
	Size nvarchar(200) NULL,
	BarCode nvarchar(200) NOT NULL,
	SerialNumber nvarchar(200) NULL,
	SerialNumber2 nvarchar(200) NULL,
	Details nvarchar(500) NULL,
	CategoryId int NOT NULL,
	BrandId int NOT NULL,
	SalePrice money NOT NULL,
	IncomePrice money NOT NULL,
	ExpirationPeriod int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Product SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Product ADD CONSTRAINT
	DF_Product_CategoryId DEFAULT ((11000)) FOR CategoryId
GO
ALTER TABLE dbo.Tmp_Product ADD CONSTRAINT
	DF_Product_BrandId DEFAULT ((10000)) FOR BrandId
GO
SET IDENTITY_INSERT dbo.Tmp_Product ON
GO
IF EXISTS(SELECT * FROM dbo.Product)
	 EXEC('INSERT INTO dbo.Tmp_Product (Id, Name, Size, BarCode, SerialNumber, SerialNumber2, Details, CategoryId, BrandId, SalePrice, IncomePrice)
		SELECT Id, Name, Size, BarCode, SerialNumber, SerialNumber2, Details, CategoryId, BrandId, SalePrice, IncomePrice FROM dbo.Product WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Product OFF
GO
ALTER TABLE dbo.OrderProduct
	DROP CONSTRAINT FK_OrderProduct_Product
GO
ALTER TABLE dbo.IncomeOrderProduct
	DROP CONSTRAINT FK_IncomeOrderProduct_Product
GO
ALTER TABLE dbo.Stock
	DROP CONSTRAINT FK_Stock_Product
GO
DROP TABLE dbo.Product
GO
EXECUTE sp_rename N'dbo.Tmp_Product', N'Product', 'OBJECT' 
GO
ALTER TABLE dbo.Product ADD CONSTRAINT
	PK_Products PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Product ADD CONSTRAINT
	FK_Product_Brand FOREIGN KEY
	(
	BrandId
	) REFERENCES dbo.Brand
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Product ADD CONSTRAINT
	FK_Product_Category FOREIGN KEY
	(
	CategoryId
	) REFERENCES dbo.Category
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Product', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.Stock SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Stock', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Stock', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Stock', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.IncomeOrderProduct SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IncomeOrderProduct', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IncomeOrderProduct', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IncomeOrderProduct', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrderProduct ADD CONSTRAINT
	FK_OrderProduct_Product FOREIGN KEY
	(
	ProductId
	) REFERENCES dbo.Product
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrderProduct SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrderProduct', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrderProduct', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrderProduct', 'Object', 'CONTROL') as Contr_Per 