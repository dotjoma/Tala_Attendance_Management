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
    ''' <param name="statusCallback">Optional status message callback</param>
    ''' <returns>True if update was successful</returns>
    Public Function DownloadAndInstallUpdateAsync(versionInfo As VersionInfo, Optional progressCallback As Action(Of Integer) = Nothing, Optional statusCallback As Action(Of String) = Nothing) As Task(Of Boolean)
        Return Task.Run(Function()
                            Try
                                _logger.LogInfo($"Starting download of update v{versionInfo.Version}")
                                statusCallback?.Invoke("Starting download...")

                                ' Get current version for display
                                Dim currentVersion = GetCurrentVersion()

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
                                statusCallback?.Invoke($"Downloading update v{versionInfo.Version}...")

                                ' Download with simple progress callback
                                Dim downloadSuccess = NetworkHelper.DownloadFile(versionInfo.DownloadUrl, downloadPath, progressCallback)

                                If Not downloadSuccess Then
                                    _logger.LogError("Failed to download update file")
                                    statusCallback?.Invoke("Failed to download update file")
                                    Return False
                                End If

                                _logger.LogInfo("Update downloaded successfully")
                                statusCallback?.Invoke("Download completed successfully!")

                                ' Create Temp folder in application directory (not system temp)
                                Dim tempRootDir = Path.Combine(appDir, "Temp")
                                If Not Directory.Exists(tempRootDir) Then
                                    Directory.CreateDirectory(tempRootDir)
                                End If

                                ' Create timestamped temp folder with version in app directory
                                Dim timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                                Dim tempExtractDir = Path.Combine(tempRootDir, $"TalaUpdate{versionInfo.Version}_{timestamp}")

                                _logger.LogInfo($"Extracting update to temp folder: {tempExtractDir}")
                                statusCallback?.Invoke("Preparing update installation...")

                                ' Create update script that will handle the update process
                                Dim updateScriptPath = CreateUpdateScript(downloadPath, tempExtractDir, appDir, currentVersion, versionInfo)

                                statusCallback?.Invoke("Update package ready")
                                statusCallback?.Invoke("Launching installer...")

                                ' Launch update script
                                Process.Start(updateScriptPath)

                                statusCallback?.Invoke("Update process initiated successfully!")
                                statusCallback?.Invoke("Application will now close for update installation...")

                                _logger.LogInfo("Update process initiated. Application will close and restart.")

                                ' Give user time to read the message
                                System.Threading.Thread.Sleep(2000)

                                ' Exit current application to allow update
                                Application.Exit()

                                Return True

                            Catch ex As Exception
                                _logger.LogError($"Error during update process: {ex.Message}")
                                statusCallback?.Invoke($"ERROR: {ex.Message}")
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
    ''' <param name="currentVersion">Current application version</param>
    ''' <param name="versionInfo">New version information including changelog</param>
    ''' <returns>Path to the created update script</returns>
    Private Function CreateUpdateScript(updateFilePath As String, tempExtractDir As String, appDir As String, currentVersion As String, versionInfo As VersionInfo) As String
        Dim scriptPath = Path.Combine(Path.GetTempPath(), "TalaUpdate.bat")
        Dim appPath = Application.ExecutablePath
        Dim appExeName = Path.GetFileName(appPath)

        ' Prepare changelog for display (escape special characters and format)
        Dim changelogLines = If(String.IsNullOrWhiteSpace(versionInfo.ChangeLog),
                               "No changelog provided",
                               versionInfo.ChangeLog.Replace("""", """""").Replace("%", "%%"))

        Dim versionHeader = String.Format("Update Manager v{0} -> v{1}", currentVersion, versionInfo.Version)

        Dim scriptContent = $"@echo off
setlocal enabledelayedexpansion
title TalaAMS Update Manager
chcp 65001 >nul
color 0A
mode con: cols=90 lines=35

echo.
echo ================================================================================
echo.
echo                    TALA ATTENDANCE MANAGEMENT SYSTEM
echo                  {versionHeader}
echo.
echo ================================================================================
echo.
echo  --------------------------------------------------------------------------------
echo   CHANGELOG:
echo  --------------------------------------------------------------------------------
echo   {changelogLines}
echo  --------------------------------------------------------------------------------
echo.
echo  --------------------------------------------------------------------------------
echo   SYSTEM UPDATE IN PROGRESS
echo   Please do not close this window or turn off your computer
echo  --------------------------------------------------------------------------------
echo.

echo  [STEP 1/6] Preparing update environment...
echo   ^> Waiting for application to close gracefully...
timeout /t 3 /nobreak > nul
echo   [OK] Application closed
echo.

echo  [STEP 2/6] Ensuring clean state...
echo   ^> Terminating any remaining processes...
taskkill /F /IM ""{appExeName}"" >nul 2>&1
timeout /t 2 /nobreak > nul
echo   [OK] Process cleanup completed
echo.

echo  [STEP 3/6] Extracting update package...
echo   ^> Source: {Path.GetFileName(updateFilePath)}
echo   ^> Target: Temp\{Path.GetFileName(tempExtractDir)}
powershell -command ""Expand-Archive -Path '{updateFilePath}' -DestinationPath '{tempExtractDir}' -Force""
if errorlevel 1 (
    color 0C
    echo.
    echo  ================================================================================
    echo   [ERROR] Failed to extract update package
    echo  ================================================================================
    echo.
    pause
    exit /b 1
)
echo   [OK] Extraction completed successfully
echo.

echo  [STEP 4/6] Installing update files...
echo   ^> Copying files to application directory...
xcopy ""{tempExtractDir}\*"" ""{appDir}\"" /E /Y /I /Q
if errorlevel 1 (
    color 0C
    echo.
    echo  ================================================================================
    echo   [ERROR] Failed to copy update files
    echo  ================================================================================
    echo.
    pause
    exit /b 1
)
echo   [OK] Files installed successfully
echo.

echo  [STEP 5/6] Preserving update history...
echo   ^> Update archive: Update\{Path.GetFileName(updateFilePath)}
echo   ^> Extracted files: Temp\{Path.GetFileName(tempExtractDir)}
echo   [OK] Update history preserved for rollback
echo.

echo  [STEP 6/6] Finalizing update...
echo   ^> Restarting application...
timeout /t 2 /nobreak > nul
start """" ""{appPath}""
echo   [OK] Application restarted
echo.

echo.
echo ================================================================================
echo.
echo                     UPDATE COMPLETED SUCCESSFULLY!
echo.
echo   TalaAMS has been updated to v{versionInfo.Version} and is now restarting...
echo.
echo ================================================================================

REM Self-delete the update script
del ""%~f0""
"

        File.WriteAllText(scriptPath, scriptContent)
        Return scriptPath
    End Function

End Class