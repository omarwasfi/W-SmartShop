USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spIncomeOrder_GetAll]    Script Date: 11/18/2019 11:45:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spIncomeOrder_GetAll]
	

AS
BEGIN
	


	SET NOCOUNT ON;

	SELECT Id,BillNumber,Date,Details
	FROM IncomeOrder;
    
END
