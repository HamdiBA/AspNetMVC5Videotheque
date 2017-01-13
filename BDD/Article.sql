CREATE TABLE [dbo].[Article]
(
	[ArticleID] INT IDENTITY NOT NULL PRIMARY KEY,
	[ArticleName] VARCHAR(MAX) NOT NULL,
	[CategoryID] INT NOT NULL,
	[GenreID] INT NOT NULL,
	[Duration] VARCHAR(MAX) NOT NULL,
	[ReleaseDate] Date NOT NULL,
	[Director] VARCHAR(MAX) NOT NULL,
	[Note] FLOAT NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] FLOAT NOT NULL,
	[Status] VARCHAR(MAX) NOT NULL,
	[DateAdded] DATETIME NOT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Categorie(CategoryID),
	FOREIGN KEY (GenreID) REFERENCES Genre(GenreID)
)
