CREATE PROCEDURE [dbo].[SP_GetOne_User]
	@UserId int
AS
BEGIN
	SELECT * From Users WHERE Id = @UserId
END
