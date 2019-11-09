
CREATE PROCEDURE spSupplier_GetPersonIdBySupplierId 
	
	@SupplierId int
		
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Supplier.PersonId
	FROM Supplier
	WHERE Supplier.Id = @SupplierId;

END
GO
