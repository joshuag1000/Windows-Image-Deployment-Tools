<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinPEForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        QuitToConsoleToolStripMenuItem = New ToolStripMenuItem()
        ShutdownWinPEToolStripMenuItem = New ToolStripMenuItem()
        ToolsToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        UseLegacyToolsToolStripMenuItem = New ToolStripMenuItem()
        OpenConsoleToolStripMenuItem = New ToolStripMenuItem()
        DuplicateWinPEUSBKeyToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, ToolsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {QuitToConsoleToolStripMenuItem, ShutdownWinPEToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' QuitToConsoleToolStripMenuItem
        ' 
        QuitToConsoleToolStripMenuItem.Name = "QuitToConsoleToolStripMenuItem"
        QuitToConsoleToolStripMenuItem.Size = New Size(165, 22)
        QuitToConsoleToolStripMenuItem.Text = "Quit to Console"
        ' 
        ' ShutdownWinPEToolStripMenuItem
        ' 
        ShutdownWinPEToolStripMenuItem.Name = "ShutdownWinPEToolStripMenuItem"
        ShutdownWinPEToolStripMenuItem.Size = New Size(165, 22)
        ShutdownWinPEToolStripMenuItem.Text = "Shutdown WinPE"
        ' 
        ' ToolsToolStripMenuItem
        ' 
        ToolsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripSeparator1, UseLegacyToolsToolStripMenuItem, OpenConsoleToolStripMenuItem, DuplicateWinPEUSBKeyToolStripMenuItem})
        ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        ToolsToolStripMenuItem.Size = New Size(46, 20)
        ToolsToolStripMenuItem.Text = "Tools"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(204, 6)
        ' 
        ' UseLegacyToolsToolStripMenuItem
        ' 
        UseLegacyToolsToolStripMenuItem.Name = "UseLegacyToolsToolStripMenuItem"
        UseLegacyToolsToolStripMenuItem.Size = New Size(207, 22)
        UseLegacyToolsToolStripMenuItem.Text = "Use Legacy Tools"
        ' 
        ' OpenConsoleToolStripMenuItem
        ' 
        OpenConsoleToolStripMenuItem.Name = "OpenConsoleToolStripMenuItem"
        OpenConsoleToolStripMenuItem.Size = New Size(207, 22)
        OpenConsoleToolStripMenuItem.Text = "Open Console"
        ' 
        ' DuplicateWinPEUSBKeyToolStripMenuItem
        ' 
        DuplicateWinPEUSBKeyToolStripMenuItem.Enabled = False
        DuplicateWinPEUSBKeyToolStripMenuItem.Name = "DuplicateWinPEUSBKeyToolStripMenuItem"
        DuplicateWinPEUSBKeyToolStripMenuItem.Size = New Size(207, 22)
        DuplicateWinPEUSBKeyToolStripMenuItem.Text = "Duplicate WinPE USB Key"
        ' 
        ' WinPEForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "WinPEForm"
        Text = "WinPEForm"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents UseLegacyToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitToConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShutdownWinPEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DuplicateWinPEUSBKeyToolStripMenuItem As ToolStripMenuItem
End Class
