sqlcmd -S 192.168.1.220 -U User1 -P User1 -i .\Scripts\restore_PublicLibrary.sql -o .\Reports\restore_report.txt
notepad .\Reports\restore_report.txt