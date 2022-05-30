CREATE PROCEDURE AddBook	
		@Title			  NVARCHAR(50),
		@AuthorName       NVARCHAR(15),
		@AuthorLastName   NVARCHAR(15),
		@AuthorMiddleName NVARCHAR(15),
		@Country          NVARCHAR(15)
		
AS
		DECLARE @BookId BIGINT = NULL
		DECLARE @WriterId BIGINT = NULL
BEGIN 		
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

	IF @WriterId IS NOT NULL
	BEGIN
		INSERT INTO Books(Title)
		VALUES(@Title)
		SET @BookId = @@IDENTITY 

		INSERT INTO BooksWriters(BookId, AuthorId)
		VALUES (@BookId, @WriterId)

		INSERT INTO BookCopy(BookId, Condition)
		VALUES (@BookId, 10)
	END
	ELSE
	BEGIN
		INSERT INTO Books(Title)
		VALUES(@Title)
		SET @BookId = @@IDENTITY 
		
		INSERT INTO Writers(FirstName, LastName, MiddleName, Country)
		VALUES (@AuthorName, @AuthorLastName, @AuthorMiddleName, @Country)
		SET @WriterId = @@IDENTITY

		INSERT INTO BooksWriters(BookId, AuthorId)
		VALUES (@BookId, @WriterId)

		INSERT INTO BookCopy(BookId, Condition)
		VALUES (@BookId, 10)
	END
END
