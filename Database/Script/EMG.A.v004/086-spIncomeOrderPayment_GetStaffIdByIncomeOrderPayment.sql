
CREATE PROCEDURE spIncomeOrderPayment_GetStaffIdByIncomeOrderPayment
	@IncomeOrderPaymentId int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT StaffId
	FROM IncomeOrderPayment
	WHERE  Id = @IncomeOrderPaymentId ;

END
GO
