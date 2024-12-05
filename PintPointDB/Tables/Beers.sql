CREATE TABLE [dbo].[Beers]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(150),
	[Price] MONEY NOT NULL,
	[Capacity] INT NOT NULL,
	[AlcholPercent] MONEY NOT NULL,
	[IdBeerType] INT NOT NULL,
	[IdBrewery] INT NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL,
	[UpdatedAt] DATETIME2 NOT NULL,

	CONSTRAINT [FK_Beers_BeerType] FOREIGN KEY ([IdBeerType]) REFERENCES [BeerType](Id),
	CONSTRAINT [FK_Beers_Breweries] FOREIGN KEY ([IdBrewery]) REFERENCES [Breweries](Id),
)
