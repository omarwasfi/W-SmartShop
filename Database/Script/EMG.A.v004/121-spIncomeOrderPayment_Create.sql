
CREATE PROCEDURE spIncomeOrderPayment_Create
		@IncomeOrderId int,
		@StaffId int,
		@StoreId int,
		@Paid money,
		@Date datetime,
		@Id int = 0 out 

AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO IncomeOrderPayment(IncomeOrderId,StaffId,StoreId,Paid,Date)
	VALUES(@IncomeOrderId,@StaffId,@StoreId,@Paid,@Date);


			SELECT @Id = SCOPE_IDENTITY();

END
GO
