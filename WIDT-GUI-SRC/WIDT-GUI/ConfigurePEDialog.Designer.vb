<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigurePEDialog
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(ConfigurePEDialog))
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        Cancel_Button = New Button()
        Label1 = New Label()
        chkDupMagic = New CheckBox()
        ToolTip1 = New ToolTip(components)
        txtWinPEPath = New TextBox()
        btnBrowse = New Button()
        Label2 = New Label()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        FlowLayoutPanel2 = New FlowLayoutPanel()
        Label3 = New Label()
        txtWinPEName = New TextBox()
        TableLayoutPanel1.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        FlowLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel1.AutoSize = True
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0)
        TableLayoutPanel1.Location = New Point(159, 158)
        TableLayoutPanel1.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(170, 33)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' OK_Button
        ' 
        OK_Button.Anchor = AnchorStyles.None
        OK_Button.Location = New Point(4, 3)
        OK_Button.Margin = New Padding(4, 3, 4, 3)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(77, 27)
        OK_Button.TabIndex = 0
        OK_Button.Text = "Go"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = AnchorStyles.None
        Cancel_Button.Location = New Point(89, 3)
        Cancel_Button.Margin = New Padding(4, 3, 4, 3)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(77, 27)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(294, 20)
        Label1.TabIndex = 1
        Label1.Text = "Hover over an option for more information"
        ' 
        ' chkDupMagic
        ' 
        chkDupMagic.AutoSize = True
        chkDupMagic.Checked = True
        chkDupMagic.CheckState = CheckState.Checked
        chkDupMagic.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        chkDupMagic.Location = New Point(3, 23)
        chkDupMagic.Name = "chkDupMagic"
        chkDupMagic.Size = New Size(202, 24)
        chkDupMagic.TabIndex = 2
        chkDupMagic.Text = "Include Duplication Magic"
        ToolTip1.SetToolTip(chkDupMagic, resources.GetString("chkDupMagic.ToolTip"))
        chkDupMagic.UseVisualStyleBackColor = True
        ' 
        ' txtWinPEPath
        ' 
        txtWinPEPath.Location = New Point(3, 3)
        txtWinPEPath.Name = "txtWinPEPath"
        txtWinPEPath.Size = New Size(236, 23)
        txtWinPEPath.TabIndex = 3
        ' 
        ' btnBrowse
        ' 
        btnBrowse.Anchor = AnchorStyles.None
        btnBrowse.AutoSize = True
        btnBrowse.Location = New Point(246, 3)
        btnBrowse.Margin = New Padding(4, 3, 4, 3)
        btnBrowse.Name = "btnBrowse"
        btnBrowse.Size = New Size(77, 27)
        btnBrowse.TabIndex = 4
        btnBrowse.Text = "Browse"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(3, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(320, 20)
        Label2.TabIndex = 5
        Label2.Text = "Select a destination. (Default is recommended)"
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.Controls.Add(txtWinPEPath)
        FlowLayoutPanel1.Controls.Add(btnBrowse)
        FlowLayoutPanel1.Dock = DockStyle.Top
        FlowLayoutPanel1.Location = New Point(3, 73)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(327, 33)
        FlowLayoutPanel1.TabIndex = 6
        ' 
        ' FlowLayoutPanel2
        ' 
        FlowLayoutPanel2.Controls.Add(Label1)
        FlowLayoutPanel2.Controls.Add(chkDupMagic)
        FlowLayoutPanel2.Controls.Add(Label2)
        FlowLayoutPanel2.Controls.Add(FlowLayoutPanel1)
        FlowLayoutPanel2.Controls.Add(Label3)
        FlowLayoutPanel2.Controls.Add(txtWinPEName)
        FlowLayoutPanel2.Controls.Add(TableLayoutPanel1)
        FlowLayoutPanel2.Dock = DockStyle.Fill
        FlowLayoutPanel2.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel2.Location = New Point(4, 4)
        FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        FlowLayoutPanel2.Size = New Size(333, 194)
        FlowLayoutPanel2.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(3, 109)
        Label3.Name = "Label3"
        Label3.Size = New Size(153, 17)
        Label3.TabIndex = 8
        Label3.Text = "Name of WinPE Instance:"
        ' 
        ' txtWinPEName
        ' 
        txtWinPEName.Location = New Point(3, 129)
        txtWinPEName.Name = "txtWinPEName"
        txtWinPEName.PlaceholderText = "WinPE-Instance"
        txtWinPEName.Size = New Size(236, 23)
        txtWinPEName.TabIndex = 7
        ' 
        ' ConfigurePEDialog
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(341, 202)
        Controls.Add(FlowLayoutPanel2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ConfigurePEDialog"
        Padding = New Padding(4)
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Configure WinPE"
        TableLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        FlowLayoutPanel2.ResumeLayout(False)
        FlowLayoutPanel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents chkDupMagic As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtWinPEPath As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtWinPEName As TextBox
End Class
