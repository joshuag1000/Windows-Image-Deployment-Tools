Public Class WinPEForm
    Private Sub UseLegacyToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UseLegacyToolsToolStripMenuItem.Click
        Process.Start(AppContext.BaseDirectory + "\Resources\LegacyScripts\Entrypoint.Bat")
        Me.Close()
    End Sub

    Private Sub ShutdownWinPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownWinPEToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you would like to shutdown WinPE?", "Shutdown WinPE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            RunCmdCommandSync("wpeutil shutdown")
            Me.Close()
        End If
    End Sub

    Private Sub QuitToConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToConsoleToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you would like to close WIDT-GUI?" + vbCrLf + "To reopen the application WIDT-GUI.exe in the console." + vbCrLf + "If all you need is a console you can open one in the tools menu.", "Close WIDT-GUI?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub OpenConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenConsoleToolStripMenuItem.Click
        Process.Start("cmd", "")
    End Sub
End Class