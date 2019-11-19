
CREATE PROCEDURE spOrderPayment_GetStaffIdByOrderPaymentId
	
	@OrderPaymentId int

AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT StaffId
	FROM OrderPayment
	WHERE Id = @OrderPaymentId ;

END
GO
