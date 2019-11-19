
CREATE PROCEDURE spOrder_GetOrderPaymentIdByOrderId
	@OrderId int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Id
	FROM OrderPayment
	WHERE OrderId = @OrderId;
  
END
GO
