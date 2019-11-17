
CREATE PROCEDURE spRevenue_GetStoreIdByRevenueId
	
	@RevenueId int

AS
BEGIN



	SET NOCOUNT ON;

	SELECT StoreId
	FROM Revenue
	WHERE Id = @RevenueId;

END
GO
