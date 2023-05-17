Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If My.Settings.StartupApp.ToLower = "winpe" Then
                SetStartupMode(True)
            Else
                SetStartupMode(False)
            End If
            If Application.CommandLineArgs.Count > 1 Then
                If Application.CommandLineArgs.Item(0) = "/S" Then
                    If Application.CommandLineArgs.Item(1).ToLower = "winpe" Then
                        SetStartupMode(True)
                    End If
                    If Application.CommandLineArgs.Item(1).ToLower = "setup" Then
                        SetStartupMode(False)
                    End If
                End If
                If Application.CommandLineArgs.Item(0) = "/SetStartupApp" Then
                    If Application.CommandLineArgs.Item(1).ToLower = "winpe" Then
                        Dim AppConfig = XDocument.Load(AppContext.BaseDirectory + "\WIDT-GUI.dll.config")
                        For Each setting In From element In AppConfig.<configuration>.<applicationSettings>.<WIDT_GUI.My.MySettings>.<setting>
                            If setting.HasAttributes = True And setting.FirstAttribute.Value = "StartupApp" Then
                                setting.<value>.Value = "WinPE"
                            End If
                        Next
                        AppConfig.Save(AppContext.BaseDirectory + "\WIDT-GUI.dll.config")
                        e.Cancel = True
                    ElseIf Application.CommandLineArgs.Item(1).ToLower = "setup" Then
                        Dim AppConfig = XDocument.Load(AppContext.BaseDirectory + "\WIDT-GUI.dll.config")
                        For Each setting In From element In AppConfig.<configuration>.<applicationSettings>.<WIDT_GUI.My.MySettings>.<setting>
                            If setting.HasAttributes = True And setting.FirstAttribute.Value = "StartupApp" Then
                                setting.<value>.Value = "Setup"
                            End If
                        Next
                        AppConfig.Save(AppContext.BaseDirectory + "\WIDT-GUI.dll.config")
                        e.Cancel = True
                    End If
                End If
            End If

            ' Checking Dependencies

        End Sub
    End Class
End Namespace
