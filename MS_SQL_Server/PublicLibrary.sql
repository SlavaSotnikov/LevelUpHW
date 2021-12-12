USE master
GO

--DROP DATABASE PublicLibrary
--GO

CREATE DATABASE PublicLibrary
GO

USE PublicLibrary
GO



CREATE TABLE Books
(
    BookId     BIGINT        NOT NULL IDENTITY (1, 1),
	Title      VARCHAR(50)   NOT NULL,
	DeletedOn  SMALLDATETIME NULL
)   

CREATE TABLE Writers
(
    WriterId   BIGINT        NOT NULL IDENTITY (1, 1),
	FirstName  NCHAR(20)     NOT NULL,
	LastName   NCHAR(20)     NOT NULL,
	MiddleName NCHAR(20)     NULL,
	DeletedOn  SMALLDATETIME NULL
)

CREATE TABLE ProcessBooks
(
    ReaderId   BIGINT        NOT NULL,
	BookId     BIGINT        NOT NULL,
	Given      SMALLDATETIME NOT NULL,
	Back       SMALLDATETIME NULL,
	DeletedOn  SMALLDATETIME NULL
)

CREATE TABLE BooksWriters
(
    BookId     BIGINT        NOT NULL,
	AuthorId   BIGINT        NOT NULL,
	DeletedOn  SMALLDATETIME NULL
)

CREATE TABLE Staff
(
    WorkerId   BIGINT        NOT NULL IDENTITY (1, 1),
	FirstName  NCHAR(20)     NOT NULL,
	LastName   NCHAR(20)     NOT NULL,
	MiddleName NCHAR(20)     NULL,
	Position   BIGINT        NOT NULL,
	DeletedOn  SMALLDATETIME NULL
)

CREATE TABLE WorkerDelete
(
    DeletedOn  SMALLDATETIME NOT NULL,
	WorkerId   BIGINT        NOT NULL,
)

CREATE TABLE WorkerPosition
(
    WorkerId   BIGINT NOT NULL,
	PositionId BIGINT NOT NULL
)

CREATE TABLE Occupation
(
    PositionId BIGINT        NOT NULL IDENTITY (1, 1),
	Position   NCHAR(50)     NOT NULL
)

CREATE TABLE BookAmount
(
    BookId BIGINT            NOT NULL,
	Amount INT               NOT NULL
)

CREATE TABLE Readers
(
    ReaderId       BIGINT       NOT NULL IDENTITY (1, 1),
	FirstName      NCHAR(20)    NOT NULL,
	LastName       NCHAR(20)    NOT NULL,
	MiddleName     NCHAR(20)    NULL,
	SubscribeDay   DATETIME     NOT NULL,
	UnsubscribeDay DATETIME     NULL
)

ALTER TABLE Readers 
    ADD CONSTRAINT PK_Readers
	    PRIMARY KEY CLUSTERED (ReaderId)

ALTER TABLE Books 
    ADD CONSTRAINT PK_Books
	    PRIMARY KEY CLUSTERED (BookId)



ALTER TABLE Occupation 
    ADD CONSTRAINT PK_Position
	    PRIMARY KEY CLUSTERED (PositionId)

ALTER TABLE Writers 
    ADD CONSTRAINT PK_Writers
	    PRIMARY KEY CLUSTERED (WriterId)

ALTER TABLE Staff 
    ADD CONSTRAINT PK_Worker
	    PRIMARY KEY CLUSTERED (WorkerId)

ALTER TABLE ProcessBooks
    ADD CONSTRAINT FK_Books_Readers
	    FOREIGN KEY(BookId) REFERENCES Readers(ReaderId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BooksWriters
    ADD CONSTRAINT FK_Books_Writers
	    FOREIGN KEY(BookId) REFERENCES Books(BookId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BooksWriters
    ADD CONSTRAINT FK_Author_Writers
	    FOREIGN KEY(AuthorId) REFERENCES Writers(WriterId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE ProcessBooks
    ADD CONSTRAINT FK_Reader_Books
	    FOREIGN KEY(ReaderId) REFERENCES Books(BookId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BookAmount
    ADD CONSTRAINT FK_Books_Amount
	    FOREIGN KEY(BookId) REFERENCES Books(BookId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE WorkerPosition
    ADD CONSTRAINT FK_Worker_Worker
	    FOREIGN KEY(WorkerId) REFERENCES Staff(WorkerId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE WorkerPosition
    ADD CONSTRAINT FK_Worker_Position
	    FOREIGN KEY(PositionId) REFERENCES Occupation(PositionId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE Books 
    ADD CONSTRAINT AK_OneCopy
	    UNIQUE (BookId, Title)

ALTER TABLE BooksWriters 
    ADD CONSTRAINT AK_OneAuthorOneTitle
	    UNIQUE (BookId, AuthorId)

ALTER TABLE Writers 
    ADD CONSTRAINT AK_OneAuthor
	    UNIQUE (FirstName, LastName, MiddleName)

GO

BACKUP DATABASE PublicLibrary
TO DISK = 'D:\SQLBackups\PublicLibraryDB.bak'
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = 'Full Backup of PublicLibraryDB';
GO