
CREATE PROCEDURE spShopBill_GetStoreIdByShopBillId
	@ShopBillId int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT StoreId
	FROM ShopBill
	WHERE Id = @ShopBillId; 
END
GO
