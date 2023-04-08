@echo off
wpeinit
powercfg /s 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c
@echo  *********************************************************************
@echo -- Working out 'USB-B' drive letter --
@IF EXIST D:\Scripts SET USBB=D:
@IF EXIST E:\Scripts SET USBB=E:
@IF EXIST F:\Scripts SET USBB=F:
@IF EXIST G:\Scripts SET USBB=G:
@IF EXIST H:\Scripts SET USBB=H:
@IF EXIST I:\Scripts SET USBB=I:
@IF EXIST C:\Scripts\Entrypoint.bat SET USBB=C:
@echo The 'USB' drive is: %USBB%
@echo  *********************************************************************

if "%USBB%"=="" (
    echo It appears that the USB Drive was not found.
    echo Please ensure that the USB is setup correctly
    echo and verify that is is not corrupt.
    goto :Shutdown
)

if "%USBB%"=="C:" (
    echo Please be aware that the script has detected the USB drive as letter C:
    echo This shouldn't be an issue if you are sure that we have detected the drive correctly.
)

%USBB%

if not exist .\Scripts\Entrypoint.bat (
    echo It appears that the Entrypoint.bat script was not found.
    echo Please ensure that the USB is setup correctly
    echo and verify that is is not corrupt.
    goto :Shutdown
)

@cd Scripts
@call Entrypoint.bat

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
