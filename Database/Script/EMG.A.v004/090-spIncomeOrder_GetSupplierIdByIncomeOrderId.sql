
CREATE PROCEDURE spIncomeOrder_GetSupplierIdByIncomeOrderId 
	
	@IncomeOrderId int

AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT SupplierId
	FROM IncomeOrder
	WHERE Id = @IncomeOrderId;

END
GO
