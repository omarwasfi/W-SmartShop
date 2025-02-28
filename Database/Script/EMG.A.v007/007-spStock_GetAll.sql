USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStock_GetAll]    Script Date: 12/23/2019 9:35:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spStock_GetAll]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,
	SBarCode,
		   IncomePrice,
		   SalePrice,
		   Date,
		   ExpirationDate,
		   NotificationDate,
		   ExpirationAlarmEnabled,
		   Quantity,
		   AlarmQuantity,
		   QuantityAlarmEnabled 
	FROM Stock;

END
