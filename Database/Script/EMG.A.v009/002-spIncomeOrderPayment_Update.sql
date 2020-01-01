
CREATE PROCEDURE spIncomeOrderPayment_Update
	@Id int,
	@Paid money
AS
BEGIN

	SET NOCOUNT ON;
	
	UPDATE IncomeOrderPayment
	SET Paid = @Paid
	WHERE Id = @Id;
    
END
GO
