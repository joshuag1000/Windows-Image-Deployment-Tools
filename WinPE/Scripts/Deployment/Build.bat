@echo off
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
if not "!folder%selection%!"=="" (
    call ApplyImage.bat "\!folder%selection%!"
    call ApplyRecovery.bat
) else (
    echo No Wim files were found.
    goto :CaptureQuestion
)
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
