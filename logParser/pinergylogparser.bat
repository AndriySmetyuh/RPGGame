@echo off
setlocal

set file=errors.txt
set minbytesize=1
set url="smtps://smtp.gmail.com:465"
set from=pinergyserver@gmail.com
set to=andr@v-lan.org.ua

logparser -i:TEXTLINE -iCodepage:1 -iCheckpoint:C:\Apps\Pinergy\LandlordsWebsite\LandLords\LandLords.WebUI\logs\pinergy.lpc -o:CSV "SELECT Text AS Error_Details, LogFilename AS Filepath INTO 'C:\Users\user2\Documents\Visual Studio 2013\Projects\RPGGame\ProbabilityTest\bin\Debug\errors.txt' FROM 'C:\Users\user2\Documents\Visual Studio 2013\Projects\RPGGame\ProbabilityTest\bin\Debug\mylogfile.txt' WHERE Text LIKE '%%error%%'"

rem CHANGE AS REQUIRED
cd C:\Users\user2\Documents\Visual Studio 2013\Projects\RPGGame\ProbabilityTest\bin\Debug

echo.Check error file - %file% - exists
IF NOT EXIST %file% GOTO NotExist

echo.Get size of error file - %file%
rem Without usebackq, the ' quote means command and not string (Run FOR /? for the details) 
rem Another alternative (To better deal with spaces in filenames) is to use: FOR /F "tokens=*" %%A IN ("%file%") DO
FOR %%F IN (%file%) DO set size=%%~zF
echo.Size  of error file - %file% = %size%

echo.Check file size = %size% against min size = %minbytesize%
IF %size% LSS %minbytesize% (
    echo.There are NO new errors in the log files so don't send email

) ELSE (
    echo.There are new errors in the log files so send an email

    echo.Create the email message as a file from the error file

    echo.From: %from% > email.txt
    echo.To: %to% >> email.txt
	echo.Subject: Pinergy - Errors in Log Files >> email.txt
    echo.See attached for log file errors: >> email.txt
    type %file% >> email.txt

    echo.Send the email mssage via %url% to %to% from %from%
    curl --url %url% --ssl-reqd --mail-from %from% --mail-rcpt %to% --upload-file email.txt --user "pinergyserver@gmail.com:{&D9uwzZ" --insecure

)

GOTO End

:NotExist
  echo.Error file - %file% - does not exist

:End
