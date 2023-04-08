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
echo *****************************************************************************
echo **  Setup WinPE - Windows Image Deployment Tools - (c) Joshua Glass 2023   **
echo *****************************************************************************
echo ** This Script will and modify WinPE so it can be                          **
echo ** used with other scripts in this folder.                                 **
echo *****************************************************************************
set OVERRIDEYN=N
Set OVERRIDEYN=%1
if "%OVERRIDEYN%"=="Y" ( 
	goto :Proceed 
)
set /P c=Are you sure you want to continue [Y/N]? 
if /I "%c%" EQU "Y" goto :Proceed
if /I "%c%" EQU "y" goto :Proceed
if /I "%c%" EQU "N" goto :ENDOFFILE
if /I "%c%" EQU "n" goto :ENDOFFILE
goto :Start

:Proceed
call "C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat"
cd /D %~dp0
if exist .\WinPE_amd64\ (
  set /P c=You already have a WinPE Folder. It will be deleted. Proceed [Y/N]? 
  if /I "%c%" EQU "N" goto :ENDOFFILE
  if /I "%c%" EQU "n" goto :ENDOFFILE
  rmdir /s /q .\WinPE_amd64
)
call copype amd64 .\WinPE_amd64
call Dism /Mount-Image /ImageFile:".\WinPE_amd64\media\sources\boot.wim" /Index:1 /MountDir:".\WinPE_amd64\mount"
:: Copy our startnet.cmd file to the WinPE Installation
if exist .\WinPE_amd64\mount\Windows\System32\startnet.cmd (
  del /Q .\WinPE_amd64\mount\Windows\System32\startnet.cmd
)
copy /Y .\startnet.cmd.txt .\WinPE_amd64\mount\Windows\System32\
rename .\WinPE_amd64\mount\Windows\System32\startnet.cmd.txt startnet.cmd
echo Image Modification Complete.

:: Save the image
call Dism /Unmount-Image /MountDir:.\WinPE_amd64\mount /Commit
echo WinPE is ready for deployment.
:ENDOFFILE
if not "%OVERRIDEYN%"=="Y" ( 
	pause
)
