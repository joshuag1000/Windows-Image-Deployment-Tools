Imports System.ComponentModel
Imports System.IO

Public Class WinPEForm
    Private Sub UseLegacyToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UseLegacyToolsToolStripMenuItem.Click
        Process.Start(AppContext.BaseDirectory + "\Resources\LegacyWinPERuntimeScripts\Entrypoint.Bat")
        Me.Close()
    End Sub

    Dim overrideCloseMessage As Boolean = False
    Private Sub ShutdownComputerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownComputerToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you would like to shutdown the computer?", "Shutdown Computer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            RunCmdCommandSync("wpeutil shutdown")
            overrideCloseMessage = True
            Me.Close()
        End If
    End Sub

    Private Sub RebootComputerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RebootComputerToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you would like to reboot the computer?", "Reboot Computer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            RunCmdCommandSync("wpeutil reboot")
            overrideCloseMessage = True
            Me.Close()
        End If
    End Sub

    Private Sub QuitToConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToConsoleToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you would like to close WIDT-GUI?" + vbCrLf + "To reopen the application WIDT-GUI.exe in the console." + vbCrLf + "If all you need is a console you can open one in the tools menu.", "Close WIDT-GUI?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            overrideCloseMessage = True
            Me.Close()
        End If
    End Sub

    Private Sub OpenConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenConsoleToolStripMenuItem.Click
        Process.Start("cmd", "")
    End Sub

    Private Sub WinPEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(AppContext.BaseDirectory + "\WinPEMagic.7z") Then
            DuplicateWinPEUSBKeyToolStripMenuItem.Enabled = True
        Else
            DuplicateWinPEUSBKeyToolStripMenuItem.Text = "Duplication Magic Unavailable"
        End If
    End Sub

    Private Sub WinPEForm_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If overrideCloseMessage = False Then
            Dim MsgResult As DialogResult = MessageBox.Show("Would you like to shutdown WinPE?", "Shutdown WinPE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If MsgResult = DialogResult.Yes Then
                RunCmdCommandSync("wpeutil shutdown")
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Async Sub DuplicateWinPEUSBKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateWinPEUSBKeyToolStripMenuItem.Click
        If ConfigureDuplicationMagic.ShowDialog(Me) = DialogResult.Cancel Then Return
        If ConfigureDuplicationMagic.CmbDrives.SelectedItem.ToString = "No Usable Drives Found" Then
            MessageBox.Show("No valid drive selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim drive As DriveInformation = ConfigureDuplicationMagic.CmbDrives.SelectedItem
        ConfigureDuplicationMagic.Close()
        If ConfigureDuplicationMagic.CmbDrives.Text = "No Usable Drives Found" Then
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

        Me.Enabled = False
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
        Await Task.Run(Sub()
                           If SetupWinPEDrive(progressPercent, progressInfo, progressInfoDetailed, drive, "", True) Then Return
                           MessageBox.Show("USB Drive Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                       End Sub)
        ProgressDialog.Close()
        Me.Enabled = True
    End Sub

    Private Sub AboutWIDTGUIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutWIDTGUIToolStripMenuItem.Click
        AboutBox.ShowDialog(Me)
    End Sub
End Class