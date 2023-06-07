﻿CREATE TABLE [dbo].[LOGINS]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIMEOFFSET NOT NULL, 
    [IpAddress] NCHAR(15) NOT NULL, 
    [DeviceSettings] NVARCHAR(150) NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_LOGINS_ToTable_USERS] FOREIGN KEY ([UserId]) REFERENCES [USERS]([Id]) ON DELETE CASCADE 
)
