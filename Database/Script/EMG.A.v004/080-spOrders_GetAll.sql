USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spOrders_GetAll]    Script Date: 11/17/2019 6:13:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spOrders_GetAll]

	
	
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id,DateTimeOfTheOrder,Details
	FROM Orders;

END
