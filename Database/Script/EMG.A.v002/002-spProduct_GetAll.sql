USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_GetAll]    Script Date: 10/30/2019 4:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_GetAll]

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id,Name,BarCode,SerialNumber,SerialNumber2,Size,Details,SalePrice,IncomePrice
	FROM Product
END
