CREATE VIEW WhenBackWhoGiven
AS
SELECT ReaderId, CopyId AS BookCopy, Back AS WhenBack, 
	(	
		SELECT FirstName		-- Ask a question about two sub queries.
		FROM Staff S
		WHERE BO.WhoGiven = S.WorkerId
	) AS WorkerName,
	(	
		SELECT LastName
		FROM Staff S
		WHERE BO.WhoGiven = S.WorkerId
	) AS LastName, Given  -- ORDER BY Date
FROM BooksOperation BO
    WHERE Back IS NOT NULL