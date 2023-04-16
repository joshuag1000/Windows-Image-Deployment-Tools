Imports System.ComponentModel
Imports System.IO
Imports System.Management

Public Module SharedFunctions
    ''' <summary>
    '''     Runs a command asynchronously and allows for a live return of the commands output.
    '''     Returns True if an error occured.
    ''' </summary>
    ''' <param name="CommandToRun"></param>
    ''' <param name="Info"></param>
    ''' <returns></returns>
    Public Function RunCmdCommand(ByVal CommandToRun As String, ByVal Info As IProgress(Of String)) As Boolean
        ' Define command to run
        Dim CommandDefinition As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo("cmd", "/c " + CommandToRun) With {
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        ' Define the process
        Dim CopyPEProc As System.Diagnostics.Process = New System.Diagnostics.Process With {
            .StartInfo = CommandDefinition
        }
        CopyPEProc.StartInfo.RedirectStandardInput = True
        CopyPEProc.StartInfo.RedirectStandardError = True
        CopyPEProc.StartInfo.RedirectStandardOutput = True
        CopyPEProc.Start() ' Start the process

        AddHandler CopyPEProc.ErrorDataReceived, Sub(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
                                                     Info.Report(If(e.Data Is Nothing, "", e.Data.ToString))
                                                 End Sub
        AddHandler CopyPEProc.OutputDataReceived, Sub(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
                                                      Info.Report(If(e.Data Is Nothing, "", e.Data.ToString))
                                                  End Sub
        CopyPEProc.BeginErrorReadLine()
        CopyPEProc.BeginOutputReadLine()
        CopyPEProc.WaitForExit()

        ' Check for errors
        If CopyPEProc.ExitCode <> 0 Then
            MessageBox.Show("An Unexpected error occured.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    '''     Runs a command, waits for it to finish and then proceeds in the code.
    ''' </summary>
    ''' <param name="CommandToRun"></param>
    ''' <returns></returns>
    Public Function RunCmdCommandSync(ByVal CommandToRun As String) As String
        ' Define command to run
        Dim CommandDefinition As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo("cmd", "/c " + CommandToRun) With {
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        ' Define the process
        Dim CopyPEProc As System.Diagnostics.Process = New System.Diagnostics.Process With {
            .StartInfo = CommandDefinition
        }

        CopyPEProc.Start() ' Start the process
        Dim result As String = CopyPEProc.StandardOutput.ReadToEnd
        ' Check for errors
        If CopyPEProc.ExitCode <> 0 Then
            MessageBox.Show("An Unexpected error occured.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        Else
            Return result
        End If
    End Function

    ''' <summary>
    '''     Structure to store the information about the drives in the system.
    ''' </summary>
    Public Structure DriveInformation
        Public DriveName As String
        Public DiskpartID As Integer
        Public VolumeLetters As String
        Public Capacity As Integer
        Public ThisDriveType As DriveType

        Public Sub New(ByVal newDriveName As String, ByVal newDiskpartID As Integer, ByVal newVolumeLetters As String, ByVal newCapacity As Integer, ByVal newDriveType As DriveType)
            DriveName = newDriveName
            DiskpartID = newDiskpartID
            VolumeLetters = newVolumeLetters
            Capacity = newCapacity
            ThisDriveType = newDriveType
        End Sub

        Public Overrides Function ToString() As String
            Return "Drive: " & DiskpartID & " - " & VolumeLetters & " " & Capacity & "GB " & DriveName
        End Function
    End Structure

    ''' <summary>
    '''     Gets all of the available drives in the system.
    '''     The way the drives are collected we are able to use diskpart super easily for creating the partitions.
    '''     In the future i might even see if i can cut out diskpart and just ask windows myself to do the partitioning.
    '''     Collecting the information i do it allows the user to ensure they have the corect drive selected.
    ''' </summary>
    ''' <param name="GetInternalDrives">When set to true includes internal drives in the search.</param>
    ''' <param name="GetRemovableDrives">When set to true includes removable drives in the search.</param>
    ''' <param name="GetUnknownDrives">When set to true includes unknown drives in the searche.</param>
    ''' <returns></returns>
    Public Function GetAvailableDrives(ByVal GetInternalDrives As Boolean, ByVal GetRemovableDrives As Boolean, ByVal GetUnknownDrives As Boolean) As List(Of DriveInformation)
        ' Just a TLDR on this. Although its simple it took me way to long to figure out. I HATE WINDOWS APIs.
        Dim Drives As List(Of DriveInformation) = New List(Of DriveInformation)

        ' Get all of the drives in the system
        Dim wmiDiskDrives = New ManagementObjectSearcher("Select DeviceID, MediaType, Size, Model From Win32_DiskDrive")
        For Each wmiDiskDrive As ManagementObject In wmiDiskDrives.Get()
            Dim OurNewDisk As DriveInformation = New DriveInformation()
            OurNewDisk.DriveName = wmiDiskDrive("Model").ToString
            OurNewDisk.ThisDriveType = Nothing
            If wmiDiskDrive("MediaType").ToString.ToLower = "Removable Media".ToLower Then OurNewDisk.ThisDriveType = DriveType.Removable
            If wmiDiskDrive("MediaType").ToString.ToLower = "Fixed Hard Disk Media".ToLower Then OurNewDisk.ThisDriveType = DriveType.Fixed
            If wmiDiskDrive("MediaType").ToString.ToLower = "Unknown".ToLower Then OurNewDisk.ThisDriveType = DriveType.Unknown         ' not sure which one of these is correct
            If wmiDiskDrive("MediaType").ToString.ToLower = "Unknown Media".ToLower Then OurNewDisk.ThisDriveType = DriveType.Unknown
            If wmiDiskDrive("MediaType").ToString.ToLower = "External Hard Disk Media".ToLower Then OurNewDisk.ThisDriveType = DriveType.Removable
            If OurNewDisk.ThisDriveType = Nothing Then
                OurNewDisk.ThisDriveType = DriveType.Unknown
            End If
            OurNewDisk.Capacity = Math.Round(Convert.ToInt64(wmiDiskDrive("Size")) / 1073741824, 0)
            OurNewDisk.DiskpartID = Convert.ToInt32(wmiDiskDrive("DeviceID").ToString.Replace("\\.\PHYSICALDRIVE", ""))
            OurNewDisk.VolumeLetters = ""
            ' Get all of the partitions on a disk
            Dim wmiDiskPartitions = New ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID=""" &
                                                                 wmiDiskDrive("DeviceID").ToString.Replace("\", "\\") &
                                                                 """} WHERE AssocClass = Win32_DiskDriveToDiskPartition")
            For Each wmiDiskPartition As ManagementObject In wmiDiskPartitions.Get()
                ' Get all of the logical disks per partitions (one to one as far as im aware)
                Dim wmiLogicalDisks = New ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID=""" &
                                                                   wmiDiskPartition("DeviceID").ToString &
                                                                   """} WHERE AssocClass = Win32_LogicalDiskToPartition")
                For Each wmiLogicalDisk As ManagementObject In wmiLogicalDisks.Get()
                    OurNewDisk.VolumeLetters += wmiLogicalDisk("DeviceID").ToString & "\ "
                Next
            Next
            If GetRemovableDrives = True And OurNewDisk.ThisDriveType = DriveType.Removable Then
                Drives.Add(OurNewDisk)
            End If
            If GetInternalDrives = True And OurNewDisk.ThisDriveType = DriveType.Fixed Then
                Drives.Add(OurNewDisk)
            End If
            If GetUnknownDrives = True And OurNewDisk.ThisDriveType = DriveType.Unknown Then
                Drives.Add(OurNewDisk)
            End If
        Next
        Return Drives
    End Function

    ''' <summary>
    '''     Verifies that the selected drive is still available and asks the user to confirm.
    ''' </summary>
    ''' <param name="DriveToVerify"></param>
    ''' <returns></returns>
    Public Function VerifyDrive(ByVal DriveToVerify As DriveInformation) As Boolean
        Return True
    End Function

    ''' <summary>
    '''     Gets 2 driver letters we can use for the winpe.
    ''' </summary>
    ''' <returns></returns>
    Public Function Get2UnusedLetters() As Char()
        Dim UsedDrives As List(Of String) = New List(Of String)
        For Each disk In DriveInfo.GetDrives
            UsedDrives.Add(disk.RootDirectory.ToString.Replace(":\", "").ToUpper)
        Next
        Dim DrivesToUse(2) As Char
        Dim FoundDrives As Short = 0
        For ascii = 65 To 90
            If Not UsedDrives.Contains(Chr(ascii)) Then
                DrivesToUse(FoundDrives) = Chr(ascii)
                FoundDrives += 1
                If FoundDrives = 2 Then Return DrivesToUse
            End If
        Next
        Return DrivesToUse
    End Function

    ''' <summary>
    '''     This creates a bootable WinPE drive from either a specofied folder or our duplication magic.
    '''     Unlike the code that creates an ISO this function does not use MakeWinPEMedia for 2 reasons.
    '''     Firstly it isnt really necassary at all (this could apply to other places but code cleanup is a future job rn)
    '''     Secondly it allows us to really easily implement our duplication magic in one simple step.
    '''     The steps used here are identical to the MakeWinPEMedia script give or take.
    '''     Returns True if an error occured.
    ''' </summary>
    ''' <param name="Percent"></param>
    ''' <param name="Info"></param>
    ''' <param name="DetailedInfo"></param>
    ''' <param name="drive"></param>
    ''' <param name="WPEPath"></param>
    ''' <param name="UseDuplicationMagic"></param>
    Public Function SetupWinPEDrive(ByVal Percent As IProgress(Of Integer), ByVal Info As IProgress(Of String), ByVal DetailedInfo As IProgress(Of String), ByVal drive As DriveInformation, ByVal WPEPath As String, ByVal UseDuplicationMagic As Boolean) As Boolean
        If WPEPath = "" And UseDuplicationMagic = False Then Return True
        ' Create the temporary directory to save the diskpart files. It it already exists delete it.
        Info.Report("Creating Temporary Directory")
        If Directory.Exists(AppContext.BaseDirectory + "\TemporaryFiles") Then Directory.Delete(AppContext.BaseDirectory + "\TemporaryFiles", True)
        Directory.CreateDirectory(AppContext.BaseDirectory + "\TemporaryFiles")
        Percent.Report(20)

        ' Format a partition for WinPE and Data Storage
        Info.Report("Creating and formatting partitions")
        Dim LettersToUse() As Char = Get2UnusedLetters()
        My.Computer.FileSystem.WriteAllText(AppContext.BaseDirectory + "\TemporaryFiles\DiskPart.tmp", "rescan" + vbCrLf +
                                                "list disk" + vbCrLf +
                                                "select disk " + drive.DiskpartID.ToString + vbCrLf +
                                                "Automount Disable" + vbCrLf +
                                                "clean" + vbCrLf +
                                                "Automount Scrub" + vbCrLf +
                                                "create partition primary size=2000" + vbCrLf +
                                                "format quick fs=fat32 label=""WinPE""" + vbCrLf +
                                                "assign letter=" + LettersToUse(0).ToString.ToUpper + vbCrLf +
                                                "create partition primary" + vbCrLf +
                                                "format quick fs=exfat label=""WIDT-Data""" + vbCrLf +
                                                "assign letter=" + LettersToUse(1).ToString.ToUpper + vbCrLf +
                                                "list vol" + vbCrLf +
                                                "Automount enable" + vbCrLf +
                                                "exit", False)
        If RunCmdCommand("Diskpart /s """ + AppContext.BaseDirectory + "\TemporaryFiles\DiskPart.tmp""", DetailedInfo) Then Return True
        Percent.Report(60)

        Info.Report("Setting boot code on WinPE partition")
        If RunCmdCommand("bootsect.exe /nt60 " + LettersToUse(0).ToString.ToUpper + ": /force /mbr", DetailedInfo) Then Return True
        Percent.Report(80)

        If WPEPath <> "" And UseDuplicationMagic = False Then
            Info.Report("Installing WinPE")
            If RunCmdCommand("call xcopy /herky " + WPEPath + "\media " + LettersToUse(0).ToString.ToUpper + ":\", DetailedInfo) Then Return True
            Percent.Report(90)
        ElseIf WPEPath = "" And UseDuplicationMagic = True Then
            Info.Report("Installing WinPE from Duplication Magic")
            If RunCmdCommand("call """ + AppContext.BaseDirectory + "\Resources\7z\7za.exe"" x """ + AppContext.BaseDirectory + "\WinPEMagic.7z"" -o""" + LettersToUse(0).ToString.ToUpper + ":\""", DetailedInfo) Then Return True
            Percent.Report(90)

            ' This is required as we cannot mount the wim in the WinPE Dir.
            Info.Report("Creating and Attaching Virtual Disk.")
            Dim VHDLetters() As Char = Get2UnusedLetters()
            Dim InternalDisksBefore As List(Of DriveInformation) = GetAvailableDrives(True, False, False) ' used for validation so we can ensure that we dont select a disk from before.
            My.Computer.FileSystem.WriteAllText(AppContext.BaseDirectory + "\TemporaryFiles\CreateVirtualDisk.tmp", "rescan" + vbCrLf +
                                                "create vdisk file=" + LettersToUse(1).ToString.ToUpper + ":\TEMPvdisk.vhd type=EXPANDABLE maximum=5000" + vbCrLf +
                                                "attach vdisk" + vbCrLf +
                                                "create partition primary" + vbCrLf +
                                                "format quick fs=ntfs label=""TempVHD""" + vbCrLf +
                                                "assign letter=" + VHDLetters(0).ToString.ToUpper + vbCrLf +
                                                "list vol" + vbCrLf +
                                                "exit", False)
            If RunCmdCommand("Diskpart /s """ + AppContext.BaseDirectory + "\TemporaryFiles\CreateVirtualDisk.tmp""", DetailedInfo) Then Return True
            File.Delete(AppContext.BaseDirectory + "\TemporaryFiles\CreateVirtualDisk.tmp")
            Percent.Report(93)

            Info.Report("Mounting the New WinPE")
            Directory.CreateDirectory(VHDLetters(0).ToString.ToUpper + ":\Mount")
            If RunCmdCommand("call Dism /Mount-Image /ImageFile:""" + LettersToUse(0).ToString.ToUpper + ":\sources\boot.wim"" /Index:1 /MountDir:""" + VHDLetters(0).ToString.ToUpper + ":\Mount""", DetailedInfo) Then Return True
            Percent.Report(92)

            Info.Report("Copying WinPE Archive to new WinPE install")
            File.Copy(AppContext.BaseDirectory + "\WinPEMagic.7z", VHDLetters(0).ToString.ToUpper + ":\Mount\WIDT-GUI\WinPEMagic.7z")
            Percent.Report(95)

            Info.Report("Saving WinPE Image")
            If RunCmdCommand("call Dism /Unmount-Image /MountDir:""" + VHDLetters(0).ToString.ToUpper + ":\Mount"" /Commit", DetailedInfo) Then Return True
            Percent.Report(96)

            Info.Report("Unmount Virtual Disk")
            My.Computer.FileSystem.WriteAllText(AppContext.BaseDirectory + "\TemporaryFiles\RemoveVirtualDisk.tmp", "rescan" + vbCrLf +
                                    "select vdisk file=" + LettersToUse(1).ToString.ToUpper + ":\TEMPvdisk.vhd" + vbCrLf +
                                    "detach vdisk" + vbCrLf +
                                    "exit", False)
            If RunCmdCommand("Diskpart /s """ + AppContext.BaseDirectory + "\TemporaryFiles\RemoveVirtualDisk.tmp""", DetailedInfo) Then Return True
            File.Delete(AppContext.BaseDirectory + "\TemporaryFiles\RemoveVirtualDisk.tmp")
            File.Delete(LettersToUse(1).ToString.ToUpper + ":\TEMPvdisk.vhd")
            Percent.Report(100)
        End If

        '''' TODO: copy config files - Will be added when congig is created

        Directory.Delete(AppContext.BaseDirectory + "\TemporaryFiles", True)
        Return False
    End Function

    Public Sub UpdateWinPE()

    End Sub

    Public Structure ConfigPEOptional
        Private Name As String
        Private CustomOptional As Boolean
        Private RootName As String
        Private DependsOn As List(Of ConfigPEOptional)
        Private HasLanguage As Boolean

        Public Sub New(ByVal newName As String, ByVal newCustomOptional As Boolean, ByVal newRootName As String, ByVal newDepends As List(Of ConfigPEOptional), ByVal newHasLanguage As Boolean)
            Name = newName
            CustomOptional = newCustomOptional
            RootName = newRootName
            DependsOn = newDepends
            HasLanguage = newHasLanguage
        End Sub

        Public Overrides Function ToString() As String
            Return Name.ToString
        End Function

        Public Function GetName() As String
            Return Name
        End Function

        Public Function GetCustomOptional() As Boolean
            Return CustomOptional
        End Function

        Public Function GetRootName() As String
            Return RootName
        End Function

        Public Function GetDepends() As List(Of ConfigPEOptional)
            Return DependsOn
        End Function

        Public Function GetHasLanguage() As Boolean
            Return HasLanguage
        End Function
    End Structure
End Module



'''''' Wall of memory for my pain figuring the GetAvailableDrives function out. This is incomplete but i think it shows enough.
'''
''Win32_DiskDrive
'Dim wdSearcher = New ManagementObjectSearcher("SELECT DeviceID FROM Win32_Volume")
'For Each drive As ManagementObject In wdSearcher.Get()
'    MsgBox("1. " + drive.ToString)
'Next

''Win32_LogicalDisk
'Dim wdSearcher2 = New ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition")
'For Each drive As ManagementObject In wdSearcher2.Get()
'    MsgBox("1. " + drive("Index").ToString + " 1. " + drive("DiskIndex").ToString + " 3. " + drive("SystemName") + " 4. " + drive("DeviceID"))
'Next

'CmbDrives.Items.Clear()
'For Each drive In DriveInfo.GetDrives
'    If drive.DriveType = IO.DriveType.Removable Or If(ShowUnknown = True, drive.DriveType = IO.DriveType.Unknown, False) Or If(ShowInternal = True, drive.DriveType = IO.DriveType.Fixed, False) Then
'        Dim driveToAdd As DriveStruct = New DriveStruct(drive.Name + " " + Convert.ToString(Math.Round(drive.TotalSize / 1073741824, 0)) + "GB " + drive.VolumeLabel, drive)
'        CmbDrives.Items.Add(driveToAdd)
'    End If
'Next
'If CmbDrives.Items.Count = 0 Then
'    CmbDrives.Items.Add("No Usable Drives Found")
'End If
'CmbDrives.SelectedIndex = 0
'''