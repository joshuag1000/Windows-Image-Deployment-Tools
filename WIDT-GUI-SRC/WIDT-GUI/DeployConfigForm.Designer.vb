<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeployConfigForm
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
        components = New ComponentModel.Container()
        Label6 = New Label()
        Label1 = New Label()
        CmbDrives = New ComboBox()
        btnRefreshDrives = New Button()
        ChkShowRemovable = New CheckBox()
        ChkShowUnknownDrives = New CheckBox()
        OK_Button = New Button()
        ToolTip1 = New ToolTip(components)
        FolderBrowserDialog1 = New FolderBrowserDialog()
        TableLayoutPanel2 = New TableLayoutPanel()
        MenuStrip1 = New MenuStrip()
        ToolsOptionsToolStripMenuItem = New ToolStripMenuItem()
        OpenConfigurationWindowToolStripMenuItem = New ToolStripMenuItem()
        ShowConsoleToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        QuitWIDTToolStripMenuItem = New ToolStripMenuItem()
        ShutdownWinPEToolStripMenuItem = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel2.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label6, 4)
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 24)
        Label6.Name = "Label6"
        Label6.Size = New Size(405, 25)
        Label6.TabIndex = 9
        Label6.Text = "Install Configuration to Disk"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label1, 4)
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(3, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(405, 20)
        Label1.TabIndex = 1
        Label1.Text = "Select a Drive"
        ' 
        ' CmbDrives
        ' 
        TableLayoutPanel2.SetColumnSpan(CmbDrives, 3)
        CmbDrives.Dock = DockStyle.Fill
        CmbDrives.DropDownStyle = ComboBoxStyle.DropDownList
        CmbDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        CmbDrives.FormattingEnabled = True
        CmbDrives.Location = New Point(3, 72)
        CmbDrives.MinimumSize = New Size(289, 0)
        CmbDrives.Name = "CmbDrives"
        CmbDrives.Size = New Size(320, 26)
        CmbDrives.TabIndex = 5
        ' 
        ' btnRefreshDrives
        ' 
        btnRefreshDrives.AutoSize = True
        btnRefreshDrives.Dock = DockStyle.Fill
        btnRefreshDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRefreshDrives.Location = New Point(329, 72)
        btnRefreshDrives.MaximumSize = New Size(76, 28)
        btnRefreshDrives.MinimumSize = New Size(76, 28)
        btnRefreshDrives.Name = "btnRefreshDrives"
        btnRefreshDrives.Size = New Size(76, 28)
        btnRefreshDrives.TabIndex = 6
        btnRefreshDrives.Text = "Refresh"
        btnRefreshDrives.UseVisualStyleBackColor = True
        ' 
        ' ChkShowRemovable
        ' 
        ChkShowRemovable.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(ChkShowRemovable, 2)
        ChkShowRemovable.Dock = DockStyle.Fill
        ChkShowRemovable.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowRemovable.Location = New Point(3, 106)
        ChkShowRemovable.MaximumSize = New Size(0, 22)
        ChkShowRemovable.MinimumSize = New Size(162, 22)
        ChkShowRemovable.Name = "ChkShowRemovable"
        ChkShowRemovable.Size = New Size(206, 22)
        ChkShowRemovable.TabIndex = 7
        ChkShowRemovable.Text = "Show Removable Drives"
        ChkShowRemovable.UseVisualStyleBackColor = True
        ' 
        ' ChkShowUnknownDrives
        ' 
        ChkShowUnknownDrives.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(ChkShowUnknownDrives, 2)
        ChkShowUnknownDrives.Dock = DockStyle.Fill
        ChkShowUnknownDrives.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowUnknownDrives.Location = New Point(215, 106)
        ChkShowUnknownDrives.MaximumSize = New Size(174, 22)
        ChkShowUnknownDrives.MinimumSize = New Size(174, 22)
        ChkShowUnknownDrives.Name = "ChkShowUnknownDrives"
        ChkShowUnknownDrives.Size = New Size(174, 22)
        ChkShowUnknownDrives.TabIndex = 8
        ChkShowUnknownDrives.Text = "Show Unknown Drives"
        ChkShowUnknownDrives.UseVisualStyleBackColor = True
        ' 
        ' OK_Button
        ' 
        OK_Button.Dock = DockStyle.Fill
        OK_Button.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        OK_Button.Location = New Point(330, 134)
        OK_Button.Margin = New Padding(4, 3, 4, 3)
        OK_Button.MaximumSize = New Size(76, 28)
        OK_Button.MinimumSize = New Size(76, 28)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(76, 28)
        OK_Button.TabIndex = 0
        OK_Button.Text = "Go"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 4
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.Controls.Add(ChkShowUnknownDrives, 2, 4)
        TableLayoutPanel2.Controls.Add(ChkShowRemovable, 0, 4)
        TableLayoutPanel2.Controls.Add(CmbDrives, 0, 3)
        TableLayoutPanel2.Controls.Add(Label1, 0, 2)
        TableLayoutPanel2.Controls.Add(Label6, 0, 1)
        TableLayoutPanel2.Controls.Add(btnRefreshDrives, 3, 3)
        TableLayoutPanel2.Controls.Add(MenuStrip1, 0, 0)
        TableLayoutPanel2.Controls.Add(OK_Button, 3, 5)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(4, 4)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 6
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.Size = New Size(411, 166)
        TableLayoutPanel2.TabIndex = 9
        ' 
        ' MenuStrip1
        ' 
        TableLayoutPanel2.SetColumnSpan(MenuStrip1, 4)
        MenuStrip1.Items.AddRange(New ToolStripItem() {ToolsOptionsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(411, 24)
        MenuStrip1.TabIndex = 10
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ToolsOptionsToolStripMenuItem
        ' 
        ToolsOptionsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OpenConfigurationWindowToolStripMenuItem, ShowConsoleToolStripMenuItem, ToolStripSeparator1, AboutToolStripMenuItem, QuitWIDTToolStripMenuItem, ShutdownWinPEToolStripMenuItem})
        ToolsOptionsToolStripMenuItem.Name = "ToolsOptionsToolStripMenuItem"
        ToolsOptionsToolStripMenuItem.Size = New Size(99, 20)
        ToolsOptionsToolStripMenuItem.Text = "Tools / Options"
        ' 
        ' OpenConfigurationWindowToolStripMenuItem
        ' 
        OpenConfigurationWindowToolStripMenuItem.Name = "OpenConfigurationWindowToolStripMenuItem"
        OpenConfigurationWindowToolStripMenuItem.Size = New Size(227, 22)
        OpenConfigurationWindowToolStripMenuItem.Text = "Open Configuration Window"
        ' 
        ' ShowConsoleToolStripMenuItem
        ' 
        ShowConsoleToolStripMenuItem.Name = "ShowConsoleToolStripMenuItem"
        ShowConsoleToolStripMenuItem.Size = New Size(227, 22)
        ShowConsoleToolStripMenuItem.Text = "Show Console"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(224, 6)
        ' 
        ' QuitWIDTToolStripMenuItem
        ' 
        QuitWIDTToolStripMenuItem.Name = "QuitWIDTToolStripMenuItem"
        QuitWIDTToolStripMenuItem.Size = New Size(227, 22)
        QuitWIDTToolStripMenuItem.Text = "Quit WIDT"
        ' 
        ' ShutdownWinPEToolStripMenuItem
        ' 
        ShutdownWinPEToolStripMenuItem.Name = "ShutdownWinPEToolStripMenuItem"
        ShutdownWinPEToolStripMenuItem.Size = New Size(227, 22)
        ShutdownWinPEToolStripMenuItem.Text = "Shutdown WinPE"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(227, 22)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' DeployConfigForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(419, 174)
        Controls.Add(TableLayoutPanel2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MainMenuStrip = MenuStrip1
        MaximizeBox = False
        MinimizeBox = False
        Name = "DeployConfigForm"
        Padding = New Padding(4)
        StartPosition = FormStartPosition.CenterScreen
        Text = "WIDT - Install Configuration to Disk"
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents OK_Button As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents CmbDrives As ComboBox
    Friend WithEvents btnRefreshDrives As Button
    Friend WithEvents ChkShowRemovable As CheckBox
    Friend WithEvents ChkShowUnknownDrives As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolsOptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenConfigurationWindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents QuitWIDTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShutdownWinPEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
