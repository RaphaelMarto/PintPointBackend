CREATE PROCEDURE [dbo].[SP_Register]
    -- User parameters
    @FirstName VARCHAR(60),
    @LastName VARCHAR(60),
    @NickName VARCHAR(25),
    @DateOfBirth DATETIME2,
    @Email VARCHAR(320),
    @Password VARCHAR(255),
    @Phone VARCHAR(10),
    @PictureUrl VARCHAR(255),
    @AccessToken VARCHAR(255),
    @RefreshToken VARCHAR(255),
    @PolicyCheck BIT,
    @IsAdmin BIT,
    -- Address parameters
    @IdCity INT,
    @Street VARCHAR(255),
    @HouseNumber VARCHAR(5),
    @PostCode VARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Insert address and get the new AddressId
        INSERT INTO Addresses (IdCity, Street, PostCode, HouseNumber, CreatedAt, UpdatedAt) 
        VALUES (@IdCity, @Street, @PostCode, @HouseNumber, GETDATE(), GETDATE());

        DECLARE @AddressId INT = SCOPE_IDENTITY();

        -- Insert user with the new AddressId
        INSERT INTO Users ([FirstName], [LastName], [NickName], [AccessToken], [RefreshToken], [IsActive], [IsAdmin], [UpdatedAt], [CreatedAt], [DateOfBirth], [Email], [PolicyCheck], [Password], [PictureUrl], [Phone], [AddressId])
        VALUES (@FirstName, @LastName, @NickName, '', '', 1, 0, GETDATE(), GETDATE(), @DateOfBirth, @Email, @PolicyCheck, @Password, @PictureUrl, @Phone, @AddressId);

        DECLARE @UserId INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        -- Return user
        SELECT 
            *
        FROM 
            Users u
        WHERE 
            u.Id = @UserId;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END