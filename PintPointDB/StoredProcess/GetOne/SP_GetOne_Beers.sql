CREATE PROCEDURE [dbo].[SP_GetOne_Beers]
	@Id int,
	@IdUser INT
AS
BEGIN
	SELECT b.*, br.Rate FROM Beers as b
	JOIN BeersRatings as br ON br.IdBeer = b.Id AND br.IdUser = @IdUser
	WHERE b.Id = @Id
END
