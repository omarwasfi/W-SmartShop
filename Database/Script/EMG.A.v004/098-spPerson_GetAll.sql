USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spPerson_GetAll]    Script Date: 11/20/2019 9:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spPerson_GetAll]

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id,FirstName,LastName,PhoneNumber,NationalNumber,BirthDate,JopTitle,JopAddress,GraduationDate,Qualification,Email,Address,City,Country FROM Person;
END
