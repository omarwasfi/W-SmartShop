/*
   Wednesday, November 20, 20199:39:34 PM
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
CREATE TABLE dbo.Tmp_Person
	(
	Id int NOT NULL IDENTITY (1000000, 1),
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NULL,
	PhoneNumber nvarchar(200) NULL,
	NationalNumber nvarchar(200) NULL,
	BirthDate datetime NULL,
	JopTitle nvarchar(200) NULL,
	JopAddress nvarchar(200) NULL,
	GraduationDate datetime NULL,
	Qualification nvarchar(200) NULL,
	Email nvarchar(200) NULL,
	Address nvarchar(200) NULL,
	City nvarchar(100) NULL,
	Country nvarchar(100) NULL,
	Details nvarchar(500) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Person SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Person ON
GO
IF EXISTS(SELECT * FROM dbo.Person)
	 EXEC('INSERT INTO dbo.Tmp_Person (Id, FirstName, LastName, PhoneNumber, NationalNumber, Email, Address, City, Country, Details)
		SELECT Id, FirstName, LastName, PhoneNumber, NationalNumber, Email, Address, City, Country, Details FROM dbo.Person WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Person OFF
GO
ALTER TABLE dbo.Customer
	DROP CONSTRAINT FK_Customers_Person
GO
ALTER TABLE dbo.Supplier
	DROP CONSTRAINT FK_Supplier_Person
GO
ALTER TABLE dbo.Owner
	DROP CONSTRAINT FK_Owner_Person
GO
ALTER TABLE dbo.Staff
	DROP CONSTRAINT FK_Staff_Person
GO
DROP TABLE dbo.Person
GO
EXECUTE sp_rename N'dbo.Tmp_Person', N'Person', 'OBJECT' 
GO
ALTER TABLE dbo.Person ADD CONSTRAINT
	PK_Person PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Person', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Person', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Person', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Staff ADD CONSTRAINT
	FK_Staff_Person FOREIGN KEY
	(
	PersonId
	) REFERENCES dbo.Person
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Staff SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Staff', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Staff', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Staff', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Owner ADD CONSTRAINT
	FK_Owner_Person FOREIGN KEY
	(
	PersonId
	) REFERENCES dbo.Person
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Owner SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Owner', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Owner', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Owner', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Supplier ADD CONSTRAINT
	FK_Supplier_Person FOREIGN KEY
	(
	PersonId
	) REFERENCES dbo.Person
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Supplier SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Supplier', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Supplier', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Supplier', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Customer ADD CONSTRAINT
	FK_Customers_Person FOREIGN KEY
	(
	PersonId
	) REFERENCES dbo.Person
	(
	Id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.Customer SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Customer', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Customer', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Customer', 'Object', 'CONTROL') as Contr_Per 