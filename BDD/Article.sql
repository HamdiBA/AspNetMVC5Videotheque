CREATE TABLE [dbo].[Article]
(
	[ArticleID] INT  IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ArticleName] VARCHAR(100) NOT NULL,
	[CategoryID] INT NOT NULL,
	[GenreID] INT NOT NULL,
	[Duration] VARCHAR(100) NOT NULL,
	[ReleaseDate] Date NOT NULL,
	[Director] VARCHAR(100) NOT NULL,
	[Note] FLOAT NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] FLOAT NOT NULL,
	[DateAdded] DATETIME NOT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Categorie(CategoryID),
	FOREIGN KEY (GenreID) REFERENCES Genre(GenreID)

)
