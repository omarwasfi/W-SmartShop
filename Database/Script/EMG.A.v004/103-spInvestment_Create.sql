USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spInvestment_Create]    Script Date: 11/24/2019 7:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spInvestment_Create]
	
	@OwnerId int,
	@Date datetime,
	@TotalMoney money,
	@StoreId int,
	@StaffId int,
	 @Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

	INSERT 	INTO Investment(OwnerId,Date,TotalMoney,StoreId,StaffId)
	VALUES (@OwnerId,@Date,@TotalMoney,@StoreId,@StaffId) ;
			SELECT @Id = SCOPE_IDENTITY();

END
