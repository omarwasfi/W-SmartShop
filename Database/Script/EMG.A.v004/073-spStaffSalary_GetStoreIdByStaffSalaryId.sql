
CREATE PROCEDURE spStaffSalary_GetStoreIdByStaffSalaryId
	
	@StaffSalaryId int

AS
BEGIN
	


	SET NOCOUNT ON;

	SELECT StoreId
	FROM StaffSalary
	WHERE  Id = @StaffSalaryId;

END
GO
