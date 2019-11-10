
CREATE PROCEDURE spOrders_GetStaffIdByOrderId
	@OrderId int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT StaffId
	FROM Orders
	WHERE  Id =  @OrderId;

END
GO
