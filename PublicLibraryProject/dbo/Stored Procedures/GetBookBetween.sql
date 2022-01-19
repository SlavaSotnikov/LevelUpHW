CREATE PROCEDURE GetBookBetween
		@Id     BIGINT = NULL,
		@From  DATE = NULL,
		@To DATE = NULL
AS
	IF @Id IS NULL
	BEGIN
		PRINT 'Wrong identifier.'
	END
	IF (@From IS NULL) OR (@To IS NULL)
	BEGIN
		PRINT 'Wrong Date.'
	END
	ELSE
	BEGIN
SELECT 
	(
		SELECT Title 
		FROM Books B
		LEFT JOIN BookCopy BC ON B.BookId = BC.BookId
		WHERE BC.CopyId = BO.CopyId
	) AS Book, Given, 
	(	
		SELECT FirstName		-- Ask a question about two sub queries.
		FROM Staff S
		WHERE BO.WhoGiven = S.WorkerId
	) AS WorkerName,
	(	
		SELECT LastName
		FROM Staff S
		WHERE BO.WhoGiven = S.WorkerId
	) AS LastName -- ORDER BY Date
FROM BooksOperation BO
WHERE (ReaderId = @Id) AND (Given BETWEEN @From AND @To)
END
