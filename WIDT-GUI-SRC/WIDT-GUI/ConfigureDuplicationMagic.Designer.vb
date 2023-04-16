<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigureDuplicationMagic
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
        FlowLayoutPanel2 = New FlowLayoutPanel()
        Label6 = New Label()
        Label1 = New Label()
        FlowLayoutPanel6 = New FlowLayoutPanel()
        CmbDrives = New ComboBox()
        btnRefreshDrives = New Button()
        FlowLayoutPanel7 = New FlowLayoutPanel()
        ChkShowInternal = New CheckBox()
        ChkShowUnknownDrives = New CheckBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        Cancel_Button = New Button()
        ToolTip1 = New ToolTip(components)
        FolderBrowserDialog1 = New FolderBrowserDialog()
        FlowLayoutPanel2.SuspendLayout()
        FlowLayoutPanel6.SuspendLayout()
        FlowLayoutPanel7.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' FlowLayoutPanel2
        ' 
        FlowLayoutPanel2.Controls.Add(Label6)
        FlowLayoutPanel2.Controls.Add(Label1)
        FlowLayoutPanel2.Controls.Add(FlowLayoutPanel6)
        FlowLayoutPanel2.Controls.Add(TableLayoutPanel1)
        FlowLayoutPanel2.Dock = DockStyle.Fill
        FlowLayoutPanel2.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel2.Location = New Point(4, 4)
        FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        FlowLayoutPanel2.Size = New Size(377, 160)
        FlowLayoutPanel2.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(147, 25)
        Label6.TabIndex = 9
        Label6.Text = "Duplicate Tools"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(3, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(131, 20)
        Label1.TabIndex = 1
        Label1.Text = "Select a USB Drive"
        ' 
        ' FlowLayoutPanel6
        ' 
        FlowLayoutPanel6.AutoSize = True
        FlowLayoutPanel6.Controls.Add(CmbDrives)
        FlowLayoutPanel6.Controls.Add(btnRefreshDrives)
        FlowLayoutPanel6.Controls.Add(FlowLayoutPanel7)
        FlowLayoutPanel6.Location = New Point(3, 48)
        FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        FlowLayoutPanel6.Size = New Size(371, 70)
        FlowLayoutPanel6.TabIndex = 9
        ' 
        ' CmbDrives
        ' 
        CmbDrives.DropDownStyle = ComboBoxStyle.DropDownList
        CmbDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        CmbDrives.FormattingEnabled = True
        CmbDrives.Location = New Point(3, 3)
        CmbDrives.Name = "CmbDrives"
        CmbDrives.Size = New Size(289, 26)
        CmbDrives.TabIndex = 5
        ' 
        ' btnRefreshDrives
        ' 
        btnRefreshDrives.AutoSize = True
        btnRefreshDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRefreshDrives.Location = New Point(298, 3)
        btnRefreshDrives.Name = "btnRefreshDrives"
        btnRefreshDrives.Size = New Size(70, 28)
        btnRefreshDrives.TabIndex = 6
        btnRefreshDrives.Text = "Refresh"
        btnRefreshDrives.UseVisualStyleBackColor = True
        ' 
        ' FlowLayoutPanel7
        ' 
        FlowLayoutPanel7.AutoSize = True
        FlowLayoutPanel7.Controls.Add(ChkShowInternal)
        FlowLayoutPanel7.Controls.Add(ChkShowUnknownDrives)
        FlowLayoutPanel7.Location = New Point(3, 37)
        FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        FlowLayoutPanel7.Size = New Size(348, 30)
        FlowLayoutPanel7.TabIndex = 8
        ' 
        ' ChkShowInternal
        ' 
        ChkShowInternal.AutoSize = True
        ChkShowInternal.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowInternal.Location = New Point(3, 3)
        ChkShowInternal.Name = "ChkShowInternal"
        ChkShowInternal.Size = New Size(162, 22)
        ChkShowInternal.TabIndex = 7
        ChkShowInternal.Text = "Show Internal Drives"
        ChkShowInternal.UseVisualStyleBackColor = True
        ' 
        ' ChkShowUnknownDrives
        ' 
        ChkShowUnknownDrives.AutoSize = True
        ChkShowUnknownDrives.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowUnknownDrives.Location = New Point(171, 3)
        ChkShowUnknownDrives.Name = "ChkShowUnknownDrives"
        ChkShowUnknownDrives.Size = New Size(174, 24)
        ChkShowUnknownDrives.TabIndex = 8
        ChkShowUnknownDrives.Text = "Show Unknown Drives"
        ChkShowUnknownDrives.UseVisualStyleBackColor = True
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
        TableLayoutPanel1.Location = New Point(203, 124)
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
        ' ConfigureDuplicationMagic
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        ClientSize = New Size(385, 168)
        Controls.Add(FlowLayoutPanel2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "ConfigureDuplicationMagic"
        Padding = New Padding(4)
        StartPosition = FormStartPosition.CenterParent
        Text = "ConfigureDuplicationMagic"
        FlowLayoutPanel2.ResumeLayout(False)
        FlowLayoutPanel2.PerformLayout()
        FlowLayoutPanel6.ResumeLayout(False)
        FlowLayoutPanel6.PerformLayout()
        FlowLayoutPanel7.ResumeLayout(False)
        FlowLayoutPanel7.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FlowLayoutPanel6 As FlowLayoutPanel
    Friend WithEvents CmbDrives As ComboBox
    Friend WithEvents btnRefreshDrives As Button
    Friend WithEvents FlowLayoutPanel7 As FlowLayoutPanel
    Friend WithEvents ChkShowInternal As CheckBox
    Friend WithEvents ChkShowUnknownDrives As CheckBox
    Friend WithEvents Label6 As Label
End Class
