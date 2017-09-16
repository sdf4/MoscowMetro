CREATE TABLE [dbo].[MetroRoute] (
    [id]                 SMALLINT        IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (50)   NOT NULL,
    [UserId]             NVARCHAR (128)  NOT NULL,
    [SequenceOfStations] NVARCHAR (1024) NOT NULL,
    CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED ([id] ASC)
);

