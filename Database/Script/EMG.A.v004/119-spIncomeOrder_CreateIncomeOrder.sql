USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spIncomeOrder_CreateIncomeOrder]    Script Date: 12/2/2019 2:30:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spIncomeOrder_CreateIncomeOrder]


	@SupplierId int ,
	@BillNumber nvarchar(200),
	@Date datetime,
	@StoreId int,
	@StaffId int,
	@Details nvarchar(500),
	@Id int = 0 output

AS
BEGIN


	SET NOCOUNT ON;

	INSERT INTO dbo.IncomeOrder(SupplierId,BillNumber,Date,StoreId,StaffId,Details)
	VALUES (@SupplierId,@BillNumber,@Date,@StoreId,@StaffId,@Details);

    SELECT @Id = SCOPE_IDENTITY();

END
