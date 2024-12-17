CREATE PROCEDURE [dbo].[SP_GetOne_Likes_Rating]
	@IdUser int,
	@IdRating int
AS
BEGIN
	SELECT Liked FROM LikesRating WHERE IdUser = @IdUser AND IdRating = @IdRating
END
