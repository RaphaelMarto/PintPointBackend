CREATE PROCEDURE [dbo].[SP_Account_Del]
    @Email VARCHAR(320),
    @Id INT
AS
BEGIN
    DECLARE @RandomPart NVARCHAR(12) = LEFT(CAST(NEWID() AS NVARCHAR(36)), 12);
    DECLARE @NickName NVARCHAR(50);
    SET @NickName = LEFT(N'Deleted_User_' + @RandomPart + CAST(@Id AS NVARCHAR(10)), 50);

    -- Update user information to anonymize the account
    UPDATE [dbo].[Users]
    SET 
        IsActive = 0,
        UpdatedAt = GETDATE(),
        AccessToken = NULL,
        RefreshToken = NULL,
        Password = 'Anonymized',
        Email = 'deleted_' + CAST(@Id AS VARCHAR) + '@anonymized.local',
        FirstName = '',
        LastName = '',
        NickName = @NickName,
        DateOfBirth = GETDATE(),
        Phone = NULL,
        PictureUrl = NULL
    WHERE Email = @Email AND Id = @Id;

    -- Retrieve associated AddressId
    DECLARE @AddressId INT;
    SELECT @AddressId = AddressId FROM [dbo].[Users] WHERE Id = @Id;

    -- Anonymize associated address if found
    IF @AddressId IS NOT NULL
    BEGIN
        UPDATE [dbo].[Addresses]
        SET 
            Street = '',
            HouseNumber = '',
            PostCode = '',
            IdCity = 1,
            UpdatedAt = GETDATE()
        WHERE Id = @AddressId;
    END
END;
