
CREATE PROCEDURE spOwner_GetPersonIdByOwnerId 

	@OwnerId int

AS
BEGIN


	SET NOCOUNT ON;

	SELECT PersonId
	FROM Owner
	WHERE Id = @OwnerId ;

END
GO
