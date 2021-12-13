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
	DeletedOn  SMALLDATETIME NULL,
	WhoRemoved BIGINT        NULL
)   

CREATE TABLE Writers
(
    WriterId   BIGINT        NOT NULL IDENTITY (1, 1),
	FirstName  NCHAR(20)     NOT NULL,
	LastName   NCHAR(20)     NOT NULL,
	MiddleName NCHAR(20)     NULL,
	DeletedOn  SMALLDATETIME NULL,
	WhoRemoved BIGINT        NULL
)

CREATE TABLE ProcessBooks
(
    ReaderId   BIGINT        NOT NULL,
	BookId     BIGINT        NOT NULL,
	Given      DATE          NOT NULL,
	Back       DATE          NULL,
	DeletedOn  DATE          NULL
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
	Haired     DATE          NOT NULL,
	Faired     DATE          NULL,
	DeletedOn  SMALLDATETIME NULL
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
    ReaderId        BIGINT       NOT NULL IDENTITY (1, 1),
	FirstName       NCHAR(20)    NOT NULL,
	LastName        NCHAR(20)    NOT NULL,
	MiddleName      NCHAR(20)    NULL,
	SubscribeDate   DATE         NOT NULL,
	UnsubscribeDate DATE         NULL
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
	    FOREIGN KEY(ReaderId) REFERENCES Readers(ReaderId)
		ON UPDATE CASCADE
		ON DELETE NO ACTION

ALTER TABLE ProcessBooks
    ADD CONSTRAINT FK_BookId_Books
	    FOREIGN KEY(BookId) REFERENCES Books(BookId)
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

INSERT INTO Writers(FirstName, LastName, MiddleName)
    VALUES('William', 'Shakespeare', NULL),
	('Jane', 'Austen', NULL),
	('George', 'Orwell', NULL),
	('Thomas', 'Hardy', NULL),
	('Thomas', 'Eliot', 'Stearns'),
	('William', 'Blake', NULL),
	('Lewis', 'Caroll', NULL),
	('Lev', 'Tolstoy', 'Nikolaevich'),
	('Fyodor', 'Dostoevsky', 'Mikhailovich'),
	('Nikolai', 'Gogol', 'Vasilyevich'),
	('Anton', 'Chekhov', 'Pavlovich'),
	('Izabella', 'Akhmadulina', 'Akhatovna'),
	('Ilya', 'Ilf', NULL),
	('Yevgeny', 'Petrov', NULL)
GO

INSERT INTO Books(Title)
    VALUES('Macbeth'),
	      ('Hamlet'),
	      ('A Midsummer Nights Dream'),
	      ('Lady Susan'),
	      ('The Watsons'),
	      ('A Clergymans Daughter'),
	      ('Far from the Madding Crowd'),
	      ('The Mayor of Casterbridge '),
	      ('The Waste Land'),
	      ('Murder in the Cathedral '),
	      (' Jerusalem'),
	      ('The Four Zoas'),
	      ('The Hunting of the Snark'),
	      ('Alices Adventure in Wonderland'),
	      ('War and Peace'),
	      ('Anna Karenina'),
	      ('The Brothers Karamazov'),
	      ('Crime and Punishment'),
	      ('Viy'),
	      ('Dead Souls'),
	      ('Three Sisters'),
	      ('The Cherry Orchard'),
	      ('The String'),
	      ('Fever'),
	      ('The Little Golden Calf')
GO

INSERT INTO Readers(FirstName, LastName, MiddleName, SubscribeDate, UnsubscribeDate)
     	VALUES(N'Rick', N'Bor',   NULL,   '2021-09-08', NULL),
		      (N'Bob', N'Arum',   NULL,   '2021-04-05', NULL),
		      (N'Rob', N'Arch',   NULL,   '2021-05-13', NULL),
		      (N'Den', N'Novack', NULL,   '2021-02-10', NULL),
		      (N'Max', N'Plank',  NULL,   '2021-01-19', NULL),
		      (N'Albert', N'Enstaine', NULL,'2021-11-01', NULL),
		      (N'Bob', N'Katz',   NULL, '2021-05-15', NULL),
		      (N'Adam', N'Tur',   NULL, '2021-12-08', NULL)
GO

INSERT INTO ProcessBooks(ReaderId, BookId, Given, Back)
    VALUES(2, 1, '2021-10-11', NULL),
	      (2, 2, '2021-10-11', NULL),
	      (6, 10, '2021-12-08', NULL),
	      (6, 4, '2021-09-08', '2021-10-03'),
	      (8, 9, '2021-09-03', NULL),
	      (8, 8, '2021-04-08', '2021-05-08'),
	      (5, 7, '2021-10-08', NULL)
GO

INSERT INTO BookAmount(BookId, Amount)
    VALUES(1, 4),
	(2, 4),
	(3, 2),
	(4, 7),
	(5, 2),
	(6, 3),
	(7, 5),
	(8, 3),
	(9, 6)
GO

INSERT INTO BooksWriters(BookId, AuthorId)
    VALUES(1, 1),
	      (2, 1),
	      (3, 1)
GO

INSERT INTO Staff(FirstName, LastName, MiddleName, Haired, Faired, DeletedOn)
    VALUES--('Vasil', 'Klein', NULL,'2020-01-01', NULL, NULL),
	      ('Den', 'Fridel', NULL,'2020-02-02', NULL, NULL),
		  ('Bob', 'Brown', NULL,'2020-03-03', NULL, NULL)

INSERT INTO Occupation(Position)
    VALUES('Consultant'),
	      ('Librarian'),
		  ('DataBaseAdmin'),
		  ('CareTaker'),
		  ('Security')

INSERT INTO WorkerPosition(WorkerId, PositionId)
    VALUES(1, 1),
	      (1, 2),
		  (3, 3),
		  (4, 4),
		  (4, 5)
GO

SELECT * FROM WorkerPosition
