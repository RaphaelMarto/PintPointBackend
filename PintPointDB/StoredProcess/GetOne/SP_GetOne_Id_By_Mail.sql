CREATE PROCEDURE [dbo].[SP_GetOne_Id_By_Mail]
	@email varchar(320)
AS
BEGIN
	SELECT Id FROM DBO.Users where Email = @email
END
