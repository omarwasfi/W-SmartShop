
CREATE PROCEDURE spTransform_GetStoreIdByTransformId
	@TransformId int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT StoreId
	FROM Transform
	WHERE Id = @TransformId ; 

END
GO
