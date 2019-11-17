
CREATE PROCEDURE spStaffSalary_GetAll
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Id,Date,Salary
	FROM StaffSalary;
  
END
GO
