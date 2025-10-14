Imports System
Imports System.IO
Imports System.Configuration
Imports System.Windows.Forms
Imports Newtonsoft.Json

''' <summary>
''' Application configuration manager that loads environment-specific settings
''' </summary>
Public Class AppConfig
    Private Shared _instance As AppConfig
    Private Shared ReadOnly _lock As New Object()

    ' Configuration properties
    Public Property ConnectionString As String
    Public Property LogLevel As String
    Public Property LogFilePath As String
    Public Property Environment As EnvironmentType
    Public Property DatabaseTimeout As Integer
    Public Property EnableDebugMode As Boolean
    Public Property MaxLoginAttempts As Integer
    Public Property SessionTimeoutMinutes As Integer
    Public Property UpdateCheckUrl As String
    
    ' Version comes from Constants module (single source of truth)
    Public ReadOnly Property ApplicationVersion As String
        Get
            Return Constants.APP_VERSION
        End Get
    End Property

    ' Singleton pattern
    Public Shared ReadOnly Property Instance As AppConfig
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New AppConfig()
                        _instance.LoadConfiguration()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    Private Sub New()
        ' Private constructor for singleton
    End Sub

    ''' <summary>
    ''' Load configuration based on current environment
    ''' </summary>
    Private Sub LoadConfiguration()
        Try
            ' Determine environment (you can set this via environment variable or app.config)
            Dim envString = ConfigurationManager.AppSettings("Environment")
            If String.IsNullOrEmpty(envString) Then
                envString = "Development" ' Default to development
            End If

            ' Parse environment
            If Not [Enum].TryParse(Of EnvironmentType)(envString, True, Environment) Then
                Environment = EnvironmentType.Development
            End If

            ' Load appropriate config file
            Dim configFileName = GetConfigFileName(Environment)
            Dim configPath = Path.Combine(Application.StartupPath, "Config", configFileName)

            If File.Exists(configPath) Then
                Dim jsonContent = File.ReadAllText(configPath)
                Dim configData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonContent)

                ' Map configuration values
                MapConfigurationValues(configData)
            Else
                ' Load default values if config file doesn't exist
                LoadDefaultConfiguration()
            End If

        Catch ex As Exception
            ' Log error and load defaults
            Console.WriteLine($"Error loading configuration: {ex.Message}")
            LoadDefaultConfiguration()
        End Try
    End Sub

    ''' <summary>
    ''' Get config file name based on environment
    ''' </summary>
    Private Function GetConfigFileName(env As EnvironmentType) As String
        Select Case env
            Case EnvironmentType.Development
                Return "config.dev.json"
            Case EnvironmentType.Staging
                Return "config.staging.json"
            Case EnvironmentType.Production
                Return "config.prod.json"
            Case Else
                Return "config.dev.json"
        End Select
    End Function

    ''' <summary>
    ''' Map JSON configuration to properties
    ''' </summary>
    Private Sub MapConfigurationValues(configData As Dictionary(Of String, Object))
        If configData.ContainsKey("ConnectionString") Then
            ConnectionString = configData("ConnectionString").ToString()
        End If

        If configData.ContainsKey("LogLevel") Then
            LogLevel = configData("LogLevel").ToString()
        End If

        If configData.ContainsKey("LogFilePath") Then
            LogFilePath = configData("LogFilePath").ToString()
        End If

        If configData.ContainsKey("DatabaseTimeout") Then
            Integer.TryParse(configData("DatabaseTimeout").ToString(), DatabaseTimeout)
        End If

        If configData.ContainsKey("EnableDebugMode") Then
            Boolean.TryParse(configData("EnableDebugMode").ToString(), EnableDebugMode)
        End If

        If configData.ContainsKey("MaxLoginAttempts") Then
            Integer.TryParse(configData("MaxLoginAttempts").ToString(), MaxLoginAttempts)
        End If

        If configData.ContainsKey("SessionTimeoutMinutes") Then
            Integer.TryParse(configData("SessionTimeoutMinutes").ToString(), SessionTimeoutMinutes)
        End If

        If configData.ContainsKey("UpdateCheckUrl") Then
            UpdateCheckUrl = configData("UpdateCheckUrl").ToString()
        End If
    End Sub

    ''' <summary>
    ''' Load default configuration values
    ''' </summary>
    Private Sub LoadDefaultConfiguration()
        ConnectionString = "Data Source=localhost;Initial Catalog=TalaAttendance;Integrated Security=True"
        LogLevel = "Information"
        LogFilePath = "Logs\app.log"
        DatabaseTimeout = 30
        EnableDebugMode = True
        MaxLoginAttempts = 3
        SessionTimeoutMinutes = 30
        UpdateCheckUrl = "https://drive.google.com/uc?export=download&id=1nNmJTgYLgitxNY73MEKur5AFQ-w3H_N8"
        ' ApplicationVersion comes from Constants.APP_VERSION
    End Sub

    ''' <summary>
    ''' Reload configuration (useful for runtime config changes)
    ''' </summary>
    Public Sub ReloadConfiguration()
        LoadConfiguration()
    End Sub
End Class