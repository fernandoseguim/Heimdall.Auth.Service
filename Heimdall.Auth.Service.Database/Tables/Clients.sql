﻿CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
	[ClientId] VARCHAR(100) NOT NULL UNIQUE, 
    [ClientData] VARCHAR(MAX) NULL
)

GO
