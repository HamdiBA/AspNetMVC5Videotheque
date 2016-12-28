CREATE TABLE [dbo].[Location]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[ArticleID] INT NOT NULL,
	[ClientID] INT NOT NULL,
	[UserID] INT NOT NULL,
	[DateLocation] DATE NOT NULL,
	[DateRetour] DATE NOT NULL,
	[EtatLocation] VARCHAR(100) NOT NULL,
	FOREIGN KEY (ArticleID) REFERENCES Article(ID),
	FOREIGN KEY (ClientID) REFERENCES Client(ID),
	FOREIGN KEY (UserID) REFERENCES Utilisateur(ID),






)
