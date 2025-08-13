CREATE PROCEDURE [dbo].[SP_Put_Beer]
	@Name varchar(50),
    @Description  varchar(150),
    @Price MONEY,
    @Capacity INT,
    @AlcoholPercent DECIMAL(5,2),
    @IdBeerType INT,
    @IdBrewery INT,
    @PictureUrl NVARCHAR(255),
    @BirthYear INT,
    @Id INT
AS
BEGIN
	UPDATE Beers
    SET [Name] = @Name, [Description] = @Description, [Price] = @Price, [Capacity] = @Capacity, [AlcoholPercent] = @AlcoholPercent,
    [IdBeerType] = @IdBeerType, [IdBrewery] = @IdBrewery, [PictureUrl] = @PictureUrl, [UpdatedAt] = GETDATE(), [BirthYear] = @BirthYear
    WHERE Id = @Id;
END
