Imports System.IO
Imports System.Windows.Forms

Public Class ConfigurePEDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtWinPEPath.Text = "" Then
            MessageBox.Show("Please specify a location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf If(txtWinPEPath.Text.Chars(txtWinPEPath.Text.Length - 1) = "\", txtWinPEPath.Text, txtWinPEPath.Text + "\") = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory, AppContext.BaseDirectory + "\") Then
            MessageBox.Show("WinPE cannot be inside the same folder as the tools.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim WinPEPath As DialogResult = FolderBrowserDialog1.ShowDialog
        If WinPEPath = DialogResult.OK Then
            txtWinPEPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ConfigurePEDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtWinPEPath.Text = Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).ToString).ToString
        FolderBrowserDialog1.InitialDirectory = Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).ToString).ToString
    End Sub
End Class
