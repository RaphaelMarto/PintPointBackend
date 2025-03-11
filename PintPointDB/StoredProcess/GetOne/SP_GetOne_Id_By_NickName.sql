CREATE PROCEDURE [dbo].[SP_GetOne_Id_By_NickName]
	@NickName VARCHAR(25)
AS
BEGIN
	SELECT Id FROM Users
	WHERE NickName = @NickName
END