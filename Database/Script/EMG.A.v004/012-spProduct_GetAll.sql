USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_GetAll]    Script Date: 11/7/2019 1:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_GetAll]

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id,Name,Size,BarCode,SerialNumber,SerialNumber2,Details,SalePrice,IncomePrice,ExpirationPeriod,AlarmQuantity
	FROM Product;
END
