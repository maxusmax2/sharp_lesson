﻿CREATE TABLE [dbo].[USERS]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(250) NOT NULL, 
    [Status] NVARCHAR(10) NOT NULL, 
    [Login] NVARCHAR(50) NOT NULL 
)
