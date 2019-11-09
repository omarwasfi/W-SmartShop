
CREATE PROCEDURE spProduct_GetCategoryIdByProductId

	@ProductId int

AS
BEGIN



	SET NOCOUNT ON;

	SELECT CategoryId
	FROM Product
	WHERE Product.Id = @ProductId;

END
GO
