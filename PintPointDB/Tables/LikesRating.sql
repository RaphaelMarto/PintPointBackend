CREATE TABLE [dbo].[LikesRating]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Liked] BIT NOT NULL,
	[IdRating] INT NOT NULL,
	[IdUser] INT NOT NULL,

	CONSTRAINT [FK_LikesRating_Beer] FOREIGN KEY ([IdRating]) REFERENCES [BeersRatings](Id),
	CONSTRAINT [FK_LikesRating_User] FOREIGN KEY ([IdUser]) REFERENCES [Users](Id)
)
