
CREATE PROCEDURE spOrderPayment_GetAll 
	

AS
BEGIN
	

	SET NOCOUNT ON;
	
	SELECT Id,Paid,Date
	FROM OrderPayment;

END
GO
