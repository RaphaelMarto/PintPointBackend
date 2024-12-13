CREATE TABLE [dbo].[Beers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(150),
	[Price] MONEY NOT NULL,
	[PictureUrl] VARCHAR(255) NOT NULL,
	[Capacity] INT NOT NULL,
	[AlcoholPercent] DECIMAL(5,2) NOT NULL,
	[Rating] DECIMAL(4,2) NOT NULL,
	[IdBeerType] INT NOT NULL,
	[IdBrewery] INT NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL,
	[UpdatedAt] DATETIME2 NOT NULL,

	CONSTRAINT [FK_Beers_BeerType] FOREIGN KEY ([IdBeerType]) REFERENCES [BeerType](Id),
	CONSTRAINT [FK_Beers_Breweries] FOREIGN KEY ([IdBrewery]) REFERENCES [Breweries](Id),
)
