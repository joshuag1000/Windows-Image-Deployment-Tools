Public Class ProgressDialog
    Public Sub SetProgressBarAmount(ByVal newValue As Integer)
        ProgressBar1.Value = newValue
    End Sub

    Public Sub SetLabelText(ByVal newText As String)
        lblInfo.Text = newText
        txtboxInfo.AppendText(newText + vbCrLf)
    End Sub

    Public Sub SetTextboxText(ByVal newText As String)
        If txtboxInfo.Text <> "" Then
            If newText = "" And txtboxInfo.Lines(txtboxInfo.Lines.Count - 2).ToString.Contains("[=") Then Return
        End If
        txtboxInfo.AppendText(newText + vbCrLf)
    End Sub

    Private Sub ProgressDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = SystemIcons.Information.ToBitmap()
    End Sub
End Class