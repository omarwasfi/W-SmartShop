USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spOrders_GetStoreIdByOrderId]    Script Date: 11/10/2019 4:36:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spOrders_GetStoreIdByOrderId]
	@OrderId int
AS
BEGIN

	

	SET NOCOUNT ON;

	/*
	SELECT Store.Id
	FROM Store
	INNER JOIN Orders
	ON Orders.StoreId = Store.Id
	WHERE Orders.Id = @OrderId;
	*/


	SELECT StoreId
	FROM Orders
	WHERE Orders.Id = @OrderId;
    
END
