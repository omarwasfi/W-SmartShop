USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStock_GetAll]    Script Date: 12/1/2019 11:56:46 AM ******/
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
		   ExpirationPeriodHours,
		   ExpirationAlarmEnabled,
		   Quantity,
		   AlarmQuantity,
		   QuantityAlarmEnabled 
	FROM Stock;

END
