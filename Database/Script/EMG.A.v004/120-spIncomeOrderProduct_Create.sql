USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spIncomeOrderProduct_Create]    Script Date: 12/2/2019 2:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spIncomeOrderProduct_Create]

	@IncomeOrderId int,
	@ProductId int,
	@IncomePrice int,
	@Quantity int,
	@Id int = 0 out 

AS
BEGIN



	SET NOCOUNT ON;

	INSERT INTO dbo.IncomeOrderProduct(IncomeOrderId,ProductId,IncomePrice,Quantity)
	VALUES (@IncomeOrderId,@ProductId,@IncomePrice,@Quantity);

		SELECT @Id = SCOPE_IDENTITY();

END
