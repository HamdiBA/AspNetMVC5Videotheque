CREATE TABLE [dbo].[Client]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[Titre] VARCHAR(100) NOT NULL,
	[Nom] VARCHAR(100) NOT NULL,
	[Prenom] VARCHAR(100) NOT NULL,
	[Adresse] VARCHAR(100) NOT NULL,
	[Code Postal] INT NOT NULL,
	[Ville] VARCHAR(100) NOT NULL,
	[Numéro Téléphone] INT NOT NULL,
	[Adresse de messagerie] VARCHAR(100) NOT NULL,
)
