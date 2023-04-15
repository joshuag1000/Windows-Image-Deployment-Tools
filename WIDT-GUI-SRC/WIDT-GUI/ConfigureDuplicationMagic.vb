Public Class ConfigureDuplicationMagic
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

    Private Sub ConfigureDuplicationMagic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDrives(False, False)
    End Sub

    Private Sub btnRefreshDrives_Click(sender As Object, e As EventArgs) Handles btnRefreshDrives.Click
        RefreshDrives(ChkShowInternal.Checked, ChkShowUnknownDrives.Checked)
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class