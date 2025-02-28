USE [SmartShopDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spStock_Create]    Script Date: 12/24/2019 3:12:38 PM ******/
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
	@ExpirationDate float,
	@NotificationDate float,
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
	ExpirationDate,
	NotificationDate,
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
	@ExpirationDate,
	@NotificationDate,
	@ExpirationAlarmEnabled,
	@Quantity,
	@AlarmQuantity
	,@QuantityAlarmEnabled);

	SELECT @Id = SCOPE_IDENTITY();

END
