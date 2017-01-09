CREATE TABLE [dbo].[Facture]
(
	[FactureID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[LocationID] INT,
	[CompnayName] VARCHAR(100) NOT NULL,
	[CompanyAddress] VARCHAR(100) NOT NULL,
	FOREIGN KEY (LocationID) REFERENCES Location(LocationID),
	
)
