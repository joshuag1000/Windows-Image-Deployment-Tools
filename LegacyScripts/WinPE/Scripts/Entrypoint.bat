@echo off
cd Deployment
echo -- Are you sure you would like to proceed with Imaging this pc? Everything will be wiped. --
echo -- If you would like to capture the image on this device say no. --
:Check
SET /P AreYouSure=-- So are you sure (Y/N): 
if /I "%AreYouSure%" EQU "N" goto :CaptureImage
if /I "%AreYouSure%" EQU "n" goto :CaptureImage
if /I "%AreYouSure%" EQU "y" goto :Proceed
if /I "%AreYouSure%" EQU "Y" goto :Proceed
goto :Check

:Proceed
echo -- Build PC Image --
call build.bat
goto :EOF

:CaptureImage
set /P c=Would you like to capture the existing image on this device [Y/N]? 
if /I "%c%" EQU "N" goto :Shutdown
if /I "%c%" EQU "n" goto :Shutdown
if /I "%c%" EQU "y" goto :BeginCapture
if /I "%c%" EQU "Y" goto :BeginCapture
goto :CaptureImage

:BeginCapture
call CaptureImage.bat
goto :EOF
