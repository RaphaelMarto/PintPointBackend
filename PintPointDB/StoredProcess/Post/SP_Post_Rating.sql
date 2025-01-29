CREATE PROCEDURE [dbo].[SP_Post_Rating]
	@Rate DECIMAL(4,2),
	@Comment VARCHAR(1500),
	@IdBeer INT,
	@IdUser INT
AS
BEGIN
	INSERT INTO BeersRatings (Rate, Comment, IdBeer, IdUser, Likes, CreatedAt, UpdatedAt) VALUES (@Rate, @Comment, @IdBeer, @IdUser, 0, GETDATE(), GETDATE())

	DECLARE @AvgRating DECIMAL(4,2);

	SELECT @AvgRating = AVG(Rate) FROM BeersRatings 
	WHERE IdBeer = @IdBeer;

	UPDATE Beers SET Rating = @AvgRating
	WHERE Id = @IdBeer;
END
