USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStaffSalary_GetToStaffIdByStaffSalaryId]    Script Date: 11/17/2019 1:02:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spStaffSalary_GetToStaffIdByStaffSalaryId]


	@StaffSalaryId int


AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT ToStaffId
	FROM StaffSalary
	WHERE Id = @StaffSalaryId; 

END
