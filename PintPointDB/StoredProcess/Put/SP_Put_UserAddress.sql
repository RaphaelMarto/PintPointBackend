CREATE PROCEDURE [dbo].[SP_Put_UserAddress]
	@Street VARCHAR(255), 
    @IdCity INT, 
    @HouseNumber VARCHAR(5), 
    @PostCode VARCHAR(10),
    @Id INT
AS
BEGIN
	UPDATE Addresses 
    SET Street = @Street, 
		IdCity = @IdCity, 
		HouseNumber = @HouseNumber, 
		PostCode = @PostCode,
		UpdatedAt = GETDATE()
	WHERE Id = @Id;
END
