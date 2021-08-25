@echo off
cd Deployment
echo -- Are you sure you would like to proceed with Imaging this pc? Everything will be wiped. --
echo -- If you would like to capture the image on this device say no. --
echo -- So are you sure (Y/N): 
SET /P RECOVERYEXIST=(Y or N):
if /I "%RECOVERYEXIST%" EQU "N" goto :CaptureImage
echo -- Are you REALLY sure (Y/N): 
SET /P RECOVERYEXIST=(Y or N):
if /I "%RECOVERYEXIST%" EQU "N" goto :CaptureImage
echo -- Build PC Image --
call build.bat
goto :EOF
:CaptureImage
set /P c=Would you like to capture the existing image on this device [Y/N]? 
if /I "%c%" EQU "N" goto :EOF
call CaptureImage.bat