USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_GetAll]    Script Date: 11/26/2019 8:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_GetAll]

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id,Name,QuantityType,Size,BarCode,SerialNumber,SerialNumber2,Details,SalePrice,IncomePrice,ExpirationPeriodHours,AlarmQuantity
	FROM Product;
END
