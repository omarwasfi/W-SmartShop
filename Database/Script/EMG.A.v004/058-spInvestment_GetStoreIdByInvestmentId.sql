USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spInvestment_GetStoreIdByInvestmentId]    Script Date: 11/16/2019 10:09:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spInvestment_GetStoreIdByInvestmentId]
	
	@InvestmentId int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT StoreId
	FROM Investment
	WHERE Id = @InvestmentId ; 


END
