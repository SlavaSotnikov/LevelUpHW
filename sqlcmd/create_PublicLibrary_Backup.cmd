sqlcmd -S 192.168.1.220 -U User1 -P User1 -i .\Scripts\create_Backup.sql -o .\Reports\backup_report.txt
notepad .\Reports\backup_report.txt