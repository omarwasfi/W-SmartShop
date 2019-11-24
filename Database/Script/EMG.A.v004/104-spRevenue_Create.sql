
CREATE PROCEDURE spRevenue_Create
	@OwnerId int,
	@Date datetime,
	@TotalMoney money,
	@StoreId int,
	@StaffId int,
	 @Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

	INSERT 	INTO Revenue(OwnerId,Date,TotalMoney,StoreId,StaffId)
	VALUES (@OwnerId,@Date,@TotalMoney,@StoreId,@StaffId) ;
			SELECT @Id = SCOPE_IDENTITY();

END
GO
