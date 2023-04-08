@echo off
:Start
cls
echo *****************************************************************************
echo **  Setup Script - Windows Image Deployment Tools - (c) Joshua Glass 2023  **
echo *****************************************************************************
echo ** This is the setup script for the Windows Image Deployment Tools.        **
echo ** This script will check you have the required dependencies installed as  **
echo ** well as any configuration that is required has been made.               **
echo ** There is currently a GUI in development which is designed to make these **
echo ** scripts easier to use and include more features.                        **
echo ** Please ensure you have read the documentation before starting.          **
echo ** This software is licensed under the MIT License.                        **
echo *****************************************************************************
set /P c=Are you sure you want to continue [Y/N]? 
if /I "%c%" EQU "Y" goto :Proceed
if /I "%c%" EQU "N" goto :ENDOFFILE
if /I "%c%" EQU "y" goto :Proceed
if /I "%c%" EQU "n" goto :ENDOFFILE
goto :Start

:Proceed
if /I "%OVERRIDEDEPCHECKS%" EQU "y" goto :SelectScriptVersion
if /I "%OVERRIDEDEPCHECKS%" EQU "Y" goto :SelectScriptVersion

:CheckForADK
if EXIST "C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat" goto :CheckForWinPE
cls
echo The Script could not find a Windows ADK installation.
echo You need to ensure that you have the Windows ADK installed before proceeding.
echo You can download the Windows ADK Here: https://go.microsoft.com/fwlink/?linkid=2196127
echo If you want to view all versions available go to: https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install
goto :ENDOFFILE

:CheckForWinPE
if exist "C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\copype.cmd" goto :CheckForDotNET
cls
echo The Script could not find a WinPE installation.
echo You need to ensure that you have the WinPE Addon for the Windows ADK installed before proceeding.
echo You can download the WinPE Addon Here: https://go.microsoft.com/fwlink/?linkid=2196224
echo If you want to view all versions available go to: https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install
goto :ENDOFFILE

:CheckForDotNET
where dotnet
IF %ERRORLEVEL% NEQ 0 goto :NotFoundSDK
(dotnet --list-sdks --help | findstr /c:"6.0." |findstr . && goto :SelectScriptVersion || goto :NotFoundSDK ) >nul

:NotFoundSDK
cls
echo The Script did not find the .Net 6.0 SDK.
echo You will need to install the SDK before you can proceed.
echo You can download the SDK here: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
echo If you are only using the legacy scripts then you do not need to install this.
echo You can override the depdency checks by setting the value OVERRIDEDEPCHECKS to Y (set OVERRIDEDEPCHECKS=Y)
goto :ENDOFFILE

:SelectScriptVersion
echo There are 2 versions of these tools. The new (beta) GUI tools and the Legacy Console Tools
echo If you use the GUI tools this should be the last console script you will need to run.
echo Enter 1 for the GUI. Enter 2 for the Legacy Scripts.
set /P c=Which Version of the tools would you like to run? 
if /I "%c%" EQU "1" goto :CompileSetupApp
if /I "%c%" EQU "2" goto :LegacyScriptMenu

:CompileSetupApp
echo Compiling Tools
cd /D "%~dp0\WIDT-GUI-SRC\WIDT-GUI"
mkdir "%~dp0\WIDT-GUI\bin"
dotnet publish -c Release -r win-x64 -p:ReadyToRun=True -p:PublishSingleFile=true --self-contained true -o "%~dp0\WIDT-GUI\bin"
IF %ERRORLEVEL% NEQ 0 goto :CompileError
cls
echo Setup is complete. You do not need to run this script again unless you have downloaded a new version or moving to a new computer.
echo You can start the application by double clicking the file WIDT-GUI-Setup.bat located in the WIDT-GUI folder.
echo Any config created by the program will be located in: %~dp0\WIDT-GUI\
echo Press enter to automatically start the application.
pause
IF EXIST "%~dp0\WIDT-GUI\WIDT-GUI-Setup.bat" del "%~dp0\WIDT-GUI\WIDT-GUI-Setup.bat"
echo start /D "%~dp0\WIDT-GUI\bin\" "" "%~dp0\WIDT-GUI\bin\WIDT-GUI-Setup.exe /S Setup" >> "%~dp0\WIDT-GUI\WIDT-GUI-Setup.bat"
start /D "%~dp0\WIDT-GUI\bin\" "" "%~dp0\WIDT-GUI\bin\WIDT-GUI-Setup.exe"
goto :EOFNoPause

:CompileError
echo there was an error compiling.
:ENDOFFILE

:LegacyScriptMenu
echo Please select a script:
echo 1 - BuildImage.bat - Modify a captured image to add drivers, languages, etc.
echo 2 - MakeWinPEDrive.bat - Install WinPE (and tools) to a USB drive or ISO file.
echo 3 - CreateAndModifyPE.bat - Setup the WinPE image to add the tools.
set /P c=Please Select an Option: 
if /I "%c%" EQU "1" goto :BuildImageBat
if /I "%c%" EQU "2" goto :MakeWinPEDriveBat
if /I "%c%" EQU "3" goto :CreateAndModifyPEBat
goto :LegacyScriptMenu

:BuildImageBat
"%~dp0\LegacyScripts\ImageModification\BuildImage.bat"
goto :ENDOFFILE

:MakeWinPEDriveBat
"%~dp0\LegacyScripts\WinPE\MakeWinPEDrive.bat"
goto :ENDOFFILE

:CreateAndModifyPEBat
"%~dp0\LegacyScripts\WinPE\CreateAndModifyPE.bat"
goto :ENDOFFILE

:ENDOFFILE
pause
:EOFNoPause