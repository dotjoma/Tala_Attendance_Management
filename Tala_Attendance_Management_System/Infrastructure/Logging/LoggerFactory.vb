''' <summary>
''' Factory for creating logger instances (Factory Pattern + Dependency Inversion)
''' </summary>
Public Class LoggerFactory
    Private Shared _instance As ILogger

    ''' <summary>
    ''' Gets the singleton logger instance
    ''' </summary>
    Public Shared ReadOnly Property Instance As ILogger
        Get
            If _instance Is Nothing Then
                _instance = New FileLogger()
            End If
            Return _instance
        End Get
    End Property

    ''' <summary>
    ''' Creates a new logger instance
    ''' </summary>
    Public Shared Function CreateLogger(Optional logFilePath As String = Nothing) As ILogger
        Return New FileLogger(logFilePath)
    End Function

    ''' <summary>
    ''' Sets a custom logger implementation (for testing or different implementations)
    ''' </summary>
    Public Shared Sub SetLogger(logger As ILogger)
        _instance = logger
    End Sub
End Class
