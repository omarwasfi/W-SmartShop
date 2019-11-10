
CREATE PROCEDURE spIncomeOrderProduct_GetAll

AS
BEGIN


	SET NOCOUNT ON;

	SELECT Id , IncomePrice , Quantity
	FROM IncomeOrderProduct;

END
GO
