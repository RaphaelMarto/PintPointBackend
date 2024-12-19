CREATE PROCEDURE [dbo].[SP_List_Rating]
	@Offset int,
	@Limit int,
	@Order NVARCHAR(4),
	@Type VARCHAR(50),
	@IdUser INT,
	@IdBeer INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(1) AS Total
	FROM V_Beers;

	DECLARE @sql NVARCHAR(MAX);

	SET @sql = N'SELECT  br.*, lr.Liked,u.NickName,u.PictureUrl
        FROM BeersRatings br
        LEFT JOIN LikesRating lr ON br.Id = lr.IdRating AND lr.IdUser = @IdUser
		LEFT JOIN Users u ON br.IdUser = u.Id
		WHERE br.IdBeer = @IdBeer
        ORDER BY ' + QUOTENAME(@Type) + ' ' + @Order + 
        ' OFFSET ' + CAST(@Offset AS NVARCHAR) + ' ROWS
        FETCH NEXT ' + CAST(@Limit AS NVARCHAR) + ' ROWS ONLY';

    EXEC sp_executesql @sql, 
                   N'@Type NVARCHAR(50), @Order NVARCHAR(4), @Offset INT, @Limit INT, @IdUser INT, @IdBeer INT', 
                    @Type, @Order, @Offset, @Limit, @IdUser, @IdBeer;
END
