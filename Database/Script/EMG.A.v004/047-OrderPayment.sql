/*
   Wednesday, November 13, 201912:47:35 AM
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
ALTER TABLE dbo.Orders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Orders', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Orders', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Orders', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_OrderPayment
	(
	Id int NOT NULL IDENTITY (1600, 1),
	OrderId int NOT NULL,
	Paid money NOT NULL,
	Date datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_OrderPayment SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_OrderPayment ON
GO
IF EXISTS(SELECT * FROM dbo.OrderPayment)
	 EXEC('INSERT INTO dbo.Tmp_OrderPayment (Id, OrderId, Paid, Date)
		SELECT Id, OrderId, Paid, Date FROM dbo.OrderPayment WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_OrderPayment OFF
GO
DROP TABLE dbo.OrderPayment
GO
EXECUTE sp_rename N'dbo.Tmp_OrderPayment', N'OrderPayment', 'OBJECT' 
GO
ALTER TABLE dbo.OrderPayment ADD CONSTRAINT
	PK_OrderPayment PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.OrderPayment ADD CONSTRAINT
	FK_OrderPayment_Orders FOREIGN KEY
	(
	OrderId
	) REFERENCES dbo.Orders
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrderPayment', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrderPayment', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrderPayment', 'Object', 'CONTROL') as Contr_Per 