
CREATE PROCEDURE spTransform_GetStaffIdByTransformId
	
	@TransformId int

AS
BEGIN
	


	SET NOCOUNT ON;

	SELECT StaffId
	FROM Transform
	WHERE Id = @TransformId;

END
GO
