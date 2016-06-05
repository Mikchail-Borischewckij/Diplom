@echo off
set IniFileName=CreateMetadataDatabase.ini
for /F "usebackq eol=;" %%s in ("%IniFileName%") do set %%s

sqlcmd -S %ServerName% -E -v DatabaseName=%DatabaseName% -i InitData.sql

pause
