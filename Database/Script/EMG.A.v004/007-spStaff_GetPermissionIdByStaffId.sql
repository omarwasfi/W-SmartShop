
CREATE PROCEDURE spStaff_GetPermissionIdByStaffId 
	@StaffId int
AS
BEGIN



	SET NOCOUNT ON;

	SELECT Staff.PermissionId
	FROM Staff
	WHERE Staff.Id = @StaffId;

END
GO
