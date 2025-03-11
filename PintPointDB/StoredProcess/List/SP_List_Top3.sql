CREATE PROCEDURE [dbo].[SP_List_Top3]
AS
BEGIN
	SELECT TOP 3 
        b.Name, 
        b.PictureUrl
    FROM 
        Beers b
    ORDER BY 
        b.Rating DESC;
END
