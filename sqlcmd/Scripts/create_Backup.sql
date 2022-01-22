USE PublicLibrary
GO

DECLARE @BackupName VARCHAR(100) = 'Full Backup of PublicLibraryDB';
SET @BackupName = @BackupName + CONVERT(VARCHAR(20), GETDATE());
--PRINT @BackupName
BACKUP DATABASE PublicLibrary
TO DISK = '.\Backups\PublicLibrary.bak'     
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = @BackupName
GO