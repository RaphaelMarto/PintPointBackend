CREATE PROCEDURE [dbo].[SP_Update_Refresh_Token]
	@UserId INT,
	@AccessToken VARCHAR(255),
	@RefreshToken VARCHAR(255)
AS
BEGIN
	UPDATE Users 
	SET AccessToken = @AccessToken, RefreshToken = @RefreshToken, UpdatedAt = GETDATE()
	WHERE Id = @UserId
END
