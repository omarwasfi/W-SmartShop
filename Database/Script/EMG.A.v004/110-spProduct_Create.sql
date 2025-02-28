USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_Create]    Script Date: 11/26/2019 6:32:40 PM ******/
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
	@ExpirationPerid time(7),
	@AlarmQuantity int,
	@BrandId int,
	@CategoryId int,

	@Id int = 0 out 
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Product
	(Name,QuantityType,Size,BarCode,SerialNumber,SerialNumber2,Details,SalePrice,IncomePrice,ExpirationPeriod,AlarmQuantity,BrandId,CategoryId)
	VALUES (@ProductName,@QuantityType,@Size,@BarCode,@SerialNumber,@SerialNumber2,@Details,@SalePrice,@IncomePrice,@ExpirationPerid,@AlarmQuantity,@BrandId,@CategoryId);

	SELECT @Id = SCOPE_IDENTITY();
END
