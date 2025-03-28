﻿CREATE PROCEDURE [dbo].[SP_List_Rating_User_Recent]
    @IdUser INT
AS
BEGIN
	SELECT TOP 3 
        br.*, 
        lr.Liked,
        u.NickName,
        u.PictureUrl
    FROM 
        BeersRatings br
    LEFT JOIN 
        LikesRating lr ON br.Id = lr.IdRating AND lr.IdUser = @IdUser
    LEFT JOIN 
        Users u ON br.IdUser = u.Id
    WHERE br.IdUser = @IdUser
    ORDER BY 
        br.CreatedAt DESC
END
