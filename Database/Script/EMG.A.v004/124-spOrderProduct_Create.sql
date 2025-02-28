USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spOrderProduct_Create]    Script Date: 12/5/2019 9:30:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[spOrderProduct_Create]
					@OrderId int,
                    @ProductId int,
					@Quantity int,
                    @SalePrice money,
                    @Discount money,
					@Profit money,
					@Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO OrderProduct(OrderId,ProductId,Quantity,SalePrice,Discount,Profit)
	VALUES (@OrderId,@ProductId,@Quantity,@SalePrice,@Discount,@Profit);
		SELECT @Id = SCOPE_IDENTITY();


END
