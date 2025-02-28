USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spProduct_Update]    Script Date: 10/30/2019 5:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spProduct_Update]
	@Id int,
	@ProductName nvarchar(200),
	@BarCode nvarchar(200),
	@SerialNumber nvarchar(200),
	@SerialNumber2 nvarchar(200),
	@Size nvarchar(200),
	@Details nvarchar(500),
	@SalePrice money,
	@IncomePrice money,
	@BrandId int,
	@CategoryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Product
	SET Name = @ProductName ,
		BarCode = @BarCode,
		SerialNumber = @SerialNumber,
		SerialNumber2 = @SerialNumber2,
		Size = @Size,
		Details = @Details,
		SalePrice = @SalePrice,
		IncomePrice = @IncomePrice,
		BrandId = @BrandId,
		CategoryId = @CategoryId
	WHERE Product.Id = @Id;

END
