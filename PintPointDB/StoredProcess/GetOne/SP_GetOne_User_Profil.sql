CREATE PROCEDURE [dbo].[SP_GetOne_User_Profil]
	@NickName VARCHAR(25)
AS
BEGIN
	SELECT PictureUrl From Users WHERE NickName = @NickName
END

