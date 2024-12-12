CREATE PROCEDURE [dbo].[SP_Post_Beer]
	@Name varchar(50),
    @Description  varchar(150),
    @Price MONEY,
    @Capacity INT,
    @AlcoholPercent DECIMAL(5,2),
    @IdBeerType INT,
    @IdBrewery INT,
    @PictureUrl NVARCHAR(255),
    @Rating DECIMAL(4,2),
    @CreatedAt DATETIME2,
    @UpdatedAt DATETIME2
AS
BEGIN
	INSERT INTO Beers 
    ([Name], [Description], [Price], [Capacity], [AlcoholPercent], [IdBeerType], [IdBrewery], [PictureUrl], [Rating], [CreatedAt], [UpdatedAt]) 
    VALUES (@Name, @Description, @Price, @Capacity, @AlcoholPercent, @IdBeerType, @IdBrewery, @PictureUrl, @Rating, @CreatedAt, @UpdatedAt);
END
