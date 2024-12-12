CREATE PROCEDURE [dbo].[SP_Post_Brewery]
	 @Name VARCHAR(50),
     @CompleteAddress VARCHAR(100),
     @City VARCHAR(60),
     @IdCountry INT
AS
BEGIN
	INSERT INTO Breweries 
    ([Name], [City], [CompleteAddress], [IdCountry]) 
    VALUES (@Name, @City, @CompleteAddress, @IdCountry);
END