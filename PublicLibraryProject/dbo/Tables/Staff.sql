CREATE TABLE [dbo].[Staff] (
    [WorkerId]   BIGINT     IDENTITY (1, 1) NOT NULL,
    [FirstName]  NCHAR (20) NOT NULL,
    [LastName]   NCHAR (20) NOT NULL,
    [MiddleName] NCHAR (20) NULL,
    [Haired]     DATE       NOT NULL,
    [Faired]     DATE       NULL,
    CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED ([WorkerId] ASC)
);

