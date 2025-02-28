USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStock_GetAll]    Script Date: 11/29/2019 4:48:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spStock_GetAll]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,
		   IncomePrice,
		   SalePrice,
		   Date,
		   ExpirationPeriodHours,
		   ExpirationAlarmEnabled,
		   Quantity,
		   AlarmQuantity,
		   QuantityAlarmEnabled 
	FROM Stock;

END
