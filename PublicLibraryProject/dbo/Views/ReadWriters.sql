CREATE VIEW ReadWriters
AS
SELECT R.FirstName AS ReaderName, R.LastName AS ReaderLastName, WR.FirstName AS WriterName, WR.LastName AS WriterLastName, COUNT(WR.FirstName) AS Amount
FROM Readers R
LEFT JOIN WriterReader WR ON R.ReaderId = WR.ReaderId
GROUP BY R.FirstName, R.LastName, WR.FirstName, WR.LastName
