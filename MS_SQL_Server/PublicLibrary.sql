USE master
GO

--DROP DATABASE PublicLibrary
--GO

SELECT * FROM BooksOperation

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
	Condition    TINYINT     NOT NULL
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

ALTER TABLE BookCopy
    ADD CONSTRAINT FK_BookCopy_Book
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

ALTER TABLE Books
    ADD CONSTRAINT FK_Book_Remove
	    FOREIGN KEY(WhoRemoved) REFERENCES Staff(WorkerId)
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

BACKUP DATABASE PublicLibrary
TO DISK = 'D:\SQLBackups\PublicLibraryDB.bak'
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = 'Full Backup of PublicLibraryDB'; --Try GETDATE
	  --CONVERT(VARCHAR, datetime [,style])
	  --CONCAT(string_value1, string_value2 [, string_valueN ]);
GO

INSERT INTO Staff(FirstName, LastName, MiddleName, Haired, Faired)
    VALUES('Vasil', 'Klein', NULL,'2020-01-01', NULL),
	      ('Den', 'Fridel', NULL,'2020-02-02', NULL),
		  ('Bob', 'Brown', NULL,'2020-03-03', NULL),
		  ('Anna', 'Mateo', NULL,'2020-04-04', NULL)

INSERT INTO Occupation(Position)
    VALUES('Consultant'),
	      ('Librarian'),
		  ('DataBaseAdmin'),
		  ('CareTaker'),
		  ('Security')

INSERT INTO WorkerPosition(WorkerId, PositionId)
    VALUES(1, 1),
	      (1, 2),
		  (2, 3),
		  (3, 4),
		  (3, 5),
		  (4, 2)
GO

INSERT INTO Writers(FirstName, LastName, MiddleName, Country)
    VALUES('William', 'Shakespeare', NULL, 'U.K.'),
	      ('Jane', 'Austen', NULL, 'U.K.'),
	      ('George', 'Orwell', NULL, 'U.K.'),
	      ('Thomas', 'Hardy', NULL, 'U.K.'),
	      ('Thomas', 'Eliot', 'Stearns', 'U.K.'),
	      ('William', 'Blake', NULL, 'U.K.'),
	      ('Lewis', 'Caroll', NULL, 'U.K.'),
	      ('Lev', 'Tolstoy', 'Nikolaevich', 'Russian Empire'),
	      ('Fyodor', 'Dostoevsky', 'Mikhailovich', 'Russian Empire'),
	      ('Nikolai', 'Gogol', 'Vasilyevich', 'Russian Empire'),
	      ('Anton', 'Chekhov', 'Pavlovich', 'Russian Empire'),
	      ('Izabella', 'Akhmadulina', 'Akhatovna', 'Russian Federation'),
	      ('Ilya', 'Ilf', NULL, 'Sovet Union'),
	      ('Yevgeny', 'Petrov', NULL, 'Sovet Union'),
		  ('Alexey', 'Tolstoy', 'Konstantinovich', 'Russian Empire'),
		  ('Alexey', 'Tolstoy', 'Nikolaevich', 'Russian Empire')
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

INSERT INTO BooksWriters(BookId, AuthorId)
    VALUES(1, 1),
	      (2, 1),
	      (3, 1),
		  (4, 2),
		  (5, 2),
		  (6, 3),
		  (7, 4),
		  (8, 4),
		  (9, 5),
		  (10, 5),
		  (11, 6),
		  (12, 6),
		  (13, 7),
		  (14, 7),
		  (15, 8),
		  (16, 8),
		  (17, 9),
		  (18, 9),
		  (19, 10),
		  (20, 10),
		  (21, 11),
		  (22, 11),
		  (23, 12),
		  (24, 12),
		  (25, 13),
		  (25, 14)
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

INSERT INTO BookCopy(BookId, Condition)
     VALUES(1, 10),
	       (1, 10),
	       (1, 10),
	       (1, 10),
	       (2, 10),
	       (2, 5),
	       (2, 9),
	       (2, 1),
	       (3, 3),
	       (3, 8),
	       (4, 10),
	       (4, 6),
	       (5, 10),
	       (5, 8),
	       (5, 2),
		   (6, 2),
		   (6, 10),
		   (7, 2),
		   (7, 10),
		   (8, 1),
		   (8, 2),
		   (8, 3),
		   (8, 9),
		   (9, 2),
		   (9, 10),
		   (9, 7),
		   (9, 3),
		   (10, 2),
		   (10, 7),
		   (10, 8),
		   (10, 2),
		   (10, 2),
		   (11, 10),
		   (11, 10),
		   (11, 10),
		   (11, 10),
		   (11, 10),
		   (12, 9),
		   (12, 9),
		   (12, 9),
		   (12, 9),
		   (13, 8),
		   (13, 7),
		   (13, 6),
		   (13, 5),
		   (14, 10),
		   (15, 8),
		   (16, 9),
		   (17, 10),
		   (17, 10),
		   (17, 10),
		   (17, 10),
		   (18, 9),
		   (19, 1),
		   (19, 0),
		   (19, 0),
		   (19, 0),
		   (19, 1),
		   (20, 0),
		   (20, 10),
		   (20, 7)
GO

INSERT INTO BooksOperation(ReaderId, CopyId, Given, WhoGiven, Back)
    VALUES(1, 1, '2021-09-08', 1 , NULL),
	      (2, 2, '2021-10-11', 1,  NULL),
	      (6, 10, '2021-12-08', 2, NULL),
	      (6, 4, '2021-09-08', 3 ,'2021-10-03'),
	      (8, 9, '2021-09-03', 2,  NULL),
	      (8, 8, '2021-04-08', 2 ,'2021-05-08'),
	      (5, 7, '2021-10-08', 3,  NULL),
		  (6, 7, '2021-10-09', 4,  NULL),
		  (7, 7, '2021-10-10', 3,  NULL),
		  (8, 7, '2021-10-11', 3,  NULL),
		  (8, 12, '2021-10-11', 3,  NULL),
		  (8, 13, '2021-10-11', 3,  NULL)
GO




SELECT WriterId, FirstName, LastName, MiddleName, Country
FROM Writers

SELECT LastName AS RussianWriters
FROM Writers
    WHERE (Country LIKE 'Russian%') OR
          (Country LIKE 'Sovet%')

SELECT WriterId AS BritishWriters
FROM Writers
    WHERE (FirstName = 'Thomas') AND
	      (Country = 'U.K.')

SELECT LastName AS BritishWriters
FROM Writers
    WHERE Country = 'U.K.'
	ORDER BY LastName

SELECT COUNT(ALL FirstName), FirstName
FROM Writers
    GROUP BY FirstName



SELECT Title, DeletedOn, WhoRemoved
FROM Books

SELECT WhoRemoved, DeletedOn
FROM Books
    WHERE DeletedOn IS NOT NULL

SELECT Title
FROM Books
    WHERE Title LIKE 'a%'

SELECT Title
FROM Books
    WHERE Title LIKE 'v_%'

SELECT DISTINCT Title
FROM Books



SELECT ReaderId, CopyId, Given, WhoGiven, Back
FROM BooksOperation

SELECT ReaderId, CopyId, Back AS WhenBack, WhoGiven, Given
FROM BooksOperation
    WHERE Back IS NOT NULL
	



SELECT FirstName, LastName, MiddleName, SubscribeDate, UnsubscribeDate
FROM Readers

SELECT ReaderId, FirstName, LastName
FROM Readers 
    WHERE SubscribeDate LIKE '%_05_%'
	ORDER BY FirstName DESC

SELECT COUNT(ReaderId) AS ReadersAmount
FROM Readers
    WHERE FirstName = 'Bob'

SELECT COUNT(ReaderId) AS ReadersAmount
FROM Readers
    WHERE SubscribeDate LIKE '%_05_%'


SELECT BookId, Condition
FROM BookCopy

SELECT COUNT(BookId), Condition 
FROM BookCopy
	GROUP BY Condition