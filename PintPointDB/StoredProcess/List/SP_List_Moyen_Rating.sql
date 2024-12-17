CREATE PROCEDURE [dbo].[SP_List_Moyen_Rating]
@IdBeer INT
AS
BEGIN
     SELECT 
        r.RoundedRate,
        ISNULL(br.RatingCount, 0) AS RatingCount
    FROM (
        SELECT 1 AS RoundedRate
        UNION ALL SELECT 2
        UNION ALL SELECT 3
        UNION ALL SELECT 4
        UNION ALL SELECT 5
    ) r
    LEFT JOIN (
        SELECT 
            ROUND(Rate, 0) AS RoundedRate,
            COUNT(*) AS RatingCount
        FROM 
            BeersRatings
        WHERE 
            IdBeer = @IdBeer
        GROUP BY 
            ROUND(Rate, 0)
    ) br ON r.RoundedRate = br.RoundedRate
    ORDER BY 
        r.RoundedRate;
END
