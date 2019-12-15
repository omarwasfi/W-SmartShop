
CREATE PROCEDURE spOrderProduct_Update
	
	@Id int,
	@Quantity float

AS
BEGIN


	SET NOCOUNT ON;

	UPDATE OrderProduct
	SET Quantity = @Quantity
	WHERE Id = Id;
	
    
END
GO
