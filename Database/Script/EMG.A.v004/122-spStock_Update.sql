USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStock_Update]    Script Date: 12/2/2019 3:47:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spStock_Update]
	@Id int,
	@Date datetime,
	@AlarmQuantity int,
	@QuantityAlarmEnabled bit,
	@Quantity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE Stock 
	SET 
	Date = @Date,
	AlarmQuantity = @AlarmQuantity,
	QuantityAlarmEnabled = @QuantityAlarmEnabled,
	Quantity = @Quantity
	WHERE Stock.Id = @Id;
END
