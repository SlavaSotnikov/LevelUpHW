CREATE PROCEDURE DeleteBook
		@CopyId BIGINT
AS
	DECLARE @Amount BIGINT
	DECLARE @BookId BIGINT
	DECLARE @WriterId BIGINT

	SELECT @BookId = BookId 
	FROM BookCopy 
	WHERE CopyId = @CopyId

	SELECT @Amount = COUNT(CopyId)
	FROM BookCopy
	WHERE BookId = @BookId
	
	IF (@Amount > 1)
	BEGIN
		DELETE FROM BookCopy
		WHERE CopyId = @CopyId
	END
	ELSE
	BEGIN
		DELETE FROM BookCopy
		WHERE CopyId = @CopyId			
	END
	 		
	SELECT @WriterId = AuthorId
		FROM BooksWriters
		WHERE BookId = @BookId

	WHILE @WriterId IS NOT NULL
	BEGIN		
		SELECT @Amount = COUNT(BookId)
		FROM BooksWriters
		WHERE AuthorId = @WriterId

		IF (@Amount = 1)
		BEGIN
			DELETE FROM BooksWriters
			WHERE AuthorId = @WriterId

			DELETE FROM Books
		    WHERE BookId = @BookId

			DELETE FROM Writers
			WHERE WriterId = @WriterId
			
			SELECT @WriterId = AuthorId
			FROM BooksWriters
			WHERE BookId = @BookId
		END
		ELSE
		BEGIN
			BREAK
		END		
	END
