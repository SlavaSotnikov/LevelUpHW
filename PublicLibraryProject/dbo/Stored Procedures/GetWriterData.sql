CREATE PROCEDURE GetWriterData
		@CopyId INT,
		@WriterName NVARCHAR(15) OUT,
		@WriterLastName NVARCHAR(15) OUT
AS
BEGIN
	SELECT @WriterName = FirstName, @WriterLastName = LastName
	FROM Writers W
		RIGHT JOIN BooksWriters BW ON W.WriterId = BW.AuthorId
		RIGHT JOIN Books B ON BW.BookId = B.BookId
		RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
	WHERE BC.CopyId = @CopyId
END
