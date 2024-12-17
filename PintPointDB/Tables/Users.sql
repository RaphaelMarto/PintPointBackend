CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(60) NOT NULL,
	[LastName] VARCHAR(60) NOT NULL,
	[NickName] VARCHAR(25) NOT NULL,
	[DateOfBirth] DATETIME2 NOT NULL,
	[Email] VARCHAR(320) NOT NULL,
	[Password] VARCHAR(255) NOT NULL,
	[Phone] VARCHAR(10),
	[PictureUrl] VARCHAR(255),
	[AccessToken] VARCHAR(255) NOT NULL,
	[RefreshToken] VARCHAR(255) NOT NULL,
	[PolicyCheck] BIT NOT NULL,
	[IsActive] BIT NOT NULL,
	[IsAdmin] BIT NOT NULL,
	[AddressId] INT NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL,
	[UpdatedAt] DATETIME2 NOT NULL,

	CONSTRAINT [FK_Users_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [Addresses](Id)
)
