CREATE VIEW FavoriteWriters
AS
SELECT W.FirstName, W.LastName, W.MiddleName, COUNT(BO.Given) AS Popularity
FROM Writers W
	RIGHT JOIN BooksWriters BW ON W.WriterId = BW.AuthorId
	RIGHT JOIN Books B ON BW.BookId = B.BookId
	RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
	RIGHT JOIN BooksOperation BO ON BC.CopyId = BO.CopyId
	RIGHT JOIN Readers R ON BO.ReaderId = R.ReaderId
	WHERE W.FirstName IS NOT NULL
	GROUP BY W.FirstName, W.LastName, W.MiddleName