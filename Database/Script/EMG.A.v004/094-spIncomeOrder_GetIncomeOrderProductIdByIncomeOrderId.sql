
CREATE PROCEDURE spIncomeOrder_GetIncomeOrderProductIdByIncomeOrderId 
	
	@IncomeOrderId int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Id
	FROM IncomeOrderProduct
	WHERE IncomeOrderId = @IncomeOrderId;

END
GO
