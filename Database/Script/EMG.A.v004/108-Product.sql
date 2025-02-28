/*
   Tuesday, November 26, 20196:26:01 PM
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
	QuantityType nvarchar(200) NULL,
	Size nvarchar(200) NULL,
	BarCode nvarchar(200) NOT NULL,
	SerialNumber nvarchar(200) NULL,
	SerialNumber2 nvarchar(200) NULL,
	Details nvarchar(500) NULL,
	CategoryId int NOT NULL,
	BrandId int NOT NULL,
	SalePrice money NULL,
	IncomePrice money NULL,
	ExpirationPeriod time(7) NULL,
	AlarmQuantity int NULL
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
	 EXEC('INSERT INTO dbo.Tmp_Product (Id, Name, QuantityType, Size, BarCode, SerialNumber, SerialNumber2, Details, CategoryId, BrandId, SalePrice, IncomePrice, ExpirationPeriod, AlarmQuantity)
		SELECT Id, Name, QuantityType, Size, BarCode, SerialNumber, SerialNumber2, Details, CategoryId, BrandId, SalePrice, IncomePrice, CONVERT(time(7), ExpirationPeriod), AlarmQuantity FROM dbo.Product WITH (HOLDLOCK TABLOCKX)')
GO
COMMIT
