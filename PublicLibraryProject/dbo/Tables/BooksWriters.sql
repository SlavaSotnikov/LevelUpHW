CREATE TABLE [dbo].[BooksWriters] (
    [BookId]   BIGINT NOT NULL,
    [AuthorId] BIGINT NOT NULL,
    CONSTRAINT [FK_Author_Writers] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Writers] ([WriterId]) ON UPDATE CASCADE,
    CONSTRAINT [FK_BookId_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]) ON UPDATE CASCADE,
    CONSTRAINT [AK_OneAuthorOneTitle] UNIQUE NONCLUSTERED ([BookId] ASC, [AuthorId] ASC)
);

