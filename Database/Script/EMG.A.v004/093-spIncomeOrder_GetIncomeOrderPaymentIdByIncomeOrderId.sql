
CREATE PROCEDURE spIncomeOrder_GetIncomeOrderPaymentIdByIncomeOrderId
	
	@IncomeOrderId int

AS
BEGIN


	SET NOCOUNT ON;

   SELECT Id
   FROM IncomeOrderPayment
   WHERE IncomeOrderId = @IncomeOrderId;
END
GO
