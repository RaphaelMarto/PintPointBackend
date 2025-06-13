CREATE PROCEDURE [dbo].[SP_GetOne_User_Profil]
	@NickName NVARCHAR(50)
AS
BEGIN
	SELECT PictureUrl From Users WHERE NickName = @NickName
END

