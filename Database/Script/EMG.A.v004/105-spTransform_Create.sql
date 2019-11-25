
CREATE PROCEDURE spTransform_Create 
	
	@StaffId int,
	@StoreId int,
	@Date DateTime,
	@TotalMoney money,
	@ToStoreId int,
		 @Id int = 0 output


AS
BEGIN
	
	SET NOCOUNT ON;
	
	INSERT INTO Transform(StaffId,StoreId,Date,TotalMoney,ToStoreId)
	VALUES(@StaffId,@StoreId,@Date,@TotalMoney,@ToStoreId);

				SELECT @Id = SCOPE_IDENTITY();
END
GO
