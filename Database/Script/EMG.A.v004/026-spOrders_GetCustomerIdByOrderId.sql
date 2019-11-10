
CREATE PROCEDURE spOrders_GetCustomerIdByOrderId
	 @OrderId int
AS
BEGIN
	


	SET NOCOUNT ON;

	SELECT CustomerId
	FROM Orders
	WHERE Id = @OrderId;
    
END
GO
