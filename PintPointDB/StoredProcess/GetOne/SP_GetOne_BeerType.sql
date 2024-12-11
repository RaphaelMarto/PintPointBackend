CREATE PROCEDURE [dbo].[SP_GetOne_BeerType]
	@Id int
AS
BEGIN
	SELECT * FROM BeerType WHERE Id = @Id
END
