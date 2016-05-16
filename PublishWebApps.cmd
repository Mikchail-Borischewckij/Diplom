rem ---------------------------------------------------------------------------
rem   Set variables
rem ---------------------------------------------------------------------------
set DeployDir=LocalDeploy
for /F "usebackq eol=; delims=" %%s in ("%DeployDir%\ConfigurationVariables.ini") do set %%s

set ManagedRuntimeVersion="v4.0"
set PingResponseTime=00:10:00
set FrameworkTempFiles=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\Temporary ASP.NET Files
set Framework64TempFiles=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files
set SqlServer=(local)\SQLEXPRESS
set MSBuildDir=c:\Program Files (x86)\MSBuild\12.0\Bin
set InternalToolsPrj=HomeFinance.UI
set ConfigurationMode=Debug


rem ---------------------------------------------------------------------------
rem   Remove Host and Shell apps, physical dirs and custom app pool
rem ---------------------------------------------------------------------------
if not defined wwwroot (
	exit /b
)

 rem %inetsrv%\appcmd list apps /path:"/%InternalToolsAppPath%"
 rem if "%ERRORLEVEL%" EQU "0" (
rem 	%inetsrv%\appcmd delete app "%DefaultSite%/%InternalToolsAppPath%"
rem  )

rem %inetsrv%\appcmd list apppool "%AppPool%"
rem if "%ERRORLEVEL%" EQU "0" (
rem 	%inetsrv%\appcmd delete apppool "%AppPool%"
rem )

rem IF EXIST "%wwwroot%\%InternalToolsAppPath%" (
rem 	rd /s /q "%wwwroot%\%InternalToolsAppPath%"
rem )

rem ---------------------------------------------------------------------------
rem   Create custom app pool, Host and Shell apps with physical dirs,
rem ---------------------------------------------------------------------------

%inetsrv%\appcmd add apppool /name:"%AppPool%" /managedRuntimeVersion:%ManagedRuntimeVersion% /managedPipelineMode:"Integrated" /processModel.pingResponseTime:%PingResponseTime%

rem md "%wwwroot%\%InternalToolsAppPath%"
rem %inetsrv%\appcmd add app /site.name:"%DefaultSite%" /path:/%InternalToolsAppPath% /physicalPath:"%wwwroot%\%InternalToolsAppPath%" /applicationPool:"%AppPool%"

rem ---------------------------------------------------------------------------
rem   Grant access ApplicationPoolIdentity to physical dirs and databases
rem ---------------------------------------------------------------------------

rem icacls "%wwwroot%\%HostAppPath%" /grant "Authenticated Users":(OI)(CI)MRXRW
rem icacls "%wwwroot%\%ShellAppPath%" /grant "Authenticated Users":(OI)(CI)MRXRW
rem icacls "%wwwroot%\%ProfileBuilderAppPath%" /grant "Authenticated Users":(OI)(CI)MRXRW
rem cacls "%wwwroot%\%InternalToolsAppPath%" /grant "Authenticated Users":(OI)(CI)MRXRW

rem This is needed to have possibility to debug WCF services from Visual Studio
rem icacls "%FrameworkTempFiles%" /grant "IIS APPPOOL\%AppPool%":(OI)(CI)MRXRW
rem icacls "%Framework64TempFiles%" /grant "IIS APPPOOL\%AppPool%":(OI)(CI)MRXRW

sqlcmd -S %SqlServer% -i "%DeployDir%\GrantAppPoolAccessToSqlServer.sql"


rem -------------------------------------------------
rem   Publish Host and Shell apps to local IIS
rem -------------------------------------------------

"%MSBuildDir%\msbuild" HomeFinance.sln /t:Clean
"%MSBuildDir%\msbuild" HomeFinance.sln /t:Build /p:DeployOnBuild=true /p:PublishProfile=LocalDeploy /p:Configuration=%ConfigurationMode% /p:Platform="Any CPU"


rem -------------------------------------------------
pause