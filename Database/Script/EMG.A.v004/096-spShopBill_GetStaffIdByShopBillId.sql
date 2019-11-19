
CREATE PROCEDURE spShopBill_GetStaffIdByShopBillId
	@ShopBillId int
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT StaffId
	FROM ShopBill
	WHERE Id = @ShopBillId;
END
GO
