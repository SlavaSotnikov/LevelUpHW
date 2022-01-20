sqlcmd -S 192.168.1.220 -U User1 -P User1 -Q "CREATE DATABASE PublicLibrary" -o .\Reports\create_report.txt
notepad .\Reports\create_report.txt