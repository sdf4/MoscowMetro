CREATE TABLE [dbo].[Station] (
    [id]        SMALLINT       NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [Relations] NVARCHAR (150) NOT NULL,
    [Line]      TINYINT        NOT NULL,
    CONSTRAINT [PK_Station] PRIMARY KEY CLUSTERED ([id] ASC)
);

