CREATE TABLE [dbo].[WorkerPosition] (
    [WorkerId]   BIGINT NOT NULL,
    [PositionId] BIGINT NOT NULL,
    CONSTRAINT [FK_Worker_Position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Occupation] ([PositionId]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Worker_Worker] FOREIGN KEY ([WorkerId]) REFERENCES [dbo].[Staff] ([WorkerId]) ON UPDATE CASCADE
);

