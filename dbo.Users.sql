﻿CREATE TABLE [dbo].[Users] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [USERNAME] NCHAR (40) NULL,
    [PASSWORD] NCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

