@echo == ApplyRecovery.bat ==
@rem *********************************************************************
@echo Checking to see if the PC is booted in BIOS or UEFI mode.
wpeutil UpdateBootInfo
for /f "tokens=2* delims=	 " %%A in ('reg query HKLM\System\CurrentControlSet\Control /v PEFirmwareType') DO SET Firmware=%%B
@echo            Note: delims is a TAB followed by a space.
@if x%Firmware%==x echo ERROR: Can't figure out which firmware we're on.
@if x%Firmware%==x echo        Common fix: In the command above:
@if x%Firmware%==x echo             for /f "tokens=2* delims=	 "
@if x%Firmware%==x echo        ...replace the spaces with a TAB character followed by a space.
@if x%Firmware%==x goto END
@if %Firmware%==0x1 echo The PC is booted in BIOS mode. 
@if %Firmware%==0x2 echo The PC is booted in UEFI mode. 
@echo  *********************************************************************
@echo Do you already have a recovery partition on this disk? (Y or N):
@set RECOVERYEXIST=Y
@if %RECOVERYEXIST%.==Y. GOTO COPYTOTOOLSPARTITION
@if not %RECOVERYEXIST%.==Y. GOTO CREATEFFURECOVERY
@echo  *********************************************************************
:COPYTOTOOLSPARTITION
@echo  == Copy the Windows RE image to the Windows RE Tools partition ==
md R:\Recovery\WindowsRE
xcopy /h W:\Windows\System32\Recovery\Winre.wim R:\Recovery\WindowsRE\
@echo  *********************************************************************
@echo  == Register the location of the recovery tools ==
W:\Windows\System32\Reagentc /Setreimage /Path R:\Recovery\WindowsRE /Target W:\Windows
@echo  *********************************************************************
@IF EXIST W:\Recovery\Customizations\USMT.ppkg (GOTO CUSTOMDATAIMAGEWIM) else goto HIDEWIMRECOVERYTOOLS
:CUSTOMDATAIMAGEWIM
@echo  == If Compact OS, single-instance the recovery provisioning package ==
@echo.     
@echo	  *Note: this step only works if you created a ScanState package called
@echo	   USMT.ppkg as directed in the OEM Deployment lab. If you aren't
@echo	   following the steps in the lab, choose N.
@echo.      
@echo     Options: N: No
@echo              Y: Yes
@echo              D: Yes, but defer cleanup steps to first boot.
@echo                 Use this if the cleanup steps take more than 30 minutes.
@echo                 defer the cleanup steps to the first boot.
@SET /P COMPACTOS=Deploy as Compact OS? (Y, N, or D):
@if %COMPACTOS%.==y. set COMPACTOS=Y
@if %COMPACTOS%.==d. set COMPACTOS=D
@if %COMPACTOS%.==Y. dism /Apply-CustomDataImage /CustomDataImage:W:\Recovery\Customizations\USMT.ppkg /ImagePath:W:\ /SingleInstance
@if %COMPACTOS%.==D. dism /Apply-CustomDataImage /CustomDataImage:W:\Recovery\Customizations\USMT.ppkg /ImagePath:W:\ /SingleInstance /Defer
@echo  *********************************************************************
:HIDEWIMRECOVERYTOOLS
@echo  == Enabling recovery Partition
@echo W:\Windows\System32\Reagentc /enable
@echo == Hiding the recovery tools partition
if %Firmware%==0x1 diskpart /s %~dp0HideRecoveryPartitions-BIOS.txt
if %Firmware%==0x2 diskpart /s %~dp0HideRecoveryPartitions-UEFI.txt
@echo *********************************************************************
@echo == Verify the configuration status of the images. ==
W:\Windows\System32\Reagentc /Info /Target W:\Windows
@echo    (Note: Windows RE status may appear as Disabled, this is OK.)
@echo *********************************************************************
@echo      All done!
@echo      Disconnect the USB drive from the reference device.
@echo      Type exit to reboot.
@echo.
GOTO END
:CREATEFFURECOVERY
@echo *********************************************************************
@echo == Creating the recovery tools partition
@if %Firmware%==0x1 diskpart /s CreateRecoveryPartitions-BIOS.txt
@if %Firmware%==0x2 diskpart /s CreateRecoveryPartitions-UEFI.txt
@echo finding the Windows Drive
@echo  *********************************************************************
@IF EXIST C:\Windows SET windowsdrive=C:\
@IF EXIST D:\Windows SET windowsdrive=D:\
@IF EXIST E:\Windows SET windowsdrive=E:\
@IF EXIST W:\Windows SET windowsdrive=W:\
@echo The Windows drive is %windowsdrive%
md R:\Recovery\WindowsRE
@echo  *********************************************************************
@echo Finding Winre.wim
@IF EXIST %windowsdrive%Recovery\WindowsRE\winre.wim SET recoveryfolder=%windowsdrive%Recovery\WindowsRE\
@IF EXIST %windowsdrive%Windows\System32\Recovery\winre.wim SET recoveryfolder=%windowsdrive%Windows\System32\Recovery\
@echo  *********************************************************************
@echo copying Winre.wim
xcopy /h %recoveryfolder%Winre.wim R:\Recovery\WindowsRE\
@echo  *********************************************************************
@echo  == Register the location of the recovery tools ==
%windowsdrive%Windows\System32\Reagentc /Setreimage /Path R:\Recovery\WindowsRE /Target %windowsdrive%Windows
@echo  *********************************************************************
@IF EXIST W:\Recovery\Customizations\USMT.ppkg (GOTO CUSTOMDATAIMAGEFFU) else goto HIDERECOVERYTOOLSFFU
:CUSTOMDATAIMAGEFFU
@echo  == If Compact OS, single-instance the recovery provisioning package ==
@echo.     
@echo	  *Note: this step only works if you created a ScanState package called
@echo	   USMT.ppkg as directed in the OEM Deployment lab. If you aren't
@echo	   following the steps in the lab, choose N.
@echo.
@echo     Options: N: No
@echo              Y: Yes
@echo              D: Yes, but defer cleanup steps to first boot.
@echo                 Use this if the cleanup steps take more than 30 minutes.
@echo                 defer the cleanup steps to the first boot.
@SET /P COMPACTOS=Deploy as Compact OS? (Y, N, or D):
@if %COMPACTOS%.==y. set COMPACTOS=Y
@if %COMPACTOS%.==d. set COMPACTOS=D
@if %COMPACTOS%.==Y. dism /Apply-CustomDataImage /CustomDataImage:%windowsdrive%Recovery\Customizations\USMT.ppkg /ImagePath:%windowsdrive% /SingleInstance
@if %COMPACTOS%.==D. dism /Apply-CustomDataImage /CustomDataImage:%windowsdrive%Recovery\Customizations\USMT.ppkg /ImagePath:%windowsdrive% /SingleInstance /Defer
:HIDERECOVERYTOOLSFFU
@rem *********************************************************************
@echo == Hiding the recovery tools partition
@if %Firmware%==0x1 diskpart /s HideRecoveryPartitions-BIOS.txt
@if %Firmware%==0x2 diskpart /s HideRecoveryPartitions-UEFI.txt
@echo *********************************************************************
@echo == Verify the configuration status of the images. ==
%windowsdrive%Windows\System32\Reagentc /Info /Target %windowsdrive%Windows
@echo    (Note: Windows RE status may appear as Disabled, this is OK.)
@echo *********************************************************************
@echo      All done!
@echo      Disconnect the USB drive from the reference device.
@echo      Type exit to reboot.
@GOTO END
:END
