rem ---------------------------------------------------------------------------
rem   Set variables
rem ---------------------------------------------------------------------------
for /F "usebackq eol=; delims=" %%s in (ConfigurationVariables.ini) do set %%s

rem ---------------------------------------------------------------------------
rem   Remove Host and Shell apps, physical dirs and custom app pool
rem ---------------------------------------------------------------------------
if not defined wwwroot (
	exit /b
)

rem %inetsrv%\appcmd list apps /path:"/%HostAppPath%"
rem if "%ERRORLEVEL%" EQU "0" (
rem 	%inetsrv%\appcmd delete app "%DefaultSite%/%HostAppPath%"
rem )

rem %inetsrv%\appcmd list apps /path:"/%ShellAppPath%"
rem if "%ERRORLEVEL%" EQU "0" (
rem 	%inetsrv%\appcmd delete app "%DefaultSite%/%ShellAppPath%"
rem )

%inetsrv%\appcmd list apppool "%AppPool%"
if "%ERRORLEVEL%" EQU "0" (
	%inetsrv%\appcmd delete apppool "%AppPool%"
)

rem IF EXIST "%wwwroot%\%HostAppPath%" (
rem 	rd /s /q "%wwwroot%\%HostAppPath%"
rem )

rem IF EXIST "%wwwroot%\%ShellAppPath%" (
rem 	rd /s /q "%wwwroot%\%ShellAppPath%"
rem )
