
CREATE PROCEDURE GetGivenBooksForQuarter
		@Quarter TINYINT = NULL
AS
DECLARE @start DATETIME = CAST(YEAR(GETDATE()) - 1 AS CHAR(4)) + 
'-' + CAST((@quarter - 1) * 3 + 1 AS CHAR(2)) + '-01'
DECLARE @finish DATETIME = DATEADD(MONTH, 3, @start)

SELECT Title, FirstName, LastName, Given
FROM Staff S
	LEFT JOIN BooksOperation BO ON BO.WhoGiven = S.WorkerId
	LEFT JOIN BookCopy BC ON BC.CopyId = BO.CopyId
	LEFT JOIN Books B ON B.BookId = BC.BookId
WHERE BO.Given BETWEEN @start AND @finish
