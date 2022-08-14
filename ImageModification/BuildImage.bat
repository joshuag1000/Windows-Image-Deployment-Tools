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
echo ************************************************************************
echo ** This script will create a Wim Image to be used to deploy an image. **
echo ** This script works in stages. Each Stage creates its own wim.       **
echo ** Created image will be named Completed-YourImageName.wim            **
echo ** This script can only be run once at a time                         **
echo ************************************************************************
set /P c=Are you sure you want to continue [Y/N]? 
if /I "%c%" EQU "Y" goto :Proceed
if /I "%c%" EQU "N" goto :ENDOFFILE
if /I "%c%" EQU "y" goto :Proceed
if /I "%c%" EQU "n" goto :ENDOFFILE
goto :Start

:Proceed
cd /D %~dp0
if not exist .\Images\ ( 
	mkdir Images
	echo Please put an image to use in the Images Folder and re-run the script
	goto :ENDOFFILE
)
if exist .\Images\Working\ (
	echo .\Images\Working\
	rmdir /s /q .\Images\Working\
)
if not exist .\Images\Working\ ( 
	mkdir Images\Working
)
echo Please select an image.
setlocal enableDelayedExpansion

::build "array" of folders
set folderCnt=0
for /f "eol=: delims=" %%F in ('dir /b .\Images\*.wim') do (
  set /a folderCnt+=1
  set "folder!folderCnt!=%%F"
)

::print menu
for /l %%N in (1 1 %folderCnt%) do echo %%N - !folder%%N!
echo(
set selection=
set /p "selection=Image Number: "
set SelectedImage=!folder%selection%!
set OrigionalImage=!folder%selection%!

if not exist .\Mountpoint\ ( 
	mkdir .\Mountpoint
)

:Questions
:: Drivers
:InstallDriversYN
set /P DriversYesNo=Would you like to install drivers to this image [Y/N]? 
if /I "%DriversYesNo%" EQU "N" goto :InstallLanguagesYN
if /I "%DriversYesNo%" EQU "Y" goto :InstallDriversY
if /I "%DriversYesNo%" EQU "n" goto :InstallLanguagesYN
if /I "%DriversYesNo%" EQU "y" goto :InstallDriversY
goto :InstallDriversYN
:InstallDriversY
if not exist .\Drivers\ ( 
	mkdir Drivers
	echo Please put drivers into the drivers folder. HAVE A SUBFOLDER FOR EACH SET OF DRIVERS. ie: Drivers for Brand1 would go in .\Drivers\Brand1
	goto :ENDOFFILE
)
echo Please select a set of drivers to install or do A for all
setlocal enableDelayedExpansion

::build "array" of folders
set folderCnt=0
for /f "eol=: delims=" %%F in ('dir /b /ad .\Drivers\*') do (
  set /a folderCnt+=1
  set "folder!folderCnt!=%%F"
)

::print menu
for /l %%N in (1 1 %folderCnt%) do echo %%N - !folder%%N!
echo(
set Driverselection=
set /p "Driverselection=Driver Set Number: "
set DriversToInstall=!folder%Driverselection%!

:: Languages
:InstallLanguagesYN
set /P LanguagesYesNo=Would you like to install languages to this image [Y/N]? 
if /I "%LanguagesYesNo%" EQU "N" goto :CleanupImageYN
if /I "%LanguagesYesNo%" EQU "Y" goto :InstallLanguagesY
if /I "%LanguagesYesNo%" EQU "n" goto :CleanupImageYN
if /I "%LanguagesYesNo%" EQU "y" goto :InstallLanguagesY
goto :InstallLanguagesYN
:InstallLanguagesY
if not exist .\Languages\ ( 
	mkdir Languages
	echo Please put the languages into the Languages folder. HAVE A SUBFOLDER FOR EACH LANGUAGE.
	echo To install a language 3 files are needed: LanguageExperiencePack.LANGUAGECODE.Neutral.appx, License.xml, Microsoft-Windows-Client-Language-Pack_x64_LANGUAGECODE.cab
	echo For example the german language pack will need to be in a folder called de-de and the files inside will need to be called: Microsoft-Windows-Client-Language-Pack_x64_de-de.cab, License.xml, LanguageExperiencePack.de-DE.Neutral.appx
	goto :ENDOFFILE
)

:: Cleanup
:CleanupImageYN
set /P CleanUpYesNo=Would you like to cleanup this image [Y/N]? 
if /I "%CleanUpYesNo%" EQU "N" goto :StartOperations
if /I "%CleanUpYesNo%" EQU "Y" goto :StartOperations
if /I "%CleanUpYesNo%" EQU "n" goto :StartOperations
if /I "%CleanUpYesNo%" EQU "y" goto :StartOperations
goto :CleanupImageYN

:StartOperations
copy .\Images\%SelectedImage% .\Images\Working\Working.wim
set SelectedImage=Working\Working.wim

:InstallDrivers
if /I "%DriversYesNo%" EQU "N" goto :InstallLanguages
if /I "%DriversYesNo%" EQU "Y" goto :InstallDriversResume
if /I "%DriversYesNo%" EQU "n" goto :InstallLanguages
if /I "%DriversYesNo%" EQU "y" goto :InstallDriversResume
echo Yeah Something strange happned. Exiting....
goto :ENDOFFILE

:InstallDriversResume
echo Creating Image to modify

if %Driverselection%=="A" (
	cd /D %~dp0
	echo Mounting Image.
	Dism /Mount-Image /ImageFile:".\Images\Working\Working.wim" /Index:1 /MountDir:".\Mountpoint"
	echo Adding drivers.
	Dism /image:".\Mountpoint" /Add-Driver /driver:".\Drivers" /recurse
	echo Saving Image
	Dism /Unmount-Image /MountDir:".\Mountpoint" /Commit
	set OrigionalImage=Drivers-All-%OrigionalImage%
) else (
	if not %DriversToInstall%=="" (
		cd /D %~dp0
		echo Mounting Image.
		Dism /Mount-Image /ImageFile:".\Images\Working\Working.wim" /Index:1 /MountDir:".\Mountpoint"
		echo Adding Drivers.
		Dism /image:".\Mountpoint" /Add-Driver /driver:".\Drivers\%DriversToInstall%" /recurse
		echo Saving Image.
		Dism /Unmount-Image /MountDir:".\Mountpoint" /Commit
		set OrigionalImage=Drivers-%DriversToInstall%-%OrigionalImage%
	)
)
echo If there is an error 2 here this should be ok as this means that one or 2 of the drivers failed to install.
echo This is to be expected.

:InstallLanguages
if /I "%LanguagesYesNo%" EQU "N" goto :CleanupImage
if /I "%LanguagesYesNo%" EQU "Y" goto :InstallLanguagesResume
if /I "%LanguagesYesNo%" EQU "n" goto :CleanupImage
if /I "%LanguagesYesNo%" EQU "y" goto :InstallLanguagesResume
echo Yeah Something strange happned. Exiting....
goto :ENDOFFILE

:InstallLanguagesResume
Dism /Mount-Image /ImageFile:".\Images\Working\Working.wim" /Index:1 /MountDir:".\Mountpoint"
::Install All languages in languages folder.
::build "array" of folders
set folderCnt=0
for /f "eol=: delims=" %%F in ('dir /b /ad .\Languages\*') do (
  set /a folderCnt+=1
  set "folder!folderCnt!=%%F"
)

::print menu
for /l %%N in (1 1 %folderCnt%) do (
	Dism /Image:".\Mountpoint" /Add-Package /PackagePath=".\Languages\!folder%%N!\Microsoft-Windows-Client-Language-Pack_x64_!folder%%N!.cab"
	dism /Image:".\Mountpoint" /Add-ProvisionedAppxPackage /PackagePath=".\Languages\!folder%%N!\LanguageExperiencePack.!folder%%N!.Neutral.appx" /LicensePath:".\Languages\!folder%%N!\License.xml"
)
echo(
set OrigionalImage=Languages-%OrigionalImage%
Dism /Unmount-Image /MountDir:".\Mountpoint" /Commit

:CleanupImage
if /I "%CleanUpYesNo%" EQU "N" goto :SaveImage
if /I "%CleanUpYesNo%" EQU "Y" goto :CleanupImageResume
if /I "%CleanUpYesNo%" EQU "n" goto :SaveImage
if /I "%CleanUpYesNo%" EQU "y" goto :CleanupImageResume
echo Yeah Something strange happned. Exiting....
goto :ENDOFFILE

:CleanupImageResume
echo Mounting Image.
Dism /Mount-Image /ImageFile:".\Images\Working\Working.wim" /Index:1 /MountDir:".\Mountpoint"
echo Cleaning up the image
Dism /Image:".\Mountpoint" /Cleanup-Image /StartComponentCleanup /ResetBase
echo Commiting the image
Dism /Unmount-Image /MountDir:".\Mountpoint" /Commit
echo Optimising the image
rename .\Images\Working\Working.wim Working-ToOptimise.wim
Dism /Export-Image /SourceImageFile:".\Images\Working\Working-ToOptimise.wim" /SourceIndex:1 /DestinationImageFile:".\Images\Working\Working.wim"
del /Q .\Images\Working\Working-ToOptimise.wim
set OrigionalImage=Tidied-%OrigionalImage%

:SaveImage
copy .\Images\%SelectedImage% .\Images\Completed-%OrigionalImage%

:CleanupWorking
rmdir /s /q .\Images\Working\

:ENDOFFILE
pause
