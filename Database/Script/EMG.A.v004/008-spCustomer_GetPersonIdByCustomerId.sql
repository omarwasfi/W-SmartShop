
CREATE PROCEDURE spCustomer_GetPersonIdByCustomerId
	
	@CustomerId int
AS
BEGIN


	SET NOCOUNT ON;

	SELECT Customer.PersonId
	FROM Customer
	WHERE Customer.Id = @CustomerId;

END
GO
