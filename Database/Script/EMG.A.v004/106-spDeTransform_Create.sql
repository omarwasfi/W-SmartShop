
CREATE PROCEDURE spDeTransform_Create
	
	@StaffId int,
	@StoreId int,
	@Date DateTime,
	@TotalMoney money,
	@FromStoreId int,
		 @Id int = 0 output
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO DeTransform(StaffId,StoreId,Date,TotalMoney,FromStoreId)
	VALUES(@StaffId,@StoreId,@Date,@TotalMoney,@FromStoreId);

				SELECT @Id = SCOPE_IDENTITY();
END
GO
