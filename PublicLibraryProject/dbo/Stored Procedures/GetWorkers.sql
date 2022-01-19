CREATE PROCEDURE GetWorkers
		@Id BIGINT = NULL
AS
	IF @Id IS NULL
	BEGIN
		PRINT 'Id is NULL'

		SELECT *
		FROM Occupation 
		
	END
    ELSE
	BEGIN
		PRINT @Id

		SELECT *
		FROM Occupation 
		WHERE PositionId = @Id
	END
	
