
CREATE PROCEDURE spOwner_GetRevenueIdByOwner
	
	@OwnerId int

AS
BEGIN


	SET NOCOUNT ON;

   SELECT Id
   FROM Revenue
   WHERE Revenue.OwnerId = @OwnerId;

END
GO
