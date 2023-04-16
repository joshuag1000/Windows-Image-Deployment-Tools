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
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        Cancel_Button = New Button()
        Label1 = New Label()
        ToolTip1 = New ToolTip(components)
        txtWinPEPath = New TextBox()
        btnBrowse = New Button()
        Label2 = New Label()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        FlowLayoutPanel2 = New FlowLayoutPanel()
        ChkOptionalComp = New CheckedListBox()
        Label4 = New Label()
        cmbLanguage = New ComboBox()
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
        TableLayoutPanel1.Location = New Point(210, 344)
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
        ' txtWinPEPath
        ' 
        txtWinPEPath.Location = New Point(3, 3)
        txtWinPEPath.Name = "txtWinPEPath"
        txtWinPEPath.Size = New Size(285, 23)
        txtWinPEPath.TabIndex = 3
        ' 
        ' btnBrowse
        ' 
        btnBrowse.Anchor = AnchorStyles.None
        btnBrowse.AutoSize = True
        btnBrowse.Location = New Point(295, 3)
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
        Label2.Location = New Point(3, 233)
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
        FlowLayoutPanel1.Location = New Point(3, 256)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(378, 33)
        FlowLayoutPanel1.TabIndex = 6
        ' 
        ' FlowLayoutPanel2
        ' 
        FlowLayoutPanel2.Controls.Add(Label1)
        FlowLayoutPanel2.Controls.Add(ChkOptionalComp)
        FlowLayoutPanel2.Controls.Add(Label4)
        FlowLayoutPanel2.Controls.Add(cmbLanguage)
        FlowLayoutPanel2.Controls.Add(Label2)
        FlowLayoutPanel2.Controls.Add(FlowLayoutPanel1)
        FlowLayoutPanel2.Controls.Add(Label3)
        FlowLayoutPanel2.Controls.Add(txtWinPEName)
        FlowLayoutPanel2.Controls.Add(TableLayoutPanel1)
        FlowLayoutPanel2.Dock = DockStyle.Fill
        FlowLayoutPanel2.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel2.Location = New Point(4, 4)
        FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        FlowLayoutPanel2.Size = New Size(384, 383)
        FlowLayoutPanel2.TabIndex = 7
        ' 
        ' ChkOptionalComp
        ' 
        ChkOptionalComp.CheckOnClick = True
        ChkOptionalComp.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkOptionalComp.FormattingEnabled = True
        ChkOptionalComp.Location = New Point(3, 23)
        ChkOptionalComp.Name = "ChkOptionalComp"
        ChkOptionalComp.ScrollAlwaysVisible = True
        ChkOptionalComp.Size = New Size(378, 158)
        ChkOptionalComp.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(3, 184)
        Label4.Name = "Label4"
        Label4.Size = New Size(200, 20)
        Label4.TabIndex = 10
        Label4.Text = "Select Language And Region"
        ' 
        ' cmbLanguage
        ' 
        cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLanguage.FormattingEnabled = True
        cmbLanguage.Location = New Point(3, 207)
        cmbLanguage.Name = "cmbLanguage"
        cmbLanguage.Size = New Size(200, 23)
        cmbLanguage.TabIndex = 11
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(3, 292)
        Label3.Name = "Label3"
        Label3.Size = New Size(174, 20)
        Label3.TabIndex = 8
        Label3.Text = "Name of WinPE Instance:"
        ' 
        ' txtWinPEName
        ' 
        txtWinPEName.Location = New Point(3, 315)
        txtWinPEName.Name = "txtWinPEName"
        txtWinPEName.PlaceholderText = "WinPE-Instance"
        txtWinPEName.Size = New Size(236, 23)
        txtWinPEName.TabIndex = 7
        ' 
        ' ConfigurePEDialog
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        CancelButton = Cancel_Button
        ClientSize = New Size(392, 391)
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
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtWinPEPath As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtWinPEName As TextBox
    Friend WithEvents ChkOptionalComp As CheckedListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbLanguage As ComboBox
End Class
