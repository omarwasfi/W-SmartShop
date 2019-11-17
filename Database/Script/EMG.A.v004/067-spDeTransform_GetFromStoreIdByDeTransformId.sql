
CREATE PROCEDURE spDeTransform_GetFromStoreIdByDeTransformId 
	
	@DeTransformId int
AS
BEGIN


	SET NOCOUNT ON;

	SELECT FromStoreId
	FROM DeTransform
	WHERE Id = @DeTransformId;

END
GO
