USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStock_Create]    Script Date: 12/2/2019 11:51:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spStock_Create] 

	@SBarCode nvarchar(200),
	@StoreId int,
	@ProductId int,
	@IncomePrice money,
	@SalePrice money,
	@Date datetime,
	@ExpirationPeriodHours float,
	@ExpirationAlarmEnabled bit,
	@Quantity int,
	@AlarmQuantity int,
	@QuantityAlarmEnabled bit,
	@Id int = 0 out
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO 
	Stock
	(SBarCode,
	StoreId,
	ProductId,
	IncomePrice,
	SalePrice,
	Date,
	ExpirationPeriodHours,
	ExpirationAlarmEnabled,
	Quantity,
	AlarmQuantity,
	QuantityAlarmEnabled)
	VALUES 
	(@SBarCode,
	@StoreId,
	@ProductId,
	@IncomePrice,
	@SalePrice,
	@Date,
	@ExpirationPeriodHours,
	@ExpirationAlarmEnabled,
	@Quantity,
	@AlarmQuantity
	,@QuantityAlarmEnabled);

	SELECT @Id = SCOPE_IDENTITY();

END
