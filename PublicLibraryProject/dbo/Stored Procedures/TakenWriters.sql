CREATE PROCEDURE TakenWriters
		@ReaderId BIGINT = NULL
AS
	IF @ReaderId IS NULL
	BEGIN
		PRINT 'Wrong identifier.'
	END
	ELSE
	BEGIN

		SELECT W.FirstName, W.LastName, W.MiddleName, COUNT(BO.Given) AS Taken
		FROM Writers W
			RIGHT JOIN BooksWriters BW ON W.WriterId = BW.AuthorId
			RIGHT JOIN Books B ON BW.BookId = B.BookId
			RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
			RIGHT JOIN BooksOperation BO ON BC.CopyId = BO.CopyId
			RIGHT JOIN Readers R ON BO.ReaderId = R.ReaderId
			WHERE W.FirstName IS NOT NULL AND BO.ReaderId = @ReaderId
			GROUP BY W.FirstName, W.LastName, W.MiddleName
	END
