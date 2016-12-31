CREATE TABLE [dbo].[Utilisateur]
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nom] VARCHAR(100) NOT NULL,
	[Prenom] VARCHAR(100) NOT NULL,
	[Date de naissance] DATE NOT NULL,
	[Adresse] VARCHAR(100) NOT NULL,
	[Ville] VARCHAR(100) NOT NULL,
	[Code Postal] INT NOT NULL,
	[Adresse de messagerie] VARCHAR(100) NOT NULL,
	[Pseudo] VARCHAR(100) NOT NULL,
	[Mot de passe] VARCHAR(100) NOT NULL,
	[Role] VARCHAR(100) NOT NULL 
)
