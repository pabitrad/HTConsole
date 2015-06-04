@echo OFF

REM Insert the log file directory

SET LOGDIR=C:\\HTBase\HTCluster\Logs

REM Insert the directory where the HTCluster.exe file is

SET EXEDIR=C:\HTBase\HTCluster

REM Insert the directory where the Incremental Replicas should be stored for Clustering

SET INCDIR=C:\

REM Insert the directory where your Essbase Applications are located

SET APPDIR=C:\user_projects\epmsystem1\EssbaseServer\essbaseserver1\app\FSNPlan

cd %EXEDIR%

HTCluster.exe /incremental /logfile=%LOGDIR%/HTCluster.log /r /y %APPDIR% %INCDIR% >> %LOGDIR%\HTClusterIncrementalReplica.log

