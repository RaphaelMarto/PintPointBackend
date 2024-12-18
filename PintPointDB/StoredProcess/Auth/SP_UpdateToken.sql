CREATE PROCEDURE [dbo].[SP_UpdateToken]
	@UserId INT,
	@AccessToken VARCHAR(255),
	@RefreshToken VARCHAR(255)
AS
BEGIN
	UPDATE Users 
	SET AccessToken = @AccessToken, RefreshToken = @RefreshToken
	WHERE Id = @UserId
END
