USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spIncomeOrderPayment_GetStoreIdByIncomeOrderPaymentId]    Script Date: 11/23/2019 8:15:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spIncomeOrderPayment_GetStoreIdByIncomeOrderPaymentId]
	@IncomeOrderPaymentId int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT StoreId
	FROM IncomeOrderPayment
	WHERE Id = @IncomeOrderPaymentId;

END
