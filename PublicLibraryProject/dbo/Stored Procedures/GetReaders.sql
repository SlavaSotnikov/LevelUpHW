CREATE PROCEDURE GetReaders
		@AuthorSurname NVARCHAR(50) = NULL
AS
IF @AuthorSurname IS NULL
BEGIN
	SELECT R.ReaderId, R.FirstName, R.LastName, R.MiddleName, BO.Given
FROM Writers W
	RIGHT JOIN BooksWriters BW ON W.WriterId = BW.AuthorId
	RIGHT JOIN Books B ON BW.BookId = B.BookId
	RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
	RIGHT JOIN BooksOperation BO ON BC.CopyId = BO.CopyId
	RIGHT JOIN Readers R ON BO.ReaderId = R.ReaderId
END
ELSE
BEGIN
SELECT R.ReaderId, R.FirstName, R.LastName, R.MiddleName, BO.Given
FROM Writers W
	RIGHT JOIN BooksWriters BW ON W.WriterId = BW.AuthorId
	RIGHT JOIN Books B ON BW.BookId = B.BookId
	RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
	RIGHT JOIN BooksOperation BO ON BC.CopyId = BO.CopyId
	RIGHT JOIN Readers R ON BO.ReaderId = R.ReaderId
	WHERE W.LastName = @AuthorSurname
END
