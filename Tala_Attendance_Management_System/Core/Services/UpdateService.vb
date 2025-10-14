Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json

''' <summary>
''' Service for handling application updates
''' </summary>
Public Class UpdateService
    Private ReadOnly _logger As ILogger

    Public Sub New(logger As ILogger)
        _logger = logger
    End Sub

    ''' <summary>
    ''' Check if an update is available
    ''' </summary>
    ''' <returns>VersionInfo if update is available, Nothing otherwise</returns>
    Public Async Function CheckForUpdateAsync() As Task(Of VersionInfo)
        Try
            ' Only check for updates in development environment
            If AppConfig.Instance.Environment <> EnvironmentType.Development Then
                _logger.LogInfo("Update check skipped - not in development environment")
                Return Nothing
            End If

            ' Check internet connectivity
            If Not NetworkHelper.IsInternetAvailable() Then
                _logger.LogWarning("Update check failed - no internet connection")
                Return Nothing
            End If

            _logger.LogInfo("Checking for application updates...")

            ' Download version information
            Dim versionInfo = Await DownloadVersionInfoAsync()
            If versionInfo Is Nothing Then
                Return Nothing
            End If

            ' Compare with current version
            Dim currentVersion = GetCurrentVersion()
            If versionInfo.IsNewerThan(currentVersion) Then
                _logger.LogInfo($"Update available: {currentVersion} -> {versionInfo.Version}")
                Return versionInfo
            Else
                _logger.LogInfo($"Application is up to date (v{currentVersion})")
                Return Nothing
            End If

        Catch ex As Exception
            _logger.LogError($"Error checking for updates: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Download and install the update
    ''' </summary>
    ''' <param name="versionInfo">Version information containing download URL</param>
    ''' <param name="progressCallback">Optional progress callback</param>
    ''' <returns>True if update was successful</returns>
    Public Function DownloadAndInstallUpdateAsync(versionInfo As VersionInfo, Optional progressCallback As Action(Of Integer) = Nothing) As Task(Of Boolean)
        Return Task.Run(Function()
                            Try
                                _logger.LogInfo($"Starting download of update v{versionInfo.Version}")

                                ' Get application directory
                                Dim appDir = Path.GetDirectoryName(Application.ExecutablePath)
                                
                                ' Create Update folder in application directory
                                Dim updateDir = Path.Combine(appDir, "Update")
                                If Not Directory.Exists(updateDir) Then
                                    Directory.CreateDirectory(updateDir)
                                End If

                                ' Download the update file to Update folder with version in filename
                                Dim downloadPath = Path.Combine(updateDir, $"update{versionInfo.Version}.zip")
                                _logger.LogInfo($"Downloading update to: {downloadPath}")
                                
                                Dim downloadSuccess = NetworkHelper.DownloadFile(versionInfo.DownloadUrl, downloadPath, progressCallback)

                                If Not downloadSuccess Then
                                    _logger.LogError("Failed to download update file")
                                    Return False
                                End If

                                _logger.LogInfo("Update downloaded successfully")

                                ' Create timestamped temp folder with version
                                Dim timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                                Dim tempExtractDir = Path.Combine(Path.GetTempPath(), $"TalaUpdate{versionInfo.Version}_{timestamp}")
                                
                                _logger.LogInfo($"Extracting update to temp folder: {tempExtractDir}")

                                ' Create update script that will handle the update process
                                Dim updateScriptPath = CreateUpdateScript(downloadPath, tempExtractDir, appDir)

                                ' Launch update script
                                Process.Start(updateScriptPath)

                                _logger.LogInfo("Update process initiated. Application will close and restart.")

                                ' Exit current application to allow update
                                Application.Exit()

                                Return True

                            Catch ex As Exception
                                _logger.LogError($"Error during update process: {ex.Message}")
                                Return False
                            End Try
                        End Function)
    End Function

    ''' <summary>
    ''' Download version information from remote source
    ''' </summary>
    ''' <returns>VersionInfo object or Nothing if failed</returns>
    Private Async Function DownloadVersionInfoAsync() As Task(Of VersionInfo)
        Try
            Using client As New WebClient()
                ' Add minimal browser headers (avoid gzip encoding issues)
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36")
                
                ' Use configured update check URL
                Dim updateUrl = AppConfig.Instance.UpdateCheckUrl
                If String.IsNullOrEmpty(updateUrl) Then
                    _logger.LogWarning("Update check URL not configured")
                    Return Nothing
                End If

                _logger.LogInfo($"Downloading version info from: {updateUrl}")
                Dim jsonContent = Await client.DownloadStringTaskAsync(updateUrl)
                _logger.LogInfo($"Downloaded content: {jsonContent}")
                
                Return JsonConvert.DeserializeObject(Of VersionInfo)(jsonContent)
            End Using
        Catch ex As Exception
            _logger.LogError($"Failed to download version info: {ex.Message}")
            If ex.InnerException IsNot Nothing Then
                _logger.LogError($"Inner exception: {ex.InnerException.Message}")
            End If
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Get the current application version
    ''' </summary>
    ''' <returns>Current version string</returns>
    Private Function GetCurrentVersion() As String
        Try
            ' First try to get version from config
            Dim configVersion = AppConfig.Instance.ApplicationVersion
            If Not String.IsNullOrEmpty(configVersion) Then
                Return configVersion
            End If

            ' Fallback to assembly version
            Dim assembly As Assembly = Assembly.GetExecutingAssembly()
            Dim version As Version = assembly.GetName().Version
            Return $"{version.Major}.{version.Minor}.{version.Build}"
        Catch ex As Exception
            _logger.LogWarning($"Could not determine current version: {ex.Message}")
            Return "1.0.0" ' Default version
        End Try
    End Function

    ''' <summary>
    ''' Create a batch script to handle the update process
    ''' </summary>
    ''' <param name="updateFilePath">Path to the downloaded update ZIP file</param>
    ''' <param name="tempExtractDir">Temporary extraction directory with timestamp</param>
    ''' <param name="appDir">Application root directory</param>
    ''' <returns>Path to the created update script</returns>
    Private Function CreateUpdateScript(updateFilePath As String, tempExtractDir As String, appDir As String) As String
        Dim scriptPath = Path.Combine(Path.GetTempPath(), "TalaUpdate.bat")
        Dim appPath = Application.ExecutablePath
        Dim appExeName = Path.GetFileName(appPath)

        Dim scriptContent = $"@echo off
echo ========================================
echo Tala Attendance Management System
echo Update Process
echo ========================================
echo.

echo [1/6] Waiting for application to close...
timeout /t 3 /nobreak > nul

echo [2/6] Killing any remaining processes...
taskkill /F /IM ""{appExeName}"" >nul 2>&1
timeout /t 2 /nobreak > nul

echo [3/6] Extracting update to temp folder...
echo Temp folder: {tempExtractDir}
powershell -command ""Expand-Archive -Path '{updateFilePath}' -DestinationPath '{tempExtractDir}' -Force""
if errorlevel 1 (
    echo ERROR: Failed to extract update!
    pause
    exit /b 1
)

echo [4/6] Copying files to application directory...
echo Target: {appDir}
xcopy ""{tempExtractDir}\*"" ""{appDir}\"" /E /Y /I /Q
if errorlevel 1 (
    echo ERROR: Failed to copy files!
    pause
    exit /b 1
)

echo [5/6] Update files preserved for reference...
echo Temp folder: {tempExtractDir}
echo ZIP file: {updateFilePath}

echo [6/6] Restarting application...
timeout /t 2 /nobreak > nul
start """" ""{appPath}""

echo.
echo Update completed successfully!
echo Application is restarting...
timeout /t 2 /nobreak > nul

REM Self-delete the update script
del ""%~f0""
"

        File.WriteAllText(scriptPath, scriptContent)
        Return scriptPath
    End Function

End Class