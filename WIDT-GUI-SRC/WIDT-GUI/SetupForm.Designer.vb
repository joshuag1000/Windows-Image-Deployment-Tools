<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetupForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        QuitToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel1 = New TableLayoutPanel()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Label1 = New Label()
        Label2 = New Label()
        FlowLayoutPanel3 = New FlowLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Label3 = New Label()
        FlowLayoutPanel2 = New FlowLayoutPanel()
        Label4 = New Label()
        FlowLayoutPanel4 = New FlowLayoutPanel()
        ChkWinPEStatus = New CheckBox()
        btnWinPESetup = New Button()
        Button1 = New Button()
        MenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        FlowLayoutPanel2.SuspendLayout()
        FlowLayoutPanel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripSeparator1, QuitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(136, 6)
        ' 
        ' QuitToolStripMenuItem
        ' 
        QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        QuitToolStripMenuItem.ShortcutKeys = Keys.Alt Or Keys.F4
        QuitToolStripMenuItem.Size = New Size(139, 22)
        QuitToolStripMenuItem.Text = "Quit"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(FlowLayoutPanel1, 0, 0)
        TableLayoutPanel1.Controls.Add(FlowLayoutPanel3, 1, 1)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 24)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 62F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(800, 426)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(Label1)
        FlowLayoutPanel1.Controls.Add(Label2)
        FlowLayoutPanel1.Dock = DockStyle.Fill
        FlowLayoutPanel1.Location = New Point(3, 3)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(394, 56)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(355, 30)
        Label1.TabIndex = 1
        Label1.Text = "Windows Image Deployment Tools"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(3, 30)
        Label2.Name = "Label2"
        Label2.Size = New Size(225, 21)
        Label2.TabIndex = 2
        Label2.Text = "Setup and Configuration Utility"
        ' 
        ' FlowLayoutPanel3
        ' 
        FlowLayoutPanel3.Dock = DockStyle.Fill
        FlowLayoutPanel3.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel3.Location = New Point(403, 65)
        FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        FlowLayoutPanel3.Size = New Size(394, 358)
        FlowLayoutPanel3.TabIndex = 2
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(Label3, 0, 0)
        TableLayoutPanel2.Controls.Add(FlowLayoutPanel2, 0, 1)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 65)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(394, 358)
        TableLayoutPanel2.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(3, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(209, 21)
        Label3.TabIndex = 1
        Label3.Text = "Install WIDT To USB or ISO"
        ' 
        ' FlowLayoutPanel2
        ' 
        FlowLayoutPanel2.Controls.Add(Label4)
        FlowLayoutPanel2.Controls.Add(FlowLayoutPanel4)
        FlowLayoutPanel2.Dock = DockStyle.Fill
        FlowLayoutPanel2.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel2.Location = New Point(3, 25)
        FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        FlowLayoutPanel2.Size = New Size(388, 330)
        FlowLayoutPanel2.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(3, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(98, 20)
        Label4.TabIndex = 0
        Label4.Text = "WinPE Status:"
        ' 
        ' FlowLayoutPanel4
        ' 
        FlowLayoutPanel4.AutoSize = True
        FlowLayoutPanel4.Controls.Add(ChkWinPEStatus)
        FlowLayoutPanel4.Controls.Add(btnWinPESetup)
        FlowLayoutPanel4.Controls.Add(Button1)
        FlowLayoutPanel4.Dock = DockStyle.Top
        FlowLayoutPanel4.Location = New Point(3, 23)
        FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        FlowLayoutPanel4.Size = New Size(266, 30)
        FlowLayoutPanel4.TabIndex = 3
        ' 
        ' ChkWinPEStatus
        ' 
        ChkWinPEStatus.AutoCheck = False
        ChkWinPEStatus.AutoSize = True
        ChkWinPEStatus.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkWinPEStatus.Location = New Point(3, 3)
        ChkWinPEStatus.Name = "ChkWinPEStatus"
        ChkWinPEStatus.Size = New Size(98, 24)
        ChkWinPEStatus.TabIndex = 2
        ChkWinPEStatus.Text = "Not Found"
        ChkWinPEStatus.UseVisualStyleBackColor = True
        ' 
        ' btnWinPESetup
        ' 
        btnWinPESetup.Location = New Point(107, 3)
        btnWinPESetup.Name = "btnWinPESetup"
        btnWinPESetup.Size = New Size(75, 23)
        btnWinPESetup.TabIndex = 3
        btnWinPESetup.Text = "Setup"
        btnWinPESetup.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(188, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 4
        Button1.Text = "Locate..."
        Button1.UseVisualStyleBackColor = True
        ' 
        ' StartForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "StartForm"
        Text = "Setup - Windows Image Deployment Tools"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        FlowLayoutPanel2.ResumeLayout(False)
        FlowLayoutPanel2.PerformLayout()
        FlowLayoutPanel4.ResumeLayout(False)
        FlowLayoutPanel4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents ChkWinPEStatus As CheckBox
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents btnWinPESetup As Button
    Friend WithEvents Button1 As Button
End Class
