USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spDeTransform_GetStaffIdByDeTransformId]    Script Date: 11/17/2019 8:29:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spDeTransform_GetStaffIdByDeTransformId]
	
	@DeTransformId int

AS
BEGIN


	SET NOCOUNT ON;

	SELECT StaffId
	FROM DeTransform
	WHERE Id = @DeTransformId;

END
