USE PublicLibrary
GO

CREATE TABLE Books
(
    BookId     BIGINT        NOT NULL IDENTITY (1, 1),
	Title      VARCHAR(50)   NOT NULL
)

CREATE TABLE Writers
(
    WriterId   BIGINT        NOT NULL IDENTITY (1, 1),
	FirstName  NCHAR(20)     NOT NULL,
	LastName   NCHAR(20)     NOT NULL,
	MiddleName NCHAR(20)     NULL,
	Country    VARCHAR(20)   NULL
)

CREATE TABLE BooksOperation
(
    ReaderId   BIGINT        NOT NULL,
	CopyId     BIGINT        NOT NULL,
	Given      DATE          NOT NULL,
	WhoGiven   BIGINT        NOT NULL,
	Back       DATE          NULL
)

CREATE TABLE BooksWriters
(
    BookId     BIGINT        NOT NULL,
	AuthorId   BIGINT        NOT NULL
)

CREATE TABLE Staff
(
    WorkerId   BIGINT        NOT NULL IDENTITY (1, 1),
	FirstName  NCHAR(20)     NOT NULL,
	LastName   NCHAR(20)     NOT NULL,
	MiddleName NCHAR(20)     NULL,
	Haired     DATE          NOT NULL,
	Faired     DATE          NULL
)

CREATE TABLE WorkerPosition
(
    WorkerId   BIGINT        NOT NULL,
	PositionId BIGINT        NOT NULL
)

CREATE TABLE Occupation
(
    PositionId BIGINT        NOT NULL IDENTITY (1, 1),
	Position   NCHAR(50)     NOT NULL
)

CREATE TABLE BookCopy
(
    CopyId       BIGINT      NOT NULL IDENTITY (1, 1),
	BookId       BIGINT      NOT NULL,
	Condition    TINYINT     NOT NULL,
	DeletedOn  SMALLDATETIME NULL,
	WhoRemoved BIGINT        NULL
)

CREATE TABLE Readers
(
    ReaderId        BIGINT       NOT NULL IDENTITY (1, 1),
	FirstName       NCHAR(20)    NOT NULL,
	LastName        NCHAR(20)    NOT NULL,
	MiddleName      NCHAR(20)    NULL,
	SubscribeDate   DATE         NOT NULL,
	UnsubscribeDate DATE         NULL
)

GO

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

ALTER TABLE BookCopy 
    ADD CONSTRAINT PK_BookCopy
	    PRIMARY KEY CLUSTERED (CopyId)

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
		
ALTER TABLE BooksOperation
    ADD CONSTRAINT FK_Books_Readers
	    FOREIGN KEY(ReaderId) REFERENCES Readers(ReaderId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BooksOperation
    ADD CONSTRAINT FK_Books_Copy
	    FOREIGN KEY(CopyId) REFERENCES BookCopy(CopyId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BooksWriters
    ADD CONSTRAINT FK_BookId_BookId
	    FOREIGN KEY(BookId) REFERENCES Books(BookId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BooksWriters 
    ADD CONSTRAINT FK_Author_Writers
	    FOREIGN KEY(AuthorId) REFERENCES Writers(WriterId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BookCopy
    ADD CONSTRAINT FK_BookCopy_Remove
	    FOREIGN KEY(WhoRemoved) REFERENCES Staff(WorkerId)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION

ALTER TABLE BookCopy 
    ADD CONSTRAINT FK_BookCopy_Books
	    FOREIGN KEY(BookId) REFERENCES Books(BookId)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION

ALTER TABLE BooksOperation
    ADD CONSTRAINT FK_Book_Given
	    FOREIGN KEY(WhoGiven) REFERENCES Staff(WorkerId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE BooksWriters 
    ADD CONSTRAINT AK_OneAuthorOneTitle
	    UNIQUE (BookId, AuthorId)

ALTER TABLE Writers 
    ADD CONSTRAINT AK_OneAuthor
	    UNIQUE (FirstName, LastName, MiddleName)

GO