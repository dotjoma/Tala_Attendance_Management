''' <summary>
''' Logger interface following Interface Segregation Principle
''' </summary>
Public Interface ILogger
    Sub LogDebug(message As String, Optional ex As Exception = Nothing)
    Sub LogInfo(message As String, Optional ex As Exception = Nothing)
    Sub LogWarning(message As String, Optional ex As Exception = Nothing)
    Sub LogError(message As String, Optional ex As Exception = Nothing)
    Sub LogCritical(message As String, Optional ex As Exception = Nothing)
    Sub Log(level As LogLevel, message As String, Optional ex As Exception = Nothing)
End Interface
