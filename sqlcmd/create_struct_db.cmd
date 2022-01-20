sqlcmd -S 192.168.1.220 -U User1 -P User1 -i .\Scripts\CreateTables.sql -o .\Reports\create_struct_report.txt
notepad .\Reports\create_struct_report.txt