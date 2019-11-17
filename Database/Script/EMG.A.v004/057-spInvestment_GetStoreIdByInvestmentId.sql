
CREATE PROCEDURE spInvestment_GetStoreIdByInvestmentId
	
	@InvestmentId int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT StoreId
	FROM Investment
	WHERE StoreId = @InvestmentId ; 


END
GO
