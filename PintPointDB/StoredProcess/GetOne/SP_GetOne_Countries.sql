CREATE PROCEDURE [dbo].[SP_GetOne_Countries]
	@Id int
AS
BEGIN
	SELECT * FROM Countries WHERE Id = @Id
END
