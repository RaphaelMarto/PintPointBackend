CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(60) NOT NULL,
	[LastName] VARCHAR(60) NOT NULL,
	[NickName] NVARCHAR(50) NOT NULL,
	[DateOfBirth] DATETIME2 NOT NULL,
	[Email] VARCHAR(320) NOT NULL,
	[Password] VARCHAR(255) NOT NULL,
	[Phone] VARCHAR(10) NULL,
	[PictureUrl] VARCHAR(255) NULL,
	[AccessToken] VARCHAR(255) NULL,
	[RefreshToken] VARCHAR(255) NULL,
	[RefreshTokenExpiration] DATETIME2 NULL,
	[PolicyCheck] BIT NOT NULL,
	[IsActive] BIT NOT NULL,
	[IsAdmin] BIT NOT NULL,
	[AddressId] INT NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL,
	[UpdatedAt] DATETIME2 NOT NULL,
	[VerificationCode] NVARCHAR(50) NULL,
	[VerifiedAt] DATETIME2 NULL,
	[PasswordResetCode] NVARCHAR(50) NULL,
	[PasswordResetCodeExpiration] DATETIME2 NULL,

	CONSTRAINT [FK_Users_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [Addresses](Id)
)
