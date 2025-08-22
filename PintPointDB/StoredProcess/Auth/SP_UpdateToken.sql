CREATE PROCEDURE [dbo].[SP_Update_Token]
	@UserId INT,
	@AccessToken VARCHAR(255),
	@RefreshToken VARCHAR(255),
	@RememberMe BIT
AS
BEGIN
	DECLARE @RefreshDuration INT
	SET @RefreshDuration = CASE WHEN @RememberMe = 1 THEN 30 ELSE 1 END
	UPDATE Users 
	SET AccessToken = @AccessToken, RefreshToken = @RefreshToken, UpdatedAt = GETDATE(),
		RefreshTokenExpiration = DATEADD(DAY, @RefreshDuration, GETDATE())
	WHERE Id = @UserId
END
