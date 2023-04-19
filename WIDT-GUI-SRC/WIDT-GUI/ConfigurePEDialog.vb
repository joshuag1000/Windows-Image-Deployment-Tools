Imports System.IO

Public Class ConfigurePEDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtWinPEPath.Text = "" Then
            MessageBox.Show("Please specify a location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf If(txtWinPEPath.Text.Chars(txtWinPEPath.Text.Length - 1) = "\", txtWinPEPath.Text, txtWinPEPath.Text + "\") = If(AppContext.BaseDirectory.Chars(AppContext.BaseDirectory.Length - 1) = "\", AppContext.BaseDirectory, AppContext.BaseDirectory + "\") Then
            MessageBox.Show("WinPE cannot be inside the same folder as the tools.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf txtWinPEName.Text = "" Then
            MessageBox.Show("Please specify a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        FolderBrowserDialog1.InitialDirectory = Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).ToString).ToString + "\WinPE-Instances"
        Dim WinPEPath As DialogResult = FolderBrowserDialog1.ShowDialog
        If WinPEPath = DialogResult.OK Then
            txtWinPEPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    ' List of things that WinPE NEEDS to have for out program to work
    Dim NonOptionalComponents() As String = {"Scripting/WinPE-WMI", "Microsoft .NET/WinPE-NetFx", "Startup/WinPE-HSP-Driver", "Startup/WinPE-SecureStartup"}
    Dim DefaultOptions() As String = {"WIDT/DuplicationMagic", "HTML/WinPE-HTA", "Scripting/WinPE-Scripting", "Windows PowerShell/WinPE-PowerShell", "Windows PowerShell/WinPE-PlatformID", "Windows PowerShell/WinPE-DismCmdlets", "Windows PowerShell/WinPE-SecureBootCmdlets", "Windows PowerShell/WinPE-StorageWMI"}

    Private Sub ConfigurePEDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtWinPEPath.Text = Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).ToString).ToString + "\WinPE-Instances"
        FolderBrowserDialog1.InitialDirectory = Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).ToString).ToString + "\WinPE-Instances"
        txtWinPEDrivers.Text = ""
        txtWinPEName.Text = ""
        ChkIncludeDrivers.Checked = False
        txtWinPEDrivers.Enabled = ChkIncludeDrivers.Checked
        btnSelectDriversDir.Enabled = ChkIncludeDrivers.Checked
        txtWinPEName.Select()

        ' The order these are defined is critical. As if something has a dependancy then it needs to be installed first. This defines that order.
        ' Add optional components to the checked list box
        Dim WinPE_WMI As ConfigPEOptional = New ConfigPEOptional("Scripting/WinPE-WMI", False, "WinPE-WMI", Nothing, True)
        Dim WinPE_SecureStartup As ConfigPEOptional = New ConfigPEOptional("Startup/WinPE-SecureStartup", False, "WinPE-SecureStartup", New List(Of ConfigPEOptional) From {WinPE_WMI}, True)
        Dim WinPE_NetFx As ConfigPEOptional = New ConfigPEOptional("Microsoft .NET/WinPE-NetFx", False, "WinPE-NetFx", New List(Of ConfigPEOptional) From {WinPE_WMI}, True)
        Dim WinPE_Scripting As ConfigPEOptional = New ConfigPEOptional("Scripting/WinPE-Scripting", False, "WinPE-Scripting", Nothing, True)
        Dim WinPE_Powershell As ConfigPEOptional = New ConfigPEOptional("Windows PowerShell/WinPE-PowerShell", False, "WinPE-PowerShell", New List(Of ConfigPEOptional) From {WinPE_WMI, WinPE_NetFx, WinPE_Scripting}, True)
        Dim WinPE_Setup As ConfigPEOptional = New ConfigPEOptional("Setup/WinPE-Setup", False, "WinPE-Setup", Nothing, True)
        Dim OptionalComponents As New List(Of ConfigPEOptional) From {
            New ConfigPEOptional("WIDT/DuplicationMagic", True, "DuplicationMagic", Nothing, False),
            WinPE_WMI,
            WinPE_SecureStartup,
            WinPE_NetFx,
            WinPE_Scripting,
            WinPE_Powershell,
            New ConfigPEOptional("Windows PowerShell/WinPE-PlatformID", False, "WinPE-PlatformId", New List(Of ConfigPEOptional) From {WinPE_WMI, WinPE_SecureStartup}, False),
            New ConfigPEOptional("Windows PowerShell/WinPE-DismCmdlets", False, "WinPE-DismCmdlets", New List(Of ConfigPEOptional) From {WinPE_WMI, WinPE_NetFx, WinPE_Scripting, WinPE_Powershell}, True),
            New ConfigPEOptional("Windows PowerShell/WinPE-SecureBootCmdlets", False, "WinPE-SecureBootCmdlets", New List(Of ConfigPEOptional) From {WinPE_WMI, WinPE_NetFx, WinPE_Scripting, WinPE_Powershell}, False),
            New ConfigPEOptional("Windows PowerShell/WinPE-StorageWMI", False, "WinPE-StorageWMI", New List(Of ConfigPEOptional) From {WinPE_WMI, WinPE_NetFx, WinPE_Scripting, WinPE_Powershell}, True),
            New ConfigPEOptional("Storage/WinPE-EnhancedStorage", False, "WinPE-EnhancedStorage", Nothing, True),
            New ConfigPEOptional("Database/WinPE-MDAC", False, "WinPE-MDAC", Nothing, True),
            New ConfigPEOptional("File management/WinPE-FMAPI", False, "WinPE-FMAPI", Nothing, False),
            New ConfigPEOptional("Network/WinPE-Dot3Svc", False, "WinPE-Dot3Svc", Nothing, True),
            New ConfigPEOptional("Network/WinPE-PPPoE", False, "WinPE-PPPoE", Nothing, True),
            New ConfigPEOptional("Network/WinPE-RNDIS", False, "WinPE-RNDIS", Nothing, True),
            New ConfigPEOptional("Network/WinPE-WDS-Tools", False, "WinPE-WDS-Tools", Nothing, True),
            New ConfigPEOptional("Recovery/WinPE-WinReCfg", False, "WinPE-WinReCfg", Nothing, True),
            New ConfigPEOptional("Setup/Winpe-LegacySetup", False, "WinPE-LegacySetup", Nothing, True),
            WinPE_Setup,
            New ConfigPEOptional("Setup/WinPE-Setup-Client", False, "WinPE-Setup-Client", New List(Of ConfigPEOptional) From {WinPE_Setup}, True),
            New ConfigPEOptional("Setup/WinPE-Setup-Server", False, "WinPE-Setup-Server", New List(Of ConfigPEOptional) From {WinPE_Setup}, True),
            New ConfigPEOptional("Fonts/WinPE-Fonts-Legacy", False, "WinPE-Fonts-Legacy", Nothing, False),
            New ConfigPEOptional("Fonts/WinPE-Font Support-JA-JP", False, "WinPE-FontSupport-JA-JP", Nothing, False),
            New ConfigPEOptional("Fonts/WinPE-Font Support-KO-KR", False, "WinPE-FontSupport-KO-KR", Nothing, False),
            New ConfigPEOptional("Fonts/WinPE-Font Support-ZH-CN", False, "WinPE-FontSupport-ZH-CN", Nothing, False),
            New ConfigPEOptional("Fonts/WinPE-Font Support-ZH-HK", False, "WinPE-FontSupport-ZH-HK", Nothing, False),
            New ConfigPEOptional("Fonts/WinPE-Font Support-ZH-TW", False, "WinPE-FontSupport-ZH-TW", Nothing, False),
            New ConfigPEOptional("Input/WinPE-GamingPeripherals", False, "WinPE-GamingPeripherals", Nothing, False),
            New ConfigPEOptional("HTML/WinPE-HTA", False, "WinPE-HTA", Nothing, True),
            New ConfigPEOptional("Startup/WinPE-HSP-Driver", False, "WinPE-HSP-Driver", Nothing, False)
        }
        ChkOptionalComp.Items.Clear()

        For Each component In OptionalComponents
            If NonOptionalComponents.Contains(component.GetName) Then
                ChkOptionalComp.Items.Add(component, True)
            ElseIf DefaultOptions.Contains(component.GetName) Then
                ChkOptionalComp.Items.Add(component, True)
            Else
                ChkOptionalComp.Items.Add(component, False)
            End If
        Next

        ' Load all of the languages into the option box
        For Each folder As String In Directory.GetDirectories("C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\")
            cmbLanguage.Items.Add(folder.ToString.Replace("C:\Program Files (x86)\Windows Kits\10\Assessment and Deployment Kit\Windows Preinstallation Environment\amd64\WinPE_OCs\", ""))
        Next
        cmbLanguage.SelectedIndex = If(cmbLanguage.Items.IndexOf("en-gb") <> -1, cmbLanguage.Items.IndexOf("en-gb"), 0)
    End Sub

    Private Sub ChkOptionalComp_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ChkOptionalComp.ItemCheck
        If NonOptionalComponents.Contains(ChkOptionalComp.Items(e.Index).ToString) And e.NewValue = CheckState.Unchecked Then
            e.NewValue = CheckState.Checked
            MessageBox.Show("This component is required for WIDT to work.", "Required Component", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If e.NewValue = CheckState.Checked Then
                Dim SelectedItem As ConfigPEOptional = ChkOptionalComp.Items(e.Index)
                If SelectedItem.GetDepends IsNot Nothing Then
                    For Each depend In SelectedItem.GetDepends
                        ChkOptionalComp.SetItemCheckState(ChkOptionalComp.Items.IndexOf(depend), CheckState.Checked)
                    Next
                End If
            ElseIf e.NewValue = CheckState.Unchecked Then
                Dim checkedItems As List(Of ConfigPEOptional) = New List(Of ConfigPEOptional)
                For i = 0 To ChkOptionalComp.Items.Count - 1
                    If ChkOptionalComp.GetItemChecked(i) = True Then
                        checkedItems.Add(ChkOptionalComp.Items(i))
                    End If
                Next
                Dim Depends As List(Of ConfigPEOptional) = New List(Of ConfigPEOptional)
                For Each item In checkedItems
                    If item.GetDepends IsNot Nothing Then
                        Depends.AddRange(item.GetDepends)
                    End If
                Next
                For Each item In Depends
                    If item.ToString = ChkOptionalComp.Items(e.Index).ToString Then
                        e.NewValue = CheckState.Checked
                        MessageBox.Show("This item cannot be removed it is required by another component.", "Error Removing Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnSelectDriversDir_Click(sender As Object, e As EventArgs) Handles btnSelectDriversDir.Click
        FolderBrowserDialog1.InitialDirectory = Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).ToString).ToString + "\WinPE-Drivers"
        Dim WinPEDrvPath As DialogResult = FolderBrowserDialog1.ShowDialog
        If WinPEDrvPath = DialogResult.OK Then
            txtWinPEDrivers.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ChkIncludeDrivers_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIncludeDrivers.CheckedChanged
        txtWinPEDrivers.Enabled = ChkIncludeDrivers.Checked
        btnSelectDriversDir.Enabled = ChkIncludeDrivers.Checked
    End Sub
End Class
