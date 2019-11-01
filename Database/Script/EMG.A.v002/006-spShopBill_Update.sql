
CREATE PROCEDURE spShopBill_Update

	@Id int,
	@Date datetime,
	@Details nvarchar(500),
	@TotalMoney money

AS
BEGIN



	SET NOCOUNT ON;

	UPDATE ShopBill
	SET Date = @Date,
		Details = @Details,
		TotalMoney = @TotalMoney
	WHERE ShopBill.Id = @Id;

END
GO
