/*
   Saturday, November 9, 201910:44:00 PM
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
ALTER TABLE dbo.OrderProduct
	DROP CONSTRAINT FK_OrderProduct_Product
GO
ALTER TABLE dbo.Product SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Product', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrderProduct
	DROP CONSTRAINT FK_OrderProduct_Order
GO
ALTER TABLE dbo.Orders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Orders', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Orders', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Orders', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrderProduct
	DROP CONSTRAINT DF_OrderProduct_OrderId
GO
ALTER TABLE dbo.OrderProduct
	DROP CONSTRAINT DF_OrderProduct_ProductId
GO
CREATE TABLE dbo.Tmp_OrderProduct
	(
	Id int NOT NULL IDENTITY (50000, 1),
	OrderId int NOT NULL,
	ProductId int NOT NULL,
	Quantity float(53) NOT NULL,
	SalePrice money NOT NULL,
	Discount money NOT NULL,
	Profit money NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_OrderProduct SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_OrderProduct ADD CONSTRAINT
	DF_OrderProduct_OrderId DEFAULT ((200000)) FOR OrderId
GO
ALTER TABLE dbo.Tmp_OrderProduct ADD CONSTRAINT
	DF_OrderProduct_ProductId DEFAULT ((100000)) FOR ProductId
GO
SET IDENTITY_INSERT dbo.Tmp_OrderProduct ON
GO
IF EXISTS(SELECT * FROM dbo.OrderProduct)
	 EXEC('INSERT INTO dbo.Tmp_OrderProduct (Id, OrderId, ProductId, Quantity, SalePrice, Discount, Profit)
		SELECT Id, OrderId, ProductId, CONVERT(float(53), Quantity), SalePrice, Discount, Profit FROM dbo.OrderProduct WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_OrderProduct OFF
GO
DROP TABLE dbo.OrderProduct
GO
EXECUTE sp_rename N'dbo.Tmp_OrderProduct', N'OrderProduct', 'OBJECT' 
GO
ALTER TABLE dbo.OrderProduct ADD CONSTRAINT
	PK_OrderItems PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.OrderProduct ADD CONSTRAINT
	FK_OrderProduct_Order FOREIGN KEY
	(
	OrderId
	) REFERENCES dbo.Orders
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
COMMIT
select Has_Perms_By_Name(N'dbo.OrderProduct', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrderProduct', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrderProduct', 'Object', 'CONTROL') as Contr_Per 