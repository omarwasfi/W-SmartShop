USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spOrderPayment_Update]    Script Date: 12/15/2019 5:03:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spOrderPayment_Update] 
	@Id int,
	@Paid money
AS
BEGIN

	SET NOCOUNT ON;

	
	UPDATE OrderPayment
	SET Paid = @Paid
	WHERE Id = @Id;

END
