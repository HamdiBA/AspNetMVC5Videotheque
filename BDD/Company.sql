﻿CREATE TABLE [dbo].[Company]
(
	[CompanyID] INT NOT NULL PRIMARY KEY,
	[CompanyName] VARCHAR(MAX) NOT NULL,
	[Address] VARCHAR(MAX) NOT NULL,
	[City] VARCHAR(MAX) NOT NULL,
	[PostalCode] INT NOT NULL,
)
