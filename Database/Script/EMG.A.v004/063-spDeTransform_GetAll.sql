
CREATE PROCEDURE spDeTransform_GetAll
	


AS
BEGIN


	SET NOCOUNT ON;

	SELECT Id,Date,TotalMoney
	FROM DeTransform;

END
GO
