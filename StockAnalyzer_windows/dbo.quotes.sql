CREATE TABLE [dbo].[quotes] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [datetime] NCHAR (20) NULL,
    [open]     TEXT NULL,
    [close]    NCHAR (10) NULL,
    [high]     NCHAR (10) NULL,
    [low]      NCHAR (10) NULL,
    [volume]   NCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

