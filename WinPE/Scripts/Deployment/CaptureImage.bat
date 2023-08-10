@echo off
:check_Permissions
echo Administrative permissions required. Detecting permissions...

net session >nul 2>&1
if not %errorLevel% == 0 (
    echo You are not running this script as administrator. Please run again as administrator.
	goto :ENDOFFILE
) 

:Start
cls
echo ****************************************************************************
echo ** This script will capture the image that is currently on this pc        **
echo ** This script will NOT make any changes to the pc.                       **
echo ** Please make sure there is sufficient space on this drive before        **
echo ** proceeding with this process.                                          **
echo ** Once the process has finished you can use the captured image to deploy **
echo ** to another computer / drive                                            **
echo ****************************************************************************
set /P c=Are you sure you want to continue [Y/N]? 
if /I "%c%" EQU "Y" goto :Proceed
if /I "%c%" EQU "N" goto :ENDOFFILE
goto Start

:Proceed
cd /D %~dp0
(echo Rescan
echo List Volume
echo Exit
)  | diskpart
set /p ChosenVolume=Please select the volume to capture (Expected input is drive letter ie: C or D): 
set /p SaveDrive=Please select the volume to save the image (Expected input is drive letter ie: C or D): 
set /P MyFileName=Please enter a name for the image: 
set /P ImageVersion=Please enter the version number of this Windows Image (i.e. 10): 
mkdir %SaveDrive%:\ScratchDir
dism /capture-image /imagefile:"%SaveDrive%:\%MyFileName%.wim" /capturedir:%ChosenVolume%:\ /name:"Windows %ImageVersion%" /Description:"Windows %ImageVersion%" /compress:maximum /checkintegrity /verify /ScratchDir:"%SaveDrive%:\ScratchDir" /LogPath:"%SaveDrive%:\Log.log"
rmdir %SaveDrive%:\ScratchDir
echo Image has been captured please check the console for errors before exiting.

set /P c=Would you like to capture again? [Y/N]? 
if /I "%c%" EQU "Y" goto :Start
if /I "%c%" EQU "y" goto :Start

:ENDOFFILE
pause
