
CREATE PROCEDURE spRevenue_GetAll



AS
BEGIN



	SET NOCOUNT ON;

	SELECT Id , Date , TotalMoney
	FROM Revenue;


END
GO
