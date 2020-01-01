
CREATE PROCEDURE spIncomeOrderPayment_Delete
		@Id int
AS
BEGIN

	SET NOCOUNT ON;

   DELETE FROM IncomeOrderPayment
	WHERE Id = @Id;
END
GO
