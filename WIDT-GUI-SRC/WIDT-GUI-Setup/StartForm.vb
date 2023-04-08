Imports System.IO.DriveInfo
Imports System.IO
Public Class StartForm

    Dim WinPEPath As String = ""

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnWinPESetup_Click(sender As Object, e As EventArgs) Handles btnWinPESetup.Click
        Dim ConfigureDialog As DialogResult = ConfigurePEDialog.ShowDialog()
        If ConfigureDialog = DialogResult.OK Then
            WinPEPath = ConfigurePEDialog.txtWinPEPath.Text + "\WIDT_WinPE_amd64"
            Dim IncludeDuplicateMagic As Boolean = ConfigurePEDialog.chkDupMagic.Checked
            ConfigurePEDialog.Close()
            ProgressDialog.Show()
            Dim ADKCommandLine As String = "call ""C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\DandISetEnv.bat"" && "

            ' check if folder exists and delete it if ok
            If Directory.Exists(WinPEPath) Then
                If MessageBox.Show("The folder WIDT_WinPE_amd64 already exists in the folder you selected. Is it ok if it is deleted?", "Folder Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Directory.Delete(WinPEPath, True)
                End If
            End If

            ' CopyPE Command - Setup the command to run
            ProgressDialog.SetLabelText("Copying WinPE to directory.")
            If RunCmdCommand(ADKCommandLine + "call copype amd64 """ + WinPEPath + """") Then Return
            ProgressDialog.SetProgressBarAmount(10)


            ProgressDialog.Close()
        End If
    End Sub

    Private Function RunCmdCommand(ByVal CommandToRun As String) As Boolean
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
        Dim CmdCopyPEresult As String = CopyPEProc.StandardOutput.ReadToEnd()
        ' Check for errors
        If CopyPEProc.ExitCode <> 0 Then
            Dim errorMessageresult As DialogResult = MessageBox.Show("An Unexpected error occured. Would you like to view the log", "Unexpected Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If errorMessageresult = DialogResult.Yes Then
                MessageBox.Show(CmdCopyPEresult, "Error Log", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return True
        End If
        Return False
    End Function

End Class
