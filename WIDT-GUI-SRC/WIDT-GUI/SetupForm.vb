﻿Imports System.IO
Imports System.Threading

Public Class SetupForm
    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check to see if there is a WinPE install in the 'default' location. If there is select it.
        'If Directory.Exists(Directory.GetParent(AppContext.BaseDirectory.ToString).ToString + "\WinPE-Instances\WIDT_WinPE_amd64") Then
        '    WinPEPath = Directory.GetParent(AppContext.BaseDirectory.ToString).ToString + "\WIDT_WinPE_amd64"
        '    RefreshWinPEPath()
        'End If

        Dim ApplicationPath As String = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 2), AppContext.BaseDirectory)
        If Not Directory.Exists(Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances") Then
            Directory.CreateDirectory(Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances")
        End If

        ' Detect any WinPE Instances including saved onces 
        DetectWinPEInstances()
        ' Load the drives into the ui
        RefreshDrives(False, False)
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Structure WinPEItem
        Private InstanceName As String
        Private InstancePath As String

        Public Sub New(ByVal newInstanceName As String, ByVal newInstancePath As String)
            InstanceName = newInstanceName
            InstancePath = newInstancePath
        End Sub

        Public Overrides Function ToString() As String
            Return InstanceName
        End Function

        Public Function GetInstancePath() As String
            Return InstancePath
        End Function

        Public Function GetInstanceName() As String
            Return InstanceName
        End Function
    End Structure

    Private Sub DetectWinPEInstances()
        BoxWinPEInstances.Items.Clear()
        BoxWinPEInstances.Items.Add(New WinPEItem("---- Detected WinPE Instances ----", "N/A"))
        Dim ApplicationPath As String = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 2), AppContext.BaseDirectory)
        For Each Folder In Directory.GetDirectories(Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances")
            BoxWinPEInstances.Items.Add(New WinPEItem(Folder.ToString.Replace(Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances\", ""), Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances\"))
        Next

        ' Add manually defined instances
        BoxWinPEInstances.Items.Add(New WinPEItem("------ Saved WinPE Instances ------", "N/A"))
    End Sub

    Private Async Sub btnNewInstance_Click(sender As Object, e As EventArgs) Handles btnNewInstance.Click
        Dim ConfigureDialog As DialogResult = ConfigurePEDialog.ShowDialog()
        If ConfigureDialog = DialogResult.OK Then
            ' Get the WinPE config information
            Dim WinPEPath As String = ConfigurePEDialog.txtWinPEPath.Text + "\" + ConfigurePEDialog.txtWinPEName.Text.Replace(" ", "_")
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
            ' TODO: If the instance is in our detectable folder do nothing otherwise add it to our manually added Instances

            ' Update UI with the newly setup tools
            DetectWinPEInstances()
        End If
    End Sub

    ReadOnly ADKCommandLine As String = "call ""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat"" && "

    Public Sub SetupWinPE(ByVal Percent As IProgress(Of Integer), ByVal Info As IProgress(Of String), ByVal DetailedInfo As IProgress(Of String), ByVal WPEPath As String, ByVal IncludeDuplicateMagic As Boolean)
        If WPEPath = "" Then
            MessageBox.Show("Please specify a location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf If(WPEPath.Chars(WPEPath.Length - 1) = "\", WPEPath, WPEPath + "\") = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory, AppContext.BaseDirectory + "\") Then
            MessageBox.Show("WinPE cannot be inside the same folder as the tools.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

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

        ' Setting Keyboard layout to en-GB.
        Info.Report("' Setting Keyboard layout to en-GB")
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Set-InputLocale:0809:00000809", DetailedInfo) Then Return
        Percent.Report(45)

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

    'Private Sub btnLocateWinPE_Click(sender As Object, e As EventArgs) Handles btnLocateWinPE.Click
    '    Dim WinPEPathDilogResult As DialogResult = FolderBrowserDialog1.ShowDialog
    '    If WinPEPathDilogResult = DialogResult.OK Then
    '        WinPEPath = FolderBrowserDialog1.SelectedPath
    '        RefreshWinPEPath()
    '    End If
    'End Sub

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
        Else
            CmbDrives.Items.Add("No Usable Drives Found")
        End If
        CmbDrives.SelectedIndex = 0
    End Sub

    Private Sub RefreshWinPEPath(ByVal WinPEInstanceName As String, ByVal WinPEInstancePath As String)
        ChkWinPEStatus.Checked = True
        ChkWinPEStatus.Text = "Using Instance: " & WinPEInstanceName
        ToolTip1.SetToolTip(ChkWinPEStatus, WinPEInstancePath)
        btnCreateISO.Enabled = True
        btnCreateUSB.Enabled = True
    End Sub

    Private Sub ChkShowInternal_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowInternal.CheckedChanged
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Async Sub btnCreateISO_Click(sender As Object, e As EventArgs) Handles btnCreateISO.Click
        ProgressDialog.Show(Me)
        ProgressDialog.SetProgressBarAmount(50)
        ProgressDialog.SetLabelText("Creating WinPE ISO")
        Dim progressInfoDetailed = New Progress(Of String)(Sub(Info)
                                                               ProgressDialog.SetTextboxText(Info)
                                                           End Sub)
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            If File.Exists(SaveFileDialog1.FileName) Then File.Delete(SaveFileDialog1.FileName)
            Dim WinPEItem As WinPEItem = BoxWinPEInstances.SelectedItem
            Await Task.Run(Sub()
                               If RunCmdCommand(ADKCommandLine + "call MakeWinPEMedia /ISO """ + WinPEItem.GetInstancePath + """ """ + SaveFileDialog1.FileName + """", progressInfoDetailed) Then Return
                               MessageBox.Show("Saved ISO Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                           End Sub)
        End If
        ProgressDialog.Close()
    End Sub

    Private Async Sub btnCreateUSB_Click(sender As Object, e As EventArgs) Handles btnCreateUSB.Click
        Me.Enabled = False
        Dim drive As DriveInformation = CmbDrives.SelectedItem
        If CmbDrives.Text = "No Usable Drives Found" Then
            MessageBox.Show("There are no usable drives available.", "Drive Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Select Case drive.ThisDriveType
            Case IO.DriveType.CDRom
                MessageBox.Show("It is not possible at this time to create a CD/DVD WinPE install using this option." + vbCrLf + "If you wish to create a CD/DVD use the ISO option to create an ISO that can be written to a CD/DVD", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.Network
                MessageBox.Show("You cannot use a network share as a drive to install WinPE", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.Ram
                MessageBox.Show("You cannot use a Ramdisk as a WinPE destination", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.NoRootDirectory
                MessageBox.Show("Windows does not detect a drive at this location", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.Unknown
                If MessageBox.Show("Windows cannot identify what type of drive this is." + vbCrLf + "Are you sure you want to continue?", "Unknown Drive Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Return
                End If
            Case IO.DriveType.Fixed
                If MessageBox.Show("Windows has identified this drive as an internal drive." + vbCrLf + "Are you sure you want to continue?", "Internal Drive Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Return
                End If
        End Select
        If VerifyDrive(drive) = False Then Return

        ProgressDialog.Show(Me)
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
        Dim WinPEItem As WinPEItem = BoxWinPEInstances.SelectedItem
        Await Task.Run(Sub() SetupWinPEDrive(progressPercent, progressInfo, progressInfoDetailed, drive, WinPEItem.GetInstancePath, False))
        ProgressDialog.Close()
        Me.Enabled = True
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub



    Private Sub ChkShowUnknownDrives_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowUnknownDrives.CheckedChanged
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CmbDrives.Enabled = False
        Dim drive As DriveInformation = CmbDrives.SelectedItem
        If CmbDrives.Text = "No Usable Drives Found" Then
            MessageBox.Show("There are no usable drives available.", "Drive Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Select Case drive.ThisDriveType
            Case IO.DriveType.CDRom
                MessageBox.Show("It is not possible at this time to create a CD/DVD WinPE install using this option." + vbCrLf + "If you wish to create a CD/DVD use the ISO option to create an ISO that can be written to a CD/DVD", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.Network
                MessageBox.Show("You cannot use a network share as a drive to install WinPE", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.Ram
                MessageBox.Show("You cannot use a Ramdisk as a WinPE destination", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.NoRootDirectory
                MessageBox.Show("Windows does not detect a drive at this location", "Invalid Drive Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Case IO.DriveType.Unknown
                If MessageBox.Show("Windows cannot identify what type of drive this is." + vbCrLf + "Are you sure you want to continue?", "Unknown Drive Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Return
                End If
            Case IO.DriveType.Fixed
                If MessageBox.Show("Windows has identified this drive as an internal drive." + vbCrLf + "Are you sure you want to continue?", "Internal Drive Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Return
                End If
        End Select
        If VerifyDrive(drive) = False Then Return

        ProgressDialog.Show(Me)
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
        Await Task.Run(Sub() SetupWinPEDrive(progressPercent, progressInfo, progressInfoDetailed, drive, "", True))
        ProgressDialog.Close()
        CmbDrives.Enabled = True
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Sub BoxWinPEInstances_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BoxWinPEInstances.SelectedIndexChanged
        Dim SelectedItem As WinPEItem = BoxWinPEInstances.SelectedItem
        If SelectedItem.GetInstancePath = "N/A" Then
            If BoxWinPEInstances.SelectedIndex + 1 > BoxWinPEInstances.Items.Count - 1 Then
                BoxWinPEInstances.SelectedItem = Nothing
            Else
                BoxWinPEInstances.SelectedIndex += 1
            End If
        End If
        If BoxWinPEInstances.SelectedItem IsNot Nothing Then
            RefreshWinPEPath(SelectedItem.GetInstanceName, SelectedItem.GetInstancePath)
        Else
            ChkWinPEStatus.Checked = False
            ChkWinPEStatus.Text = "Not Found"
            ToolTip1.SetToolTip(ChkWinPEStatus, "")
        End If
    End Sub

    Private Sub btnRemoveInstance_Click(sender As Object, e As EventArgs) Handles btnRemoveInstance.Click
        If BoxWinPEInstances.SelectedItem IsNot Nothing Then
            BoxWinPEInstances.Items.RemoveAt(BoxWinPEInstances.SelectedIndex)
        End If
    End Sub
End Class
