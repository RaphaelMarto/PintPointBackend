CREATE PROCEDURE [dbo].[SP_GetOne_Breweries]
	@Id int
AS
BEGIN
	SELECT * FROM Breweries WHERE Id = @Id
END
