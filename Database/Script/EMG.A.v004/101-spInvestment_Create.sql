
CREATE PROCEDURE spInvestment_Create
	
	@OwnerId int,
	@Date datetime,
	@TotalMoney money,
	@StoreId int,
	@StaffId int
AS
BEGIN

	SET NOCOUNT ON;

	INSERT 	INTO Investment(OwnerId,Date,TotalMoney,StoreId,StaffId)
	VALUES (@OwnerId,@Date,@TotalMoney,@StoreId,@StaffId) ;
	
END
GO
