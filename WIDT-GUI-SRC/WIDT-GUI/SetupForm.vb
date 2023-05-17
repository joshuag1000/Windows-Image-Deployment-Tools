Imports System.IO

Public Class SetupForm
    Dim DetectedConfigPath As String = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 2), AppContext.BaseDirectory)

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Detect any WinPE Instances including saved onces. If we are in WinPE mode this ONLY checks for Duplication Magic
        DetectWinPEInstances()

        ' If we are running in WinPE Mode behave slightly differently.
        If GetStartupMode() = True Then
            Me.Text = "WinPE - Windows Image Deployment Tools"
            btnNewInstance.Enabled = False
            btnRemoveInstance.Enabled = False
            btnLocateExistingInstance.Enabled = False
            btnCreateISO.Enabled = False
            TabControl1.SelectedIndex = 1

            For Each drive In System.IO.DriveInfo.GetDrives
                If drive.RootDirectory.ToString <> "" Then
                    If File.Exists(drive.RootDirectory.ToString & ":\WinPEDriveAutoDetect") Then
                        DetectedConfigPath = drive.RootDirectory.ToString & ":\"
                        Exit For
                    End If
                End If
            Next
        End If
        ' Detect any configs and check the required folders exist.
        DetectConfigs(DetectedConfigPath)
        ' Load the drives into the ui
        RefreshDrives(False, False)
    End Sub

    Private Sub DetectConfigs(ByVal DataPath As String)
        If Not Directory.Exists(Directory.GetParent(DataPath).ToString + "\WinPE-Instances") Then
            Directory.CreateDirectory(Directory.GetParent(DataPath).ToString + "\WinPE-Instances")
        End If
        If Not Directory.Exists(Directory.GetParent(DataPath).ToString + "\WinPE-Drivers") Then
            Directory.CreateDirectory(Directory.GetParent(DataPath).ToString + "\WinPE-Drivers")
        End If
        If Not Directory.Exists(Directory.GetParent(DataPath).ToString + "\Configs") Then
            Directory.CreateDirectory(Directory.GetParent(DataPath).ToString + "\Configs")
        End If
        If Not Directory.Exists(Directory.GetParent(DataPath).ToString + "\Drivers") Then
            Directory.CreateDirectory(Directory.GetParent(DataPath).ToString + "\Drivers")
        End If
        If Not Directory.Exists(Directory.GetParent(DataPath).ToString + "\Images") Then
            Directory.CreateDirectory(Directory.GetParent(DataPath).ToString + "\Images")
        End If

        ' Load the existing configs into the list boxes
        BoxCreateConfigs.Items.Clear()
        For Each Configs In Directory.GetFiles(Directory.GetParent(DataPath).ToString + "\Configs")
            If Configs.Substring(Configs.Length - 4, 4).ToLower = ".xml" Then
                BoxCreateConfigs.Items.Add(New ConfigItem(Configs.Replace(Directory.GetParent(DataPath).ToString + "\Configs\", "").Substring(0, Configs.Replace(Directory.GetParent(DataPath).ToString + "\Configs\", "").Length - 4), Configs))
                boxWIDTConfigs.Items.Add(New ConfigItem(Configs.Replace(Directory.GetParent(DataPath).ToString + "\Configs\", "").Substring(0, Configs.Replace(Directory.GetParent(DataPath).ToString + "\Configs\", "").Length - 4), Configs))
            End If
        Next

        ' Load the existing images into the list boxes
        BoxCreateImages.Items.Clear()
        For Each Images In Directory.GetFiles(Directory.GetParent(DataPath).ToString + "\Images")
            If Images.Substring(Images.Length - 4, 4) = ".wim".ToLower Or Images.Substring(Images.Length - 4, 4) = ".iso".ToLower Then
                BoxCreateImages.Items.Add(New ConfigItem(Images.Replace(Directory.GetParent(DataPath).ToString + "\Images\", ""), Images))
                boxSelectImage.Items.Add(New ConfigItem(Images.Replace(Directory.GetParent(DataPath).ToString + "\Images\", ""), Images))
            End If
        Next

        ' Load the Driver Packs into the list boxes.
        BoxCreateDrivers.Items.Clear()
        For Each DriverPack In Directory.GetDirectories(Directory.GetParent(DataPath).ToString + "\Drivers")
            BoxCreateDrivers.Items.Add(New ConfigItem(DriverPack.Replace(Directory.GetParent(DataPath).ToString + "\Drivers\", ""), DriverPack))
            boxSelectedDriverPacks.Items.Add(New ConfigItem(DriverPack.Replace(Directory.GetParent(DataPath).ToString + "\Drivers\", ""), DriverPack))
        Next
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Structure WinPEItem
        Private InstanceName As String
        Private InstancePath As String
        Private IsInstanceDetected As Boolean

        Public Sub New(ByVal newInstanceName As String, ByVal newInstancePath As String, ByVal newIsInstanceDetected As Boolean)
            InstanceName = newInstanceName
            InstancePath = newInstancePath
            IsInstanceDetected = newIsInstanceDetected
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

        Public Function GetIsInstanceDetected() As Boolean
            Return IsInstanceDetected
        End Function
    End Structure

    Private Sub DetectWinPEInstances()
        BoxWinPEInstances.Items.Clear()
        BoxWinPEInstances.Items.Add(New WinPEItem("---- Detected WinPE Instances ----", "N/A", True))
        If GetStartupMode() = True Then
            If File.Exists(AppContext.BaseDirectory + "\WinPEMagic.7z") Then
                BoxWinPEInstances.Items.Add(New WinPEItem("WIDT: Duplication Magic", AppContext.BaseDirectory + "\WinPEMagic.7z", True))
            Else
                BoxWinPEInstances.Items.Add(New WinPEItem("Duplication Magic Not Found", "N/A", True))
            End If
        Else
            Dim ApplicationPath As String = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 2), AppContext.BaseDirectory)
            For Each Folder In Directory.GetDirectories(Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances")
                BoxWinPEInstances.Items.Add(New WinPEItem(Folder.ToString.Replace(Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances\", ""), Folder, True))
            Next

            ' Add manually defined instances
            BoxWinPEInstances.Items.Add(New WinPEItem("------ Saved WinPE Instances ------", "N/A", False))
        End If

    End Sub

    Private Async Sub btnNewInstance_Click(sender As Object, e As EventArgs) Handles btnNewInstance.Click
        Dim ConfigureDialog As DialogResult = ConfigurePEDialog.ShowDialog()
        If ConfigureDialog = DialogResult.OK Then
            ' Get the WinPE config information
            Dim WinPEPath As String = ConfigurePEDialog.txtWinPEPath.Text + "\" + ConfigurePEDialog.txtWinPEName.Text.Replace(" ", "_")
            Dim OptionalComponents As List(Of ConfigPEOptional) = New List(Of ConfigPEOptional)
            For i = 0 To ConfigurePEDialog.ChkOptionalComp.Items.Count - 1
                If ConfigurePEDialog.ChkOptionalComp.GetItemChecked(i) = True Then
                    OptionalComponents.Add(ConfigurePEDialog.ChkOptionalComp.Items(i))
                End If
            Next
            Dim Language As String = ConfigurePEDialog.cmbLanguage.SelectedItem.ToString
            Dim AddWinPEDrivers As Boolean = ConfigurePEDialog.ChkIncludeDrivers.Checked
            Dim WinPEDriversPath As String = ConfigurePEDialog.txtWinPEDrivers.Text
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
            Await Task.Run(Sub()
                               If SetupWinPE(progressPercent, progressInfo, progressInfoDetailed, WinPEPath, OptionalComponents, Language, AddWinPEDrivers, WinPEDriversPath) Then Return
                               MessageBox.Show("WinPE Instance Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                           End Sub)
            ProgressDialog.Close()
            Me.Enabled = True
            Me.BringToFront()
            ' TODO: If the instance is in our detectable folder do nothing otherwise add it to our manually added Instances

            Dim ApplicationPath As String = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.Length - 2), AppContext.BaseDirectory)
            If Not WinPEPath.Contains(Directory.GetParent(ApplicationPath).ToString + "\WinPE-Instances\") Then
                ' Add to our config
            End If

            ' Update UI with the newly setup tools
            DetectWinPEInstances()
        End If
    End Sub

    ReadOnly ADKCommandLine As String = "call ""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat"" && "

    Public Function SetupWinPE(ByVal Percent As IProgress(Of Integer), ByVal Info As IProgress(Of String), ByVal DetailedInfo As IProgress(Of String), ByVal WPEPath As String, ByVal OptionalComponents As List(Of ConfigPEOptional), ByVal Language As String, ByVal AddWinPEDrivers As Boolean, ByVal WinPEDriversPath As String)
        If WPEPath = "" Then
            MessageBox.Show("Please specify a location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        ElseIf If(WPEPath.Chars(WPEPath.Length - 1) = "\", WPEPath, WPEPath + "\") = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory, AppContext.BaseDirectory + "\") Then
            MessageBox.Show("WinPE cannot be inside the same folder as the tools.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If

        ' Create the folder
        Info.Report("Creating Folder")
        If Directory.Exists(WPEPath) Then
            If MessageBox.Show("The WinPE Instance already exists in the folder you selected. Is it ok if it is deleted?", "Folder Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Directory.Delete(WPEPath, True)
            End If
        End If
        Percent.Report(10)

        ' Copy winpe to folder
        Info.Report("Copying WinPE to folder")
        If RunCmdCommand(ADKCommandLine + "call copype amd64 """ + WPEPath + """", DetailedInfo) Then Return True
        Percent.Report(20)

        ' Mount the Image
        Info.Report("Mounting WinPE")
        If RunCmdCommand("call Dism /Mount-Image /ImageFile:""" + WPEPath + "\media\sources\boot.wim"" /Index:1 /MountDir:""" + WPEPath + "\mount""", DetailedInfo) Then Return True
        Percent.Report(30)

        ' Add in any WinPE Drivers if they are needed.
        If AddWinPEDrivers = True Then
            Info.Report("Adding WinPE Drivers")
            If RunCmdCommand("call Dism /Add-Driver /Image:""" + WPEPath + "\mount"" /Driver:""" + WinPEDriversPath + """ /recurse", DetailedInfo) Then Return True
            Percent.Report(35)
        End If

        ' Add WinPE Optional Components
        Info.Report("Adding WinPE Optional Components")
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\" + Language + "\lp.cab""", DetailedInfo) Then Return True
        For Each component In OptionalComponents
            If component.GetCustomOptional = False Then
                If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\" + component.GetRootName + ".cab""", DetailedInfo) Then Return True
                If component.GetHasLanguage() = True Then
                    If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Add-Package /PackagePath:""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\" + Language + "\" + component.GetRootName + "_" + Language + ".cab""", DetailedInfo) Then Return True
                End If
            End If
        Next
        Percent.Report(40)

        ' Setting Keyboard layout to en-GB.
        Info.Report("Setting Keyboard layout to en-GB")
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Set-InputLocale:0809:00000809", DetailedInfo) Then Return True
        Percent.Report(45)

        ' Copy in the needed files
        Info.Report("Copying Files to WinPE")
        If File.Exists(WPEPath + "\mount\Windows\System32\Winpeshl.ini") Then
            File.Delete(WPEPath + "\mount\Windows\System32\Winpeshl.ini")
        End If
        File.WriteAllText(WPEPath + "\mount\Windows\System32\Winpeshl.ini", My.Resources.Winpeshl)
        Directory.CreateDirectory(WPEPath + "\mount\WIDT-GUI")
        If RunCmdCommand("Call xCopy """ + AppContext.BaseDirectory + """ """ + WPEPath + "\mount\WIDT-GUI\"" /e /q", DetailedInfo) Then Return True
        If RunCmdCommand("Call """ + WPEPath + "\mount\WIDT-GUI\WIDT-GUI.exe"" /SetStartupApp WinPE", DetailedInfo) Then Return True
        Percent.Report(50)

        ' Cleanup the WinPE image to reduce size
        Info.Report("Cleaning up WinPE Image")
        If RunCmdCommand("call Dism /Image:""" + WPEPath + "\mount"" /Cleanup-Image /StartComponentCleanup", DetailedInfo) Then Return True

        ' Unmount and Save the image
        Info.Report("Saving WinPE Image")
        If RunCmdCommand("call Dism /Unmount-Image /MountDir:""" + WPEPath + "\Mount"" /Commit", DetailedInfo) Then Return True
        Percent.Report(60)

        ' Export the optimised image
        Info.Report("Exporting Cleaned Image")
        If RunCmdCommand("call Dism /Export-Image /SourceImageFile:""" + WPEPath + "\media\sources\boot.wim"" /SourceIndex:1 /DestinationImageFile:""" + WPEPath + "\media\sources\boot.wim.new""", DetailedInfo) Then Return True
        File.Delete(WPEPath + "\media\sources\boot.wim")
        File.Move(WPEPath + "\media\sources\boot.wim.new", WPEPath + "\media\sources\boot.wim")


        If OptionalComponents.Contains(New ConfigPEOptional("WIDT/DuplicationMagic", True, "DuplicationMagic", Nothing, False)) Then
            ' Create a 7z Archive at max compression 
            Info.Report("Compressing WinPE to 7z Archive")
            If RunCmdCommand("call """ + AppContext.BaseDirectory + "\Resources\7z\7za.exe"" a -t7z -m0=lzma2 -mx=9 """ + WPEPath + "\WinPEMagic.7z"" """ + WPEPath + "\media\*""", DetailedInfo) Then Return True
            Percent.Report(70)

            ' ReMount the Image
            Info.Report("Mounting WinPE")
            If RunCmdCommand("call Dism /Mount-Image /ImageFile:""" + WPEPath + "\media\sources\boot.wim"" /Index:1 /MountDir:""" + WPEPath + "\mount""", DetailedInfo) Then Return True
            Percent.Report(80)

            ' Move the file into the WinPE Environment
            Info.Report("Adding archive to WinPE")
            File.Move(WPEPath + "\WinPEMagic.7z", WPEPath + "\mount\WIDT-GUI\WinPEMagic.7z")
            Percent.Report(90)

            ' Unmount and Save the image
            Info.Report("Saving WinPE Image")
            If RunCmdCommand("call Dism /Unmount-Image /MountDir:""" + WPEPath + "\Mount"" /Commit", DetailedInfo) Then Return True
            Percent.Report(100)
        Else
            Percent.Report(100)
        End If
        Return False
    End Function

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
        If VerifyDrive(drive) = False Then
            RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
            Return
        End If

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
        Dim SelectedWinPEItem As WinPEItem = BoxWinPEInstances.SelectedItem
        Await Task.Run(Sub()
                           Dim ItemsToCopy As New List(Of ConfigItem)
                           For i = 0 To BoxCreateConfigs.Items.Count - 1
                               If BoxCreateConfigs.GetItemChecked(i) = True Then
                                   ItemsToCopy.Add(BoxCreateConfigs.Items(i))
                               End If
                           Next
                           For i = 0 To BoxCreateDrivers.Items.Count - 1
                               If BoxCreateDrivers.GetItemChecked(i) = True Then
                                   ItemsToCopy.Add(BoxCreateDrivers.Items(i))
                               End If
                           Next
                           For i = 0 To BoxCreateImages.Items.Count - 1
                               If BoxCreateImages.GetItemChecked(i) = True Then
                                   ItemsToCopy.Add(BoxCreateImages.Items(i))
                               End If
                           Next
                           If SelectedWinPEItem.GetInstanceName = "WIDT: Duplication Magic" And SelectedWinPEItem.GetInstancePath = AppContext.BaseDirectory + "\WinPEMagic.7z" And SelectedWinPEItem.GetIsInstanceDetected = True Then
                               If SetupWinPEDrive(progressPercent, progressInfo, progressInfoDetailed, drive, "", True, DetectedConfigPath, ItemsToCopy) Then Return
                           Else
                               If SetupWinPEDrive(progressPercent, progressInfo, progressInfoDetailed, drive, SelectedWinPEItem.GetInstancePath, False, DetectedConfigPath, ItemsToCopy) Then Return
                           End If
                           MessageBox.Show("USB Drive Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                       End Sub)
        ProgressDialog.Close()
        Me.Enabled = True
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Sub ChkShowUnknownDrives_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowUnknownDrives.CheckedChanged
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
            btnCreateISO.Enabled = False
            btnCreateUSB.Enabled = False
        End If
    End Sub

    Private Sub btnRemoveInstance_Click(sender As Object, e As EventArgs) Handles btnRemoveInstance.Click
        If BoxWinPEInstances.SelectedItem IsNot Nothing Then
            Dim ItemToRemove As WinPEItem = BoxWinPEInstances.SelectedItem
            If ItemToRemove.GetIsInstanceDetected = False Then
                If MessageBox.Show("Are you sure you would like to remove this instance?" + vbCrLf + "It can be added again using the locate instance button", "Remove Instance?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BoxWinPEInstances.Items.RemoveAt(BoxWinPEInstances.SelectedIndex)
                    If MessageBox.Show("Would you like to delete this instance from your computer?", "Delete Instance from Computer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Directory.Delete(ItemToRemove.GetInstancePath, True)
                    End If
                    ' TODO: Remove instance from saved config
                End If
            ElseIf ItemToRemove.GetIsInstanceDetected = True Then
                If MessageBox.Show("Removing this instance will delete the instance from your computer." + vbCrLf + "Are you sure you would like to continue?", "Remove Instance?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BoxWinPEInstances.Items.RemoveAt(BoxWinPEInstances.SelectedIndex)
                    Directory.Delete(ItemToRemove.GetInstancePath, True)
                End If
            End If
        End If
    End Sub

    Private Sub btnLocateExistingInstance_Click(sender As Object, e As EventArgs) Handles btnLocateExistingInstance.Click
        Dim WinPEPathDilogResult As DialogResult = FolderBrowserDialog1.ShowDialog
        If WinPEPathDilogResult = DialogResult.OK Then
            Dim PathCalc As String = If(FolderBrowserDialog1.SelectedPath.Chars(FolderBrowserDialog1.SelectedPath.Length - 1) = "\", FolderBrowserDialog1.SelectedPath.Substring(0, FolderBrowserDialog1.SelectedPath.Length - 2), FolderBrowserDialog1.SelectedPath)
            BoxWinPEInstances.Items.Add(New WinPEItem(PathCalc.ToString.Replace(Directory.GetParent(PathCalc).ToString, ""), PathCalc, False))
            ' TODO: Add instance to config
        End If
    End Sub

    Private Sub AboutWIDTGUIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutWIDTGUIToolStripMenuItem.Click
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub btnRefreshConfigs_Click(sender As Object, e As EventArgs) Handles btnRefreshConfigs.Click
        DetectConfigs(DetectedConfigPath)
    End Sub
End Class
