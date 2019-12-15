
CREATE PROCEDURE spOrderPayment_Delete
	@Id int
AS
BEGIN
	

	SET NOCOUNT ON;

	DELETE FROM OrderPayment
	WHERE Id = @Id;
    
END
GO
