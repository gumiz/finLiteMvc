REM ten aby skrypt wymaga uzupe³nienia pliku c:\Users\gumiz\AppData\Roaming\postgresql\pgpass.conf
c:\"Program Files"\PostgreSQL\9.4\bin\pg_dump.exe -U postgres -w -d finLiteDb -f finLiteDb.sql

REM ten aby skrypt NIE wymaga rêcznego podania has³a
REM c:\"Program Files"\PostgreSQL\9.4\bin\pg_dump.exe -U postgres -d finLiteDb -f finLiteDb.sql