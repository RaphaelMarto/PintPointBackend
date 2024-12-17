CREATE TABLE [dbo].[Cities]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CountryId] INT NOT NULL,
	[Name] VARCHAR(255) NOT NULL

	CONSTRAINT [FK_Cities_Countries] FOREIGN KEY ([CountryId]) REFERENCES [Countries](Id),
)
