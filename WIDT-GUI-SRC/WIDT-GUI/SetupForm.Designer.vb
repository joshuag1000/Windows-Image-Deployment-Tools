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
        btnCreateUSB = New Button()
        btnCreateISO = New Button()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        btnRefreshDrives = New Button()
        ChkShowInternal = New CheckBox()
        ChkShowUnknownDrives = New CheckBox()
        Label1 = New Label()
        Label2 = New Label()
        btnLocateExistingInstance = New Button()
        Label6 = New Label()
        BoxWinPEInstances = New ListBox()
        btnNewInstance = New Button()
        btnRemoveInstance = New Button()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        SaveFileDialog1 = New SaveFileDialog()
        ToolTip1 = New ToolTip(components)
        ChkWinPEStatus = New CheckBox()
        CmbDrives = New ComboBox()
        MenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(647, 24)
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
        AboutWIDTGUIToolStripMenuItem.Size = New Size(161, 22)
        AboutWIDTGUIToolStripMenuItem.Text = "About WIDT-GUI"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(158, 6)
        ' 
        ' QuitToolStripMenuItem
        ' 
        QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        QuitToolStripMenuItem.ShortcutKeys = Keys.Alt Or Keys.F4
        QuitToolStripMenuItem.Size = New Size(161, 22)
        QuitToolStripMenuItem.Text = "Quit"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 5
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(btnCreateISO, 2, 8)
        TableLayoutPanel1.Controls.Add(CmbDrives, 1, 6)
        TableLayoutPanel1.Controls.Add(btnCreateUSB, 1, 8)
        TableLayoutPanel1.Controls.Add(ChkShowUnknownDrives, 3, 7)
        TableLayoutPanel1.Controls.Add(ChkShowInternal, 1, 7)
        TableLayoutPanel1.Controls.Add(Label2, 0, 1)
        TableLayoutPanel1.Controls.Add(btnRefreshDrives, 4, 6)
        TableLayoutPanel1.Controls.Add(Label5, 1, 5)
        TableLayoutPanel1.Controls.Add(ChkWinPEStatus, 1, 4)
        TableLayoutPanel1.Controls.Add(Label4, 1, 3)
        TableLayoutPanel1.Controls.Add(BoxWinPEInstances, 0, 3)
        TableLayoutPanel1.Controls.Add(Label3, 1, 2)
        TableLayoutPanel1.Controls.Add(Label6, 0, 2)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(btnLocateExistingInstance, 0, 11)
        TableLayoutPanel1.Controls.Add(btnNewInstance, 0, 9)
        TableLayoutPanel1.Controls.Add(btnRemoveInstance, 0, 10)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 24)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 12
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(647, 421)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' btnCreateUSB
        ' 
        btnCreateUSB.AutoSize = True
        btnCreateUSB.Dock = DockStyle.Top
        btnCreateUSB.Enabled = False
        btnCreateUSB.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCreateUSB.Location = New Point(242, 213)
        btnCreateUSB.MaximumSize = New Size(100, 28)
        btnCreateUSB.MinimumSize = New Size(100, 28)
        btnCreateUSB.Name = "btnCreateUSB"
        btnCreateUSB.Size = New Size(100, 28)
        btnCreateUSB.TabIndex = 3
        btnCreateUSB.Text = "Create USB"
        btnCreateUSB.UseVisualStyleBackColor = True
        ' 
        ' btnCreateISO
        ' 
        btnCreateISO.AutoSize = True
        btnCreateISO.Dock = DockStyle.Top
        btnCreateISO.Enabled = False
        btnCreateISO.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCreateISO.Location = New Point(348, 213)
        btnCreateISO.MaximumSize = New Size(100, 28)
        btnCreateISO.MinimumSize = New Size(100, 28)
        btnCreateISO.Name = "btnCreateISO"
        btnCreateISO.Size = New Size(100, 28)
        btnCreateISO.TabIndex = 5
        btnCreateISO.Text = "Create ISO"
        btnCreateISO.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label5, 4)
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(242, 128)
        Label5.Name = "Label5"
        Label5.Size = New Size(402, 18)
        Label5.TabIndex = 4
        Label5.Text = "Select a Drive:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label4, 4)
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(242, 82)
        Label4.Name = "Label4"
        Label4.Size = New Size(402, 18)
        Label4.TabIndex = 0
        Label4.Text = "WinPE Instance:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label3, 4)
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(242, 57)
        Label3.Name = "Label3"
        Label3.Size = New Size(402, 25)
        Label3.TabIndex = 1
        Label3.Text = "Install WIDT To USB or ISO"
        ' 
        ' btnRefreshDrives
        ' 
        btnRefreshDrives.AutoSize = True
        btnRefreshDrives.Dock = DockStyle.Fill
        btnRefreshDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRefreshDrives.Location = New Point(539, 149)
        btnRefreshDrives.MaximumSize = New Size(89, 28)
        btnRefreshDrives.MinimumSize = New Size(89, 28)
        btnRefreshDrives.Name = "btnRefreshDrives"
        btnRefreshDrives.Size = New Size(89, 28)
        btnRefreshDrives.TabIndex = 6
        btnRefreshDrives.Text = "Refresh"
        btnRefreshDrives.UseVisualStyleBackColor = True
        ' 
        ' ChkShowInternal
        ' 
        ChkShowInternal.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(ChkShowInternal, 2)
        ChkShowInternal.Dock = DockStyle.Fill
        ChkShowInternal.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowInternal.Location = New Point(242, 183)
        ChkShowInternal.Name = "ChkShowInternal"
        ChkShowInternal.Size = New Size(206, 24)
        ChkShowInternal.TabIndex = 7
        ChkShowInternal.Text = "Show Internal Drives"
        ChkShowInternal.UseVisualStyleBackColor = True
        ' 
        ' ChkShowUnknownDrives
        ' 
        ChkShowUnknownDrives.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(ChkShowUnknownDrives, 2)
        ChkShowUnknownDrives.Dock = DockStyle.Fill
        ChkShowUnknownDrives.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowUnknownDrives.Location = New Point(454, 183)
        ChkShowUnknownDrives.Name = "ChkShowUnknownDrives"
        ChkShowUnknownDrives.Size = New Size(190, 24)
        ChkShowUnknownDrives.TabIndex = 8
        ChkShowUnknownDrives.Text = "Show Unknown Drives"
        ChkShowUnknownDrives.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label1, 3)
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
        TableLayoutPanel1.SetColumnSpan(Label2, 3)
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(3, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(273, 25)
        Label2.TabIndex = 2
        Label2.Text = "Setup and Configuration Utility"
        ' 
        ' btnLocateExistingInstance
        ' 
        btnLocateExistingInstance.AutoSize = True
        btnLocateExistingInstance.Dock = DockStyle.Top
        btnLocateExistingInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnLocateExistingInstance.Location = New Point(3, 382)
        btnLocateExistingInstance.Name = "btnLocateExistingInstance"
        btnLocateExistingInstance.Size = New Size(233, 28)
        btnLocateExistingInstance.TabIndex = 5
        btnLocateExistingInstance.Text = "Locate Existing Instance"
        btnLocateExistingInstance.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 57)
        Label6.Name = "Label6"
        Label6.Size = New Size(233, 25)
        Label6.TabIndex = 2
        Label6.Text = "Select WinPE Instance"
        ' 
        ' BoxWinPEInstances
        ' 
        BoxWinPEInstances.Dock = DockStyle.Fill
        BoxWinPEInstances.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        BoxWinPEInstances.FormattingEnabled = True
        BoxWinPEInstances.ItemHeight = 18
        BoxWinPEInstances.Location = New Point(3, 85)
        BoxWinPEInstances.Name = "BoxWinPEInstances"
        TableLayoutPanel1.SetRowSpan(BoxWinPEInstances, 6)
        BoxWinPEInstances.Size = New Size(233, 223)
        BoxWinPEInstances.TabIndex = 0
        ' 
        ' btnNewInstance
        ' 
        btnNewInstance.AutoSize = True
        btnNewInstance.Dock = DockStyle.Top
        btnNewInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnNewInstance.Location = New Point(3, 314)
        btnNewInstance.Name = "btnNewInstance"
        btnNewInstance.Size = New Size(233, 28)
        btnNewInstance.TabIndex = 3
        btnNewInstance.Text = "Create New Instance"
        btnNewInstance.UseVisualStyleBackColor = True
        ' 
        ' btnRemoveInstance
        ' 
        btnRemoveInstance.AutoSize = True
        btnRemoveInstance.Dock = DockStyle.Top
        btnRemoveInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRemoveInstance.Location = New Point(3, 348)
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
        ' ChkWinPEStatus
        ' 
        ChkWinPEStatus.AutoCheck = False
        ChkWinPEStatus.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(ChkWinPEStatus, 4)
        ChkWinPEStatus.Dock = DockStyle.Fill
        ChkWinPEStatus.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkWinPEStatus.Location = New Point(242, 103)
        ChkWinPEStatus.Name = "ChkWinPEStatus"
        ChkWinPEStatus.Size = New Size(402, 22)
        ChkWinPEStatus.TabIndex = 2
        ChkWinPEStatus.Text = "Not Found"
        ChkWinPEStatus.UseVisualStyleBackColor = True
        ' 
        ' CmbDrives
        ' 
        TableLayoutPanel1.SetColumnSpan(CmbDrives, 3)
        CmbDrives.DropDownStyle = ComboBoxStyle.DropDownList
        CmbDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        CmbDrives.FormattingEnabled = True
        CmbDrives.Location = New Point(242, 149)
        CmbDrives.MaximumSize = New Size(289, 0)
        CmbDrives.MinimumSize = New Size(100, 0)
        CmbDrives.Name = "CmbDrives"
        CmbDrives.Size = New Size(289, 26)
        CmbDrives.TabIndex = 5
        ' 
        ' SetupForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(647, 445)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "SetupForm"
        Text = "Setup - Windows Image Deployment Tools"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCreateUSB As Button
    Friend WithEvents btnCreateISO As Button
    Friend WithEvents btnRefreshDrives As Button
    Friend WithEvents ChkShowInternal As CheckBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ChkShowUnknownDrives As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BoxWinPEInstances As ListBox
    Friend WithEvents btnLocateExistingInstance As Button
    Friend WithEvents btnNewInstance As Button
    Friend WithEvents btnRemoveInstance As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents AboutWIDTGUIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CmbDrives As ComboBox
    Friend WithEvents ChkWinPEStatus As CheckBox
End Class
