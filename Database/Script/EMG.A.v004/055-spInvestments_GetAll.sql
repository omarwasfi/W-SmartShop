
CREATE PROCEDURE spInvestments_GetAll
	


AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT Id , Date , TotalMoney
	FROM Investment;
    
END
GO
