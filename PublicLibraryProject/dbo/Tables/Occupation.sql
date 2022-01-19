CREATE TABLE [dbo].[Occupation] (
    [PositionId] BIGINT     IDENTITY (1, 1) NOT NULL,
    [Position]   NCHAR (50) NOT NULL,
    CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED ([PositionId] ASC)
);

