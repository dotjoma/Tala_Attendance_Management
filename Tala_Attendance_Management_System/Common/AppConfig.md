```vb
' Get configuration anywhere in your app
Dim config = AppConfig.Instance

' Use in database connections
Using connection As New SqlConnection(config.ConnectionString)
    connection.CommandTimeout = config.DatabaseTimeout
    ' Your database code
End Using

' Use for logging decisions
If config.EnableDebugMode AndAlso config.LogLevel = "Debug" Then
    ' Log debug information
End If

' Access any setting
Dim sessionTimeout = config.SessionTimeoutMinutes
```