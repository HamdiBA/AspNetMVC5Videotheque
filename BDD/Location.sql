CREATE TABLE [dbo].[Location]
(
	[LocationID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ArticleID] INT NOT NULL,
	[CustomerID] INT NOT NULL,
	[UserID] INT NOT NULL,
	[DateLocation] DATE NOT NULL,
	[DateBack] DATE NOT NULL,
	[EtatLocation] VARCHAR(100) NOT NULL,
	FOREIGN KEY (ArticleID) REFERENCES Article(ArticleID),
	FOREIGN KEY (CustomerID) REFERENCES Client(CustomerID),
	FOREIGN KEY (UserID) REFERENCES Utilisateur(UserID),






)
