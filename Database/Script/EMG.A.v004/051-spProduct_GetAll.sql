USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_GetAll]    Script Date: 11/13/2019 2:35:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_GetAll]

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id,Name,QuantityType,Size,BarCode,SerialNumber,SerialNumber2,Details,SalePrice,IncomePrice,ExpirationPeriod,AlarmQuantity
	FROM Product;
END
