CREATE PROCEDURE [dbo].[SP_Get_Password]
	@Email VARCHAR(255)
AS
BEGIN
	SELECT [Password] FROM Users WHERE Email = @Email
END
