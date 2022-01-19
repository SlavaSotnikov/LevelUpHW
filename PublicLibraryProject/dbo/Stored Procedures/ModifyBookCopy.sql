CREATE PROCEDURE ModifyBookCopy
		@CopyId BIGINT,
		@Title NVARCHAR(50) = NULL,
		@AuthorName NVARCHAR(15) = NULL,
		@AuthorLastName NVARCHAR(15) = NULL,
		@AuthorMiddleName NVARCHAR(15) = NULL
AS
	DECLARE @BookId BIGINT = NULL
	DECLARE @WriterId BIGINT = NULL
	BEGIN
		SELECT @BookId = BookId
		FROM BookCopy
		WHERE CopyId = @CopyId
	    
		UPDATE Books
		SET Title = ISNULL(@Title, Title)
		WHERE BookId = @BookId
	END

	IF EXISTS 
		(
			SELECT FirstName, LastName
			FROM Writers 
			WHERE FirstName = @AuthorName AND LastName = @AuthorLastName 
				AND MiddleName IS NULL
		)
		BEGIN
		SELECT @WriterId = WriterId
		FROM Writers
		WHERE FirstName = @AuthorName AND LastName = @AuthorLastName

		UPDATE BooksWriters
		SET AuthorId = @WriterId
		WHERE BookId = @BookId
		END
	ELSE
		BEGIN
		SELECT @WriterId = WriterId
		FROM Writers
		WHERE FirstName = @AuthorName AND LastName = @AuthorLastName 
			AND MiddleName = @AuthorMiddleName

		UPDATE BooksWriters
		SET AuthorId = @WriterId
		WHERE BookId = @BookId
		END
