USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spIncomeOrder_GetStoreIdByIncomeOrderId]    Script Date: 11/18/2019 12:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spIncomeOrder_GetStoreIdByIncomeOrderId]
	
	@IncomeOrderId int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT StoreId
	FROM IncomeOrder
	WHERE Id = @IncomeOrderId;


END
