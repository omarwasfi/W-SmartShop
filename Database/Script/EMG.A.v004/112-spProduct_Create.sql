USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_Create]    Script Date: 11/26/2019 7:54:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_Create]
	
	@ProductName nvarchar(200),
	@QuantityType nvarchar(200),
	@Size nvarchar(200),
	@BarCode nvarchar(200),
	@SerialNumber nvarchar(200),
	@SerialNumber2 nvarchar(200),
	@Details nvarchar(500),
	@SalePrice money,
	@IncomePrice money,
	@ExpirationPeriodHours float ,
	@AlarmQuantity int,
	@BrandId int,
	@CategoryId int,

	@Id int = 0 out 
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Product
	(Name,QuantityType,Size,BarCode,SerialNumber,SerialNumber2,Details,SalePrice,IncomePrice,ExpirationPeriodHours,AlarmQuantity,BrandId,CategoryId)
	VALUES (@ProductName,@QuantityType,@Size,@BarCode,@SerialNumber,@SerialNumber2,@Details,@SalePrice,@IncomePrice,@ExpirationPeriodHours,@AlarmQuantity,@BrandId,@CategoryId);

	SELECT @Id = SCOPE_IDENTITY();
END
