CREATE VIEW BookGivenWorker
AS
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