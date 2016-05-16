:SETVAR AppPoolUser "IIS APPPOOL\DefaultAppPool"

USE [Master]
GO
IF NOT EXISTS (SELECT name FROM master.sys.server_principals WHERE name = '$(AppPoolUser)')
BEGIN
	CREATE LOGIN [$(AppPoolUser)] FROM WINDOWS;
END
GO

USE [HomeFinance]
GO

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = '$(AppPoolUser)')
BEGIN
	CREATE USER [$(AppPoolUser)] FOR LOGIN [$(AppPoolUser)]
END
GO

SP_ADDROLEMEMBER 'db_owner', '$(AppPoolUser)'
GO
