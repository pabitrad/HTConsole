@echo OFF

REM Insert the log file directory

SET LOGDIR=C:\EBackup

REM Insert the directory where the HTBase.exe file is

SET EXEDIR=C:\HTBase\HTBackup

REM Insert the directory where the Incremental backups should be stored

SET INCDIR=C:\EBackup\Incremental

REM Insert the directory where your Essbase Applications are located

SET APPDIR=C:\Hyperion\products\Essbase\EssbaseServer\app\

cd %INCDIR%

set TIMESTAMP=%DATE:~0,2%-%DATE:~3,2%-%DATE:~6,4%-%TIME:~0,2%.%TIME:~3,2%.%TIME:~6,2%

md "%TIMESTAMP%"

cd %EXEDIR%

HTBase.exe /incremental /logfile=%LOGDIR%/HTBase.log /r /y %APPDIR% %INCDIR%/"%TIMESTAMP%" >> %LOGDIR%\HTBaseIncrementalBackup.log