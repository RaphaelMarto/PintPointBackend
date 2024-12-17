CREATE PROCEDURE [dbo].[SP_Post_Like_Rating]
	 @Liked BIT,
     @IdUser INT,
     @IdRating INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM LikesRating WHERE IdUser = @IdUser AND IdRating = @IdRating)
    BEGIN
        UPDATE LikesRating
        SET Liked = @Liked
        WHERE IdUser = @IdUser AND IdRating = @IdRating;
    END
    ELSE
    BEGIN
        INSERT INTO LikesRating (Liked, IdUser, IdRating)
        VALUES (@Liked, @IdUser, @IdRating);
    END
END
