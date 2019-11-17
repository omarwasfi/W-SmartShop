

CREATE PROCEDURE spTransform_GetToStoreIdByTransformId
	

	@TransformId int
AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT ToStoreId
	FROM Transform
	WHERE Id = @TransformId  ; 
    
END
GO
