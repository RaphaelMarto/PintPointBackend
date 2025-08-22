CREATE PROCEDURE [dbo].[SP_Check_Refresh]
	@AccessToken VARCHAR(255),
	@RefreshToken VARCHAR(255)
AS
BEGIN
	SELECT Id FROM Users WHERE RefreshToken = @RefreshToken AND AccessToken = @AccessToken AND RefreshTokenExpiration >= GETDATE()
END
