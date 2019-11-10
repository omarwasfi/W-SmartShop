
CREATE PROCEDURE spOrderProduct_GetAll


AS
BEGIN

	SET NOCOUNT ON;

	SELECT Quantity,SalePrice,Discount,Profit
	FROM OrderProduct

END
GO
