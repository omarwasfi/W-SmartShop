/*
   Wednesday, November 6, 20199:16:04 AM
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
ALTER TABLE dbo.Permission
	DROP CONSTRAINT DF_Permissions_CanSellUC
GO
ALTER TABLE dbo.Permission
	DROP CONSTRAINT DF_Permissions_CanInventoryUC
GO
ALTER TABLE dbo.Permission
	DROP CONSTRAINT DF_Permissions_CanProductManager
GO
ALTER TABLE dbo.Permission
	DROP CONSTRAINT DF_Permission_CanStaffsManagerUC
GO
CREATE TABLE dbo.Tmp_Permission
	(
	Id int NOT NULL IDENTITY (300000, 1),
	CanSellUC bit NOT NULL,
	CanSellingOrdersManagerUC bit NULL,
	CanInventoryUC bit NOT NULL,
	CanGlobalInventoryUC bit NULL,
	CanProductManagerUC bit NOT NULL,
	CanStaffsManagerUC bit NOT NULL,
	CanIncomeOrderUC bit NULL,
	CanIncomeOrderManagerUC bit NULL,
	CanInstallmentOrderUC bit NULL,
	CanCashFlowUC bit NULL,
	CanBillManagerUC bit NULL,
	CanPriceListUC bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Permission SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Permission ADD CONSTRAINT
	DF_Permissions_CanSellUC DEFAULT ((0)) FOR CanSellUC
GO
ALTER TABLE dbo.Tmp_Permission ADD CONSTRAINT
	DF_Permissions_CanInventoryUC DEFAULT ((0)) FOR CanInventoryUC
GO
ALTER TABLE dbo.Tmp_Permission ADD CONSTRAINT
	DF_Permissions_CanProductManager DEFAULT ((0)) FOR CanProductManagerUC
GO
ALTER TABLE dbo.Tmp_Permission ADD CONSTRAINT
	DF_Permission_CanStaffsManagerUC DEFAULT ((0)) FOR CanStaffsManagerUC
GO
SET IDENTITY_INSERT dbo.Tmp_Permission ON
GO
IF EXISTS(SELECT * FROM dbo.Permission)
	 EXEC('INSERT INTO dbo.Tmp_Permission (Id, CanSellUC, CanInventoryUC, CanProductManagerUC, CanStaffsManagerUC)
		SELECT Id, CanSellUC, CanInventoryUC, CanProductManagerUC, CanStaffsManagerUC FROM dbo.Permission WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Permission OFF
GO
DROP TABLE dbo.Permission
GO
EXECUTE sp_rename N'dbo.Tmp_Permission', N'Permission', 'OBJECT' 
GO
ALTER TABLE dbo.Permission ADD CONSTRAINT
	PK_Permissions PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Permission', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Permission', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Permission', 'Object', 'CONTROL') as Contr_Per 