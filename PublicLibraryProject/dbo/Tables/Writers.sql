CREATE TABLE [dbo].[Writers] (
    [WriterId]   BIGINT       IDENTITY (1, 1) NOT NULL,
    [FirstName]  NCHAR (20)   NOT NULL,
    [LastName]   NCHAR (20)   NOT NULL,
    [MiddleName] NCHAR (20)   NULL,
    [Country]    VARCHAR (20) NULL,
    CONSTRAINT [PK_Writers] PRIMARY KEY CLUSTERED ([WriterId] ASC),
    CONSTRAINT [AK_OneAuthor] UNIQUE NONCLUSTERED ([FirstName] ASC, [LastName] ASC, [MiddleName] ASC)
);

