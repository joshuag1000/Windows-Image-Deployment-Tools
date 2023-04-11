Imports System.IO
Imports System.Threading

Public Class SetupForm
    Dim WinPEPath As String = ""

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check to see if there is a WinPE install in the 'default' location. If there is select it.
        If Directory.Exists(Directory.GetParent(AppContext.BaseDirectory.ToString).ToString + "\WIDT_WinPE_amd64") Then
            WinPEPath = Directory.GetParent(AppContext.BaseDirectory.ToString).ToString + "\WIDT_WinPE_amd64"
            RefreshWinPEPath()
        End If

        ' Load the drives into the ui
        RefreshDrives(False, False)
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Async Sub btnWinPESetup_Click(sender As Object, e As EventArgs) Handles btnWinPESetup.Click
        Dim ConfigureDialog As DialogResult = ConfigurePEDialog.ShowDialog()
        If ConfigureDialog = DialogResult.OK Then
            ' Get the WinPE config information
            WinPEPath = ConfigurePEDialog.txtWinPEPath.Text + "\WIDT_WinPE_amd64"
            Dim IncludeDuplicateMagic As Boolean = ConfigurePEDialog.chkDupMagic.Checked
            ' close the dialog (frees memory etc)
            ConfigurePEDialog.Close()
            ' show our progress bar information
            ProgressDialog.Show(Me)
            Me.Enabled = False
            ProgressDialog.SetProgressBarAmount(10)

            Dim progressPercent = New Progress(Of Integer)(Sub(Percent)
                                                               ProgressDialog.SetProgressBarAmount(Percent)
                                                           End Sub)
            Dim progressInfo = New Progress(Of String)(Sub(Info)
                                                           ProgressDialog.SetLabelText(Info)
                                                       End Sub)
            Dim progressInfoDetailed = New Progress(Of String)(Sub(Info)
                                                                   ProgressDialog.SetTextboxText(Info)
                                                               End Sub)
            Await Task.Run(Sub() SetupWinPE(progressPercent, progressInfo, progressInfoDetailed, WinPEPath, IncludeDuplicateMagic))
            ProgressDialog.Close()
            Me.Enabled = True
            Me.BringToFront()
            ' Update UI with the newly setup tools
            RefreshWinPEPath()
        End If
    End Sub

    ReadOnly ADKCommandLine As String = "call ""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat"" && "

    Public Sub SetupWinPE(ByVal Percent As IProgress(Of Integer), ByVal Info As IProgress(Of String), ByVal DetailedInfo As IProgress(Of String), ByVal WPEPath As String, ByVal IncludeDuplicateMagic As Boolean)
        ' Create the folder
        Info.Report("Creating Folder")
        If Directory.Exists(WPEPath) Then
            If MessageBox.Show("The folder WIDT_WinPE_amd64 already exists in the folder you selected. Is it ok if it is deleted?", "Folder Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Directory.Delete(WPEPath, True)
            End If
        End If
        Percent.Report(10)

        ' Copy winpe to folder
        Info.Report("Copying WinPE to folder")
        If RunCmdCommand(ADKCommandLine + "call copype amd64 """ + WPEPath + """", DetailedInfo) Then Return
        Percent.Report(20)

        ' Mount the Image
        Info.Report("Mounting WinPE")
        If RunCmdCommand("call Dism /Mount-Image /ImageFile:""" + WPEPath + "\media\sources\boot.wim"" /Index:1 /MountDir:""" + WPEPath + "\mount""", DetailedInfo) Then Return
        Percent.Report(30)

        ' Add WinPE Optional Components
        Info.Report("Adding WinPE Optional Components")
        ' Bare minimum for the best WinPE Experience
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-HSP-Driver.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\lp.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-WMI.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-WMI_en-gb.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-SecureStartup.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-SecureStartup_en-gb.cab""", DetailedInfo) Then Return
        ' Very Nice to have. I plan to add an option to make these optional in the future.
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-HTA.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-HTA_en-gb.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-NetFx.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-NetFx_en-gb.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-Scripting.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-Scripting_en-gb.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-PowerShell.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-PowerShell_en-gb.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-PlatformId.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-DismCmdlets.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-DismCmdlets_en-gb.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-SecureBootCmdlets.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\WinPE-StorageWMI.cab""", DetailedInfo) Then Return
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\en-gb\WinPE-StorageWMI_en-gb.cab""", DetailedInfo) Then Return
        Percent.Report(40)

        ' Copy in the needed files
        Info.Report("Copying Files to WinPE")
        If File.Exists(WPEPath + "\mount\Windows\System32\startnet.cmd") Then
            File.Delete(WPEPath + "\mount\Windows\System32\startnet.cmd")
        End If
        File.WriteAllText(WPEPath + "\mount\Windows\System32\startnet.cmd", My.Resources.startnet)
        Directory.CreateDirectory(WPEPath + "\mount\WIDT-GUI")
        If RunCmdCommand("Call xCopy """ + AppContext.BaseDirectory + """ """ + WPEPath + "\mount\WIDT-GUI\"" /e /q", DetailedInfo) Then Return
        If RunCmdCommand("Call """ + WPEPath + "\mount\WIDT-GUI\WIDT-GUI.exe"" /SetStartupApp WinPE", DetailedInfo) Then Return
        Percent.Report(50)

        ' Cleanup the WinPE image to reduce size
        Info.Report("Cleaning up WinPE Image")
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Cleanup-Image /StartComponentCleanup", DetailedInfo) Then Return

        ' Unmount and Save the image
        Info.Report("Saving WinPE Image")
        If RunCmdCommand("call Dism /Unmount-Image /MountDir:""" + WPEPath + "\Mount"" /Commit", DetailedInfo) Then Return
        Percent.Report(60)

        ' Export the optimised image
        Info.Report("Exporting Cleaned Image")
        If RunCmdCommand("call Dism /Export-Image /SourceImageFile:""" + WPEPath + "\media\sources\boot.wim"" /SourceIndex:1 /DestinationImageFile:""" + WPEPath + "\media\sources\boot.wim.new""", DetailedInfo) Then Return
        File.Delete(WPEPath + "\media\sources\boot.wim")
        File.Move(WPEPath + "\media\sources\boot.wim.new", WPEPath + "\media\sources\boot.wim")


        If IncludeDuplicateMagic = True Then
            ' Create a 7z Archive at max compression 
            Info.Report("Compressing WinPE to 7z Archive")
            If RunCmdCommand("call """ + AppContext.BaseDirectory + "\Resources\7z\7za.exe"" a -t7z -m0=lzma2 -mx=9 """ + WPEPath + "\WinPEMagic.7z"" """ + WPEPath + "\media\*""", DetailedInfo) Then Return
            Percent.Report(70)

            ' ReMount the Image
            Info.Report("Mounting WinPE")
            If RunCmdCommand("call Dism /Mount-Image /ImageFile:""" + WPEPath + "\media\sources\boot.wim"" /Index:1 /MountDir:""" + WPEPath + "\mount""", DetailedInfo) Then Return
            Percent.Report(80)

            ' Move the file into the WinPE Environment
            Info.Report("Adding archive to WinPE")
            File.Move(WPEPath + "\WinPEMagic.7z", WPEPath + "\mount\WIDT-GUI\WinPEMagic.7z")
            Percent.Report(90)

            ' Unmount and Save the image
            Info.Report("Saving WinPE Image")
            If RunCmdCommand("call Dism /Unmount-Image /MountDir:""" + WPEPath + "\Mount"" /Commit", DetailedInfo) Then Return
            Percent.Report(100)
        Else
            Percent.Report(100)
        End If

        Thread.Sleep(300)
    End Sub

    Private Sub btnLocateWinPE_Click(sender As Object, e As EventArgs) Handles btnLocateWinPE.Click
        Dim WinPEPathDilogResult As DialogResult = FolderBrowserDialog1.ShowDialog
        If WinPEPathDilogResult = DialogResult.OK Then
            WinPEPath = FolderBrowserDialog1.SelectedPath
            RefreshWinPEPath()
        End If
    End Sub

    Private Sub btnRefreshDrives_Click(sender As Object, e As EventArgs) Handles btnRefreshDrives.Click
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Async Sub RefreshDrives(ByVal ShowInternal As Boolean, ByVal ShowUnknown As Boolean)
        Dim PotentialDrives As List(Of DriveInformation) = New List(Of DriveInformation)
        Await Task.Run(Sub() PotentialDrives = GetAvailableDrives(ShowInternal, True, ShowUnknown))
        CmbDrives.Items.Clear()
        If PotentialDrives.Count > 0 Then
            For Each drive As DriveInformation In PotentialDrives
                CmbDrives.Items.Add(drive)
            Next
            CmbDrives.SelectedIndex = 0
        End If
    End Sub

    Private Sub RefreshWinPEPath()
        ChkWinPEStatus.Checked = True
        Dim StringCalc As String = Directory.GetParent(WinPEPath).ToString
        ChkWinPEStatus.Text = "Found in: " + If(StringCalc.Length > 33, WinPEPath.Substring(0, 3) + "..." + StringCalc.Substring(StringCalc.Length - 30, 30), StringCalc)
        btnCreateISO.Enabled = True
        btnCreateUSB.Enabled = True
    End Sub

    Private Sub ChkShowInternal_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowInternal.CheckedChanged
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Async Sub btnCreateISO_Click(sender As Object, e As EventArgs) Handles btnCreateISO.Click
        ProgressDialog.Show()
        ProgressDialog.SetProgressBarAmount(50)
        ProgressDialog.SetLabelText("Creating WinPE ISO")
        Dim progressInfoDetailed = New Progress(Of String)(Sub(Info)
                                                               ProgressDialog.SetTextboxText(Info)
                                                           End Sub)
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            If File.Exists(SaveFileDialog1.FileName) Then File.Delete(SaveFileDialog1.FileName)
            Await Task.Run(Sub()
                               If RunCmdCommand(ADKCommandLine + "call MakeWinPEMedia /ISO """ + WinPEPath + """ """ + SaveFileDialog1.FileName + """", progressInfoDetailed) Then Return
                               MessageBox.Show("Saved ISO Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                           End Sub)
        End If
        ProgressDialog.Close()
    End Sub

    Private Async Sub btnCreateUSB_Click(sender As Object, e As EventArgs) Handles btnCreateUSB.Click
        'If CmbDrives.Text = "No Usable Drives Found" Then
        '    MessageBox.Show("There are no usable drives available.", "Drive Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        'Select Case drive.GetDriveInfo.DriveType
        '    Case IO.DriveType.CDRom
        '        MessageBox.Show("It is not possible at this time to create a CD/DVD WinPE install using this option." + vbCrLf + "If you wish to create a CD/DVD use the ISO option to create an ISO that can be written to a CD/DVD", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return
        '    Case IO.DriveType.Network
        '        MessageBox.Show("You cannot use a network share as a drive to install WinPE", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return
        '    Case IO.DriveType.Ram
        '        MessageBox.Show("You cannot use a Ramdisk as a WinPE destination", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return
        '    Case IO.DriveType.NoRootDirectory
        '        MessageBox.Show("Windows does not detect a drive at this location", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return
        '    Case IO.DriveType.Unknown
        '        If MessageBox.Show("Windows cannot identify what type of drive this is." + vbCrLf + "Are you sure you want to continue?", "Unknown Drive Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
        '            Return
        '        End If
        '    Case IO.DriveType.Fixed
        '        If MessageBox.Show("Windows has identified this drive as an internal drive." + vbCrLf + "Are you sure you want to continue?", "Internal Drive Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
        '            Return
        '        End If
        'End Select

        'Dim drive As DriveStruct = CmbDrives.SelectedItem
        'MsgBox(drive.ToString)
        'ProgressDialog.Show()
        'ProgressDialog.SetProgressBarAmount(10)
        'Dim progressPercent = New Progress(Of Integer)(Sub(Percent)
        '                                                   ProgressDialog.SetProgressBarAmount(Percent)
        '                                               End Sub)
        'Dim progressInfo = New Progress(Of String)(Sub(Info)
        '                                               ProgressDialog.SetLabelText(Info)
        '                                           End Sub)
        'Dim progressInfoDetailed = New Progress(Of String)(Sub(Info)
        '                                                       ProgressDialog.SetTextboxText(Info)
        '                                                   End Sub)
        'Await Task.Run(Sub() SetupWinPEDrive(progressPercent, progressInfo, progressInfoDetailed, WinPEPath))
        'ProgressDialog.Close()
    End Sub

    Private Sub SetupWinPEDrive(ByVal Percent As IProgress(Of Integer), ByVal Info As IProgress(Of String), ByVal DetailedInfo As IProgress(Of String), ByVal WPEPath As String)
        Directory.CreateDirectory(AppContext.BaseDirectory + "\TemporaryFiles")
        My.Computer.FileSystem.WriteAllText(AppContext.BaseDirectory + "\TemporaryFiles\ListDisks.tmp", "list disk" + vbCrLf + "exit", False)
        Dim DismListDisks() As String = RunCmdCommandSync("Diskpart /s """ + AppContext.BaseDirectory + "\TemporaryFiles\ListDisks.tmp""").Split(vbCrLf)
        File.Delete(AppContext.BaseDirectory + "\TemporaryFiles\ListDisks.tmp")

        Dim Drives As New List(Of String)
        For i = 0 To DismListDisks.Length - 1
            If DismListDisks(i).Contains("Disk ###") And DismListDisks(i + 1).Contains("---") Then
                i += 2
                While DismListDisks(i).Contains("Disk")
                    Drives.Add(DismListDisks(i))
                    i += 1
                End While
                i = DismListDisks.Length - 1
            End If
        Next
        For Each i In Drives
            MsgBox(i)
        Next


    End Sub

    Private Sub ChkShowUnknownDrives_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowUnknownDrives.CheckedChanged
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub
End Class
