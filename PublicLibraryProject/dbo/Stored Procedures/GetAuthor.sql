
CREATE PROCEDURE GetAuthor	

		@AuthorName       NVARCHAR(30),
		@AuthorLastName   NVARCHAR(30),
		@AuthorMiddleName NVARCHAR(30)		
AS
		DECLARE @WriterId BIGINT = NULL

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
		END
		ELSE
		BEGIN
			SELECT @WriterId = WriterId
			FROM Writers
			WHERE FirstName = @AuthorName AND LastName = @AuthorLastName
				AND MiddleName = @AuthorMiddleName
		END

		PRINT @WriterId
