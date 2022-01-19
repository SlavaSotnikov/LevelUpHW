CREATE PROCEDURE GetBookTitle
		@CopyId INT,
		@Title NVARCHAR(50) OUT
		
AS
BEGIN
	SELECT @Title = Title
	FROM Books B
		RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
	WHERE BC.CopyId = @CopyId
END
