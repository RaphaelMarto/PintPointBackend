CREATE PROCEDURE [dbo].[SP_Put_Rating]
	@Rate DECIMAL(4,2),
	@Comment VARCHAR(1500),
	@IdBeer INT,
	@IdUser INT
AS
BEGIN
	UPDATE BeersRatings
	SET Rate = @Rate, Comment = @Comment, UpdatedAt = GETDATE()
	WHERE IdBeer = @IdBeer AND IdUser = @IdUser
END
