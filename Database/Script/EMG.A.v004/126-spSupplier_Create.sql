USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spSupplier_Create]    Script Date: 12/8/2019 4:13:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spSupplier_Create]
	
	@PersonId int,

	@Company nvarchar(200),

	@Id int = 0 output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Supplier(PersonId , Company)
	VALUES(@PersonId,@Company);

	SELECT @Id = SCOPE_IDENTITY();
END
