
CREATE PROCEDURE spIncomeOrderPayment_GetAll

AS
BEGIN

	SET NOCOUNT ON;

    SELECT Id,Date,Paid
	FROM IncomeOrderPayment
END
GO
