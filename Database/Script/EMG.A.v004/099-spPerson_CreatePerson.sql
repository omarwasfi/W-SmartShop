USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spPerson_CreatePerson]    Script Date: 11/21/2019 11:30:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spPerson_CreatePerson]
				@FirstName nvarchar(50),
                @LastName nvarchar(50),
                @PhoneNumber nvarchar(200),
                @NationalNumber nvarchar(200),
				@BirthDate datetime,
				@JopTitle nvarchar(200),
				@JopAddress nvarchar(200),
				@GradutionDate datetime,
				@Qualification nvarchar(200),
                @Email nvarchar(200),
                @Address nvarchar(200),
                @City nvarchar(100),
                @Country nvarchar(100),
				@Details nvarchar(500),

                @Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Person(FirstName,LastName,PhoneNumber,NationalNumber,BirthDate,JopTitle,JopAddress,GraduationDate,Qualification,Email,Address,City,Country,Details)
	VALUES (@FirstName,@LastName ,@PhoneNumber , @NationalNumber,@BirthDate,@JopTitle,@JopAddress,@GradutionDate,@Qualification , @Email , @Address , @City , @Country,@Details);

	SELECT @Id = SCOPE_IDENTITY();
END
