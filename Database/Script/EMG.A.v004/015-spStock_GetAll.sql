
ALTER PROCEDURE [dbo].[spStock_GetAll]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,
		   IncomePrice,
		   SalePrice,
		   Date,
		   ExpirationPeriod,
		   ExpirationAlarmEnabled,
		   Quantity,
		   AlarmQuantity,
		   QuantityAlarmEnabled 
	FROM Stock;

END
