﻿CREATE TABLE [dbo].[Player] (
    [PlayerID]         INT           NOT NULL,
    [Login]            VARCHAR(16)    NOT NULL,
	[Nickname] VARCHAR(50) NOT NULL, 
	[FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [E-mail]           VARCHAR(100)   NOT NULL,
    [Password]         VARCHAR (100) NOT NULL,
    [RegistrationDate] DATE          NULL,
    [RegistrationTime] TIME (7)      NULL,
    CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([PlayerID] ASC)
);

