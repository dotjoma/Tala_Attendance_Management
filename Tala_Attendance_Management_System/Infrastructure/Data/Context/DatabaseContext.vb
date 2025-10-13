Imports System.Data.Odbc

Public Class DatabaseContext
    Private ReadOnly _connectionString As String
    Private ReadOnly _logger As ILogger

    Public Sub New()
        _connectionString = "DSN=tala_ams"
        _logger = LoggerFactory.Instance
    End Sub

    Public Function GetConnection() As OdbcConnection
        Try
            Dim connection As New OdbcConnection(_connectionString)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
                _logger.LogInfo("Database connection opened successfully")
            End If
            Return connection
        Catch ex As Exception
            _logger.LogError($"Failed to open database connection: {ex.Message}")
            Throw
        End Try
    End Function

    Public Sub CloseConnection(connection As OdbcConnection)
        Try
            If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
                connection.Close()
                _logger.LogInfo("Database connection closed")
            End If
        Catch ex As Exception
            _logger.LogWarning($"Error closing database connection: {ex.Message}")
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Function ExecuteScalar(query As String, ParamArray parameters() As Object) As Object
        Dim connection As OdbcConnection = Nothing
        Try
            connection = GetConnection()
            Using cmd As New OdbcCommand(query, connection)
                For Each param In parameters
                    cmd.Parameters.AddWithValue("?", param)
                Next
                Return cmd.ExecuteScalar()
            End Using
        Finally
            CloseConnection(connection)
        End Try
    End Function

    Public Function ExecuteQuery(query As String, ParamArray parameters() As Object) As DataTable
        Dim connection As OdbcConnection = Nothing
        Try
            connection = GetConnection()
            Using cmd As New OdbcCommand(query, connection)
                For Each param In parameters
                    cmd.Parameters.AddWithValue("?", param)
                Next

                Using da As New OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Finally
            CloseConnection(connection)
        End Try
    End Function

    Public Function ExecuteNonQuery(query As String, ParamArray parameters() As Object) As Integer
        Dim connection As OdbcConnection = Nothing
        Try
            connection = GetConnection()
            Using cmd As New OdbcCommand(query, connection)
                For Each param In parameters
                    cmd.Parameters.AddWithValue("?", param)
                Next
                Return cmd.ExecuteNonQuery()
            End Using
        Finally
            CloseConnection(connection)
        End Try
    End Function
End Class
