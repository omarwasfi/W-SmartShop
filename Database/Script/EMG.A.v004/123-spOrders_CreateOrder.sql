USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spOrders_CreateOrder]    Script Date: 12/4/2019 11:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spOrders_CreateOrder] 
	
	@CustomerId int,
	@DateTimeOfTheOrder datetime,
	@StoreId int,
	@StaffId int,
	@Details nvarchar(500),
	@Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.Orders(CustomerId,DateTimeOfTheOrder,StoreId,StaffId,Details)
	VALUES (@CustomerId,@DateTimeOfTheOrder,@StoreId,@StaffId,@Details);

	SELECT @Id = SCOPE_IDENTITY();
	
END
