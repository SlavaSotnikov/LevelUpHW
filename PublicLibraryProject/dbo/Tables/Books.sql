CREATE TABLE [dbo].[Books] (
    [BookId] BIGINT       IDENTITY (1, 1) NOT NULL,
    [Title]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([BookId] ASC)
);

