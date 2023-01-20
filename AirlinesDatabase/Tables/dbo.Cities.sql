CREATE TABLE [dbo].[Cities] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL,
    [Name]       TEXT NOT NULL,
    [Population] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

