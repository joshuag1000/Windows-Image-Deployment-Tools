Public Class WinPEForm
    Private Sub UseLegacyToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UseLegacyToolsToolStripMenuItem.Click
        Process.Start(AppContext.BaseDirectory + "\Resources\LegacyScripts\Entrypoint.Bat")
        Me.Close()
    End Sub
End Class