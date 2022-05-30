CREATE PROCEDURE ModifyBookCopyTitle
		@CopyId BIGINT,
		@Title NVARCHAR(50) = NULL
AS
	DECLARE @BookId BIGINT = NULL
	BEGIN
		SELECT @BookId = BookId
		FROM BookCopy
		WHERE CopyId = @CopyId
	    
		UPDATE Books
		SET Title = ISNULL(@Title, Title)
		WHERE BookId = @BookId
	END
