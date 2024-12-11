CREATE PROCEDURE [dbo].[SP_List_Beers]
	@Offset int,
	@Limit int,
	@Order NVARCHAR(4),
	@Type VARCHAR(50),
	@Search NVARCHAR(100) = ''
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(1) AS Total
	FROM V_Beers;

	DECLARE @sql NVARCHAR(MAX);

	SET @sql = N'SELECT b.*, bt.Name AS BeerTypeName 
        FROM Beers b 
        INNER JOIN BeerType bt ON b.IdBeerType = bt.Id
        WHERE (@Search IS NULL OR DATALENGTH(@Search) = 0 OR bt.Name LIKE ''%'' + @Search + ''%'' OR b.Name LIKE ''%'' + @Search + ''%'')
        ORDER BY ' + QUOTENAME(@Type) + ' ' + @Order + 
        ' OFFSET ' + CAST(@Offset AS NVARCHAR) + ' ROWS
        FETCH NEXT ' + CAST(@Limit AS NVARCHAR) + ' ROWS ONLY';

    EXEC sp_executesql @sql, 
                   N'@Search NVARCHAR(100), @Type NVARCHAR(50), @Order NVARCHAR(4), @Offset INT, @Limit INT', 
                   @Search, @Type, @Order, @Offset, @Limit;
END