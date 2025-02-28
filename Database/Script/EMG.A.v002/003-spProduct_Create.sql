USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_Create]    Script Date: 10/30/2019 5:22:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_Create]
	
	@ProductName nvarchar(200),
	@BarCode nvarchar(200),
	@SerialNumber nvarchar(200),
	@SerialNumber2 nvarchar(200),
	@Size nvarchar(200),
	@Details nvarchar(500),
	@SalePrice money,
	@IncomePrice money,
	@BrandId int,
	@CategoryId int,

	@Id int = 0 out 
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Product(Name,BarCode,SerialNumber,SerialNumber2,Size,Details,SalePrice,IncomePrice,BrandId,CategoryId)
	VALUES (@ProductName,@BarCode,@SerialNumber,@SerialNumber2,@Size,@Details,@SalePrice,@IncomePrice,@BrandId,@CategoryId);

	SELECT @Id = SCOPE_IDENTITY();
END
