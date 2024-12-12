CREATE TABLE [dbo].[Breweries]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[CompleteAddress] VARCHAR(100) NOT NULL,
	[City] VARCHAR(60) NOT NULL,
	[IdCountry] INT NOT NULL,

	CONSTRAINT [FK_Breweries_Countries] FOREIGN KEY ([IdCountry]) REFERENCES [Countries](Id)
)
