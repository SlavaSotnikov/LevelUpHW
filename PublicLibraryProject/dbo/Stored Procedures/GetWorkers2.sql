CREATE PROCEDURE GetWorkers2
		@Id BIGINT = NULL,
		@PositionFilter NVARCHAR(50) = NULL
AS
	SELECT PositionId, Position
	FROM Occupation
	WHERE ((@Id IS NULL) OR (@Id = PositionId))
	AND ((@PositionFilter IS NULL) OR (Position LIKE @PositionFilter))
