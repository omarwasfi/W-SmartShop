USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spOrderProduct_GetAll]    Script Date: 11/10/2019 12:05:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spOrderProduct_GetAll]


AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,Quantity,SalePrice,Discount,Profit
	FROM OrderProduct

END
