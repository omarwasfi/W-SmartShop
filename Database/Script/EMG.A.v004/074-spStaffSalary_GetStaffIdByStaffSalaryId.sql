
CREATE PROCEDURE spStaffSalary_GetStaffIdByStaffSalaryId 
	
	@StaffSalaryId int


AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT StaffId
	FROM StaffSalary
	WHERE Id = @StaffSalaryId; 

END
GO
