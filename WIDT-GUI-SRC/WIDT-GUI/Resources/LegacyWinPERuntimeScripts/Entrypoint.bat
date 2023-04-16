:: Only different file from the Legacy Scripts. Contains a merged Entrypoint.bat and startnet.cmd from the original scripts as well as some patches.
@echo off
@echo  *********************************************************************
@echo -- Working out 'USB-B' drive letter --
@IF EXIST D:\*.wim SET USBB=D:
@IF EXIST E:\*.wim SET USBB=E:
@IF EXIST F:\*.wim SET USBB=F:
@IF EXIST G:\*.wim SET USBB=G:
@IF EXIST H:\*.wim SET USBB=H:
@IF EXIST I:\*.wim SET USBB=I:
@IF EXIST C:\*.wim SET USBB=C:
@echo The 'USB' drive is: %USBB%
@echo  *********************************************************************

cd /D "%~dp0\Deployment\"

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
call %~dp0\Deployment\build.bat
goto :UnmountUSB

:CaptureImage
set /P c=Would you like to capture the existing image on this device [Y/N]? 
if /I "%c%" EQU "N" goto :Shutdown
if /I "%c%" EQU "n" goto :Shutdown
if /I "%c%" EQU "y" goto :BeginCapture
if /I "%c%" EQU "Y" goto :BeginCapture
goto :CaptureImage

:BeginCapture
call %~dp0\Deployment\CaptureImage.bat
goto :UnmountUSB

:UnmountUSB
cd /d X:\
mountvol %USBB%\ /p

:Shutdown
echo It is recommended that you shutdown this device to prevent corruption to the USB key.
echo Once the device has shutdown you may remove the key and boot your device.
set /P ShutdownNow=Would you like to shutdown now? [Y/N]: 
if /I "%ShutdownNow%" EQU "y" goto :ShutdownSystem
if /I "%ShutdownNow%" EQU "Y" goto :ShutdownSystem
if /I "%ShutdownNow%" EQU "n" goto :EOF
if /I "%ShutdownNow%" EQU "N" goto :EOF
goto :Shutdown

:ShutdownSystem
wpeutil shutdown