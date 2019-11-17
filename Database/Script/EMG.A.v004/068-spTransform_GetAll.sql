
CREATE PROCEDURE spTransform_GetAll
	

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Id ,Date,TotalMoney
	FROM Transform

END
GO
