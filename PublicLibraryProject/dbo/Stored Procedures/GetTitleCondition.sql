CREATE PROCEDURE GetTitleCondition
		@CopyId BIGINT,
		@Title NVARCHAR(50) OUT,
		@Condition INT OUT
AS		
		SELECT @Title = Title, @Condition = Condition
		FROM Books B
		RIGHT JOIN BookCopy BC ON B.BookId = BC.BookId
		WHERE BC.CopyId = @CopyId
