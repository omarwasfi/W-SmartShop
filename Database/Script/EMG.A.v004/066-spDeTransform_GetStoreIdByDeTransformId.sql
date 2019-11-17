
CREATE PROCEDURE spDeTransform_GetStoreIdByDeTransformId
	
	@DeTransformId int

AS
BEGIN
	


	SET NOCOUNT ON;

	SELECT StoreId
	FROM DeTransform
	WHERE Id = @DeTransformId;

END
GO
