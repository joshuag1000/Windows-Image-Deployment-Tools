Imports System.IO.DriveInfo
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
        RefreshDrives(False)
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
            Await Task.Run(Sub() SetupWinPE(progressPercent, progressInfo, WinPEPath, IncludeDuplicateMagic))
            ProgressDialog.Close()
            Me.Enabled = True
            Me.BringToFront()
            ' Update UI with the newly setup tools
            RefreshWinPEPath()
        End If
    End Sub

    Public Sub SetupWinPE(ByVal Percent As IProgress(Of Integer), ByVal Info As IProgress(Of String), ByVal WPEPath As String, ByVal IncludeDuplicateMagic As Boolean)
        Dim ADKCommandLine As String = "call ""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat"" && "

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
        If RunCmdCommand(ADKCommandLine + "call copype amd64 """ + WPEPath + """") Then Return
        Percent.Report(20)

        ' Mount the Image
        Info.Report("Mounting WinPE")
        If RunCmdCommand("call Dism /Mount-Image /ImageFile:""" + WPEPath + "\media\sources\boot.wim"" /Index:1 /MountDir:""" + WPEPath + "\mount""") Then Return
        Percent.Report(30)

        ' Copy in the needed files
        Info.Report("Copying Files to WinPE")
        If File.Exists(WPEPath + "\mount\Windows\System32\startnet.cmd") Then
            File.Delete(WPEPath + "\mount\Windows\System32\startnet.cmd")
        End If
        File.WriteAllText(WPEPath + "\mount\Windows\System32\startnet.cmd", My.Resources.startnet)
        Directory.CreateDirectory(WPEPath + "\mount\WIDT-GUI")
        If RunCmdCommand("Call xCopy """ + AppContext.BaseDirectory + """ """ + WPEPath + "\mount\WIDT-GUI\"" /e /q") Then Return
        If RunCmdCommand("Call """ + WPEPath + "\mount\WIDT-GUI\WIDT-GUI.exe"" /SetStartupApp WinPE") Then Return
        Percent.Report(40)

        ' Unmount and Save the image
        Info.Report("Saving WinPE Image")
        If RunCmdCommand("call Dism /Unmount-Image /MountDir:""" + WPEPath + "\Mount"" /Commit") Then Return
        Percent.Report(50)

        ' Create a 7z Archive at max compression 
        Info.Report("Compressing WinPE to 7z Archive")
        If RunCmdCommand("call """ + AppContext.BaseDirectory + "\Resources\7zr.exe"" a -t7z -m0=lzma2 -mx=9 """ + WPEPath + "\WinPEMagic.7z"" """ + WPEPath + "\media\*""") Then Return
        Percent.Report(60)

        If IncludeDuplicateMagic = True Then
            ' ReMount the Image
            Info.Report("Mounting WinPE")
            If RunCmdCommand("call Dism /Mount-Image /ImageFile:""" + WPEPath + "\media\sources\boot.wim"" /Index:1 /MountDir:""" + WPEPath + "\mount""") Then Return
            Percent.Report(70)

            ' Move the file into the WinPE Environment
            Info.Report("Adding archive to WinPE")
            File.Move(WPEPath + "\WinPEMagic.7z", WPEPath + "\mount\WIDT-GUI\WinPEMagic.7z")
            Percent.Report(80)

            ' Unmount and Save the image
            Info.Report("Saving WinPE Image")
            If RunCmdCommand("call Dism /Unmount-Image /MountDir:""" + WPEPath + "\Mount"" /Commit") Then Return
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
        RefreshDrives(ChkShowInternal.Checked)
    End Sub

    Private Structure DriveStruct
        Private DriveName As String
        Private drive As DriveInfo

        Public Sub New(name As String, newdrv As DriveInfo)
            DriveName = name
            drive = newdrv
        End Sub

        Public Overrides Function ToString() As String
            Return DriveName
        End Function
    End Structure

    Private Sub RefreshDrives(ByVal ShowInternal As Boolean)
        CmbDrives.Items.Clear()
        For Each drive In DriveInfo.GetDrives
            If drive.DriveType = IO.DriveType.Removable Or drive.DriveType = IO.DriveType.NoRootDirectory Or If(ShowInternal = True, drive.DriveType = IO.DriveType.Fixed, Nothing) Then
                Dim driveToAdd As DriveStruct = New DriveStruct(drive.Name + " " + drive.VolumeLabel, drive)
                CmbDrives.Items.Add(driveToAdd)
            End If
        Next
        If CmbDrives.Items.Count = 0 Then
            CmbDrives.Items.Add("No Usable Drives Found")
        End If
        CmbDrives.SelectedIndex = 0
    End Sub

    Private Sub RefreshWinPEPath()
        ChkWinPEStatus.Checked = True
        Dim StringCalc As String = Directory.GetParent(WinPEPath).ToString
        ChkWinPEStatus.Text = "Found in: " + If(StringCalc.Length > 33, WinPEPath.Substring(0, 3) + "..." + StringCalc.Substring(StringCalc.Length - 30, 30), StringCalc)
    End Sub

    Private Sub ChkShowInternal_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowInternal.CheckedChanged
        RefreshDrives(ChkShowInternal.Checked)
    End Sub
End Class
