CREATE PROCEDURE [dbo].[SP_Sign_In]
	@Password VARCHAR(255),
	@Email VARCHAR(320)
AS
BEGIN
	SELECT Id FROM Users WHERE [Password] = @Password AND Email = @Email
END
