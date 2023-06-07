﻿CREATE TABLE [dbo].[ROLES_USERS]
(
	[RoleId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_ROLES_USERS_UserId_USERS] FOREIGN KEY ([UserId]) REFERENCES [USERS]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ROLES_USERS_RoleId_ROLES] FOREIGN KEY ([RoleId]) REFERENCES [ROLES]([Id]) ON DELETE CASCADE,
)
