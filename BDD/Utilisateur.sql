﻿CREATE TABLE [dbo].[Utilisateur]
(
	[UserID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[LastName] VARCHAR(100) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[City] VARCHAR(100) NOT NULL,
	[PostalCode] INT NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[UserName] VARCHAR(100) NOT NULL,
	[Password] VARCHAR(100) NOT NULL,
	[Role] VARCHAR(100) NOT NULL 
)
