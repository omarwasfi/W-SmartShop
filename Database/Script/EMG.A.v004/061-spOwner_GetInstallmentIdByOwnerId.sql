
CREATE PROCEDURE spOwner_GetInstallmentIdByOwnerId
	@OwnerId int
AS
BEGIN

	SET NOCOUNT ON;

    SELECT Id
	FROM Investment
	WHERE  Investment.OwnerId = @OwnerId ; 
END
GO
