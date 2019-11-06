
CREATE PROCEDURE spStaff_GetPersonIdByStaffId 
	
	@StaffId int

AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT Staff.PersonId
	FROM Staff 
	WHERE Staff.Id = @StaffId;
	

END
GO
