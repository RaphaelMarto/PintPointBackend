CREATE PROCEDURE [dbo].[SP_List_Top3_User]
 @UserId int
AS
BEGIN
	SELECT TOP 3 
        b.Name, 
        b.PictureUrl
    FROM 
        BeersRatings br
    JOIN 
        Beers b ON br.IdBeer = b.Id
    WHERE br.IdUser = @UserId
    ORDER BY 
        br.Rate DESC;
END
