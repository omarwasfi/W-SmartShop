USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_Update]    Script Date: 12/17/2019 12:01:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_Update]
	@Id int,
	@ProductName nvarchar(200),
	@QuantityType nvarchar(200),
	@Size nvarchar(200),
	@Details nvarchar(500),
	@SalePrice money,
	@IncomePrice money,
	@ExpirationPeriodHours float,
	@AlarmQuantity int,
	@BrandId int,
	@CategoryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Product
	SET Name = @ProductName ,
		QuantityType = @QuantityType,
		Size = @Size,
		Details = @Details,
		SalePrice = @SalePrice,
		IncomePrice = @IncomePrice,
		ExpirationPeriodHours  = @ExpirationPeriodHours,
		AlarmQuantity = @AlarmQuantity,
		BrandId = @BrandId,
		CategoryId = @CategoryId
	WHERE Product.Id = @Id;

END
