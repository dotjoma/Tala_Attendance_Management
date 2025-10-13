Imports System.Runtime.CompilerServices

''' <summary>
''' Extension methods for common types
''' </summary>
Public Module Extensions
    ''' <summary>
    ''' Checks if a string is null or empty
    ''' </summary>
    <Extension()>
    Public Function IsNullOrEmpty(value As String) As Boolean
        Return String.IsNullOrEmpty(value)
    End Function

    ''' <summary>
    ''' Checks if a string is null, empty, or whitespace
    ''' </summary>
    <Extension()>
    Public Function IsNullOrWhiteSpace(value As String) As Boolean
        Return String.IsNullOrWhiteSpace(value)
    End Function

    ''' <summary>
    ''' Safely converts object to integer, returns default value if conversion fails
    ''' </summary>
    <Extension()>
    Public Function ToIntOrDefault(value As Object, Optional defaultValue As Integer = 0) As Integer
        If value Is Nothing OrElse IsDBNull(value) Then
            Return defaultValue
        End If

        Dim result As Integer
        If Integer.TryParse(value.ToString(), result) Then
            Return result
        End If

        Return defaultValue
    End Function

    ''' <summary>
    ''' Safely converts object to string, returns empty string if null
    ''' </summary>
    <Extension()>
    Public Function ToStringOrEmpty(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then
            Return String.Empty
        End If
        Return value.ToString()
    End Function

    ''' <summary>
    ''' Formats a date to display format
    ''' </summary>
    <Extension()>
    Public Function ToDisplayDate(value As Date) As String
        Return value.ToString(Constants.DISPLAY_DATE_FORMAT)
    End Function

    ''' <summary>
    ''' Formats a date to display time format
    ''' </summary>
    <Extension()>
    Public Function ToDisplayTime(value As Date) As String
        Return value.ToString(Constants.DISPLAY_TIME_FORMAT)
    End Function
End Module
