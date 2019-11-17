
CREATE PROCEDURE spRevenue_GetStaffIdByRevenueId 
	@RevenueId int
AS
BEGIN


	SET NOCOUNT ON;

	SELECT StaffId
	FROM Revenue
	WHERE Id = @RevenueId;

END
GO
