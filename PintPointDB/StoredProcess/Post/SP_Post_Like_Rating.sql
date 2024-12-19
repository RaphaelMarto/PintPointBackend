CREATE PROCEDURE [dbo].[SP_Post_Like_Rating]
	 @Liked BIT,
     @IdUser INT,
     @IdRating INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        IF EXISTS (SELECT 1 FROM LikesRating WHERE IdUser = @IdUser AND IdRating = @IdRating)
        BEGIN
            UPDATE LikesRating
            SET Liked = @Liked
            WHERE IdUser = @IdUser AND IdRating = @IdRating;

            IF @Liked = 0
            BEGIN
                UPDATE BeersRatings
                SET Likes = Likes - 1
                WHERE Id = @IdRating;
            END
            ELSE IF @Liked = 1
            BEGIN
                UPDATE BeersRatings
                SET Likes = Likes + 1
                WHERE Id = @IdRating;
            END
        END
        ELSE
        BEGIN
            INSERT INTO LikesRating (Liked, IdUser, IdRating)
            VALUES (@Liked, @IdUser, @IdRating);

            BEGIN
                UPDATE BeersRatings
                SET Likes = Likes + 1
                WHERE Id = @IdRating;
            END
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
