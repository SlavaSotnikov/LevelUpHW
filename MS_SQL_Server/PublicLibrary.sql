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

DECLARE @BackupName VARCHAR(100) = 'Full Backup of PublicLibraryDB';
SET @BackupName = @BackupName + CONVERT(VARCHAR(20), GETDATE());
--PRINT @BackupName
BACKUP DATABASE PublicLibrary
TO DISK = 'D:\SQLBackups\PublicLibraryDB.bak'     
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = @BackupName
	 

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
		  ('Alexey', 'Tolstoy', 'Nikolaevich', 'Russian Empire'),
		  ('Mikhail', 'Lermontov', 'Yuryevich', 'Russian Empire')
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
	      ('The Little Golden Calf'),
		  ('A Confession'),
		  ('A Confession'),
		  ('Prince Serebrenni'),-- Aleksey Konstantinovich Tolstoy
		  ('Tsar Boris'), -- Aleksey Konstantinovich Tolstoy
		  ('The Great Big Enormous Turnip'), -- Aleksey Nikolayevich Tolstoy
		  ('Aelita, Or, The Decline of Mars') -- Aleksey Nikolayevich Tolstoy
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
		  (25, 14),
		  (26, 8),
		  (27, 17),
		  (28, 15),
		  (29, 15),
		  (30, 16),
		  (31, 16)
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
		   (20, 7),
		   (26, 8),
		   (26, 10),
		   (27, 9),
		   (27, 10)

GO

INSERT INTO BooksOperation(ReaderId, CopyId, Given, WhoGiven, Back)
    VALUES--(1, 1, '2021-09-08', 1 , NULL),
	      --(2, 2, '2021-10-11', 1,  NULL),
	      --(6, 10, '2021-12-08', 2, NULL),
	      --(6, 4, '2021-09-08', 3 ,'2021-10-03'),
	      --(8, 9, '2021-09-03', 2,  NULL),
	      --(8, 8, '2021-04-08', 2 ,'2021-05-08'),
	      --(5, 3, '2021-10-08', 3,  NULL),
		  --(6, 6, '2021-10-09', 4,  NULL),
		  --(7, 5, '2021-10-10', 3,  NULL),
		  --(8, 7, '2021-10-11', 3,  NULL),
		  --(8, 12, '2021-10-11', 3,  NULL),
		  --(8, 13, '2021-10-11', 3,  NULL),
		  --(7, 20, '2021-12-12', 4, '2021-12-25'),
		  --(5, 21, '2021-11-02', 2, '2021-12-20'),
		  --(2, 47, '2021-09-02', 1, '2021-09-20'),
		  --(2, 48, '2021-10-05', 1, '2021-11-04')
		  (1, 17, '2021-10-05', 1, '2021-11-04'),
		  (1, 17, '2021-10-05', 1, '2021-11-04')
GO

------- FROM Writers------------------

SELECT WriterId, FirstName, LastName, MiddleName, Country
FROM Writers
ORDER BY FirstName

SELECT LastName AS RussianWriters
FROM Writers
    WHERE (Country LIKE 'Russian%') 
          OR (Country LIKE 'Sovet%')

SELECT WriterId AS BritishWriters
FROM Writers
    WHERE (FirstName = 'Thomas') AND
	      (Country = 'U.K.')

SELECT LastName AS BritishWriters
FROM Writers
WHERE Country = 'U.K.'
ORDER BY LastName

SELECT COUNT(ALL LastName), FirstName
FROM Writers
    GROUP BY FirstName

SELECT COUNT(DISTINCT LastName), FirstName
FROM Writers
    GROUP BY FirstName

------- FROM Books------------------

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

SELECT COUNT(BookId), Title  --Find similar Titles
FROM Books
GROUP BY Title
HAVING COUNT(BookId) > 1

SELECT BookId, COUNT(*) AS Books , Condition 
FROM BookCopy
GROUP BY BookId, Condition

------- FROM BooksOperation------------------

SELECT ReaderId, CopyId, Given, WhoGiven, Back
FROM BooksOperation

SELECT ReaderId, CopyId, Back AS WhenBack, WhoGiven, Given  -- ORDER BY Date
FROM BooksOperation
    WHERE Back IS NOT NULL
	

------- FROM Readers------------------

SELECT FirstName, LastName, MiddleName, SubscribeDate, UnsubscribeDate
FROM Readers

SELECT ReaderId, FirstName, LastName
FROM Readers 
    WHERE SubscribeDate LIKE '%_05_%'
	ORDER BY FirstName DESC

SELECT ReaderId, FirstName, LastName
FROM Readers 
    WHERE MONTH(SubscribeDate) = 5
	ORDER BY  FirstName DESC

SELECT COUNT(ReaderId) AS ReadersAmount
FROM Readers
    WHERE FirstName = 'Bob'

SELECT COUNT(ReaderId) AS ReadersAmount
FROM Readers
    WHERE SubscribeDate LIKE '%_05_%'

------- FROM BookCopy------------------

SELECT BookId, Condition
FROM BookCopy
ORDER BY Condition

SELECT BookId, COUNT(*) AS Books , Condition 
FROM BookCopy
	GROUP BY BookId, Condition
	--HAVING AVG(Condition) < 5

------- UNION ------------------

SELECT BookId 
FROM Books
UNION ALL
SELECT CopyId
FROM BookCopy
ORDER BY BookId

SELECT BookId, Title
FROM Books
UNION
SELECT WriterId, LastName
FROM Writers
ORDER BY BookId

------- Multi-Table Queries ------------------

SELECT FirstName, LastName
FROM Writers
WHERE EXISTS
(
 SELECT CopyId
 FROM BooksOperation
)
ORDER BY FirstName
-- All Authors BETWEEN 

SELECT ReaderId, FirstName, LastName
FROM Readers R
WHERE EXISTS
(
 SELECT ReaderId
 FROM BooksOperation
 WHERE Back IS NOT NULL AND R.ReaderId = BooksOperation.ReaderId
)
-- Try BETWEEN 

SELECT COUNT(CopyId) AS BooksCopy
FROM BookCopy
WHERE BookId = 
(
 SELECT BookId
 FROM Books
 WHERE Title = 'Macbeth'
)

SELECT FirstName, LastName, Haired
FROM Staff
WHERE WorkerId IN 
(
 SELECT WhoGiven
 FROM BooksOperation
 WHERE CopyId IN 
 (
  SELECT CopyId
  FROM BookCopy
  WHERE BookId = 
  (
   SELECT BookId
   FROM Books
   WHERE Title = 'Hamlet'
  )
 )
)

SELECT FirstName, LastName
FROM Staff
WHERE WorkerId IN
(
 SELECT WorkerId
 FROM WorkerPosition
 WHERE PositionId IN 
 (
  SELECT PositionId
  FROM Occupation
  WHERE Position = 'Librarian'
 )
)

SELECT Title
FROM Books
WHERE BookId IN
(
 SELECT BookId
 FROM BooksWriters
 WHERE AuthorId IN
 (
  SELECT WriterId
  FROM Writers
  WHERE (Country NOT LIKE '%rus%') AND
        (Country NOT LIKE '%sov%')
 )
)

SELECT FirstName, LastName
FROM Readers
WHERE ReaderId IN
(
 SELECT ReaderId
 FROM BooksOperation
 GROUP BY ReaderId
 HAVING COUNT(ReaderId) >= 2
)

------- JOINS ------------------

SELECT * 
FROM BooksWriters BW, Writers W
WHERE W.WriterId = BW.AuthorId
ORDER BY FirstName

SELECT *
FROM BooksWriters BW INNER JOIN Writers W
ON BW.BookId = W.WriterId

SELECT FirstName, LastName
FROM Writers
RIGHT JOIN BooksWriters 
ON BooksWriters.AuthorId = Writers.WriterId

SELECT FirstName, LastName
FROM BooksWriters
LEFT JOIN Writers 
ON BooksWriters.AuthorId = Writers.WriterId

-- Book's condition less than 5 
SELECT CopyId, Title
FROM Books B
	INNER JOIN BookCopy BC ON BC.BookId = B.BookId
WHERE BC.Condition < 5

-- Who got back book on time
SELECT CopyId, FirstName, LastName, Given, Back
FROM Readers R
	RIGHT JOIN BooksOperation BO ON R.ReaderId = BO.ReaderId
WHERE DATEDIFF(MONTH, Given, Back) <= 1
ORDER BY FirstName

-- Who've got expired, how many days.
SELECT BO.CopyId, Title, FirstName, LastName, DATEDIFF(DAY, BO.Given, BO.Back) - 30 AS Expire
FROM Readers R
	RIGHT JOIN BooksOperation BO ON R.ReaderId = BO.ReaderId
	RIGHT JOIN BookCopy BC ON BO.CopyId = BC.CopyId
	RIGHT JOIN Books B ON BC.BookId = B.BookId
WHERE DATEDIFF(DAY, Given, Back) > 30
ORDER BY FirstName

-- Who has books. How many days. Keep holding beyond 30 days. Not Back.
SELECT BO.CopyId, Title, FirstName, LastName, DATEDIFF(DAY, BO.Given, GETDATE()) AS DaysPass
FROM Readers R
	LEFT JOIN BooksOperation BO ON R.ReaderId = BO.ReaderId
	LEFT JOIN BookCopy BC ON BO.CopyId = BC.CopyId
	LEFT JOIN Books B ON BC.BookId = B.BookId
WHERE DATEDIFF(DAY, BO.Given, GETDATE()) > 30 AND Back IS NULL
ORDER BY FirstName 

SELECT * FROM Readers

-- All books all writers
SELECT B.BookId, Title AS Book, FirstName, LastName, MiddleName
FROM Books B
	RIGHT JOIN BooksWriters BW ON BW.BookId = B.BookId
	RIGHT JOIN Writers W ON W.WriterId = BW.AuthorId
ORDER BY FirstName

-- Positions how many occupied a position. 
SELECT Position, COUNT(*) AS Workers
FROM Staff S
	RIGHT JOIN WorkerPosition WP ON WP.WorkerId = S.WorkerId
	RIGHT JOIN Occupation O ON O.PositionId = WP.PositionId
GROUP BY Position

-- Reader, Book copies, Title, Who given, When, When back.
SELECT R.FirstName, R.LastName, BC.CopyId AS BookCopy, Title, S.FirstName, S.LastName, Given,
DATEADD(MONTH, 1, BO.Given) AS MustBack
FROM BooksOperation BO
	LEFT JOIN Readers R ON R.ReaderId = BO.ReaderId
	LEFT JOIN BookCopy BC ON BC.CopyId = BO.CopyId
	LEFT JOIN Books B ON BC.BookId = B.BookId
	LEFT JOIN Staff S ON BO.WhoGiven = S.WorkerId
ORDER BY R.FirstName

-- Book title and who has been given for 1 quarter.
DECLARE @quarter TINYINT = 4;
DECLARE @start DATETIME = CAST(YEAR(GETDATE()) AS CHAR(4)) + 
'-' + CAST((@quarter - 1) * 3 + 1 AS CHAR(2)) + '-01'
DECLARE @finish DATETIME = DATEADD(MONTH, 3, @start)

SELECT Title, FirstName, LastName, Given
FROM Staff S
	LEFT JOIN BooksOperation BO ON BO.WhoGiven = S.WorkerId
	LEFT JOIN BookCopy BC ON BC.CopyId = BO.CopyId
	LEFT JOIN Books B ON B.BookId = BC.BookId
WHERE BO.Given BETWEEN @start AND @finish

-- SubQuery
SELECT R.ReaderId, FirstName, LastName, COUNT(BC.CopyId) AS Books
FROM Readers R
	INNER JOIN BooksOperation BO ON R.ReaderId = BO.ReaderId
	INNER JOIN BookCopy BC ON BO.CopyId = BC.CopyId
	INNER JOIN Books B ON BC.BookId = B.BookId
GROUP BY R.ReaderId, R.FirstName, R.LastName

SELECT R.ReaderId, FirstName, LastName,
	(
		SELECT COUNT(CopyId)
		FROM BooksOperation BO
		WHERE BO.ReaderId = R.ReaderId
	) AS Books
FROM Readers R
GROUP BY R.ReaderId, R.FirstName, R.LastName

-- Writer. How many times has been given.
SELECT R.FirstName, R.LastName, R.MiddleName, W.FirstName, W.LastName, W.MiddleName
FROM Writers W
	RIGHT JOIN BooksWriters BW ON W.WriterId = BW.AuthorId
	RIGHT JOIN Books B ON BW.BookId = B.BookId
	RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
	RIGHT JOIN BooksOperation BO ON BC.CopyId = BO.CopyId
	RIGHT JOIN Readers R ON BO.ReaderId = R.ReaderId
	WHERE W.FirstName IS NOT NULL
	ORDER BY R.FirstName, W.FirstName DESC




SELECT * FROM Writers
SELECT * FROM BooksOperation
SELECT * FROM Books
SELECT * FROM BookCopy
