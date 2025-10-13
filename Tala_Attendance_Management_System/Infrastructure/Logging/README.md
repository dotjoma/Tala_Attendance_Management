# Logging System

## Architecture
This logging system follows SOLID principles and Clean Architecture:

- **ILogger** (Interface) - Defines the contract (Dependency Inversion Principle)
- **FileLogger** (Implementation) - Handles file-based logging (Single Responsibility)
- **LoggerFactory** (Factory) - Creates logger instances (Factory Pattern)

## Usage

### Basic Usage
```vb
' Get the singleton logger instance
Dim logger As ILogger = LoggerFactory.Instance

' Log messages at different levels
logger.LogDebug("Debug message")
logger.LogInfo("Information message")
logger.LogWarning("Warning message")
logger.LogError("Error message", ex)
logger.LogCritical("Critical error", ex)
```

### In a Class
```vb
Public Class MyForm
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    
    Private Sub MyMethod()
        _logger.LogInfo("Method started")
        Try
            ' Your code here
        Catch ex As Exception
            _logger.LogError("Error in MyMethod", ex)
        End Try
    End Sub
End Class
```

## Log File Location
Logs are stored in: `{Application.StartupPath}\Logs\app_log_YYYYMMDD.txt`

## Log Format
```
[2025-01-13 14:30:45.123] [INFO    ] User logged in successfully
[2025-01-13 14:30:50.456] [ERROR   ] Database connection failed
Exception: SqlException
Message: Cannot connect to database
StackTrace: ...
```

## Benefits
- ✅ Testable (can mock ILogger)
- ✅ Flexible (easy to add DatabaseLogger, ConsoleLogger, etc.)
- ✅ Thread-safe
- ✅ Follows SOLID principles
- ✅ Clean Architecture compliant
