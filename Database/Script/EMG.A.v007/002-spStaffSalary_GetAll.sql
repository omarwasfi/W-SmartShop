USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStaffSalary_GetAll]    Script Date: 12/19/2019 9:27:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spStaffSalary_GetAll]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Id,Date,Salary,Details
	FROM StaffSalary;
  
END
