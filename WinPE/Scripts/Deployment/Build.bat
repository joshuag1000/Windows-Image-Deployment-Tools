@echo off
setlocal ENABLEEXTENSIONS
setlocal enableDelayedExpansion
::build "array" of Wim Files
set folderCnt=0
for /f "eol=: delims=" %%F in ('dir /b \*.wim') do (
  set /a folderCnt+=1
  set "folder!folderCnt!=%%F"
)
if %folderCnt% EQU 0 (
    echo No Wim files were found.
    goto :CaptureQuestion
)
if %folderCnt% EQU 1 (
    echo Only one wim file detected selecting file.
    set selection=1
) else (
    echo More than one image detected please select an image:
    ::print menu
    for /l %%N in (1 1 %folderCnt%) do echo %%N - !folder%%N!
    echo(
    set selection=
    set /p "selection=Image: "
)
if "!folder%selection%!"=="" (
    echo No Wim files were found.
    goto :CaptureQuestion
)

(echo Rescan
echo List Disk
echo Exit
)  | diskpart

set /P diskNumber=Please select a drive to install the image to:
Set "OldString1=select disk 0"  
Set "NewString1=select disk %diskNumber%"  

@ECHO OFF &SETLOCAL
cd /D %~dp0
for %%x in (.\DismTemplates\*.txt) do call:process "%%~x"

call ApplyImage.bat "\!folder%selection%!"
call ApplyRecovery.bat
goto :EOF

:CaptureQuestion
set /P c=Would you like to capture the existing image on this device [Y/N]? 
if /I "%c%" EQU "N" goto :EOF
if /I "%c%" EQU "n" goto :EOF
if /I "%c%" EQU "Y" goto :CaptureImage
if /I "%c%" EQU "y" goto :CaptureImage
goto :CaptureQuestion

:CaptureImage
call CaptureImage.bat

goto :EOF

:: https://superuser.com/a/683079
:process 
set "outFile=%~n1%~x1"  
(for /f "skip=2 delims=" %%a in ('find /n /v "" "%~1"') do (  
    set "ln=%%a"  
    Setlocal enableDelayedExpansion  
    set "ln=!ln:*]=!"  
    if defined ln (
        set "ln=!ln:%OldString1%=%NewString1%!"  
    )
    echo(!ln!  
    endlocal  
))>"%outFile%"
exit /b