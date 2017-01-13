CREATE TABLE [dbo].[Facture]
(
	[FactureID] INT IDENTITY NOT NULL PRIMARY KEY,
	[CustomerName] VARCHAR(MAX) NOT NULL,
	[Article1ID] INT NOT NULL,
	[ArticleName1] VARCHAR(MAX) NOT NULL,
	[Catégorie1] VARCHAR(MAX) NOT NULL,
	[Quantity1] INT NOT NULL,
	[Price1] INT NOT NULL,
	[Article2ID] INT,
	[ArticleName2] VARCHAR(MAX),
	[Catégorie2] VARCHAR(MAX),
	[Quantity2] INT,
	[Price2] INT,
	[User] VARCHAR(MAX) NOT NULL,
	[FactureDate] DATE NOT NULL,
	
)
