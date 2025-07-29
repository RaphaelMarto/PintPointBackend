CREATE PROCEDURE [dbo].[SP_Put_Pwd_By_Code]
	@Id int,
	@Pwd VARCHAR(255),
	@PasswordRestCode NVARCHAR(50)
AS
BEGIN
	Update [dbo].[Users]
	SET [Password] = @Pwd, UpdatedAt = GETDATE(), PasswordResetCode = null , PasswordResetCodeExpiration = null
	WHERE Id = @Id AND PasswordResetCode = @PasswordRestCode;
END
