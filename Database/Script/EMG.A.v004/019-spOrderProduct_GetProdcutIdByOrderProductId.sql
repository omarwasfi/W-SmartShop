
CREATE PROCEDURE spOrderProduct_GetProdcutIdByOrderProductId 
	
	@OrderProductId int
AS
BEGIN


	SET NOCOUNT ON;

	SELECT ProductId
	FROM OrderProduct
	WHERE Id = @OrderProductId;

END
GO
