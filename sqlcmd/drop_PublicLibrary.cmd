sqlcmd -S 192.168.1.220 -U User1 -P User1 -i .\Scripts\drop_PublicLibrary.sql -o .\Reports\drop_report.txt
notepad .\Reports\drop_report.txt