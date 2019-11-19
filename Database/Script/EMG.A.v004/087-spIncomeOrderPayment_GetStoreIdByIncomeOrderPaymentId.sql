
CREATE PROCEDURE spIncomeOrderPayment_GetStoreIdByIncomeOrderPaymentId
	@IncomeOrderPayment int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT StoreId
	FROM IncomeOrderPayment
	WHERE Id = @IncomeOrderPayment;

END
GO
