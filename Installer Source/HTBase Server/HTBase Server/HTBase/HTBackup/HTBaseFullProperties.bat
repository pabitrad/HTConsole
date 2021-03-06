@echo OFF

REM Insert the log file directory

SET LOGDIR=C:\HTBase\Logs

REM Insert the directory where the HTBase.exe file is

SET EXEDIR=C:\HTBase\HTBackup

REM Insert the directory where the Full backup should be stored

SET FULLDIR=C:\HTBase\Backup

REM Insert the directory where your Essbase Applications are located

SET APPDIR=C:\user_projects\epmsystem1\EssbaseServer\essbaseserver1\app\Demo

cd %FULLDIR%

set TIMESTAMP=%DATE:~0,2%-%DATE:~3,2%-%DATE:~6,4%-%TIME:~0,2%.%TIME:~3,2%.%TIME:~6,2%

md "%TIMESTAMP%"

cd %EXEDIR%

HTBase.exe /full /logfile=%LOGDIR%\HTBase.log /r /y %APPDIR% %FULLDIR%/"%TIMESTAMP%" >> %LOGDIR%\HTBaseFullBackup.log