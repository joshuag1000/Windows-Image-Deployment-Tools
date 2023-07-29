Public Class DeployConfigForm
    Private SilentClose As Boolean = False

    Private Async Sub RefreshDrives(ByVal ShowRemovable As Boolean, ByVal ShowUnknown As Boolean)
        Dim PotentialDrives As List(Of DriveInformation) = New List(Of DriveInformation)
        Await Task.Run(Sub() PotentialDrives = GetAvailableDrives(True, ShowRemovable, ShowUnknown))
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

    Private Sub DeployConfigForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDrives(False, False)
        If Not GetStartupMode() Then
            ShutdownWinPEToolStripMenuItem.Enabled = False
            ShutdownWinPEToolStripMenuItem.Visible = False
            OpenConfigurationWindowToolStripMenuItem.Enabled = False
            OpenConfigurationWindowToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub btnRefreshDrives_Click(sender As Object, e As EventArgs) Handles btnRefreshDrives.Click
        RefreshDrives(ChkShowRemovable.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click

    End Sub

    Private Sub QuitWIDTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitWIDTToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DeployConfigForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SilentClose = False And GetStartupMode() Then
            Dim MsgResult As DialogResult = MessageBox.Show("Are you sure you want to close WIDT?" + vbCrLf + "You can shutdown the computer from the Tools / Options menu.", "Close WIDT?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If MsgResult = DialogResult.Yes Then
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub ShutdownWinPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownWinPEToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you would like to shutdown the computer?", "Shutdown Computer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SilentClose = True
            RunCmdCommandSync("wpeutil shutdown")
        End If
    End Sub

    Private Sub OpenConfigurationWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenConfigurationWindowToolStripMenuItem.Click
        SetupForm.ShowDialog()
        ' Refresh the configs
    End Sub

    Private Sub ShowConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowConsoleToolStripMenuItem.Click
        Process.Start("%SYSTEMROOT%\System32\cmd.exe")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub
End Class