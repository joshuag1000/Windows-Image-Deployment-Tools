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
        components = New ComponentModel.Container()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        AboutWIDTGUIToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        QuitToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel1 = New TableLayoutPanel()
        FlowLayoutPanel3 = New FlowLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        FlowLayoutPanel5 = New FlowLayoutPanel()
        btnCreateUSB = New Button()
        btnCreateISO = New Button()
        Label5 = New Label()
        FlowLayoutPanel4 = New FlowLayoutPanel()
        ChkWinPEStatus = New CheckBox()
        Label4 = New Label()
        Label3 = New Label()
        FlowLayoutPanel6 = New FlowLayoutPanel()
        CmbDrives = New ComboBox()
        btnRefreshDrives = New Button()
        FlowLayoutPanel7 = New FlowLayoutPanel()
        ChkShowInternal = New CheckBox()
        ChkShowUnknownDrives = New CheckBox()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Label1 = New Label()
        Label2 = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        btnLocateExistingInstance = New Button()
        Label6 = New Label()
        BoxWinPEInstances = New ListBox()
        btnNewInstance = New Button()
        btnRemoveInstance = New Button()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        SaveFileDialog1 = New SaveFileDialog()
        ToolTip1 = New ToolTip(components)
        MenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        FlowLayoutPanel5.SuspendLayout()
        FlowLayoutPanel4.SuspendLayout()
        FlowLayoutPanel6.SuspendLayout()
        FlowLayoutPanel7.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(811, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AboutWIDTGUIToolStripMenuItem, ToolStripSeparator1, QuitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' AboutWIDTGUIToolStripMenuItem
        ' 
        AboutWIDTGUIToolStripMenuItem.Name = "AboutWIDTGUIToolStripMenuItem"
        AboutWIDTGUIToolStripMenuItem.Size = New Size(180, 22)
        AboutWIDTGUIToolStripMenuItem.Text = "About WIDT-GUI"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(177, 6)
        ' 
        ' QuitToolStripMenuItem
        ' 
        QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        QuitToolStripMenuItem.ShortcutKeys = Keys.Alt Or Keys.F4
        QuitToolStripMenuItem.Size = New Size(180, 22)
        QuitToolStripMenuItem.Text = "Quit"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 245F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel1.Controls.Add(FlowLayoutPanel3, 2, 1)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 1)
        TableLayoutPanel1.Controls.Add(FlowLayoutPanel1, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 24)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 64F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(811, 426)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' FlowLayoutPanel3
        ' 
        FlowLayoutPanel3.Dock = DockStyle.Fill
        FlowLayoutPanel3.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel3.Location = New Point(644, 67)
        FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        FlowLayoutPanel3.Size = New Size(164, 356)
        FlowLayoutPanel3.TabIndex = 2
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(FlowLayoutPanel5, 0, 5)
        TableLayoutPanel2.Controls.Add(Label5, 0, 3)
        TableLayoutPanel2.Controls.Add(FlowLayoutPanel4, 0, 2)
        TableLayoutPanel2.Controls.Add(Label4, 0, 1)
        TableLayoutPanel2.Controls.Add(Label3, 0, 0)
        TableLayoutPanel2.Controls.Add(FlowLayoutPanel6, 0, 4)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(248, 67)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 6
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.Size = New Size(390, 356)
        TableLayoutPanel2.TabIndex = 3
        ' 
        ' FlowLayoutPanel5
        ' 
        FlowLayoutPanel5.AutoSize = True
        FlowLayoutPanel5.Controls.Add(btnCreateUSB)
        FlowLayoutPanel5.Controls.Add(btnCreateISO)
        FlowLayoutPanel5.Location = New Point(3, 174)
        FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        FlowLayoutPanel5.Size = New Size(200, 34)
        FlowLayoutPanel5.TabIndex = 8
        ' 
        ' btnCreateUSB
        ' 
        btnCreateUSB.AutoSize = True
        btnCreateUSB.Enabled = False
        btnCreateUSB.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCreateUSB.Location = New Point(3, 3)
        btnCreateUSB.Name = "btnCreateUSB"
        btnCreateUSB.Size = New Size(97, 28)
        btnCreateUSB.TabIndex = 3
        btnCreateUSB.Text = "Create USB"
        btnCreateUSB.UseVisualStyleBackColor = True
        ' 
        ' btnCreateISO
        ' 
        btnCreateISO.AutoSize = True
        btnCreateISO.Enabled = False
        btnCreateISO.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCreateISO.Location = New Point(106, 3)
        btnCreateISO.Name = "btnCreateISO"
        btnCreateISO.Size = New Size(91, 28)
        btnCreateISO.TabIndex = 5
        btnCreateISO.Text = "Create ISO"
        btnCreateISO.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(3, 77)
        Label5.Name = "Label5"
        Label5.Size = New Size(103, 18)
        Label5.TabIndex = 4
        Label5.Text = "Select a Drive:"
        ' 
        ' FlowLayoutPanel4
        ' 
        FlowLayoutPanel4.AutoSize = True
        FlowLayoutPanel4.Controls.Add(ChkWinPEStatus)
        FlowLayoutPanel4.Location = New Point(3, 46)
        FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        FlowLayoutPanel4.Size = New Size(103, 28)
        FlowLayoutPanel4.TabIndex = 3
        ' 
        ' ChkWinPEStatus
        ' 
        ChkWinPEStatus.AutoCheck = False
        ChkWinPEStatus.AutoSize = True
        ChkWinPEStatus.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkWinPEStatus.Location = New Point(3, 3)
        ChkWinPEStatus.Name = "ChkWinPEStatus"
        ChkWinPEStatus.Size = New Size(97, 22)
        ChkWinPEStatus.TabIndex = 2
        ChkWinPEStatus.Text = "Not Found"
        ChkWinPEStatus.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(3, 25)
        Label4.Name = "Label4"
        Label4.Size = New Size(117, 18)
        Label4.TabIndex = 0
        Label4.Text = "WinPE Instance:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(3, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(248, 25)
        Label3.TabIndex = 1
        Label3.Text = "Install WIDT To USB or ISO"
        ' 
        ' FlowLayoutPanel6
        ' 
        FlowLayoutPanel6.AutoSize = True
        FlowLayoutPanel6.Controls.Add(CmbDrives)
        FlowLayoutPanel6.Controls.Add(btnRefreshDrives)
        FlowLayoutPanel6.Controls.Add(FlowLayoutPanel7)
        FlowLayoutPanel6.Location = New Point(3, 98)
        FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        FlowLayoutPanel6.Size = New Size(371, 70)
        FlowLayoutPanel6.TabIndex = 7
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
        ' FlowLayoutPanel1
        ' 
        TableLayoutPanel1.SetColumnSpan(FlowLayoutPanel1, 3)
        FlowLayoutPanel1.Controls.Add(Label1)
        FlowLayoutPanel1.Controls.Add(Label2)
        FlowLayoutPanel1.Dock = DockStyle.Fill
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.Location = New Point(3, 3)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(805, 58)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(412, 32)
        Label1.TabIndex = 1
        Label1.Text = "Windows Image Deployment Tools"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(3, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(273, 25)
        Label2.TabIndex = 2
        Label2.Text = "Setup and Configuration Utility"
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(btnLocateExistingInstance, 0, 4)
        TableLayoutPanel3.Controls.Add(Label6, 0, 0)
        TableLayoutPanel3.Controls.Add(BoxWinPEInstances, 0, 1)
        TableLayoutPanel3.Controls.Add(btnNewInstance, 0, 2)
        TableLayoutPanel3.Controls.Add(btnRemoveInstance, 0, 3)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 67)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 5
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.RowStyles.Add(New RowStyle())
        TableLayoutPanel3.Size = New Size(239, 356)
        TableLayoutPanel3.TabIndex = 4
        ' 
        ' btnLocateExistingInstance
        ' 
        btnLocateExistingInstance.AutoSize = True
        btnLocateExistingInstance.Dock = DockStyle.Fill
        btnLocateExistingInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnLocateExistingInstance.Location = New Point(3, 325)
        btnLocateExistingInstance.Name = "btnLocateExistingInstance"
        btnLocateExistingInstance.Size = New Size(233, 28)
        btnLocateExistingInstance.TabIndex = 5
        btnLocateExistingInstance.Text = "Locate Existing Instance"
        btnLocateExistingInstance.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(206, 25)
        Label6.TabIndex = 2
        Label6.Text = "Select WinPE Instance"
        ' 
        ' BoxWinPEInstances
        ' 
        BoxWinPEInstances.Dock = DockStyle.Fill
        BoxWinPEInstances.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        BoxWinPEInstances.FormattingEnabled = True
        BoxWinPEInstances.ItemHeight = 18
        BoxWinPEInstances.Location = New Point(3, 28)
        BoxWinPEInstances.Name = "BoxWinPEInstances"
        BoxWinPEInstances.Size = New Size(233, 223)
        BoxWinPEInstances.TabIndex = 0
        ' 
        ' btnNewInstance
        ' 
        btnNewInstance.AutoSize = True
        btnNewInstance.Dock = DockStyle.Fill
        btnNewInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnNewInstance.Location = New Point(3, 257)
        btnNewInstance.Name = "btnNewInstance"
        btnNewInstance.Size = New Size(233, 28)
        btnNewInstance.TabIndex = 3
        btnNewInstance.Text = "Create New Instance"
        btnNewInstance.UseVisualStyleBackColor = True
        ' 
        ' btnRemoveInstance
        ' 
        btnRemoveInstance.AutoSize = True
        btnRemoveInstance.Dock = DockStyle.Fill
        btnRemoveInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRemoveInstance.Location = New Point(3, 291)
        btnRemoveInstance.Name = "btnRemoveInstance"
        btnRemoveInstance.Size = New Size(233, 28)
        btnRemoveInstance.TabIndex = 4
        btnRemoveInstance.Text = "Remove Instance"
        btnRemoveInstance.UseVisualStyleBackColor = True
        ' 
        ' SaveFileDialog1
        ' 
        SaveFileDialog1.DefaultExt = "iso"
        SaveFileDialog1.Filter = "ISO Files|*.iso"
        SaveFileDialog1.Title = "Save ISO as..."
        ' 
        ' SetupForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(811, 450)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "SetupForm"
        Text = "Setup - Windows Image Deployment Tools"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        FlowLayoutPanel5.ResumeLayout(False)
        FlowLayoutPanel5.PerformLayout()
        FlowLayoutPanel4.ResumeLayout(False)
        FlowLayoutPanel4.PerformLayout()
        FlowLayoutPanel6.ResumeLayout(False)
        FlowLayoutPanel6.PerformLayout()
        FlowLayoutPanel7.ResumeLayout(False)
        FlowLayoutPanel7.PerformLayout()
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
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
    Friend WithEvents ChkWinPEStatus As CheckBox
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbDrives As ComboBox
    Friend WithEvents btnCreateUSB As Button
    Friend WithEvents btnCreateISO As Button
    Friend WithEvents FlowLayoutPanel6 As FlowLayoutPanel
    Friend WithEvents btnRefreshDrives As Button
    Friend WithEvents ChkShowInternal As CheckBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents FlowLayoutPanel5 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel7 As FlowLayoutPanel
    Friend WithEvents ChkShowUnknownDrives As CheckBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents BoxWinPEInstances As ListBox
    Friend WithEvents btnLocateExistingInstance As Button
    Friend WithEvents btnNewInstance As Button
    Friend WithEvents btnRemoveInstance As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents AboutWIDTGUIToolStripMenuItem As ToolStripMenuItem
End Class
