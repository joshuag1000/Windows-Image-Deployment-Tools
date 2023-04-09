Public Module SharedFunctions
    Public Function RunCmdCommand(ByVal CommandToRun As String) As Boolean
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
End Module
