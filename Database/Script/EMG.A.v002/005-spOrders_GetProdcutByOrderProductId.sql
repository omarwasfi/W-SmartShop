USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spOrders_GetProdcutByOrderProductId]    Script Date: 10/30/2019 5:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spOrders_GetProdcutByOrderProductId]
	
	@OrderProductId int

AS
BEGIN
	
	
	
	SET NOCOUNT ON;

	SELECT Product.Id,Name,BarCode,SerialNumber,SerialNumber2,Size,Details,Product.SalePrice,IncomePrice
	FROM Product
	INNER JOIN OrderProduct
	ON  OrderProduct.ProductId = Product.Id
	where OrderProduct.Id = @OrderProductId ;

END
