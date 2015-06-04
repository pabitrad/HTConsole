@echo OFF

REM Insert the log file directory

SET LOGDIR=D:\ORCL\MW\HTBase\HTCluster\Logs

REM Insert the directory where the HTCluster.exe file is

SET EXEDIR=D:\ORCL\MW\HTBase\HTCluster

REM Insert the directory where the Incremental Replicas should be stored for Clustering

SET INCDIR=H:\

REM Insert the directory where your Essbase Applications are located

SET APPDIR=D:\ORCL\MW\user_projects\epmsystem1\EssbaseServer\essbaseserver1\app\FSNPlan

cd %EXEDIR%

HTCluster.exe /incremental /logfile=%LOGDIR%/HTCluster.log /r /y %APPDIR% %INCDIR% >> %LOGDIR%\HTClusterIncrementalReplica.log

