
CREATE PROCEDURE spOrderPayment_Update 
	@Id int,
	@Paid money
AS
BEGIN

	SET NOCOUNT ON;

	
	UPDATE OrderPayment
	SET Paid = @Paid
	WHERE Id = Id;

END
GO
