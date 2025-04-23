CREATE PROCEDURE [dbo].[SP_GetOne_UserUpdate]
    @id int
AS
BEGIN
    SELECT 
        u.FirstName, 
        u.LastName, 
        u.NickName, 
        u.Email, 
        u.Phone, 
        u.DateOfBirth,
        a.Id as AddressId,
        a.Street, 
        a.IdCity, 
        a.HouseNumber, 
        a.PostCode
    FROM Users u
    LEFT JOIN Addresses a
        ON u.AddressId = a.Id
    WHERE u.Id = @id
END
