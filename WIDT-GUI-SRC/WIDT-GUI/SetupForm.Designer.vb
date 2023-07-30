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
        InstallConfigurationsToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel1 = New TableLayoutPanel()
        CmbDrives = New ComboBox()
        btnRefreshDrives = New Button()
        Label5 = New Label()
        ChkWinPEStatus = New CheckBox()
        Label4 = New Label()
        BoxWinPEInstances = New ListBox()
        Label3 = New Label()
        Label6 = New Label()
        btnLocateExistingInstance = New Button()
        btnNewInstance = New Button()
        btnRemoveInstance = New Button()
        TableLayoutPanel3 = New TableLayoutPanel()
        ChkShowInternal = New CheckBox()
        ChkShowUnknownDrives = New CheckBox()
        TableLayoutPanel4 = New TableLayoutPanel()
        BoxSelectConfigs = New CheckedListBox()
        BoxCreateImages = New CheckedListBox()
        BoxCreateDrivers = New CheckedListBox()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        btnRefreshConfigs = New Button()
        btnCreateISO = New Button()
        btnCreateUSB = New Button()
        Label2 = New Label()
        Label1 = New Label()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        SaveFileDialog1 = New SaveFileDialog()
        ToolTip1 = New ToolTip(components)
        TabControl1 = New TabControl()
        PageCreateDrives = New TabPage()
        pageManageConfigs = New TabPage()
        TableLayoutPanel5 = New TableLayoutPanel()
        Label13 = New Label()
        btnLoadConfigs = New Button()
        Label11 = New Label()
        boxWIDTConfigs = New ListBox()
        btnCreateConfig = New Button()
        btnRemoveConfig = New Button()
        boxSelectImage = New ListBox()
        Label12 = New Label()
        boxSelectedDriverPacks = New CheckedListBox()
        TableLayoutPanel6 = New TableLayoutPanel()
        btnBuildConfigToWim = New Button()
        TableLayoutPanel2 = New TableLayoutPanel()
        MenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TabControl1.SuspendLayout()
        PageCreateDrives.SuspendLayout()
        pageManageConfigs.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, InstallConfigurationsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.MaximumSize = New Size(0, 24)
        MenuStrip1.MinimumSize = New Size(0, 24)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(876, 24)
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
        ' InstallConfigurationsToolStripMenuItem
        ' 
        InstallConfigurationsToolStripMenuItem.Name = "InstallConfigurationsToolStripMenuItem"
        InstallConfigurationsToolStripMenuItem.Size = New Size(132, 20)
        InstallConfigurationsToolStripMenuItem.Text = "Install Configurations"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 5
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(CmbDrives, 1, 4)
        TableLayoutPanel1.Controls.Add(btnRefreshDrives, 4, 4)
        TableLayoutPanel1.Controls.Add(Label5, 1, 3)
        TableLayoutPanel1.Controls.Add(ChkWinPEStatus, 1, 2)
        TableLayoutPanel1.Controls.Add(Label4, 1, 1)
        TableLayoutPanel1.Controls.Add(BoxWinPEInstances, 0, 1)
        TableLayoutPanel1.Controls.Add(Label3, 1, 0)
        TableLayoutPanel1.Controls.Add(Label6, 0, 0)
        TableLayoutPanel1.Controls.Add(btnLocateExistingInstance, 0, 9)
        TableLayoutPanel1.Controls.Add(btnNewInstance, 0, 7)
        TableLayoutPanel1.Controls.Add(btnRemoveInstance, 0, 8)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 1, 5)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel4, 1, 6)
        TableLayoutPanel1.Controls.Add(btnRefreshConfigs, 2, 9)
        TableLayoutPanel1.Controls.Add(btnCreateISO, 3, 9)
        TableLayoutPanel1.Controls.Add(btnCreateUSB, 4, 9)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(3, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 10
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(856, 478)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' CmbDrives
        ' 
        TableLayoutPanel1.SetColumnSpan(CmbDrives, 3)
        CmbDrives.Dock = DockStyle.Fill
        CmbDrives.DropDownStyle = ComboBoxStyle.DropDownList
        CmbDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        CmbDrives.FormattingEnabled = True
        CmbDrives.Location = New Point(239, 92)
        CmbDrives.MinimumSize = New Size(100, 0)
        CmbDrives.Name = "CmbDrives"
        CmbDrives.Size = New Size(498, 26)
        CmbDrives.TabIndex = 5
        ' 
        ' btnRefreshDrives
        ' 
        btnRefreshDrives.AutoSize = True
        btnRefreshDrives.Dock = DockStyle.Fill
        btnRefreshDrives.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRefreshDrives.Location = New Point(743, 92)
        btnRefreshDrives.MaximumSize = New Size(110, 28)
        btnRefreshDrives.MinimumSize = New Size(110, 28)
        btnRefreshDrives.Name = "btnRefreshDrives"
        btnRefreshDrives.Size = New Size(110, 28)
        btnRefreshDrives.TabIndex = 6
        btnRefreshDrives.Text = "Refresh"
        btnRefreshDrives.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label5, 4)
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(239, 71)
        Label5.Name = "Label5"
        Label5.Size = New Size(614, 18)
        Label5.TabIndex = 4
        Label5.Text = "Select a Drive:"
        ' 
        ' ChkWinPEStatus
        ' 
        ChkWinPEStatus.AutoCheck = False
        ChkWinPEStatus.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(ChkWinPEStatus, 4)
        ChkWinPEStatus.Dock = DockStyle.Fill
        ChkWinPEStatus.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkWinPEStatus.Location = New Point(239, 46)
        ChkWinPEStatus.Name = "ChkWinPEStatus"
        ChkWinPEStatus.Size = New Size(614, 22)
        ChkWinPEStatus.TabIndex = 2
        ChkWinPEStatus.Text = "Not Found"
        ChkWinPEStatus.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label4, 4)
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(239, 25)
        Label4.Name = "Label4"
        Label4.Size = New Size(614, 18)
        Label4.TabIndex = 0
        Label4.Text = "WinPE Instance:"
        ' 
        ' BoxWinPEInstances
        ' 
        BoxWinPEInstances.Dock = DockStyle.Fill
        BoxWinPEInstances.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        BoxWinPEInstances.FormattingEnabled = True
        BoxWinPEInstances.ItemHeight = 18
        BoxWinPEInstances.Location = New Point(3, 28)
        BoxWinPEInstances.Name = "BoxWinPEInstances"
        TableLayoutPanel1.SetRowSpan(BoxWinPEInstances, 6)
        BoxWinPEInstances.Size = New Size(230, 345)
        BoxWinPEInstances.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label3, 4)
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(239, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(614, 25)
        Label3.TabIndex = 1
        Label3.Text = "Install WinPE To USB or ISO"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 0)
        Label6.MaximumSize = New Size(230, 25)
        Label6.MinimumSize = New Size(230, 25)
        Label6.Name = "Label6"
        Label6.Size = New Size(230, 25)
        Label6.TabIndex = 2
        Label6.Text = "Select WinPE Instance"
        ' 
        ' btnLocateExistingInstance
        ' 
        btnLocateExistingInstance.AutoSize = True
        btnLocateExistingInstance.Dock = DockStyle.Fill
        btnLocateExistingInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnLocateExistingInstance.Location = New Point(3, 447)
        btnLocateExistingInstance.MaximumSize = New Size(0, 28)
        btnLocateExistingInstance.MinimumSize = New Size(0, 28)
        btnLocateExistingInstance.Name = "btnLocateExistingInstance"
        btnLocateExistingInstance.Size = New Size(230, 28)
        btnLocateExistingInstance.TabIndex = 5
        btnLocateExistingInstance.Text = "Locate Existing Instance"
        btnLocateExistingInstance.UseVisualStyleBackColor = True
        ' 
        ' btnNewInstance
        ' 
        btnNewInstance.AutoSize = True
        btnNewInstance.Dock = DockStyle.Fill
        btnNewInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnNewInstance.Location = New Point(3, 379)
        btnNewInstance.MaximumSize = New Size(230, 28)
        btnNewInstance.MinimumSize = New Size(230, 28)
        btnNewInstance.Name = "btnNewInstance"
        btnNewInstance.Size = New Size(230, 28)
        btnNewInstance.TabIndex = 3
        btnNewInstance.Text = "Create New Instance"
        btnNewInstance.UseVisualStyleBackColor = True
        ' 
        ' btnRemoveInstance
        ' 
        btnRemoveInstance.AutoSize = True
        btnRemoveInstance.Dock = DockStyle.Fill
        btnRemoveInstance.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRemoveInstance.Location = New Point(3, 413)
        btnRemoveInstance.MaximumSize = New Size(0, 28)
        btnRemoveInstance.MinimumSize = New Size(0, 28)
        btnRemoveInstance.Name = "btnRemoveInstance"
        btnRemoveInstance.Size = New Size(230, 28)
        btnRemoveInstance.TabIndex = 4
        btnRemoveInstance.Text = "Remove Instance"
        btnRemoveInstance.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel1.SetColumnSpan(TableLayoutPanel3, 4)
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(ChkShowInternal, 0, 0)
        TableLayoutPanel3.Controls.Add(ChkShowUnknownDrives, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(239, 126)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(614, 29)
        TableLayoutPanel3.TabIndex = 9
        ' 
        ' ChkShowInternal
        ' 
        ChkShowInternal.AutoSize = True
        ChkShowInternal.Dock = DockStyle.Fill
        ChkShowInternal.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowInternal.Location = New Point(3, 3)
        ChkShowInternal.Name = "ChkShowInternal"
        ChkShowInternal.Size = New Size(162, 23)
        ChkShowInternal.TabIndex = 7
        ChkShowInternal.Text = "Show Internal Drives"
        ChkShowInternal.UseVisualStyleBackColor = True
        ' 
        ' ChkShowUnknownDrives
        ' 
        ChkShowUnknownDrives.AutoSize = True
        ChkShowUnknownDrives.Dock = DockStyle.Fill
        ChkShowUnknownDrives.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        ChkShowUnknownDrives.Location = New Point(171, 3)
        ChkShowUnknownDrives.Name = "ChkShowUnknownDrives"
        ChkShowUnknownDrives.Size = New Size(174, 23)
        ChkShowUnknownDrives.TabIndex = 8
        ChkShowUnknownDrives.Text = "Show Unknown Drives"
        ChkShowUnknownDrives.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 3
        TableLayoutPanel1.SetColumnSpan(TableLayoutPanel4, 4)
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel4.Controls.Add(BoxSelectConfigs, 0, 2)
        TableLayoutPanel4.Controls.Add(BoxCreateImages, 1, 2)
        TableLayoutPanel4.Controls.Add(BoxCreateDrivers, 2, 2)
        TableLayoutPanel4.Controls.Add(Label7, 0, 1)
        TableLayoutPanel4.Controls.Add(Label8, 1, 1)
        TableLayoutPanel4.Controls.Add(Label9, 2, 1)
        TableLayoutPanel4.Controls.Add(Label10, 0, 0)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(239, 161)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 3
        TableLayoutPanel1.SetRowSpan(TableLayoutPanel4, 3)
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle())
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Size = New Size(614, 280)
        TableLayoutPanel4.TabIndex = 10
        ' 
        ' BoxSelectConfigs
        ' 
        BoxSelectConfigs.CheckOnClick = True
        BoxSelectConfigs.Dock = DockStyle.Fill
        BoxSelectConfigs.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        BoxSelectConfigs.FormattingEnabled = True
        BoxSelectConfigs.Location = New Point(3, 43)
        BoxSelectConfigs.Name = "BoxSelectConfigs"
        BoxSelectConfigs.Size = New Size(198, 234)
        BoxSelectConfigs.TabIndex = 0
        ' 
        ' BoxCreateImages
        ' 
        BoxCreateImages.CheckOnClick = True
        BoxCreateImages.Dock = DockStyle.Fill
        BoxCreateImages.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        BoxCreateImages.FormattingEnabled = True
        BoxCreateImages.Location = New Point(207, 43)
        BoxCreateImages.Name = "BoxCreateImages"
        BoxCreateImages.Size = New Size(198, 234)
        BoxCreateImages.TabIndex = 1
        ' 
        ' BoxCreateDrivers
        ' 
        BoxCreateDrivers.CheckOnClick = True
        BoxCreateDrivers.Dock = DockStyle.Fill
        BoxCreateDrivers.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        BoxCreateDrivers.FormattingEnabled = True
        BoxCreateDrivers.Location = New Point(411, 43)
        BoxCreateDrivers.Name = "BoxCreateDrivers"
        BoxCreateDrivers.Size = New Size(200, 234)
        BoxCreateDrivers.TabIndex = 2
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(3, 20)
        Label7.Name = "Label7"
        Label7.Size = New Size(106, 20)
        Label7.TabIndex = 3
        Label7.Text = "Select Configs:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(207, 20)
        Label8.Name = "Label8"
        Label8.Size = New Size(104, 20)
        Label8.TabIndex = 4
        Label8.Text = "Select Images:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(411, 20)
        Label9.Name = "Label9"
        Label9.Size = New Size(135, 20)
        Label9.TabIndex = 5
        Label9.Text = "Select Driver Packs:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        TableLayoutPanel4.SetColumnSpan(Label10, 3)
        Label10.Dock = DockStyle.Fill
        Label10.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.Location = New Point(3, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(608, 20)
        Label10.TabIndex = 6
        Label10.Text = "Select Items to Copy to USB: (USB Only)"
        ' 
        ' btnRefreshConfigs
        ' 
        btnRefreshConfigs.AutoSize = True
        btnRefreshConfigs.Dock = DockStyle.Fill
        btnRefreshConfigs.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRefreshConfigs.Location = New Point(496, 447)
        btnRefreshConfigs.MaximumSize = New Size(0, 28)
        btnRefreshConfigs.MinimumSize = New Size(0, 28)
        btnRefreshConfigs.Name = "btnRefreshConfigs"
        btnRefreshConfigs.Size = New Size(125, 28)
        btnRefreshConfigs.TabIndex = 11
        btnRefreshConfigs.Text = "Refresh Configs"
        btnRefreshConfigs.UseVisualStyleBackColor = True
        ' 
        ' btnCreateISO
        ' 
        btnCreateISO.AutoSize = True
        btnCreateISO.Dock = DockStyle.Fill
        btnCreateISO.Enabled = False
        btnCreateISO.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCreateISO.Location = New Point(627, 447)
        btnCreateISO.MaximumSize = New Size(0, 28)
        btnCreateISO.MinimumSize = New Size(0, 28)
        btnCreateISO.Name = "btnCreateISO"
        btnCreateISO.Size = New Size(110, 28)
        btnCreateISO.TabIndex = 5
        btnCreateISO.Text = "Create ISO"
        btnCreateISO.UseVisualStyleBackColor = True
        ' 
        ' btnCreateUSB
        ' 
        btnCreateUSB.AutoSize = True
        btnCreateUSB.Dock = DockStyle.Fill
        btnCreateUSB.Enabled = False
        btnCreateUSB.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCreateUSB.Location = New Point(743, 447)
        btnCreateUSB.MaximumSize = New Size(0, 28)
        btnCreateUSB.MinimumSize = New Size(0, 28)
        btnCreateUSB.Name = "btnCreateUSB"
        btnCreateUSB.Size = New Size(110, 28)
        btnCreateUSB.TabIndex = 3
        btnCreateUSB.Text = "Create USB"
        btnCreateUSB.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(3, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(870, 25)
        Label2.TabIndex = 2
        Label2.Text = "Setup and Configuration Utility"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(870, 32)
        Label1.TabIndex = 1
        Label1.Text = "Windows Image Deployment Tools"
        ' 
        ' SaveFileDialog1
        ' 
        SaveFileDialog1.DefaultExt = "iso"
        SaveFileDialog1.Filter = "ISO Files|*.iso"
        SaveFileDialog1.Title = "Save ISO as..."
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(PageCreateDrives)
        TabControl1.Controls.Add(pageManageConfigs)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TabControl1.Location = New Point(3, 60)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(870, 518)
        TabControl1.TabIndex = 2
        ' 
        ' PageCreateDrives
        ' 
        PageCreateDrives.Controls.Add(TableLayoutPanel1)
        PageCreateDrives.Location = New Point(4, 30)
        PageCreateDrives.Name = "PageCreateDrives"
        PageCreateDrives.Padding = New Padding(3)
        PageCreateDrives.Size = New Size(862, 484)
        PageCreateDrives.TabIndex = 0
        PageCreateDrives.Text = "Create WinPE Drives"
        PageCreateDrives.UseVisualStyleBackColor = True
        ' 
        ' pageManageConfigs
        ' 
        pageManageConfigs.Controls.Add(TableLayoutPanel5)
        pageManageConfigs.Location = New Point(4, 30)
        pageManageConfigs.Name = "pageManageConfigs"
        pageManageConfigs.Padding = New Padding(3)
        pageManageConfigs.Size = New Size(862, 484)
        pageManageConfigs.TabIndex = 1
        pageManageConfigs.Text = "Manage Image Configs"
        pageManageConfigs.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 3
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.Controls.Add(Label13, 2, 0)
        TableLayoutPanel5.Controls.Add(btnLoadConfigs, 0, 4)
        TableLayoutPanel5.Controls.Add(Label11, 0, 0)
        TableLayoutPanel5.Controls.Add(boxWIDTConfigs, 0, 1)
        TableLayoutPanel5.Controls.Add(btnCreateConfig, 0, 2)
        TableLayoutPanel5.Controls.Add(btnRemoveConfig, 0, 3)
        TableLayoutPanel5.Controls.Add(boxSelectImage, 1, 1)
        TableLayoutPanel5.Controls.Add(Label12, 1, 0)
        TableLayoutPanel5.Controls.Add(boxSelectedDriverPacks, 2, 1)
        TableLayoutPanel5.Controls.Add(TableLayoutPanel6, 1, 2)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(3, 3)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 5
        TableLayoutPanel5.RowStyles.Add(New RowStyle())
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle())
        TableLayoutPanel5.RowStyles.Add(New RowStyle())
        TableLayoutPanel5.RowStyles.Add(New RowStyle())
        TableLayoutPanel5.Size = New Size(856, 478)
        TableLayoutPanel5.TabIndex = 0
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Dock = DockStyle.Fill
        Label13.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label13.Location = New Point(549, 0)
        Label13.MaximumSize = New Size(230, 25)
        Label13.MinimumSize = New Size(230, 25)
        Label13.Name = "Label13"
        Label13.Size = New Size(230, 25)
        Label13.TabIndex = 12
        Label13.Text = "Select Driver Packs for Config"
        ' 
        ' btnLoadConfigs
        ' 
        btnLoadConfigs.AutoSize = True
        btnLoadConfigs.Dock = DockStyle.Fill
        btnLoadConfigs.Enabled = False
        btnLoadConfigs.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnLoadConfigs.Location = New Point(3, 443)
        btnLoadConfigs.MaximumSize = New Size(230, 28)
        btnLoadConfigs.MinimumSize = New Size(230, 28)
        btnLoadConfigs.Name = "btnLoadConfigs"
        btnLoadConfigs.Size = New Size(230, 28)
        btnLoadConfigs.TabIndex = 6
        btnLoadConfigs.Text = "Load External Configurations"
        btnLoadConfigs.UseVisualStyleBackColor = True
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Dock = DockStyle.Fill
        Label11.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label11.Location = New Point(3, 0)
        Label11.MaximumSize = New Size(230, 25)
        Label11.MinimumSize = New Size(230, 25)
        Label11.Name = "Label11"
        Label11.Size = New Size(230, 25)
        Label11.TabIndex = 3
        Label11.Text = "WIDT Configurations"
        ' 
        ' boxWIDTConfigs
        ' 
        boxWIDTConfigs.Dock = DockStyle.Fill
        boxWIDTConfigs.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        boxWIDTConfigs.FormattingEnabled = True
        boxWIDTConfigs.ItemHeight = 18
        boxWIDTConfigs.Location = New Point(3, 28)
        boxWIDTConfigs.Name = "boxWIDTConfigs"
        boxWIDTConfigs.Size = New Size(230, 341)
        boxWIDTConfigs.TabIndex = 4
        ' 
        ' btnCreateConfig
        ' 
        btnCreateConfig.AutoSize = True
        btnCreateConfig.Dock = DockStyle.Fill
        btnCreateConfig.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCreateConfig.Location = New Point(3, 375)
        btnCreateConfig.MaximumSize = New Size(230, 28)
        btnCreateConfig.MinimumSize = New Size(230, 28)
        btnCreateConfig.Name = "btnCreateConfig"
        btnCreateConfig.Size = New Size(230, 28)
        btnCreateConfig.TabIndex = 5
        btnCreateConfig.Text = "Create New Configuration"
        btnCreateConfig.UseVisualStyleBackColor = True
        ' 
        ' btnRemoveConfig
        ' 
        btnRemoveConfig.AutoSize = True
        btnRemoveConfig.Dock = DockStyle.Fill
        btnRemoveConfig.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnRemoveConfig.Location = New Point(3, 409)
        btnRemoveConfig.MaximumSize = New Size(230, 28)
        btnRemoveConfig.MinimumSize = New Size(230, 28)
        btnRemoveConfig.Name = "btnRemoveConfig"
        btnRemoveConfig.Size = New Size(230, 28)
        btnRemoveConfig.TabIndex = 7
        btnRemoveConfig.Text = "Remove Configuration"
        btnRemoveConfig.UseVisualStyleBackColor = True
        ' 
        ' boxSelectImage
        ' 
        boxSelectImage.Dock = DockStyle.Fill
        boxSelectImage.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        boxSelectImage.FormattingEnabled = True
        boxSelectImage.ItemHeight = 18
        boxSelectImage.Location = New Point(239, 28)
        boxSelectImage.Name = "boxSelectImage"
        boxSelectImage.Size = New Size(304, 341)
        boxSelectImage.TabIndex = 9
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label12.Location = New Point(239, 0)
        Label12.MaximumSize = New Size(230, 25)
        Label12.MinimumSize = New Size(230, 25)
        Label12.Name = "Label12"
        Label12.Size = New Size(230, 25)
        Label12.TabIndex = 10
        Label12.Text = "Select Image for Config"
        ' 
        ' boxSelectedDriverPacks
        ' 
        boxSelectedDriverPacks.Dock = DockStyle.Fill
        boxSelectedDriverPacks.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        boxSelectedDriverPacks.FormattingEnabled = True
        boxSelectedDriverPacks.Location = New Point(549, 28)
        boxSelectedDriverPacks.Name = "boxSelectedDriverPacks"
        boxSelectedDriverPacks.Size = New Size(304, 341)
        boxSelectedDriverPacks.TabIndex = 11
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 2
        TableLayoutPanel5.SetColumnSpan(TableLayoutPanel6, 2)
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 210F))
        TableLayoutPanel6.Controls.Add(btnBuildConfigToWim, 1, 2)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(239, 375)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 3
        TableLayoutPanel5.SetRowSpan(TableLayoutPanel6, 3)
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel6.Size = New Size(614, 100)
        TableLayoutPanel6.TabIndex = 15
        ' 
        ' btnBuildConfigToWim
        ' 
        btnBuildConfigToWim.Dock = DockStyle.Fill
        btnBuildConfigToWim.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnBuildConfigToWim.Location = New Point(407, 69)
        btnBuildConfigToWim.Name = "btnBuildConfigToWim"
        btnBuildConfigToWim.Size = New Size(204, 28)
        btnBuildConfigToWim.TabIndex = 2
        btnBuildConfigToWim.Text = "Build Config To Wim"
        btnBuildConfigToWim.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(Label1, 0, 0)
        TableLayoutPanel2.Controls.Add(Label2, 0, 1)
        TableLayoutPanel2.Controls.Add(TabControl1, 0, 2)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 24)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(876, 581)
        TableLayoutPanel2.TabIndex = 3
        ' 
        ' SetupForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(876, 605)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        MinimumSize = New Size(668, 488)
        Name = "SetupForm"
        Text = "Setup - Windows Image Deployment Tools"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        TabControl1.ResumeLayout(False)
        PageCreateDrives.ResumeLayout(False)
        pageManageConfigs.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        TableLayoutPanel6.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
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
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents PageCreateDrives As TabPage
    Friend WithEvents pageManageConfigs As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents BoxSelectConfigs As CheckedListBox
    Friend WithEvents BoxCreateImages As CheckedListBox
    Friend WithEvents BoxCreateDrivers As CheckedListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnRefreshConfigs As Button
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents btnLoadConfigs As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents boxWIDTConfigs As ListBox
    Friend WithEvents btnCreateConfig As Button
    Friend WithEvents btnRemoveConfig As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents boxSelectImage As ListBox
    Friend WithEvents Label12 As Label
    Friend WithEvents boxSelectedDriverPacks As CheckedListBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents btnBuildConfigToWim As Button
    Friend WithEvents InstallConfigurationsToolStripMenuItem As ToolStripMenuItem
End Class
