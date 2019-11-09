
CREATE PROCEDURE spProduct_GetBrandIdByProductId

	@ProductId int
	
AS
BEGIN

	
	SET NOCOUNT ON;
	
	SELECT BrandId
	FROM Product
	WHERE Product.Id = @ProductId;

END
GO
