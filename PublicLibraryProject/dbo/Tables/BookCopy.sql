CREATE TABLE [dbo].[BookCopy] (
    [CopyId]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [BookId]     BIGINT        NOT NULL,
    [Condition]  TINYINT       NOT NULL,
    [DeletedOn]  SMALLDATETIME NULL,
    [WhoRemoved] BIGINT        NULL,
    CONSTRAINT [PK_BookCopy] PRIMARY KEY CLUSTERED ([CopyId] ASC),
    CONSTRAINT [FK_BookCopy_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]),
    CONSTRAINT [FK_BookCopy_Remove] FOREIGN KEY ([WhoRemoved]) REFERENCES [dbo].[Staff] ([WorkerId])
);

