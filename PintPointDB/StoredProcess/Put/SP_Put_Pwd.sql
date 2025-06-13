CREATE PROCEDURE [dbo].[SP_Put_Pwd]
	@Id int,
	@Pwd VARCHAR(255)
AS
BEGIN
	Update [dbo].[Users]
	SET [Password] = @Pwd, UpdatedAt = GETDATE()
	WHERE Id = @Id;
END
