
CREATE PROCEDURE spShopBill_Delete
	@Id int
AS
BEGIN


	SET NOCOUNT ON;

	DELETE FROM ShopBill
	WHERE ShopBill.Id = @Id;

END
GO
