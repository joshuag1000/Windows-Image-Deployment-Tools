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
        OK_Button = New Button()
        Cancel_Button = New Button()
        Label1 = New Label()
        ToolTip1 = New ToolTip(components)
        txtWinPEPath = New TextBox()
        btnBrowse = New Button()
        Label2 = New Label()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        ChkOptionalComp = New CheckedListBox()
        ChkIncludeDrivers = New CheckBox()
        Label5 = New Label()
        txtWinPEDrivers = New TextBox()
        btnSelectDriversDir = New Button()
        Label4 = New Label()
        cmbLanguage = New ComboBox()
        Label3 = New Label()
        txtWinPEName = New TextBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' OK_Button
        ' 
        OK_Button.Dock = DockStyle.Fill
        OK_Button.Location = New Point(233, 426)
        OK_Button.Margin = New Padding(4, 3, 4, 3)
        OK_Button.MaximumSize = New Size(77, 27)
        OK_Button.MinimumSize = New Size(77, 27)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(77, 27)
        OK_Button.TabIndex = 0
        OK_Button.Text = "Go"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Dock = DockStyle.Fill
        Cancel_Button.Location = New Point(318, 426)
        Cancel_Button.Margin = New Padding(4, 3, 4, 3)
        Cancel_Button.MaximumSize = New Size(77, 27)
        Cancel_Button.MinimumSize = New Size(77, 27)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(77, 27)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label1, 4)
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(393, 20)
        Label1.TabIndex = 1
        Label1.Text = "Select Optional Components:"
        ' 
        ' txtWinPEPath
        ' 
        TableLayoutPanel2.SetColumnSpan(txtWinPEPath, 3)
        txtWinPEPath.Dock = DockStyle.Fill
        txtWinPEPath.Location = New Point(3, 344)
        txtWinPEPath.Name = "txtWinPEPath"
        txtWinPEPath.Size = New Size(308, 23)
        txtWinPEPath.TabIndex = 3
        ' 
        ' btnBrowse
        ' 
        btnBrowse.AutoSize = True
        btnBrowse.Dock = DockStyle.Fill
        btnBrowse.Location = New Point(318, 344)
        btnBrowse.Margin = New Padding(4, 3, 4, 3)
        btnBrowse.MaximumSize = New Size(77, 27)
        btnBrowse.MinimumSize = New Size(77, 27)
        btnBrowse.Name = "btnBrowse"
        btnBrowse.Size = New Size(77, 27)
        btnBrowse.TabIndex = 4
        btnBrowse.Text = "Browse"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label2, 4)
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(3, 321)
        Label2.Name = "Label2"
        Label2.Size = New Size(393, 20)
        Label2.TabIndex = 5
        Label2.Text = "Select a destination. (Default is recommended)"
        ' 
        ' ChkOptionalComp
        ' 
        ChkOptionalComp.CheckOnClick = True
        TableLayoutPanel2.SetColumnSpan(ChkOptionalComp, 4)
        ChkOptionalComp.Dock = DockStyle.Fill
        ChkOptionalComp.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkOptionalComp.FormattingEnabled = True
        ChkOptionalComp.Location = New Point(3, 23)
        ChkOptionalComp.Name = "ChkOptionalComp"
        ChkOptionalComp.ScrollAlwaysVisible = True
        ChkOptionalComp.Size = New Size(393, 163)
        ChkOptionalComp.TabIndex = 9
        ' 
        ' ChkIncludeDrivers
        ' 
        ChkIncludeDrivers.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(ChkIncludeDrivers, 4)
        ChkIncludeDrivers.Dock = DockStyle.Fill
        ChkIncludeDrivers.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkIncludeDrivers.Location = New Point(3, 192)
        ChkIncludeDrivers.Name = "ChkIncludeDrivers"
        ChkIncludeDrivers.Size = New Size(393, 24)
        ChkIncludeDrivers.TabIndex = 14
        ChkIncludeDrivers.Text = "Inlcude WinPE Drivers?"
        ChkIncludeDrivers.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label5, 4)
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(3, 219)
        Label5.Name = "Label5"
        Label5.Size = New Size(393, 20)
        Label5.TabIndex = 12
        Label5.Text = "Select Folders Containing WinPE Drivers"
        ' 
        ' txtWinPEDrivers
        ' 
        TableLayoutPanel2.SetColumnSpan(txtWinPEDrivers, 3)
        txtWinPEDrivers.Dock = DockStyle.Fill
        txtWinPEDrivers.Location = New Point(3, 242)
        txtWinPEDrivers.Name = "txtWinPEDrivers"
        txtWinPEDrivers.Size = New Size(308, 23)
        txtWinPEDrivers.TabIndex = 3
        ' 
        ' btnSelectDriversDir
        ' 
        btnSelectDriversDir.AutoSize = True
        btnSelectDriversDir.Dock = DockStyle.Fill
        btnSelectDriversDir.Location = New Point(318, 242)
        btnSelectDriversDir.Margin = New Padding(4, 3, 4, 3)
        btnSelectDriversDir.MaximumSize = New Size(77, 27)
        btnSelectDriversDir.MinimumSize = New Size(77, 27)
        btnSelectDriversDir.Name = "btnSelectDriversDir"
        btnSelectDriversDir.Size = New Size(77, 27)
        btnSelectDriversDir.TabIndex = 4
        btnSelectDriversDir.Text = "Browse"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label4, 4)
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(3, 272)
        Label4.Name = "Label4"
        Label4.Size = New Size(393, 20)
        Label4.TabIndex = 10
        Label4.Text = "Select Language And Region"
        ' 
        ' cmbLanguage
        ' 
        TableLayoutPanel2.SetColumnSpan(cmbLanguage, 3)
        cmbLanguage.Dock = DockStyle.Fill
        cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLanguage.FormattingEnabled = True
        cmbLanguage.Location = New Point(3, 295)
        cmbLanguage.Name = "cmbLanguage"
        cmbLanguage.Size = New Size(308, 23)
        cmbLanguage.TabIndex = 11
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        TableLayoutPanel2.SetColumnSpan(Label3, 4)
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(3, 374)
        Label3.Name = "Label3"
        Label3.Size = New Size(393, 20)
        Label3.TabIndex = 8
        Label3.Text = "Name of WinPE Instance:"
        ' 
        ' txtWinPEName
        ' 
        TableLayoutPanel2.SetColumnSpan(txtWinPEName, 3)
        txtWinPEName.Dock = DockStyle.Fill
        txtWinPEName.Location = New Point(3, 397)
        txtWinPEName.Name = "txtWinPEName"
        txtWinPEName.PlaceholderText = "WinPE-Instance"
        txtWinPEName.Size = New Size(308, 23)
        txtWinPEName.TabIndex = 7
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 4
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.Controls.Add(Cancel_Button, 3, 11)
        TableLayoutPanel2.Controls.Add(OK_Button, 2, 11)
        TableLayoutPanel2.Controls.Add(btnBrowse, 3, 8)
        TableLayoutPanel2.Controls.Add(txtWinPEPath, 0, 8)
        TableLayoutPanel2.Controls.Add(txtWinPEName, 0, 10)
        TableLayoutPanel2.Controls.Add(Label3, 0, 9)
        TableLayoutPanel2.Controls.Add(btnSelectDriversDir, 3, 4)
        TableLayoutPanel2.Controls.Add(Label2, 0, 7)
        TableLayoutPanel2.Controls.Add(cmbLanguage, 0, 6)
        TableLayoutPanel2.Controls.Add(Label4, 0, 5)
        TableLayoutPanel2.Controls.Add(txtWinPEDrivers, 0, 4)
        TableLayoutPanel2.Controls.Add(Label5, 0, 3)
        TableLayoutPanel2.Controls.Add(ChkIncludeDrivers, 0, 2)
        TableLayoutPanel2.Controls.Add(ChkOptionalComp, 0, 1)
        TableLayoutPanel2.Controls.Add(Label1, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(4, 4)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 12
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.Size = New Size(399, 456)
        TableLayoutPanel2.TabIndex = 8
        ' 
        ' ConfigurePEDialog
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        CancelButton = Cancel_Button
        ClientSize = New Size(407, 464)
        Controls.Add(TableLayoutPanel2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ConfigurePEDialog"
        Padding = New Padding(4)
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Configure WinPE"
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtWinPEPath As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents txtWinPEName As TextBox
    Friend WithEvents ChkOptionalComp As CheckedListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbLanguage As ComboBox
    Friend WithEvents ChkIncludeDrivers As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtWinPEDrivers As TextBox
    Friend WithEvents btnSelectDriversDir As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
