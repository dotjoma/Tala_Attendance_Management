Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

''' <summary>
''' Manager class for handling application updates
''' </summary>
Public Class UpdateManager
    Private ReadOnly _updateService As UpdateService
    Private ReadOnly _logger As ILogger

    Public Sub New(logger As ILogger)
        _logger = logger
        _updateService = New UpdateService(logger)
    End Sub

    ''' <summary>
    ''' Check for updates and show dialog if update is available
    ''' </summary>
    ''' <param name="parentForm">Parent form for the update dialog</param>
    ''' <returns>True if update check was performed, False if skipped</returns>
    Public Async Function CheckForUpdatesAsync(Optional parentForm As Form = Nothing) As Task(Of Boolean)
        Try
            _logger.LogInfo("Starting update check...")

            ' Check if we should perform update check
            If Not ShouldCheckForUpdates() Then
                _logger.LogInfo("Update check skipped - conditions not met")
                Return False
            End If

            ' Check for available updates
            Dim versionInfo = Await _updateService.CheckForUpdateAsync()

            If versionInfo IsNot Nothing Then
                ' Show update dialog
                ShowUpdateDialog(versionInfo, parentForm)
                Return True
            Else
                _logger.LogInfo("No updates available")
                Return True
            End If

        Catch ex As Exception
            _logger.LogError($"Error during update check: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Check for updates silently without showing dialog
    ''' </summary>
    ''' <returns>VersionInfo if update is available, Nothing otherwise</returns>
    Public Async Function CheckForUpdatesSilentAsync() As Task(Of VersionInfo)
        Try
            If Not ShouldCheckForUpdates() Then
                Return Nothing
            End If

            Return Await _updateService.CheckForUpdateAsync()

        Catch ex As Exception
            _logger.LogError($"Error during silent update check: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Show update notification to user
    ''' </summary>
    ''' <param name="versionInfo">Version information</param>
    ''' <param name="parentForm">Parent form for the dialog</param>
    Public Sub ShowUpdateNotification(versionInfo As VersionInfo, Optional parentForm As Form = Nothing)
        Try
            Dim message = $"A new version ({versionInfo.Version}) is available.{Environment.NewLine}Do you want to update now?"
            Dim result = MessageBox.Show(message, "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If result = DialogResult.Yes Then
                ShowUpdateDialog(versionInfo, parentForm)
            End If

        Catch ex As Exception
            _logger.LogError($"Error showing update notification: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Determine if update check should be performed
    ''' </summary>
    ''' <returns>True if update check should proceed</returns>
    Private Function ShouldCheckForUpdates() As Boolean
        Try
            ' Only check in development environment
            If AppConfig.Instance.Environment <> EnvironmentType.Development Then
                _logger.LogInfo("Update check disabled - not in development environment")
                Return False
            End If

            ' Check internet connectivity
            If Not NetworkHelper.IsInternetAvailable() Then
                _logger.LogWarning("Update check disabled - no internet connection")
                Return False
            End If

            Return True

        Catch ex As Exception
            _logger.LogError($"Error checking update conditions: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Show the update dialog
    ''' </summary>
    ''' <param name="versionInfo">Version information</param>
    ''' <param name="parentForm">Parent form for the dialog</param>
    Private Sub ShowUpdateDialog(versionInfo As VersionInfo, parentForm As Form)
        Try
            Using updateDialog As New UpdateDialog(_updateService, versionInfo, _logger)
                If parentForm IsNot Nothing Then
                    updateDialog.ShowDialog(parentForm)
                Else
                    updateDialog.ShowDialog()
                End If
            End Using

        Catch ex As Exception
            _logger.LogError($"Error showing update dialog: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Check for updates on application startup
    ''' </summary>
    ''' <param name="parentForm">Parent form for dialogs</param>
    Public Async Sub CheckForUpdatesOnStartup(Optional parentForm As Form = Nothing)
        Try
            ' Add a small delay to avoid blocking startup
            Await Task.Delay(2000)

            Dim versionInfo = Await CheckForUpdatesSilentAsync()
            If versionInfo IsNot Nothing Then
                ' Show notification in UI thread
                If parentForm IsNot Nothing AndAlso parentForm.InvokeRequired Then
                    parentForm.Invoke(New Action(Sub() ShowUpdateNotification(versionInfo, parentForm)))
                Else
                    ShowUpdateNotification(versionInfo, parentForm)
                End If
            End If

        Catch ex As Exception
            _logger.LogError($"Error during startup update check: {ex.Message}")
        End Try
    End Sub

End Class