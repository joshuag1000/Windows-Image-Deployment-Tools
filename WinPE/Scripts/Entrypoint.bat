@echo off
cd Deployment
echo -- Are you sure you would like to proceed with Imaging this pc? Everything will be wiped. --
echo -- If you would like to capture the image on this device say no. --
:Check
SET /P AreYouSure=-- So are you sure (Y/N)::
if /I "%AreYouSure%" EQU "N" goto :CaptureImage
if /I "%AreYouSure%" EQU "n" goto :CaptureImage
if /I "%AreYouSure%" EQU "y" goto :Proceed
if /I "%AreYouSure%" EQU "Y" goto :Proceed
goto :Check

:Proceed
echo -- Build PC Image --
call build.bat
goto :Shutdown

:CaptureImage
set /P c=Would you like to capture the existing image on this device [Y/N]? 
if /I "%c%" EQU "N" goto :Shutdown
if /I "%c%" EQU "n" goto :Shutdown
if /I "%c%" EQU "y" goto :BeginCapture
if /I "%c%" EQU "Y" goto :BeginCapture
goto :CaptureImage

:BeginCapture
call CaptureImage.bat
goto :Shutdown

:Shutdown
echo It is recommended that you shutdown this device to prevent corruption to the USB key.
echo Once the device has shutdown you may remove the key and boot your device.
set /P ShutdownNow=Would you like to shutdown now? [Y/N]: 
if /I "%ShutdownNow%" EQU "y" goto :ShutdownSystem
if /I "%ShutdownNow%" EQU "Y" goto :ShutdownSystem
goto :EOF

:ShutdownSystem
wpetuil shutdown
