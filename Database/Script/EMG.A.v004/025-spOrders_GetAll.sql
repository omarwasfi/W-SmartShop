
ALTER PROCEDURE [dbo].[spOrders_GetAll]

	
	
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id,DateTimeOfTheOrder,Paid,LastPaymentDate,Details
	FROM Orders;

END
