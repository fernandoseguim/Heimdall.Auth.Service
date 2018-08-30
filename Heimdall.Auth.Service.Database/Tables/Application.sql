CREATE TABLE [dbo].[Application]
(
	[ApplicationId] INT NOT NULL PRIMARY KEY, 
    [AppClientIdentifier] UNIQUEIDENTIFIER NOT NULL, 
    [AppSecurityKey] VARCHAR(100) NOT NULL, 
    [AppClientName] VARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT getUtcDate(), 
    [UpdateAt] DATETIME NOT NULL DEFAULT getUtcDate(), 
    [Enabled] BIT NOT NULL DEFAULT 0
)

GO

CREATE INDEX [IX_Application_AppClientIdentifier] ON [dbo].[Application] ([AppClientIdentifier])

GO

CREATE INDEX [IX_Application_AppClientIdentifier_AppClientName] ON [dbo].[Application] ([AppClientIdentifier], [AppClientName])
