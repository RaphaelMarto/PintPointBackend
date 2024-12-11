CREATE PROCEDURE [dbo].[SP_GetOne_Beers]
	@Id int
AS
BEGIN
	SELECT * FROM Beers WHERE Id = @Id
END
