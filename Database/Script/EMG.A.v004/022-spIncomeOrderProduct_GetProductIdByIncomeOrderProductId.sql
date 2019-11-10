
CREATE PROCEDURE spIncomeOrderProduct_GetProductIdByIncomeOrderProductId

	@IncomeOrderProductId int

AS
BEGIN


	SET NOCOUNT ON;

	SELECT ProductId
	FROM IncomeOrderProduct
	WHERE Id = @IncomeOrderProductId;

END
GO
