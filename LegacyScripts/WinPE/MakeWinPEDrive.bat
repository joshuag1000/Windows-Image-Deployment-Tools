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
echo *********************************************************************************
echo **  Make WinPE Drive - Windows Image Deployment Tools - (c) Joshua Glass 2023  **
echo *********************************************************************************
echo ** This Script will install WinPE onto a USB drive                             **
echo ** THIS WILL WIPE THE DRIVE YOU HAVE SELECTED                                  **
echo ** Please make sure you have run CreateAndModifyPE.bat before this script.     **
echo ** Please make sure you have no drives mounted as P or O.                      **
echo *********************************************************************************
set /P c=Are you sure you want to continue [Y/N]? 
if /I "%c%" EQU "Y" goto :Proceed
if /I "%c%" EQU "N" goto :ENDOFFILE
if /I "%c%" EQU "y" goto :Proceed
if /I "%c%" EQU "n" goto :ENDOFFILE
goto :Start

:Proceed
call "C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat"
cd /D %~dp0
if not exist .\WinPE_amd64\ (
  set /P c=WinPE was not detected in this folder. Would you like to create and modify WinPE [Y/N]? 
  if /I "%c%" EQU "N" goto :ENDOFFILE
  if /I "%c%" EQU "n" goto :ENDOFFILE
  call CreateAndModifyPE.bat Y
  if not exist .\WinPE_amd64\ (
    goto :ENDOFFILE
  )
  cd /D %~dp0
)

:ISOorUSB
echo Would you like to create an iso image or USB Drive?
echo If you are not sure you probably want a USB drive
echo If you are using an ISO image you will need a separate USB drive or partition with the scrips on it.
echo To do this just copy the scripts folder onto an NTFS formatted drive.
set /P ISOorUSB=Type 1 for USB or 2 for ISO: 
if /I "%ISOorUSB%" EQU "1" goto :MakeUSB
if /I "%ISOorUSB%" EQU "2" goto :MakeISO
goto :ISOorUSB

:MakeISO
Call MakeWinPEMedia /ISO .\WinPE_amd64 .\WinPEISO.iso
goto :ENDOFFILE

:MakeUSB
(echo Rescan
echo List Disk
echo Exit
)  | diskpart
set /p ChosenDrive=Please select a drive: 
:choice
set /P c=Are you sure you want to continue [Y/N]? 
if /I "%c%" EQU "Y" goto :MakeDrive
if /I "%c%" EQU "N" goto :ENDOFFILE
if /I "%c%" EQU "y" goto :MakeDrive
if /I "%c%" EQU "n" goto :ENDOFFILE
goto :choice

:MakeDrive
echo Selected Drive: %ChosenDrive%
(echo Rescan
echo list disk
echo select disk %ChosenDrive%
echo Automount Scrub
echo clean
echo rem === Create the Windows PE partition. ===
echo create partition primary size=500
echo format quick fs=fat32 label="WinPE"
echo assign letter=P
echo active
echo rem === Create a data partition. ===
echo create partition primary
echo format fs=ntfs quick label="USB-01"
echo assign letter=O
echo list vol
echo Automount enable
echo Exit
) | diskpart

Call MakeWinPEMedia /UFD /f .\WinPE_amd64 P:
mkdir O:\Scripts
Call xCopy ".\Scripts" O:\Scripts /e /q

:ENDOFFILE
pause
