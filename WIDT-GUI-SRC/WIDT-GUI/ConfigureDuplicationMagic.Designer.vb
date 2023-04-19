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
        Label6 = New Label()
        Label1 = New Label()
        CmbDrives = New ComboBox()
        btnRefreshDrives = New Button()
        ChkShowInternal = New CheckBox()
        ChkShowUnknownDrives = New CheckBox()
        OK_Button = New Button()
        Cancel_Button = New Button()
        ToolTip1 = New ToolTip(components)
        FolderBrowserDialog1 = New FolderBrowserDialog()
        TableLayoutPanel2 = New TableLayoutPanel()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label6, 4)
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(373, 25)
        Label6.TabIndex = 9
        Label6.Text = "Duplicate Tools"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label1, 4)
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(3, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(373, 20)
        Label1.TabIndex = 1
        Label1.Text = "Select a USB Drive"
        ' 
        ' CmbDrives
        ' 
        TableLayoutPanel2.SetColumnSpan(CmbDrives, 3)
        CmbDrives.Dock = DockStyle.Fill
        CmbDrives.DropDownStyle = ComboBoxStyle.DropDownList
        CmbDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        CmbDrives.FormattingEnabled = True
        CmbDrives.Location = New Point(3, 48)
        CmbDrives.MaximumSize = New Size(289, 0)
        CmbDrives.MinimumSize = New Size(289, 0)
        CmbDrives.Name = "CmbDrives"
        CmbDrives.Size = New Size(289, 26)
        CmbDrives.TabIndex = 5
        ' 
        ' btnRefreshDrives
        ' 
        btnRefreshDrives.AutoSize = True
        btnRefreshDrives.Dock = DockStyle.Fill
        btnRefreshDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRefreshDrives.Location = New Point(298, 48)
        btnRefreshDrives.MaximumSize = New Size(76, 28)
        btnRefreshDrives.MinimumSize = New Size(76, 28)
        btnRefreshDrives.Name = "btnRefreshDrives"
        btnRefreshDrives.Size = New Size(76, 28)
        btnRefreshDrives.TabIndex = 6
        btnRefreshDrives.Text = "Refresh"
        btnRefreshDrives.UseVisualStyleBackColor = True
        ' 
        ' ChkShowInternal
        ' 
        ChkShowInternal.AutoSize = True
        ChkShowInternal.Dock = DockStyle.Fill
        ChkShowInternal.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowInternal.Location = New Point(3, 82)
        ChkShowInternal.MaximumSize = New Size(162, 22)
        ChkShowInternal.MinimumSize = New Size(162, 22)
        ChkShowInternal.Name = "ChkShowInternal"
        ChkShowInternal.Size = New Size(162, 22)
        ChkShowInternal.TabIndex = 7
        ChkShowInternal.Text = "Show Internal Drives"
        ChkShowInternal.UseVisualStyleBackColor = True
        ' 
        ' ChkShowUnknownDrives
        ' 
        ChkShowUnknownDrives.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(ChkShowUnknownDrives, 3)
        ChkShowUnknownDrives.Dock = DockStyle.Fill
        ChkShowUnknownDrives.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowUnknownDrives.Location = New Point(171, 82)
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
        OK_Button.Location = New Point(215, 110)
        OK_Button.Margin = New Padding(4, 3, 4, 3)
        OK_Button.MaximumSize = New Size(76, 28)
        OK_Button.MinimumSize = New Size(76, 28)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(76, 28)
        OK_Button.TabIndex = 0
        OK_Button.Text = "Go"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Dock = DockStyle.Fill
        Cancel_Button.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Cancel_Button.Location = New Point(299, 110)
        Cancel_Button.Margin = New Padding(4, 3, 4, 3)
        Cancel_Button.MaximumSize = New Size(76, 28)
        Cancel_Button.MinimumSize = New Size(76, 28)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(76, 28)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 4
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.Controls.Add(ChkShowUnknownDrives, 1, 3)
        TableLayoutPanel2.Controls.Add(ChkShowInternal, 0, 3)
        TableLayoutPanel2.Controls.Add(CmbDrives, 0, 2)
        TableLayoutPanel2.Controls.Add(Label1, 0, 1)
        TableLayoutPanel2.Controls.Add(Label6, 0, 0)
        TableLayoutPanel2.Controls.Add(Cancel_Button, 3, 4)
        TableLayoutPanel2.Controls.Add(OK_Button, 2, 4)
        TableLayoutPanel2.Controls.Add(btnRefreshDrives, 3, 2)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(4, 4)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 5
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.Size = New Size(379, 144)
        TableLayoutPanel2.TabIndex = 9
        ' 
        ' ConfigureDuplicationMagic
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(387, 152)
        Controls.Add(TableLayoutPanel2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "ConfigureDuplicationMagic"
        Padding = New Padding(4)
        StartPosition = FormStartPosition.CenterParent
        Text = "Duplicate Tools"
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents CmbDrives As ComboBox
    Friend WithEvents btnRefreshDrives As Button
    Friend WithEvents ChkShowInternal As CheckBox
    Friend WithEvents ChkShowUnknownDrives As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
