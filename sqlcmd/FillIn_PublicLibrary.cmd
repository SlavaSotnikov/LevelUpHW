sqlcmd -S 192.168.1.220 -U User1 -P User1 -i .\Scripts\FillIn_Tables.sql -o .\Reports\fillin_report.txt
notepad .\Reports\fillin_report.txt