CREATE PROCEDURE GetTitleWriter
		@Title NVARCHAR(50) = NULL 
AS
	IF @Title IS NULL
	BEGIN
		PRINT 'Wrong Title.'
    END
	ELSE
	BEGIN
	SELECT Title, W.FirstName, W.LastName
	FROM Books B
	LEFT JOIN BooksWriters BW ON B.BookId = BW.BookId
	LEFT JOIN Writers W ON BW.AuthorId = W.WriterId
	WHERE B.Title LIKE @Title
	ORDER BY W.LastName
	END
