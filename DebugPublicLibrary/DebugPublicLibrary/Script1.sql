DECLARE @Title NVARCHAR(50)
DECLARE @CopyId INT
SET @Title = 'Test';
SET @CopyId = 44;
EXEC GetBookTitle @CopyId, @Title OUT --@CopyId = 44 ??? 

IF @Title IS NULL
	PRINT 'NULL'
ELSE
	PRINT @Title