
CREATE PROCEDURE spOrderPayment_Create
		@OrderId int,
		@StaffId int,
		@StoreId int,
		@Paid money,
		@Date datetime,
		@Id int = 0 out 
AS
BEGIN

	SET NOCOUNT ON;
  INSERT INTO OrderPayment(OrderId,StaffId,StoreId,Paid,Date)
	VALUES(@OrderId,@StaffId,@StoreId,@Paid,@Date);


			SELECT @Id = SCOPE_IDENTITY();
END
GO
