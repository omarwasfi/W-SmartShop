
CREATE PROCEDURE spIncomeOrder_GetStaffIdByIncomeOrderId
	@IncomeOrderId int
AS
BEGIN


	SET NOCOUNT ON;

	SELECT StaffId
	FROM IncomeOrder
	WHERE Id = @IncomeOrderId;
    
END
GO
