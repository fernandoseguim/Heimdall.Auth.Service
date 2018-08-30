CREATE TABLE [dbo].[AllowedScope]
(
	[ServiceId] INT NOT NULL , 
    [ApplicationId] INT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT getUtcDate(), 
    PRIMARY KEY ([ServiceId], [ApplicationId]), 
    CONSTRAINT [FK_AllowedScope_To_Service] FOREIGN KEY ([ServiceId]) REFERENCES [Service]([ServiceId]),
	CONSTRAINT [FK_AllowedScope_To_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [Application]([ApplicationId])
)
