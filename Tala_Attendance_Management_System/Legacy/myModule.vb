Imports System.Data.Odbc
Imports System.Resources
Module myModule
    Public con As Odbc.OdbcConnection
    'Public port As New SerialPort("COM3", 9600) ' Replace "COM3" with the appropriate COM port for your Arduino Uno

    Public btnItemsClicked As Integer = 0 'for Class Schedule form to determine if its for students or teachers
    Public sectionListGradeID As Integer = 0
    Public Sub connectDB()
        Try
            con = New Odbc.OdbcConnection("DSN=tala_ams")
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function IsUsernameUnique(username As String) As Boolean
        Try
            connectDB() ' Call your connection function

            ' Query to check for duplicate user name
            Dim query As String = "SELECT COUNT(*) FROM logins WHERE username = ? AND isActive=1"
            Dim command As New OdbcCommand(query, con)
            command.Parameters.AddWithValue("?", username)

            ' Execute query and check if count > 0 (duplicate found)
            Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
            If result > 0 Then
                Return False ' Duplicate user name found
            Else
                Return True ' user name is unique
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate username: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function
    Public Sub loadDGV(ByVal sql As String, ByVal dgv As DataGridView, Optional ByVal fieldname As String = "", Optional ByVal fieldnametwo As String = "", Optional ByVal fieldnamethree As String = "", Optional ByVal value As String = "")

        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable

        Try
            Call connectDB()
            If fieldname.Length <> 0 Then
                sql = sql + " WHERE (" + fieldname + " LIKE ? OR " + fieldnametwo + " LIKE ? OR " + fieldnamethree + " LIKE ?)"
                value = "%" + value + "%"
            End If
            cmd = New Odbc.OdbcCommand(sql, con)
            For i As Integer = 1 To 3
                cmd.Parameters.AddWithValue("@", value)
            Next
            da.SelectCommand = cmd
            da.Fill(dt)
            dgv.DataSource = dt
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Public Sub loadCBO(ByVal query As String, ByVal id As String, ByVal display As String, ByVal cbo As ComboBox)
        Dim cmd As OdbcCommand
        Dim da As New OdbcDataAdapter()
        Dim dt As New DataTable()

        Try
            connectDB()
            cmd = New OdbcCommand(query, con)
            da.SelectCommand = cmd
            da.Fill(dt)
            cbo.DataSource = dt
            cbo.ValueMember = id
            cbo.DisplayMember = display
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Function fieldChecker(ByVal pnl As Panel, Optional logErrors As Boolean = True, Optional excludeFields As String() = Nothing) As Boolean
        Dim logger As ILogger = LoggerFactory.Instance

        ' Default excluded fields (middle name is optional)
        Dim defaultExcluded As String() = {"txtMiddleName", "txtExtName"}

        ' Combine default excluded fields with any additional ones passed in
        Dim allExcluded As New List(Of String)(defaultExcluded)
        If excludeFields IsNot Nothing Then
            allExcluded.AddRange(excludeFields)
        End If

        For Each obj As Control In pnl.Controls
            If TypeOf obj Is TextBox OrElse TypeOf obj Is ComboBox Then
                ' Skip validation for excluded fields
                If allExcluded.Contains(obj.Name) Then
                    Continue For
                End If

                If String.IsNullOrEmpty(obj.Text.Trim()) Then
                    fieldChecker = False

                    ' Log validation failure
                    If logErrors Then
                        logger.LogWarning($"Field validation failed - Empty field: '{obj.Name}' in panel '{pnl.Name}'")
                    End If

                    MsgBox("Please fill up every field in the form.", vbCritical, "Warning")
                    obj.Focus()
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function

    Public Sub ClearFields(ByVal container As Control)
        For Each obj As Control In container.Controls
            If TypeOf obj Is TextBox Then
                DirectCast(obj, TextBox).Text = ""
            ElseIf TypeOf obj Is ComboBox Then
                DirectCast(obj, ComboBox).SelectedIndex = -1
            ElseIf TypeOf obj Is PictureBox Then
                DirectCast(obj, PictureBox).Image = My.Resources.default_image
            End If
        Next
    End Sub

    Public Sub ClickEnter(ByVal e As KeyEventArgs, ByVal btn As Button)
        If e.KeyCode = Keys.Enter Then
            btn.PerformClick()
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
    End Sub

    ''' <summary>
    ''' Formats a full name, excluding middle name if it's "--" or empty
    ''' </summary>
    ''' <param name="firstName">First name</param>
    ''' <param name="middleName">Middle name (optional)</param>
    ''' <param name="lastName">Last name</param>
    ''' <param name="extName">Extension name (optional)</param>
    ''' <returns>Formatted full name</returns>
    Public Function FormatFullName(firstName As String, Optional middleName As String = "", Optional lastName As String = "", Optional extName As String = "") As String
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
    Public Function GetNameConcatSQL() As String
        Return "CONCAT(firstname, " &
               "IF(middlename IS NULL OR middlename = '' OR middlename = '--' OR UPPER(middlename) = 'N/A', '', CONCAT(' ', middlename)), " &
               "' ', lastname, " &
               "IF(extName IS NULL OR extName = '' OR extName = '--' OR UPPER(extName) = 'N/A', '', CONCAT(' ', extName)))"
    End Function

End Module
