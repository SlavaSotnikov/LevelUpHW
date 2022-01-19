
CREATE VIEW SimilarTiles
AS
SELECT COUNT(BookId) AS Amount, Title  --Find similar Titles
FROM Books
GROUP BY Title
HAVING COUNT(BookId) > 1