﻿CREATE VIEW WorkersPrevYears
AS
	SELECT WorkerId, FirstName, LastName, Haired
	FROM Staff
	WHERE YEAR(Haired) < CONVERT(VARCHAR(4), YEAR(GETDATE()))
WITH CHECK OPTION
