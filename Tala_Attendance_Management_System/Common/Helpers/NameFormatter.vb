Public Class NameFormatter
    ''' <summary>
    ''' Formats a full name, excluding middle name if it's "--" or empty
    ''' </summary>
    ''' <param name="firstName">First name</param>
    ''' <param name="middleName">Middle name (optional)</param>
    ''' <param name="lastName">Last name</param>
    ''' <param name="extName">Extension name (optional)</param>
    ''' <returns>Formatted full name</returns>
    Public Shared Function FormatFullName(firstName As String, Optional middleName As String = "", Optional lastName As String = "", Optional extName As String = "") As String
        Dim nameParts As New List(Of String)

        ' Add first name
        If Not String.IsNullOrWhiteSpace(firstName) Then
            nameParts.Add(firstName.Trim())
        End If

        ' Add middle name only if it's not "--", "N/A", or empty
        If Not String.IsNullOrWhiteSpace(middleName) AndAlso
           middleName.Trim() <> "--" AndAlso
           middleName.Trim().ToUpper() <> "N/A" Then
            nameParts.Add(middleName.Trim())
        End If

        ' Add last name
        If Not String.IsNullOrWhiteSpace(lastName) Then
            nameParts.Add(lastName.Trim())
        End If

        ' Add extension name only if it's not "--", "N/A", or empty
        If Not String.IsNullOrWhiteSpace(extName) AndAlso
           extName.Trim() <> "--" AndAlso
           extName.Trim().ToUpper() <> "N/A" Then
            nameParts.Add(extName.Trim())
        End If

        Return String.Join(" ", nameParts)
    End Function

    ''' <summary>
    ''' SQL CONCAT expression that excludes middle name if it's "--"
    ''' Usage in SQL: SELECT {GetNameConcatSQL()} AS full_name FROM teacherinformation
    ''' </summary>
    Public Shared Function GetNameConcatSQL() As String
        Return "CONCAT(firstname, " &
               "IF(middlename IS NULL OR middlename = '' OR middlename = '--' OR UPPER(middlename) = 'N/A', '', CONCAT(' ', middlename)), " &
               "' ', lastname, " &
               "IF(extName IS NULL OR extName = '' OR extName = '--' OR UPPER(extName) = 'N/A', '', CONCAT(' ', extName)))"
    End Function
End Class
