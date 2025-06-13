CREATE PROCEDURE [dbo].[SP_Check_Email_NickName]
	@NickName NVARCHAR(50),
    @Email VARCHAR(320)
AS
BEGIN
    SELECT 
        CASE WHEN EXISTS (SELECT 1 FROM Users WHERE NickName = @NickName) THEN 1 ELSE 0 END AS UserNameExists,
        CASE WHEN EXISTS (SELECT 1 FROM Users WHERE Email = @Email) THEN 1 ELSE 0 END AS EmailExists
END
