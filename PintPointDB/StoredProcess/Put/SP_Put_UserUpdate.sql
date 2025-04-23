CREATE PROCEDURE [dbo].[SP_Put_UserUpdate]
	@Id INT, 
    @FirstName VARCHAR(60), 
    @LastName VARCHAR(60), 
    @NickName VARCHAR(25), 
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
		DateOfBirth = @DateOfBirth
	WHERE Id = @Id;
END