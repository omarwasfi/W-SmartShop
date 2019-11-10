
CREATE PROCEDURE spOrders_GetOrderProductIdByOrderId
	@OrderId int
AS
BEGIN
	


	SET NOCOUNT ON;

	SELECT Id
	FROM OrderProduct
	WHERE OrderId = @OrderId ;

END
GO
