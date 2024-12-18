CREATE PROCEDURE [dbo].[SP_CheckRefresh]
	@AccessToken VARCHAR(255),
	@RefreshToken VARCHAR(255)
AS
BEGIN
	SELECT Id FROM Users WHERE RefreshToken = @RefreshToken AND AccessToken = @AccessToken
END
