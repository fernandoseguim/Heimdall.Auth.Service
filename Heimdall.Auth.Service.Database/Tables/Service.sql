CREATE TABLE [dbo].[Service]
(
	[ServiceId] INT NOT NULL PRIMARY KEY,
	[AppServiceIdentifier] UNIQUEIDENTIFIER NOT NULL, 
    [AppServiceName] VARCHAR(100) NOT NULL, 
    [Dns] VARCHAR(100) NOT NULL, 
    [Port] INT NOT NULL, 
    [Enviroment] TINYINT NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT getUtcDate(), 
    [UpdateAt] DATETIME NOT NULL DEFAULT getUtcDate(), 
    [Enabled] BIT NOT NULL DEFAULT 0,
)

GO

CREATE INDEX [IX_Service_AppServiceIdentifier] ON [dbo].[Service] ([AppServiceIdentifier])

GO

CREATE INDEX [IX_Service_AppServiceIdentifier_AppServiceName] ON [dbo].[Service] ([AppServiceIdentifier], [AppServiceName])
