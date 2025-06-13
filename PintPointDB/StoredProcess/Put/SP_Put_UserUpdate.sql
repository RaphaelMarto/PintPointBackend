CREATE PROCEDURE [dbo].[SP_Put_UserUpdate]
	@Id INT, 
    @FirstName VARCHAR(60), 
    @LastName VARCHAR(60), 
    @NickName NVARCHAR(50), 
    @Email VARCHAR(320), 
    @Phone VARCHAR(10), 
    @DateOfBirth datetime2(7)
AS
BEGIN
	UPDATE Users 
	SET FirstName = @FirstName, 
		LastName = @LastName, 
		NickName = @NickName, 
		Email = @Email, 
		Phone = @Phone, 
		DateOfBirth = @DateOfBirth,
		UpdatedAt = GETDATE()
	WHERE Id = @Id;
END