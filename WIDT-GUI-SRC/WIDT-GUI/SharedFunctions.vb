Public Module SharedFunctions
    Public Function RunCmdCommand(ByVal CommandToRun As String, ByVal Info As IProgress(Of String)) As Boolean
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
        CopyPEProc.StartInfo.RedirectStandardInput = True
        CopyPEProc.StartInfo.RedirectStandardError = True
        CopyPEProc.StartInfo.RedirectStandardOutput = True
        CopyPEProc.Start() ' Start the process
        AddHandler CopyPEProc.ErrorDataReceived, Sub(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
                                                     Info.Report(If(e.Data Is Nothing, "", e.Data.ToString))
                                                 End Sub
        AddHandler CopyPEProc.OutputDataReceived, Sub(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
                                                      Info.Report(If(e.Data Is Nothing, "", e.Data.ToString))
                                                  End Sub
        CopyPEProc.BeginErrorReadLine()
        CopyPEProc.BeginOutputReadLine()
        CopyPEProc.WaitForExit()
        ' Check for errors
        If CopyPEProc.ExitCode <> 0 Then
            MessageBox.Show("An Unexpected error occured. Would you like to view the log", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        Return False
    End Function
End Module
