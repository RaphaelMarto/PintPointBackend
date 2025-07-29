CREATE PROCEDURE [dbo].[SP_Put_Verified]
	@Id int,
	@VerificationCode NVARCHAR(50)
AS
BEGIN
	UPDATE [dbo].[Users] SET [VerifiedAt] = GETDATE(), [VerificationCode] = null WHERE [Id] = @Id AND [VerificationCode] = @VerificationCode;
END
