Imports System.IO

''' <summary>
''' File-based logger implementation following Single Responsibility Principle
''' </summary>
Public Class FileLogger
    Implements ILogger

    Private ReadOnly _logFilePath As String
    Private ReadOnly _lockObject As New Object()

    Public Sub New(Optional logFilePath As String = Nothing)
        If String.IsNullOrEmpty(logFilePath) Then
            Dim logFolder As String = Path.Combine(Application.StartupPath, "Logs")
            If Not Directory.Exists(logFolder) Then
                Directory.CreateDirectory(logFolder)
            End If
            _logFilePath = Path.Combine(logFolder, $"app_log_{DateTime.Now:yyyyMMdd}.txt")
        Else
            _logFilePath = logFilePath
        End If
    End Sub

    Public Sub Log(level As LogLevel, message As String, Optional ex As Exception = Nothing) Implements ILogger.Log
        Try
            SyncLock _lockObject
                Dim logEntry As String = FormatLogEntry(level, message, ex)
                File.AppendAllText(_logFilePath, logEntry & Environment.NewLine)
            End SyncLock
        Catch
            ' Fail silently to prevent logging errors from crashing the app
        End Try
    End Sub

    Public Sub LogDebug(message As String, Optional ex As Exception = Nothing) Implements ILogger.LogDebug
        Log(LogLevel.Debug, message, ex)
    End Sub

    Public Sub LogInfo(message As String, Optional ex As Exception = Nothing) Implements ILogger.LogInfo
        Log(LogLevel.Info, message, ex)
    End Sub

    Public Sub LogWarning(message As String, Optional ex As Exception = Nothing) Implements ILogger.LogWarning
        Log(LogLevel.Warning, message, ex)
    End Sub

    Public Sub LogError(message As String, Optional ex As Exception = Nothing) Implements ILogger.LogError
        Log(LogLevel.Error, message, ex)
    End Sub

    Public Sub LogCritical(message As String, Optional ex As Exception = Nothing) Implements ILogger.LogCritical
        Log(LogLevel.Critical, message, ex)
    End Sub

    Private Function FormatLogEntry(level As LogLevel, message As String, ex As Exception) As String
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
        Dim levelStr As String = level.ToString().ToUpper().PadRight(8)
        Dim entry As String = $"[{timestamp}] [{levelStr}] {message}"

        If ex IsNot Nothing Then
            entry &= Environment.NewLine & $"Exception: {ex.GetType().Name}" & Environment.NewLine
            entry &= $"Message: {ex.Message}" & Environment.NewLine
            entry &= $"StackTrace: {ex.StackTrace}"
        End If

        Return entry
    End Function
End Class
