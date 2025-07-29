CREATE PROCEDURE [dbo].[SP_GetOne_Pwd_Code]
	@Id int,
	@PasswordRestCode NVARCHAR(50)
AS
BEGIN
	UPDATE [dbo].[Users]
	SET PasswordResetCode = @PasswordRestCode, PasswordResetCodeExpiration = DATEADD(MINUTE, 60, GETDATE())
	WHERE Id = @Id;
END
