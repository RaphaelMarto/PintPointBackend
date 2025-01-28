CREATE PROCEDURE [dbo].[SP_GetOne_Rate]
	@IdBeer int,
	@IdUser int
AS
BEGIN
	SELECT Rate, Comment FROM BeersRatings
	WHERE IdUser = @IdUser AND IdBeer = @IdBeer
END
