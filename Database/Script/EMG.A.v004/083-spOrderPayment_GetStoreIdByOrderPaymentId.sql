
CREATE PROCEDURE spOrderPayment_GetStoreIdByOrderPaymentId
	@OrderPaymentId int
AS
BEGIN
	

	SET NOCOUNT ON;

	SELECT StoreId
	FROM OrderPayment
	WHERE Id = @OrderPaymentId;
    
END
GO
