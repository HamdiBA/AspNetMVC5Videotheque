CREATE TABLE [dbo].[Article]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[Nom_art] VARCHAR(100) NOT NULL,
	[Categorie] VARCHAR(100) NOT NULL,
	[Genre] VARCHAR(100) NOT NULL,
	[Quantite] INT NOT NULL,
	[Prix] FLOAT NOT NULL,
	[Date_ajout] DATETIME DEFAULT(getdate())

)
