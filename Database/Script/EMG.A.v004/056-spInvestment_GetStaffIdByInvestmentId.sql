
CREATE PROCEDURE spInvestment_GetStaffIdByInvestmentId
	
	@InvestmentId int

AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT StaffId
	FROM Investment
	WHERE  Id = @InvestmentId ;

    
END
GO
