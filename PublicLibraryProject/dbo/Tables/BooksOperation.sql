CREATE TABLE [dbo].[BooksOperation] (
    [ReaderId] BIGINT NOT NULL,
    [CopyId]   BIGINT NOT NULL,
    [Given]    DATE   NOT NULL,
    [WhoGiven] BIGINT NOT NULL,
    [Back]     DATE   NULL,
    CONSTRAINT [FK_Book_Given] FOREIGN KEY ([WhoGiven]) REFERENCES [dbo].[Staff] ([WorkerId]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Books_Copy] FOREIGN KEY ([CopyId]) REFERENCES [dbo].[BookCopy] ([CopyId]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Books_Readers] FOREIGN KEY ([ReaderId]) REFERENCES [dbo].[Readers] ([ReaderId]) ON UPDATE CASCADE
);

